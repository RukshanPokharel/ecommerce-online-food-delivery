using DriverApplication.DTOs.PushLog;
using DriverApplication.Models;
using DriverApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Repositories
{
    public interface IPushLogRepository : IRepository<PushLog>
    {

        void AddPushLog(PushLogDto pushLogDto, DBContext context);
    }
}