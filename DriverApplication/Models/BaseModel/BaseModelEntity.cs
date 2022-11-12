using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DriverApplication.Models.BaseModel
{
    public class BaseModelEntity
    {
        private DateTime? date_created;
        [Column("date_created", TypeName ="date")]
        [IgnoreDataMember]
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

        private DateTime? date_modified;
        [Column("date_modified", TypeName = "date")]
        [IgnoreDataMember]
        public DateTime? Date_modified
        {
            get
            {
                return this.date_modified.HasValue
                   ? this.date_modified.Value
                   : DateTime.Now.Date;
            }
            set { this.date_modified = value; }
        }

        private TimeSpan modified_time_stamp = DateTime.Now.TimeOfDay;
        [Column("modified_timestamp")]
        public TimeSpan Modified_time_stamp
        {
            get => modified_time_stamp;
            set => modified_time_stamp = value;
        }

        private string user_type;
        [Column("user_type")]
        [StringLength(50)]
        [IgnoreDataMember]
        public string User_type { get => user_type; set => user_type = value; }

        private int user_id;
        [Column("user_id")]
        [DefaultValue(0)]
        [IgnoreDataMember]
        public int User_id { get => user_id; set => user_id = value; }

        private string ip_address;
        [Column("ip_address")]
        [StringLength(50)]
        [IgnoreDataMember]
        public string Ip_address { get => ip_address; set => ip_address = value; }

    }
}