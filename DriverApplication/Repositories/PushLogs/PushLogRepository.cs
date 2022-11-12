using DriverApplication.DTOs.PushLog;
using DriverApplication.Hubs;
using DriverApplication.Models;
using DriverApplication.Utilities;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Repositories.PushLogs
{
    public class PushLogRepository : RepositoryBase<PushLog>, IPushLogRepository
    {
        private readonly IHubContext _hubContext;

        public PushLogRepository(IDbFactory dbFactory)
           : base(dbFactory)
        {
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();

        }

        public void AddPushLog(PushLogDto pushLogDto, DBContext context)
        {
            Driver driver = context.mt_driver.Find(pushLogDto.Driver_id);
            BulkPush bulkPush = context.mt_driver_bulk_push.Find(pushLogDto.Bulk_id);
            DriverTask driverTask = context.mt_driver_task.Find(pushLogDto.Task_id);
            Order order = context.mt_order.Find(pushLogDto.Order_id);

            if (driver != null && bulkPush != null && driverTask != null && order != null)
            {
                PushLog pushLog = new PushLog();
                //use bulkpush title and messages
                pushLog.Push_title = pushLogDto.Push_title;
                pushLog.Push_message = pushLogDto.Push_message;
                pushLog.Push_type = pushLogDto.Push_type;
                pushLog.Device_id = pushLogDto.Device_id;
                pushLog.Device_platform = pushLogDto.Device_platform;
                pushLog.Status = pushLogDto.Status;
                pushLog.Driver1 = driver;
                pushLog.BulkPush1 = bulkPush;
                pushLog.DriverTask1 = driverTask;
                pushLog.Order1 = order;
                

                context.mt_driver_pushlog.Add(pushLog);
                context.SaveChanges();

                string notificationTitle = pushLogDto.Push_title;
                string notificationMessage = pushLogDto.Push_message;

                _hubContext.Clients.All.sendPushNotification(notificationTitle, notificationMessage);


            }
            else if (driver == null &&  bulkPush == null &&  driverTask == null &&  order == null)
            {
                PushLog pushLog = new PushLog();

                pushLog.Push_title = pushLogDto.Push_title;
                pushLog.Push_message = pushLogDto.Push_message;
                pushLog.Push_type = pushLogDto.Push_type;
                pushLog.Device_id = pushLogDto.Device_id;
                pushLog.Device_platform = pushLogDto.Device_platform;
                pushLog.Status = pushLogDto.Status;
                pushLog.Driver1 = null;
                pushLog.BulkPush1 = null;
                pushLog.DriverTask1 = null;
                pushLog.Order1 = null;

                context.mt_driver_pushlog.Add(pushLog);
                context.SaveChanges();
            }
            else if (driver != null && bulkPush != null && driverTask == null && order == null)
            {
                PushLog pushLog = new PushLog();

                pushLog.Push_title = pushLogDto.Push_title;
                pushLog.Push_message = pushLogDto.Push_message;
                pushLog.Push_type = pushLogDto.Push_type;
                pushLog.Device_id = pushLogDto.Device_id;
                pushLog.Device_platform = pushLogDto.Device_platform;
                pushLog.Status = pushLogDto.Status;
                pushLog.Driver1 = driver;
                pushLog.BulkPush1 = bulkPush;
                pushLog.DriverTask1 = null;
                pushLog.Order1 = null;

                context.mt_driver_pushlog.Add(pushLog);
                context.SaveChanges();
            }
            else
                throw new ArgumentNullException();
        }
    }
}