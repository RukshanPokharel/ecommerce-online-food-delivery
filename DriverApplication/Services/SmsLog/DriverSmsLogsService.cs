using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DriverApplication.DTOs.SMSLogs;
using DriverApplication.Repositories.SmsLog;
using DriverApplication.Utilities;

namespace DriverApplication.Services.SmsLog
{
    public class DriverSmsLogsService : IDriverSmsLogsService
    {
        private readonly IDriverSmsLogsRepository driverSmsLogsRepository;
        private readonly IUnitOfWork unitOfWork;


        public DriverSmsLogsService(IDriverSmsLogsRepository driverSmsLogsRepository, IUnitOfWork unitOfWork)
        {
            this.driverSmsLogsRepository = driverSmsLogsRepository;
            this.unitOfWork = unitOfWork;
        }

        public void AddDriverSmsLogs(SmsLogsDto driverSmsLogsDto)
        {
            driverSmsLogsRepository.AddDriverSmsLogs(driverSmsLogsDto);
        }

        public void SaveDriverSmsLogs()
        {
            unitOfWork.Commit();
        }
    }
}