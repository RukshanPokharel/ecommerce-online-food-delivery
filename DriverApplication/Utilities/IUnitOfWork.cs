using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Utilities
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}