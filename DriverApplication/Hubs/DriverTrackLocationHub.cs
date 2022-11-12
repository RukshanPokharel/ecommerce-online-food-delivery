using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using DriverApplication.DTOs.DriverTrack;
using DriverApplication.Models;
using DriverApplication.Repositories.DriverTrack;
using DriverApplication.Services.DriverTrack;
using DriverApplication.Utilities;
using Microsoft.AspNet.SignalR;

namespace DriverApplication.Hubs
{

    public class DriverTrackLocationHub : Hub<IDriverTrackLocationMethod>
    {
        // Is set via the constructor on each creation
        private DriverBroadcaster _broadcaster;
        public DriverTrackLocationHub()
            :this(DriverBroadcaster.Instance)
        {
        }
        public DriverTrackLocationHub(DriverBroadcaster _broadcasters)
        {
            _broadcaster = _broadcasters;

        }

        //private IDriverTrackService driverTrackService;
        //public DriverTrackLocationHub(IDriverTrackService driverTrackService)
        //{
        //    this.driverTrackService = driverTrackService;
        //}

        public override Task OnConnected()
        {
            string connectionId = Context.ConnectionId; //The connection ID is a GUID that is assigned by SignalR..
                                                        // The same connection ID is used by all Hubs if you have multiple Hubs in your application..

            //System.Collections.Specialized.NameValueCollection headers = Context.Request.Headers;     //HTTP header data.
            //System.Collections.Specialized.NameValueCollection queryString = Context.Request.QueryString; //Query string data.
            //string parameterValue = queryString["parametername"]

            return base.OnConnected();
        }

        public void ReceiveDriverTrackInfo(DriverTrackLocationDto driverTrackLocationDto) // (IProgress<Task> progress) use this as parameter to implement progress reporting...
        {
            // update our DriverLocationDto within our DriverBroadcaster
            _broadcaster.UpdateLocation(driverTrackLocationDto);

            //DriverTrackLocationDto driverTrackLocationInDb = null;
            //if (driverTrackLocationDto != null)
            //{
            //    using (var db = new DBContext())
            //    {
            //        if (!db.mt_driver_track_location.Any())
            //        {
            //            // if the table is empty insert into it
            //            driverTrackLocationInDb = driverTrackService.CreateDriverTrackLocation(driverTrackLocationDto);   // after insertion send an id to client and they will update using that id
            //            driverTrackService.SaveDriverTrackLocation();
            //        }
            //        else
            //        {
            //            // if the table is not empty update the table
            //            driverTrackLocationInDb = driverTrackService.UpdateDriverTrackLocation(driverTrackLocationDto);
            //            driverTrackService.SaveDriverTrackLocation();
            //        }
            //    }
            //}

        }

        public override Task OnDisconnected(bool stopCalled)
        {
            //driverTrackService.CreateDriverTrackLocation(driverTrackLocationDto);
            //driverTrackService.SaveDriverTrackLocation();
            return base.OnDisconnected(stopCalled);
        }

    }
}