using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Autofac;
using DriverApplication.DTOs.NotificationsTriggers;
using DriverApplication.Services.DriverAssignmentSettings;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace DriverApplication.Hubs
{
    //[HubName("")]
    public class NotificationHub : Hub<INotificationMethod>
    {
        private readonly IDriverSettingsService driverSettingsService;
        //private readonly ILifetimeScope _hubLifetimeScope;

        public NotificationHub(IDriverSettingsService driverSettingsService)
        {
            this.driverSettingsService = driverSettingsService;

            // Create a lifetime scope for the hub.
            //_hubLifetimeScope = lifetimeScope.BeginLifetimeScope();

            // Resolve dependencies from the hub lifetime scope.
            //driverSettingsService = _hubLifetimeScope.Resolve<IDriverSettingsService>();
        }

        public override Task OnConnected()
        {
            string connectionId = Context.ConnectionId; //The connection ID is a GUID that is assigned by SignalR..
                                                        // The same connection ID is used by all Hubs if you have multiple Hubs in your application..

            //System.Collections.Specialized.NameValueCollection headers = Context.Request.Headers;     //HTTP header data.
            //System.Collections.Specialized.NameValueCollection queryString = Context.Request.QueryString; //Query string data.
            //string parameterValue = queryString["parametername"]

            return base.OnConnected();
        }

       
        //[HubMethodName("")]
        //public async Task HelloSushantSir() // (IProgress<Task> progress) use this as parameter to implement progress reporting...
        //{
        //    string message = "milyo haina ta bro??? hasdim nata ekpalta..churot khaidim gara";
        //    await Clients.All.receiveSushantSir(message);
        //}

        public async Task PickupRequestReceived() // (IProgress<Task> progress) use this as parameter to implement progress reporting...
        {
            PickupRequestReceivedTriggerDto pickupRequestReceiveMessage =  driverSettingsService.GetPickupRequestReceivedMessage("pickup_request_received");
            await Clients.All.pickupRequestReceived(pickupRequestReceiveMessage);
        }

        public async Task PickupDriverStarted()
        {
            string message = "Driver is on its way for pickup!!";
            await Clients.All.pickupDriverStarted(message);
        }
    }
}