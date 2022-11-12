using DriverApplication.DTOs.DriverTrack;
using DriverApplication.Models;
using DriverApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Repositories.DriverTrack
{
    public class DriverTrackLocationRepository : RepositoryBase<TrackLocation>, IDriverTrackLocationRepository
    {
        public DriverTrackLocationRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public DriverTrackLocationDto AddDriverTrackLocation(DriverTrackLocationDto driverTrackLocationDto)
        {
            if (driverTrackLocationDto!= null)
            {
                TrackLocation trackLocation = new TrackLocation();
                trackLocation.Driver_id = driverTrackLocationDto.Driver_id;
                trackLocation.Latitude = driverTrackLocationDto.Latitude;
                trackLocation.Longitude = driverTrackLocationDto.Longitude;
                trackLocation.Altitude = driverTrackLocationDto.Altitude;
                trackLocation.Accuracy = driverTrackLocationDto.Accuracy;
                trackLocation.AltitudeAccuracy = driverTrackLocationDto.AltitudeAccuracy;
                trackLocation.Heading = driverTrackLocationDto.Heading;
                trackLocation.Speed = driverTrackLocationDto.Speed;
                trackLocation.Date_created = driverTrackLocationDto.Date_created;
                trackLocation.Track_type = driverTrackLocationDto.Track_type;
                trackLocation.Device_platform = driverTrackLocationDto.Device_platform;
                trackLocation.Date_log = driverTrackLocationDto.Date_log;
                trackLocation.Full_request = driverTrackLocationDto.Full_request;

                this.DbContext.mt_driver_track_location.Add(trackLocation);
                this.DbContext.SaveChanges();

                return driverTrackLocationDto;
            }
            else
                throw new ArgumentNullException();
        }

        public DriverTrackLocationDto UpdateDriverTrackLocation(DriverTrackLocationDto driverTrackLocationDto)
        {
            var driverLocationInDb = this.DbContext.mt_driver_track_location.Find(driverTrackLocationDto.Id);
            if (driverLocationInDb == null)
            {
                throw new ArgumentException();
            }
            else
            {
                driverLocationInDb.Driver_id = driverTrackLocationDto.Driver_id;
                driverLocationInDb.Latitude = driverTrackLocationDto.Latitude;
                driverLocationInDb.Longitude = driverTrackLocationDto.Longitude;
                driverLocationInDb.Altitude = driverTrackLocationDto.Altitude;
                driverLocationInDb.Accuracy = driverTrackLocationDto.Accuracy;
                driverLocationInDb.AltitudeAccuracy = driverTrackLocationDto.AltitudeAccuracy;
                driverLocationInDb.Heading = driverTrackLocationDto.Heading;
                driverLocationInDb.Speed = driverTrackLocationDto.Speed;
                driverLocationInDb.Date_created = driverTrackLocationDto.Date_created;
                driverLocationInDb.Track_type = driverTrackLocationDto.Track_type;
                driverLocationInDb.Device_platform = driverTrackLocationDto.Device_platform;
                driverLocationInDb.Date_log = driverTrackLocationDto.Date_log;
                driverLocationInDb.Full_request = driverTrackLocationDto.Full_request;

                this.DbContext.Entry(driverLocationInDb).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                return driverTrackLocationDto;
            }
        }
    }
}