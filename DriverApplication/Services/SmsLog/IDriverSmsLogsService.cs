using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DriverApplication.DTOs.SMSLogs;

namespace DriverApplication.Services.SmsLog
{
    public interface IDriverSmsLogsService
    {
        void AddDriverSmsLogs(SmsLogsDto driverSmsLogsDto);
        void SaveDriverSmsLogs();
    }
}