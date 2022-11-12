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
    public class DriverAssignment
    {
        private int assignment_id;
        [Column("assignment_id")]
        [Key]
        [IgnoreDataMember]
        public int Assignment_id { get => assignment_id; set => assignment_id = value; }

        private bool automatic_assign_type = false;
        [Column("automatic_assign_type")]
        public bool Automatic_assign_type { get => automatic_assign_type; set => automatic_assign_type = value; }

        //[ForeignKey("task_id")]              // foregin key from mt_driver_task
        private DriverTask DriverTask;
        public virtual DriverTask DriverTask1 { get => DriverTask; set => DriverTask = value; }
       
        //[ForeignKey("driver_id")]             //foreign key mt_driver
        private Driver Driver;
        public virtual Driver Driver1 { get => Driver; set => Driver = value; }
       
        private string first_name;
        [Column("first_name")]
        [StringLength(255)]
        public string First_name { get => first_name; set => first_name = value; }

        private string last_name;
        [Column("last_name")]
        [StringLength(255)]
        public string Last_name { get => last_name; set => last_name = value; }

        private string status = "pending";
        [Column("status")]
        [StringLength(100)]
        public string Status { get => status; set => status = value; }

        private string task_status="unassigned";
        [Column("task_status")]
        [StringLength(255)]
        public string Task_status { get => task_status; set => task_status = value; }

        private DateTime? date_created;
        [Column("date_created", TypeName = "date")]
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
        public string Ip_address { get => ip_address; set => ip_address = value; }



    }
}