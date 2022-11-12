using Autofac;
using Autofac.Integration.SignalR;
using Autofac.Integration.WebApi;
using DriverApplication.CacheLayer;
using DriverApplication.Hubs;
using DriverApplication.Repositories;
using DriverApplication.Repositories.DriverSettings.NotificationSettings;
using DriverApplication.Repositories.DriverTrack;
using DriverApplication.Repositories.PushLogs;
using DriverApplication.Repositories.RefreshToken;
using DriverApplication.Services;
using DriverApplication.Services.DriverAssignmentSettings;
using DriverApplication.Services.DriverTrack;
using DriverApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace DriverApplication.App_Start
{
    public class AutofacConfig
    {
        public static void config()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());    //Register WebApi Controllers
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            builder.RegisterType<DriverServices>().As<IDriverService>().InstancePerRequest();
            builder.RegisterType<DriverRepository>().As<IDriverRepository>().InstancePerRequest();

            builder.RegisterType<DriverTasksService>().As<IDriverTasksService>().InstancePerRequest();
            builder.RegisterType<DriverTasksRepository>().As<IDriverTasksRepository>().InstancePerRequest();

            builder.RegisterType<DriverTeamsService>().As<IDriverTeamsService>().InstancePerRequest();
            builder.RegisterType<DriverTeamsRepository>().As<IDriverTeamsRepository>().InstancePerRequest();

            builder.RegisterType<DriverAssignmentService>().As<IDriverAssignmentService>().InstancePerRequest();
            builder.RegisterType<DriverAssignmentRepository>().As<IDriverAssignmentRepository>().InstancePerRequest();

            builder.RegisterType<BulkPushService>().As<IBulkPushService>().InstancePerRequest();
            builder.RegisterType<BulkPushRepository>().As<IBulkPushRepository>().InstancePerRequest();

            builder.RegisterType<PushLogService>().As<IPushLogService>().InstancePerRequest();
            builder.RegisterType<PushLogRepository>().As<IPushLogRepository>().InstancePerRequest();

            builder.RegisterType<DriverTrackService>().As<IDriverTrackService>().InstancePerRequest();
            builder.RegisterType<DriverTrackLocationRepository>().As<IDriverTrackLocationRepository>().InstancePerRequest();

            builder.RegisterType<DriverSettingsService>().As<IDriverSettingsService>().InstancePerRequest();
            builder.RegisterType<DriverNotificationSettingsRepository>().As<IDriverNotificationSettingsRepository>().InstancePerRequest();

            //builder.RegisterType<RefreshTokenRepository>().As<IRefreshTokenRepository>().InstancePerRequest();


            //builder.RegisterInstance<IPushLogRepository>(new PushLogRepository());

            // Repositories
            builder.RegisterAssemblyTypes(typeof(DriverRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            // Services
            builder.RegisterAssemblyTypes(typeof(DriverServices).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver; //Set the WebApi DependencyResolver

        }
    }
}