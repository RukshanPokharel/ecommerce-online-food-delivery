using DriverApplication.DTOs;
using DriverApplication.DTOs.PushLog;
using DriverApplication.Models;
using DriverApplication.Repositories;
using DriverApplication.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Caching;

namespace DriverApplication.CacheLayer
{
    public class ApplicationCache
    {
        private readonly IPushLogRepository pushLogRepository;
        private readonly IUnitOfWork unitOfWork;

        //private IDbFactory DbFactory
        //{
        //    get;
        //    set;
        //}

        //private DBContext dataContext;
        //public DBContext DataContext
        //{
        //    get { return dataContext ?? (dataContext = DbFactory.Init()); }
        //}

        public ApplicationCache(IPushLogRepository pushLogRepository, IUnitOfWork unitOfWork)
        {
            this.pushLogRepository = pushLogRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Add<T>(T objInfo, string key)
        {
            HttpContext.Current.Cache.Add(key, objInfo, null, DateTime.Now.AddSeconds(10), Cache.NoSlidingExpiration, CacheItemPriority.NotRemovable, new CacheItemRemovedCallback(cacheItemRemovedCallback));
        }

        private void cacheItemRemovedCallback(string key, object value, CacheItemRemovedReason reason)
        {
            BulkPush bulkPush = new BulkPush();
            bulkPush = (BulkPush)value; // use 'as' for casting.. value as BulkPush

            DBContext context = new DBContext();

            if (bulkPush != null)
            {
            IEnumerable<Driver> drivers = context.mt_driver.Where(dt => dt.Team_id == bulkPush.Team_id).ToList();

            foreach (var item in drivers)
            {
                PushLogDto pushLogDto = new PushLogDto();

                pushLogDto.Push_title = bulkPush.Push_title;
                pushLogDto.Push_message = bulkPush.Push_message;
                pushLogDto.Driver_id = item.Driver_id;
                pushLogDto.Bulk_id = bulkPush.Bulk_id;
                pushLogDto.Status = "Process";
                pushLogDto.Order_id = null;
                pushLogDto.Task_id = null;

                pushLogRepository.AddPushLog(pushLogDto, context);
            }

            }
        }

        public static void Clear(string key)
        {
            HttpContext.Current.Cache.Remove(key);
        }

        public static bool Exists(string key)
        {
            return HttpContext.Current.Cache[key] != null;
        }

        public static bool Get<T>(string key, out T value)
        {
            try
            {
                if (!Exists(key))
                { 
                    value =
                        default(T);
                    return false;
                }
                value = (T)HttpContext.Current.Cache[key];
            }
            catch
            {
                value =
                    default(T);
                return false;
            }
            return true;
        }

        //public static BulkPush GetBulkPushCache()
        //{
        //    return HttpContext.Current.Cache["pushLog"] as BulkPush;
        //}
    }
}