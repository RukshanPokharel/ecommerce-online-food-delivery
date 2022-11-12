using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.DTOs.DriverTrack
{
    public class DriverTrackLocationDto
    {
        private int id;
        public int Id { get => id; set => id = value; }

        private string user_type;
        public string User_type { get => user_type; set => user_type = value; }

        private int user_id;
        public int User_id { get => user_id; set => user_id = value; }

        private int? driver_id;
        public int? Driver_id { get => driver_id; set => driver_id = value; }

        private string latitude;
        public string Latitude { get => latitude; set => latitude = value; }

        private string longitude;
        public string Longitude { get => longitude; set => longitude = value; }

        private string altitude;
        public string Altitude { get => altitude; set => altitude = value; }

        private string accuracy;
        public string Accuracy { get => accuracy; set => accuracy = value; }

        private string altitudeAccuracy;
        public string AltitudeAccuracy { get => altitudeAccuracy; set => altitudeAccuracy = value; }

        private string heading;
        public string Heading { get => heading; set => heading = value; }

        private string speed;
        public string Speed { get => speed; set => speed = value; }

        private DateTime? date_created;
        public DateTime? Date_created
        {
            get
            {
                return this.date_created.HasValue
                   ? this.date_created.Value
                   : DateTime.Now;
            }
            set { this.date_created = value; }
        }

        private string track_type;
        public string Track_type { get => track_type; set => track_type = value; }

        private string device_platform;
        public string Device_platform { get => device_platform; set => device_platform = value; }

        private DateTime? date_log;
        public DateTime? Date_log
        {
            get
            {
                return this.date_log.HasValue
                   ? this.date_log.Value
                   : DateTime.Now;
            }
            set { this.date_log = value; }
        }


        private string full_request;
        public string Full_request { get => full_request; set => full_request = value; }

    }
}