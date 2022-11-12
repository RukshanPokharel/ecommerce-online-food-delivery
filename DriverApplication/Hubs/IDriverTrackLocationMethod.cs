using DriverApplication.DTOs.DriverTrack;
using DriverApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DriverApplication.Hubs
{
    public interface IDriverTrackLocationMethod
    {
        Task sendDriverLocationInfo(DriverTrackLocationDto driverTrackLocationInDb);
    }
}