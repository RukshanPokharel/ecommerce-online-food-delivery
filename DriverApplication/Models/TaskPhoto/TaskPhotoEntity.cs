using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DriverApplication.Models
{
    public class TaskPhoto
    {
        private int id;
        [Column("id")]
        [Key]
        [IgnoreDataMember]
        public int Id { get => id; set => id = value; }

        [ForeignKey("task_id")]              // foregin key from mt_driver_task
        private DriverTask DriverTask;
        public DriverTask DriverTask1 { get => DriverTask; set => DriverTask = value; }
        private int? task_id;
        [Column("task_id")]
        public int? Task_id { get => task_id; set => task_id = value; }

        private string photo_name;
        [Column("photo_name")]
        [StringLength(255)]
        public string Photo_name { get => photo_name; set => photo_name = value; }

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