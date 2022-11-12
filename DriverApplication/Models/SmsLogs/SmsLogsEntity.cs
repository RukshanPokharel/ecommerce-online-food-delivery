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
    public class SmsLogs
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

        private string contact_phone;
        [Column("contact_phone")]
        [StringLength(50)]
        public string Contact_phone { get => contact_phone; set => contact_phone = value; }

        private string sms_message;
        [Column("sms_message")]
        [StringLength(255)]
        public string Sms_message { get => sms_message; set => sms_message = value; }

        private string status;
        [Column("status")]
        [StringLength(255)]
        public string Status { get => status; set => status = value; }

        private string gateway_response;
        [Column("gateway_response")]
        [StringLength(255)]
        public string Gateway_response { get => gateway_response; set => gateway_response = value; }

        private string gateway;
        [Column("gateway")]
        [StringLength(100)]
        public string Gateway { get => gateway; set => gateway = value; }

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




    }
}