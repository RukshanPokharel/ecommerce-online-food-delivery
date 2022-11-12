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
    public class BulkPush
    {
        private int bulk_id;
        [Column("bulk_id")]
        [Key]
        [IgnoreDataMember]
        public int Bulk_id { get => bulk_id; set => bulk_id = value; }

        private string push_title;
        [Column("push_title")]
        [StringLength(255)]
        public string Push_title { get => push_title; set => push_title = value; }

        private string push_message;        //text--Nullable
        [Column("push_message")]
        public string Push_message { get => push_message; set => push_message = value; }

        private string status = "pending";
        [Column("status")]
        [StringLength(255)]
        public string Status { get => status; set => status = value; }

        private DateTime? date_created;
        [Column("date_created", TypeName = "date")]
        [IgnoreDataMember]
        public DateTime? Date_created {
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

        private DateTime? date_process;
        [Column("date_process", TypeName = "date")]
        [IgnoreDataMember]
        public DateTime? Date_process {
            get
            {
                return this.date_process.HasValue
                   ? this.date_process.Value
                   : DateTime.Now.Date;
            }
            set { this.date_process = value; }
        }

        private TimeSpan process_time_stamp = DateTime.Now.TimeOfDay;
        [Column("process_timestamp")]
        public TimeSpan Process_time_stamp
        {
            get => process_time_stamp;
            set => process_time_stamp = value;
        }

        private string ip_address;
        [Column("ip_address")]
        [StringLength(50)]
        [IgnoreDataMember]
        public string Ip_address { get => ip_address; set => ip_address = value; }

        [ForeignKey("team_id")]         //foreign key mt_driver_team
        private DriverTeam DriverTeam;
        public DriverTeam DriverTeam1 { get => DriverTeam; set => DriverTeam = value; }
        private int? team_id;
        [Column("team_id")]
        public int? Team_id { get => team_id; set => team_id = value; }

        private string user_type;
        [Column("user_type")]
        [StringLength(50)]
        [IgnoreDataMember]
        public string User_type { get => user_type; set => user_type = value; }

        private int user_id;
        [Column("user_id")]
        [IgnoreDataMember]
        public int User_id { get => user_id; set => user_id = value; }

        private ICollection<PushLog> PushLog;
        [JsonIgnore]
        public virtual ICollection<PushLog> PushLog1 { get => PushLog; set => PushLog = value; }
    }
}