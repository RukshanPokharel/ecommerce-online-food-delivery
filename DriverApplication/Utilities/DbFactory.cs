using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Utilities
{
    public class DbFactory : Disposable, IDbFactory
    {
        DBContext dbContext;

        public DBContext Init()
        {
            return dbContext ?? (dbContext = new DBContext());      // returns new DBContext
        }

        protected override void DisposeCore()           // dispose the DBContext
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}