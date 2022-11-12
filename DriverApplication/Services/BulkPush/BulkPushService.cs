using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DriverApplication.DTOs;
using DriverApplication.Models;
using DriverApplication.Repositories;
using DriverApplication.Utilities;

namespace DriverApplication.Services
{
    public class BulkPushService : IBulkPushService
    {
        private readonly IBulkPushRepository bulkPushRepository;
        private readonly IUnitOfWork unitOfWork;

        public BulkPushService(IBulkPushRepository bulkPushRepository, IUnitOfWork unitOfWork)
        {
            this.bulkPushRepository = bulkPushRepository;
            this.unitOfWork = unitOfWork;
        }

        public void AddBulkPush(BulkPushDto bulkPushDto)
        {
            bulkPushRepository.AddBulkPush(bulkPushDto);
        }

        public void DeleteBulkPush(BulkPush bulkPush)
        {
            bulkPushRepository.Delete(bulkPush);
        }

        public IEnumerable<BulkPush> GetAllBulkPush()
        {
            return bulkPushRepository.GetAll();
     
        }

        public BulkPush GetBulkPush(int id)
        {
            return bulkPushRepository.GetById(id);
        }

        public string PutBulkPush(int id, BulkPushDto bulkPushDto)
        {
             return bulkPushRepository.UpdateBulkPush(id, bulkPushDto);
        }

        public void SaveBulkPush()
        {
            unitOfWork.Commit();
        }
    }
}