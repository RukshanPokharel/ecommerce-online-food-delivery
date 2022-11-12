using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DriverApplication.Models;
using DriverApplication.Repositories;
using DriverApplication.Utilities;

namespace DriverApplication.Services
{
    public class PushLogService : IPushLogService
    {
        private readonly IPushLogRepository pushLogRepository;
        private readonly IUnitOfWork unitOfWork;

        public PushLogService(IPushLogRepository pushLogRepository, IUnitOfWork unitOfWork)
        {
            this.pushLogRepository = pushLogRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<PushLog> GetAllPushLog()
        {
            return pushLogRepository.GetAll();
        }

        public PushLog GetPushLog(int id)
        {
            return pushLogRepository.GetById(id);
        }
    }
}