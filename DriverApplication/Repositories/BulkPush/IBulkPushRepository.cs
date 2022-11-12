using DriverApplication.DTOs;
using DriverApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Repositories
{
    public interface IBulkPushRepository : IRepository<BulkPush>
    {
        void AddBulkPush(BulkPushDto bulkPushDto);
        string UpdateBulkPush(int id, BulkPushDto bulkPushDto);

    }
}