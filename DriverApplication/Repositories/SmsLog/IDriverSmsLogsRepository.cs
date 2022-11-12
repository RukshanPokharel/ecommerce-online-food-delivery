using DriverApplication.DTOs.SMSLogs;
using DriverApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Repositories.SmsLog
{
    public interface IDriverSmsLogsRepository : IRepository<SmsLogs>
    {
        void AddDriverSmsLogs(SmsLogsDto driverSmsLogsDto);
    }
}