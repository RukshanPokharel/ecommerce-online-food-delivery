using DriverApplication.Models;
using DriverApplication.Repositories.RefreshToken;
using DriverApplication.Utilities;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace DriverApplication.JwtManagers
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            //var user = context.OwinContext.Get<DBContext>().mt_driver.FirstOrDefault(u => u.Username == context.UserName && u.Password == context.Password);
            var user = context.OwinContext.Get<DBContext>().mt_driver.Where(u => u.Username == context.UserName).FirstOrDefault();

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name is invalid or doesn't exists!");
                context.Rejected();
                return Task.FromResult<object>(null);
            }

            else
            {
                bool result = BCrypt.Net.BCrypt.Verify(context.Password, user.Password);

                if (result == true)
                {
                    var ticket = new AuthenticationTicket(SetClaimsIdentity(context, user), new AuthenticationProperties());
                    context.Validated(ticket);

                    return Task.FromResult<object>(null);
                }
                else
                {
                    context.SetError("invalid_grant", "The user name and password is incorrect");
                    context.Rejected();
                    return Task.FromResult<object>(null);
                }
            }
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            //string clientId = "a";
            //string clientSecret = "abc";

            //if(!context.TryGetBasicCredentials (out clientId, out clientSecret))
            //{
            //    context.TryGetBasicCredentials(out clientId, out clientSecret);

            //}

            //if (context.ClientId == null)
            //{
            //    //Remove the comments from the below line context.SetError, and invalidate context 
            //    //if you want to force sending clientId/secrects once obtain access tokens. 
            //    context.Validated();
            //    //context.SetError("invalid_clientId", "ClientId should be sent.");
            //    return Task.FromResult<object>(null);
            //}

            //using (RefreshTokenRepository _repo = new RefreshTokenRepository())
            //{
            //    client = _repo.FindClient(context.ClientId);
            //}


            //if (client == null)
            //{
            //    context.SetError("invalid_clientId", string.Format("Client '{0}' is not registered in the system.", context.ClientId));
            //    return Task.FromResult<object>(null);
            //}


            //if (client.ApplicationType == Models.ApplicationTypes.NativeConfidential)
            //{
            //    if (string.IsNullOrWhiteSpace(clientSecret))
            //    {
            //        context.SetError("invalid_clientId", "Client secret should be sent.");
            //        return Task.FromResult<object>(null);
            //    }
            //    else
            //    {
            //        if (client.Secret != Helper.GetHash(clientSecret))
            //        {
            //            context.SetError("invalid_clientId", "Client secret is invalid.");
            //            return Task.FromResult<object>(null);
            //        }
            //    }
            //}

            //if (!client.Active)
            //{
            //    context.SetError("invalid_clientId", "Client is inactive.");
            //    return Task.FromResult<object>(null);
            //}

            //context.OwinContext.Set<string>("as:clientAllowedOrigin", client.AllowedOrigin);
            //context.OwinContext.Set<string>("as:clientRefreshTokenLifeTime", client.RefreshTokenLifeTime.ToString());

            context.Validated();
            return Task.FromResult<object>(null);

        }

        private static ClaimsIdentity SetClaimsIdentity(OAuthGrantResourceOwnerCredentialsContext context, Driver user)
        {
            var identity = new ClaimsIdentity("JWT");
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("driver_id", user.Driver_id.ToString()));

            identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
            identity.AddClaim(new Claim(ClaimTypes.Role, "User"));

            //var userRoles = context.OwinContext.Get<BookUserManager>().GetRoles(user.Id);
            //foreach (var role in userRoles)
            //{
            //    identity.AddClaim(new Claim(ClaimTypes.Role, role));
            //}

            return identity;
        }

        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            //var originalClient = context.Ticket.Properties.Dictionary["as:client_id"];
            //var currentClient = context.ClientId;

            //if (originalClient != currentClient)
            //{
            //    context.SetError("invalid_clientId", "Refresh token is issued to a different clientId.");
            //    return Task.FromResult<object>(null);
            //}

            // Change auth ticket for refresh token requests
            var newIdentity = new ClaimsIdentity(context.Ticket.Identity);
            //newIdentity.AddClaim(new Claim("newClaim", "newValue"));
 
            var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
            context.Validated(newTicket);

            return Task.FromResult<object>(null);

            //return base.GrantRefreshToken(context);
        }
    }
}