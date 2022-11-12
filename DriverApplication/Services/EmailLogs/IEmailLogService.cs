using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DriverApplication.Models.EmailLogs;

namespace DriverApplication.Services.EmailLogs
{
    public interface IEmailLogService
    {
        IEnumerable<EmailLogEntity> GetEmailBySubject();
    }
}