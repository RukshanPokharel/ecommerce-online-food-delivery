using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DriverApplication.DTOs.DriverTrack;

namespace DriverApplication.Services.DriverTrack
{
    public interface IDriverTrackService
    {
        DriverTrackLocationDto CreateDriverTrackLocation(DriverTrackLocationDto driverTrackLocationDto);
        DriverTrackLocationDto UpdateDriverTrackLocation(DriverTrackLocationDto driverTrackLocationDto);
        void SaveDriverTrackLocation();
    }
}