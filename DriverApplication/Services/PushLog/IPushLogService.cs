using DriverApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Services
{
    public interface IPushLogService
    {
        IEnumerable<PushLog> GetAllPushLog();
        PushLog GetPushLog(int id);
    }
}