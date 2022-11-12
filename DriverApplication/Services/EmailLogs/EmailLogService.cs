using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DriverApplication.Models.EmailLogs;
using DriverApplication.Repositories.EmailLogs;

namespace DriverApplication.Services.EmailLogs
{
    public class EmailLogService : IEmailLogService
    {
        private readonly IDriverEmailLogsRepository driverEmailLogsRepository;

        public EmailLogService(IDriverEmailLogsRepository driverEmailLogsRepository)
        {
            this.driverEmailLogsRepository = driverEmailLogsRepository;
        }
        public IEnumerable<EmailLogEntity> GetEmailBySubject()
        {
            return driverEmailLogsRepository.GetEmailBySubject();
        }
    }
}