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
    public class DriverTask : BaseModel.BaseModelEntity
    {
        private int task_id;
        [Column("task_id")]
        [Key]
        [IgnoreDataMember]
        public int Task_id { get => task_id; set => task_id = value; }

        private Order Order;
        public virtual Order Order1 { get => Order; set => Order = value; }
        
        //[ForeignKey("order_id")]            //foregin key of order table mt_order
        //private Order Order;
        //public Order Order1 { get => Order; set => Order = value; }
        //private int? order_id;
        //[Column("order_id")]
        //public int? Order_id { get => order_id; set => order_id = value; }

        private string task_description;
        [Column("task_description")]
        [StringLength(255)]
        public string Task_description { get => task_description; set => task_description = value; }

        private string trans_type;
        [Column("trans_type")]
        [StringLength(255)]
        public string Trans_type { get => trans_type; set => trans_type = value; }

        private string contact_number;
        [Column("contact_number")]
        [StringLength(50)]
        public string Contact_number { get => contact_number; set => contact_number = value; }

        private string email_address;
        [Column("email_address")]
        [StringLength(200)]
        public string Email_address { get => email_address; set => email_address = value; }

        private string customer_name;
        [Column("customer_name")]
        [StringLength(255)]
        public string Customer_name { get => customer_name; set => customer_name = value; }

        private DateTime? delivery_date;
        [Column("delivery_date", TypeName = "date")]
        public DateTime? Delivery_date
        {
            get
            {
                return this.delivery_date.HasValue
                   ? this.delivery_date.Value
                   : DateTime.Now.Date;
            }
            set { this.delivery_date = value; }
        }

        private TimeSpan deliveryDate_time_stamp = DateTime.Now.TimeOfDay;
        [Column("delivery_date_timestamp")]
        public TimeSpan DeliveryDate_time_stamp
        {
            get => deliveryDate_time_stamp;
            set => deliveryDate_time_stamp = value;
        }

        private string delivery_address;
        [Column("delivery_address")]
        [StringLength(255)]
        public string Delivery_address { get => delivery_address; set => delivery_address = value; }

        //[ForeignKey("team_id")]             //foreign key mt_driver_team
        private DriverTeam DriverTeam;
        public virtual DriverTeam DriverTeam1 { get => DriverTeam; set => DriverTeam = value; }
        private int? team_id;
        [Column("team_id")]
        public int? Team_id { get => team_id; set => team_id = value; }

        //[ForeignKey("driver_id")]             //foreign key mt_driver
        private Driver Driver;
        public virtual Driver Driver1 { get => Driver; set => Driver = value; }
        private int? driver_id;
        [Column("driver_id")]
        public int? Driver_id { get => driver_id; set => driver_id = value; }

        private string task_lat;
        [Column("task_lat")]
        [StringLength(50)]
        public string Task_lat { get => task_lat; set => task_lat = value; }

        private string task_lng;
        [Column("task_lng")]
        [StringLength(50)]
        public string Task_lng { get => task_lng; set => task_lng = value; }

        private string customer_signature;
        [Column("customer_signature")]
        [StringLength(255)]
        public string Customer_signature { get => customer_signature; set => customer_signature = value; }

        private string status = "unassigned";
        [Column("status")]
        [StringLength(255)]
        public string Status { get => status; set => status = value; }

        private string auto_assign_type;
        [Column("auto_assign_type")]
        [StringLength(255)]
        public string Auto_assign_type { get => auto_assign_type; set => auto_assign_type = value; }

        private DateTime? assign_started;
        [Column("assign_started", TypeName = "date")]
        public DateTime? Assign_started {
            get
            {
                return this.assign_started.HasValue
                   ? this.assign_started.Value
                   : DateTime.Now.Date;
            }
            set { this.assign_started = value; }
        }

        private TimeSpan assign_started_time_stamp = DateTime.Now.TimeOfDay;
        [Column("assign_started_timestamp")]
        public TimeSpan Assign_started_time_stamp
        {
            get => assign_started_time_stamp;
            set => assign_started_time_stamp = value;
        }

        private string assignment_status;
        [Column("assignment_status")]
        [StringLength(255)]
        public string Assignment_status { get => assignment_status; set => assignment_status = value; }

        private int dropoff_merchant;
        [Column("dropoff_merchant")]
        [DefaultValue(0)]
        public int Dropoff_merchant { get => dropoff_merchant; set => dropoff_merchant = value; }

        private string dropoff_contact_name;
        [Column("dropoff_contact_name")]
        [StringLength(255)]
        public string Dropoff_contact_name { get => dropoff_contact_name; set => dropoff_contact_name = value; }

        private string dropoff_contact_number;
        [Column("dropoff_contact_number")]
        [StringLength(20)]
        public string Dropoff_contact_number { get => dropoff_contact_number; set => dropoff_contact_number = value; }

        private string drop_address;
        [Column("drop_address")]
        [StringLength(255)]
        public string Drop_address { get => drop_address; set => drop_address = value; }

        private string dropoff_lat;
        [Column("dropoff_lat")]
        [StringLength(30)]
        public string Dropoff_lat { get => dropoff_lat; set => dropoff_lat = value; }

        private string dropoff_lng;
        [Column("dropoff_lng")]
        [StringLength(30)]
        public string Dropoff_lng { get => dropoff_lng; set => dropoff_lng = value; }

        private string recipient_name;
        [Column("recipient_name")]
        [StringLength(255)]
        public string Recipient_name { get => recipient_name; set => recipient_name = value; }

        private int critical;
        [Column("critical")]
        [DefaultValue(1)]
        public int Critical { get => critical; set => critical = value; }

        private ICollection<PushLog> PushLog;
        [JsonIgnore]
        public virtual ICollection<PushLog> PushLog1 { get => PushLog; set => PushLog = value; }

        [JsonIgnore]
        private DriverAssignment DriverAssignment;
        public virtual DriverAssignment DriverAssignment1 { get => DriverAssignment; set => DriverAssignment = value; }

    }
}