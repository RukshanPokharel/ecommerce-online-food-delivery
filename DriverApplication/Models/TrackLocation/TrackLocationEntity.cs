using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DriverApplication.Models
{
    public class TrackLocation
    {
        private int id;
        [Column("id")]
        [Key]
        [IgnoreDataMember]
        public int Id { get => id; set => id = value; }

        private string user_type;
        [Column("user_type")]
        [StringLength(50)]
        public string User_type { get => user_type; set => user_type = value; }

        private int user_id;
        [Column("user_id")]
        [DefaultValue(0)]
        public int User_id { get => user_id; set => user_id = value; }

        //[ForeignKey("driver_id")]             //foreign key mt_driver
        private Driver Driver;
        public Driver Driver1 { get => Driver; set => Driver = value; }
        private int? driver_id;
        [Column("driver_id")]
        public int? Driver_id { get => driver_id; set => driver_id = value; }

        private string latitude;
        [Column("latitude")]
        [StringLength(50)]
        public string Latitude { get => latitude; set => latitude = value; }

        private string longitude;
        [Column("longitude")]
        [StringLength(50)]
        public string Longitude { get => longitude; set => longitude = value; }

        private string altitude;
        [Column("altitude")]
        [StringLength(50)]
        public string Altitude { get => altitude; set => altitude = value; }

        private string accuracy;
        [Column("accuracy")]
        [StringLength(50)]
        public string Accuracy { get => accuracy; set => accuracy = value; }

        private string altitudeAccuracy;
        [Column("altitudeAccuracy")]
        [StringLength(50)]
        public string AltitudeAccuracy { get => altitudeAccuracy; set => altitudeAccuracy = value; }

        private string heading;
        [Column("heading")]
        [StringLength(50)]
        public string Heading { get => heading; set => heading = value; }

        private string speed;
        [Column("speed")]
        [StringLength(50)]
        public string Speed { get => speed; set => speed = value; }

        private DateTime? date_created;
        [Column("date_created", TypeName = "date")]
        public DateTime? Date_created
        {
            get
            {
                return this.date_created.HasValue
                   ? this.date_created.Value
                   : DateTime.Now.Date;
            }
            set { this.date_created = value; }
        }

        private TimeSpan created_time_stamp = DateTime.Now.TimeOfDay;
        [Column("created_timestamp")]
        public TimeSpan Created_time_stamp
        {
            get => created_time_stamp;
            set => created_time_stamp = value;
        }

        private string ip_address;
        [Column("ip_address")]
        [StringLength(50)]
        public string Ip_address { get => ip_address; set => ip_address = value; }

        private string track_type;
        [Column("track_type")]
        [StringLength(100)]
        public string Track_type { get => track_type; set => track_type = value; }

        private string device_platform = "Android";
        [Column("device_platform")]
        [StringLength(50)]
        public string Device_platform { get => device_platform; set => device_platform = value; }

        private DateTime? date_log;
        [Column("date_log", TypeName = "date")]
        public DateTime? Date_log
        {
            get
            {
                return this.date_log.HasValue
                   ? this.date_log.Value
                   : DateTime.Now.Date;
            }
            set { this.date_log = value; }
        }

        private TimeSpan date_log_time_stamp = DateTime.Now.TimeOfDay;
        [Column("date_log_timestamp")]
        public TimeSpan Date_log_time_stamp
        {
            get => date_log_time_stamp;
            set => date_log_time_stamp = value;
        }

        private string full_request;
        [Column("full_request")]
        [StringLength(50)]
        public string Full_request { get => full_request; set => full_request = value; }

    }
}