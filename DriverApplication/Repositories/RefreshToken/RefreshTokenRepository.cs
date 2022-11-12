using DriverApplication.Models.RefreshToken;
using DriverApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DriverApplication.Repositories.RefreshToken
{
    public class RefreshTokenRepository : IDisposable
    {
        //public RefreshTokenRepository(IDbFactory dbFactory)
        //    : base(dbFactory) { }

        private DBContext context = new DBContext();

        public async Task<bool> AddRefreshToken(RefreshTokenEntity token)
        {
            var existingToken = context.mt_driver_refresh_token.Where(r => r.Subject1 == token.Subject1 && r.ClientId1 == token.ClientId1).SingleOrDefault();

            if (existingToken != null)
            {
                var result = await RemoveRefreshToken(existingToken);
            }

            context.mt_driver_refresh_token.Add(token);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveRefreshToken(string refreshTokenId)
        {
            var refreshToken = await context.mt_driver_refresh_token.FindAsync(refreshTokenId);

            if (refreshToken != null)
            {
                context.mt_driver_refresh_token.Remove(refreshToken);
                return await context.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<bool> RemoveRefreshToken(RefreshTokenEntity refreshToken)
        {
            context.mt_driver_refresh_token.Remove(refreshToken);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<RefreshTokenEntity> FindRefreshToken(string refreshTokenId)
        {
            var refreshToken = await context.mt_driver_refresh_token.FindAsync(refreshTokenId);

            return refreshToken;
        }

        public List<RefreshTokenEntity> GetAllRefreshTokens()
        {
            return context.mt_driver_refresh_token.ToList();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}