using DriverApplication.CacheLayer;
using DriverApplication.DTOs;
using DriverApplication.DTOs.PushLog;
using DriverApplication.Hubs;
using DriverApplication.Models;
using DriverApplication.Utilities;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace DriverApplication.Repositories
{
    public class BulkPushRepository : RepositoryBase<BulkPush>, IBulkPushRepository 
    {
        private readonly IPushLogRepository pushLogRepository;
        private readonly IUnitOfWork unitOfWork;


        public BulkPushRepository(IDbFactory dbFactory, IPushLogRepository pushLogRepository, IUnitOfWork unitOfWork)
            : base(dbFactory) {

            this.pushLogRepository = pushLogRepository;
            this.unitOfWork = unitOfWork;

        }

        public void AddBulkPush(BulkPushDto bulkPushDto)
        {
            DriverTeam driverTeam = this.DbContext.mt_driver_team.Find(bulkPushDto.Team_id);
            if (driverTeam != null)
            {
                BulkPush bulkPush = new BulkPush();
                bulkPush.Push_title = bulkPushDto.Push_title;
                bulkPush.Push_message = bulkPushDto.Push_message;
                bulkPush.Status = bulkPushDto.Status;
                bulkPush.DriverTeam1 = driverTeam;
                
                this.DbContext.mt_driver_bulk_push.Add(bulkPush);
                this.DbContext.SaveChanges();


                if (ApplicationCache.Exists("bulkPushCache") == false)
                {
                    ApplicationCache appCache = new ApplicationCache(pushLogRepository, unitOfWork);
                    appCache.Add(bulkPush, "bulkPushCache");

                    int id = bulkPush.Bulk_id;
                    bulkPushDto.Status = "Process";
                    UpdateBulkPush(id, bulkPushDto);

                }
                else {

                    ApplicationCache.Clear("bulkPushCache");
                }

            }
            else if (driverTeam == null)
            {
                throw new ArgumentNullException();      // throw error from error response class

            }
            else
            {
                throw new ArgumentNullException();

            }
        }

        public string UpdateBulkPush(int id, BulkPushDto bulkPushDto)
        {
            DriverTeam driverTeam = this.DbContext.mt_driver_team.Find(bulkPushDto.Team_id);
            var bulkPushInDb = this.DbContext.mt_driver_bulk_push.Find(id);
            if (bulkPushInDb == null)
            {
                throw new ArgumentException();
            }
            else
            {
                bulkPushInDb.Push_title = bulkPushDto.Push_title;
                bulkPushInDb.Push_message = bulkPushDto.Push_message;
                bulkPushInDb.Status = bulkPushDto.Status;
                bulkPushInDb.DriverTeam1 = driverTeam;

                this.DbContext.Entry(bulkPushInDb).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();
                return "Hey!! Shady your bulk push Data Updated Successfully...";

            }
        }
}
}