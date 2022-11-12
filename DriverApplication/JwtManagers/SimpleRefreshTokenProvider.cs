using DriverApplication.Models.RefreshToken;
using DriverApplication.Repositories.RefreshToken;
using DriverApplication.Utilities;
using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DriverApplication.JwtManagers
{
    public class SimpleRefreshTokenProvider : IAuthenticationTokenProvider
    {
        //private readonly IRefreshTokenRepository refreshTokenRepository;
        //private readonly IUnitOfWork unitOfWork;

        //public SimpleRefreshTokenProvider()
        //{

        //}

        //public SimpleRefreshTokenProvider(IRefreshTokenRepository refreshTokenRepository, IUnitOfWork unitOfWork)
        //{
        //    this.refreshTokenRepository = refreshTokenRepository;
        //    this.unitOfWork = unitOfWork;
        //}

        public void Create(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            //var clientid = context.Ticket.Properties.Dictionary["as:client_id"];
            var clientid = "a";

            if (string.IsNullOrEmpty(clientid))
            {
                return;
            }

            var refreshTokenId = Guid.NewGuid().ToString("n");

            //using (RefreshTokenRepository _repo = new RefreshTokenRepository())
            //{
                //var refreshTokenLifeTime = context.OwinContext.Get<string>("as:clientRefreshTokenLifeTime");

                var token = new RefreshTokenEntity()
                {
                    //Id = Helper.GetHash(refreshTokenId),
                    Id = refreshTokenId,
                    ClientId1 = clientid,
                    Subject1 = context.Ticket.Identity.Name,
                    IssuedUtc1 = DateTime.UtcNow,
                    ExpiresUtc1 = DateTime.UtcNow.AddMinutes(Convert.ToDouble(50)),
                };

                context.Ticket.Properties.IssuedUtc = token.IssuedUtc1;
                context.Ticket.Properties.ExpiresUtc = token.ExpiresUtc1;

                token.ProtectedTicket1 = context.SerializeTicket();

                RefreshTokenRepository _repo = new RefreshTokenRepository();
                var result = await _repo.AddRefreshToken(token);

                if (result)
                {
                    context.SetToken(refreshTokenId);
                }

            //}
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }

        public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            //var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            //string hashedTokenId = Helper.GetHash(context.Token);
            string hashedTokenId = context.Token;

            //using (AuthRepository _repo = new AuthRepository())
            //{
                RefreshTokenRepository _repo = new RefreshTokenRepository();
                var refreshToken = await _repo.FindRefreshToken(hashedTokenId);

                if (refreshToken != null)
                {
                    //Get protectedTicket from refreshToken class
                    context.DeserializeTicket(refreshToken.ProtectedTicket1);
                    var result = await _repo.RemoveRefreshToken(hashedTokenId);
                }
            //}
        }
    }
}