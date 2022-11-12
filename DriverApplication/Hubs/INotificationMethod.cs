using DriverApplication.DTOs.NotificationsTriggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DriverApplication.Hubs
{
    public interface INotificationMethod
    {
        Task receiveSushantSir(string message);
        Task pickupRequestReceived(PickupRequestReceivedTriggerDto pickupRequestReceiveMessage);
        Task pickupDriverStarted(string message);
    }
}