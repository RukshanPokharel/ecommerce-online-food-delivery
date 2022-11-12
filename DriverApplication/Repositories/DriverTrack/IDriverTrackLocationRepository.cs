using DriverApplication.DTOs.DriverTrack;
using DriverApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Repositories.DriverTrack
{
    public interface IDriverTrackLocationRepository : IRepository<TrackLocation>
    {
        DriverTrackLocationDto AddDriverTrackLocation(DriverTrackLocationDto driverTrackLocationDto);
        DriverTrackLocationDto UpdateDriverTrackLocation(DriverTrackLocationDto driverTrackLocationDto);
    }
}