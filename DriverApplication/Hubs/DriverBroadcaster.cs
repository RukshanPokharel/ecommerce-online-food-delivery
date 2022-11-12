using DriverApplication.DTOs.DriverTrack;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace DriverApplication.Hubs
{
    public class DriverBroadcaster
    {
        private readonly static Lazy<DriverBroadcaster> _instance =
            new Lazy<DriverBroadcaster>(() => new DriverBroadcaster());
        // We're going to broadcast to all clients a maximum of 25 times per second
        private readonly TimeSpan BroadcastInterval =
            TimeSpan.FromMilliseconds(40);
        private readonly IHubContext _hubContext;
        private Timer _broadcastLoop;
        private DriverTrackLocationDto driverTrackLocationDto;
        private bool _modelUpdated;

        public DriverBroadcaster()
        {
            // Save our hub context so we can easily use it 
            // to send to its connected clients
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<DriverTrackLocationHub>();
            driverTrackLocationDto = new DriverTrackLocationDto();
            _modelUpdated = false;
            //start the broadcast loop
            _broadcastLoop = new Timer(
                BroadcastLocation,
                null,
                BroadcastInterval,
                BroadcastInterval);
        }

        private void BroadcastLocation(object state)
        {
            // No need to send anything if our model hasn't changed
            if (_modelUpdated)
            {
                // This is how we can access the Clients property 
                // in a static hub method or outside of the hub entirely
                _hubContext.Clients.All.sendDriverLocationInfo(driverTrackLocationDto);
                _modelUpdated = false;
            }
        }
        public void UpdateLocation(DriverTrackLocationDto trackLocationDto)
        {
            driverTrackLocationDto = trackLocationDto;
            _modelUpdated = true;
        }
        public static DriverBroadcaster Instance
        {
            get
            {
                return _instance.Value;
            }
        }
    }
}