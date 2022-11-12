using Newtonsoft.Json;
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
    public class Driver : BaseModel.BaseModelEntity
    { 
        private int driver_id;
        [Column("driver_id")]
        [Key]
        //[IgnoreDataMember]
        public int Driver_id { get => driver_id; set => driver_id = value; }
 
        private bool on_duty;
        [Column("on_duty")]
        [DefaultValue(true)]
        [IgnoreDataMember]
        public bool On_duty { get => on_duty; set => on_duty = value; }

        //[Required]      // indicates that this property should not be null
        
        private string first_name;
        [Column("first_name")]
        [StringLength(255)]
        public string First_name { get => first_name; set => first_name = value; }
       
        private string last_name;
        [Column("last_name")]
        [StringLength(255)]
        public string Last_name { get => last_name; set => last_name = value; }
        
        private string email;
        [Column("email")]
        [StringLength(100)]
        public string Email { get => email; set => email = value; }
        
        private string phone;
        [Column("phone")]
        [StringLength(20)]
        public string Phone { get => phone; set => phone = value; }
        
        private string username;
        [Column("username")]
        [StringLength(100)]
        public string Username { get => username; set => username = value; }
        
        private string password;
        [Column("password")]
        [StringLength(100)]
        [IgnoreDataMember]
        public string Password { get => password; set => password = value; }

        [ForeignKey("team_id")]         //foreign key mt_driver_team
        private DriverTeam DriverTeam;
        [JsonIgnore]
        public virtual DriverTeam DriverTeam1 { get => DriverTeam; set => DriverTeam = value; }
        private int? team_id;
        [Column("team_id")]
        public int? Team_id { get => team_id; set => team_id = value; }

        private string transport_type_id;
        [Column("transport_type_id")]
        [StringLength(50)]
        public string Transport_type_id { get => transport_type_id; set => transport_type_id = value; }
    
        private string transport_description;
        [Column("transport_description")]
        [StringLength(255)]
        public string Transport_description { get => transport_description; set => transport_description = value; }
        
        private string licence_plate;   
        [Column("licence_plate")]
        [StringLength(255)]
        public string Licence_plate { get => licence_plate; set => licence_plate = value; }
        
        private string color;
        [Column("color")]
        [StringLength(255)]
        public string Color { get => color; set => color = value; }
        
        private string status;
        [Column("status")]
        [StringLength(255)]
        [DefaultValue("active")]
        [IgnoreDataMember]
        public string Status { get => status; set => status = value; }

        private DateTime? last_login;
        [Column("last_login", TypeName ="date")]
        [IgnoreDataMember]
        public DateTime? Last_login {
            get
            {
                return this.last_login.HasValue
                   ? this.last_login.Value
                   : DateTime.Now.Date;
            }
            set { this.last_login = value; }
        }

        private TimeSpan last_login_time_stamp = DateTime.Now.TimeOfDay;
        [Column("last_login_timestamp")]
        public TimeSpan Last_login_time_stamp
        {
            get => last_login_time_stamp;
            set => last_login_time_stamp = value;
        }


        private int last_online;
        [Column("last_online")]
        [DefaultValue(0)]
        [IgnoreDataMember]
        public int Last_online { get => last_online; set => last_online = value; }

        private string location_address;   //text
        [Column("location_address")]
        [IgnoreDataMember]
        public string Location_address { get => location_address; set => location_address = value; }
        
        private string location_lat;
        [Column("location_lat")]
        [StringLength(50)]
        [IgnoreDataMember]
        public string Location_lat { get => location_lat; set => location_lat = value; }
        
        private string location_lng;
        [Column("location_lng")]
        [StringLength(50)]
        [IgnoreDataMember]
        public string Location_lng { get => location_lng; set => location_lng = value; }
         
        private string forgot_pass_code;
        [Column("forgot_pass_code")]
        [StringLength(10)]
        [IgnoreDataMember]
        public string Forgot_pass_code { get => forgot_pass_code; set => forgot_pass_code = value; }
        
        private string token;
        [Column("token")]
        [StringLength(255)]
        [IgnoreDataMember]
        public string Token { get => token; set => token = value; }

        private string device_id;   //text
        [Column("device_id")]
        [IgnoreDataMember]
        public string Device_id { get => device_id; set => device_id = value; }
        
        private string device_platform;
        [Column("device_platform")]
        [StringLength(50)]
        [DefaultValue("Android")]
        [IgnoreDataMember]
        public string Device_platform { get => device_platform; set => device_platform = value; }
        
        private bool enabled_push;
        [Column("enabled_push")]
        [DefaultValue(true)]
        [IgnoreDataMember]
        public bool Enabled_push { get => enabled_push; set => enabled_push = value; }
        
        private string profile_photo;
        [Column("profile_photo")]
        [StringLength(255)]
        [IgnoreDataMember]
        public string Profile_photo { get => profile_photo; set => profile_photo = value; }
        
        private int is_signup;
        [Column("is_signup")]
        [DefaultValue(2)]
        [IgnoreDataMember]
        public int Is_signup { get => is_signup; set => is_signup = value; }
        
        private string app_version;
        [Column("app_version")]
        [StringLength(14)]
        [IgnoreDataMember]
        public string App_version { get => app_version; set => app_version = value; }
       
        private string last_onduty;
        [Column("last_onduty")]
        [StringLength(50)]
        [IgnoreDataMember]
        public string Last_onduty { get => last_onduty; set => last_onduty = value; }

        private ICollection<DriverTask> DriverTask;
        [JsonIgnore]
        public virtual ICollection<DriverTask> DriverTask1 { get => DriverTask; set => DriverTask = value; }

        private ICollection<PushLog> PushLog;
        [JsonIgnore]
        public virtual ICollection<PushLog> PushLog1 { get => PushLog; set => PushLog = value; }

        private ICollection<TrackLocation> TrackLocation;
        [JsonIgnore]
        public virtual ICollection<TrackLocation> TrackLocation1 { get => TrackLocation; set => TrackLocation = value; }

        private DriverAssignment DriverAssignment;
        [JsonIgnore]
        public virtual DriverAssignment DriverAssignment1 { get => DriverAssignment; set => DriverAssignment = value; }

    }
}