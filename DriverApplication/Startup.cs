using System;
using System.Configuration;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using Autofac;
using Autofac.Integration.SignalR;
using DriverApplication.Hubs;
using DriverApplication.JwtManagers;
using DriverApplication.Repositories.RefreshToken;
using DriverApplication.Services.DriverAssignmentSettings;
using DriverApplication.Services.DriverTrack;
using DriverApplication.Utilities;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(DriverApplication.Startup))]

namespace DriverApplication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);

            //app.MapSignalR();      // configures signalR middleware component in the request pipeline.. default path to hub URL is ../signalr/hubs
            var builder = new ContainerBuilder();
            // STANDARD SIGNALR SETUP:

            // Get your HubConfiguration. In OWIN, you'll create one
            // rather than using GlobalHost.
            var config = new HubConfiguration();
            // registering autofac dependency injection for signalR
            // Register your SignalR hubs all at once using assembly scanning...
            builder.RegisterHubs(Assembly.GetExecutingAssembly());
            // ...or you can register individual hubs manually.
            //builder.RegisterType<DriverTrackLocationHub>().ExternallyOwned();
            //builder.RegisterType<DriverSettingsService>().As<IDriverSettingsService>().ExternallyOwned();
            //builder.RegisterType<DriverSettingsService>().AsImplementedInterfaces();
            builder.RegisterType<DriverSettingsService>().As<IDriverSettingsService>().PropertiesAutowired();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.Resolver = new AutofacDependencyResolver(container);

            // OWIN SIGNALR SETUP:

            // Register the Autofac middleware FIRST, then the standard SignalR middleware.
            //app.UseAutofacMiddleware(container);
            //app.MapSignalR("/signalr", config);

            // To add custom HubPipeline modules, you have to get the HubPipeline
            // from the dependency resolver, for example:
            var hubPipeline = config.Resolver.Resolve<IHubPipeline>();
            hubPipeline.AddModule(new ErrorHandlingPipelineModule());

            app.Map("/driverHubs", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration
                {
                    Resolver = config.Resolver,
                    EnableDetailedErrors = true             // make this false while deploying appliation because 
                                                            // malicious users might be able to use the information in attacks against your application.

                    //EnableJavaScriptProxies = false       // uncomment this when you do not want to display JavaScript proxies
                    //for the server-side hubs should be auto generated at {Path}/hubs or {Path}/js. 
                    //Defaults to true.

                };

                map.RunSignalR(hubConfiguration);
            });

            //GlobalHost.DependencyResolver.Register(
            //           typeof(NotificationHub),
            //           () => new NotificationHub(new IDriverSettingsService()));
        }

        private void ConfigureOAuth(IAppBuilder app)
        {
            var issuer = ConfigurationManager.AppSettings["issuer"];
            var secret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["secret"]);

            app.CreatePerOwinContext(() => new DBContext());

            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/driversLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new CustomOAuthProvider(),
                RefreshTokenProvider = new SimpleRefreshTokenProvider(),
                AccessTokenFormat = new CustomJwtFormat(issuer), // example (http://jwtauthzsrv.azurewebsites.net)
            });

            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                AllowedAudiences = new[] { "Any" },
                //TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                // {
                //    ValidateLifetime = true
                // },
                IssuerSecurityKeyProviders = new IIssuerSecurityKeyProvider[]
                {
                    new SymmetricKeyIssuerSecurityKeyProvider(issuer, secret),
                },
                //IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                // {
                //  new SymmetricKeyIssuerSecurityTokenProvider(issuer, secret)
                // }
            });
        }
    }
}
