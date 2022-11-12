using DriverApplication.DTOs;
using DriverApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Services
{
    public interface IBulkPushService
    {
        IEnumerable<BulkPush> GetAllBulkPush();
        BulkPush GetBulkPush(int id);
        void AddBulkPush(BulkPushDto bulkPushDto);
        string PutBulkPush(int id, BulkPushDto bulkPushDto);
        void DeleteBulkPush(BulkPush bulkPush);
        void SaveBulkPush();
    }
}