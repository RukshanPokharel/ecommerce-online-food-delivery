using DriverApplication.DTOs.SMSLogs;
using DriverApplication.Models;
using DriverApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Repositories.SmsLog
{
    public class DriverSmsLogsRepository : RepositoryBase<SmsLogs>, IDriverSmsLogsRepository
    {
        public DriverSmsLogsRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public void AddDriverSmsLogs(SmsLogsDto driverSmsLogsDto)
        {
            if (driverSmsLogsDto != null)
            {
                SmsLogs smsLogs = new SmsLogs();
                smsLogs.Contact_phone = driverSmsLogsDto.Contact_phone;
                smsLogs.Sms_message = driverSmsLogsDto.Sms_message;
                smsLogs.Status = driverSmsLogsDto.Status;
                smsLogs.Gateway_response = driverSmsLogsDto.Gateway_response;
                smsLogs.Gateway = driverSmsLogsDto.Gateway;

                this.DbContext.mt_driver_sms_logs.Add(smsLogs);
                this.DbContext.SaveChanges();

            }
            else
                throw new ArgumentException();
        }
    }
}