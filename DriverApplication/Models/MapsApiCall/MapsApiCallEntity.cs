using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DriverApplication.Models
{
    public class MapsApiCall
    {
        private int id;
        [Column("id")]
        [Key]
        [IgnoreDataMember]
        public int Id { get => id; set => id = value; }

        private string map_provider;
        [Column("map_provider")]
        [StringLength(100)]
        public string Map_provider { get => map_provider; set => map_provider = value; }

        private string api_functions;
        [Column("api_functions")]
        [StringLength(255)]
        public string Api_functions { get => api_functions; set => api_functions = value; }

        private string api_response;
        [Column("api_response")]
        [StringLength(255)]
        public string Api_response { get => api_response; set => api_response = value; }

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

        private DateTime? date_call;
        [Column("date_call",TypeName = "date")]
        public DateTime? Date_call
        {
            get
            {
                return this.date_call.HasValue
                   ? this.date_call.Value
                   : DateTime.Now.Date;
            }
            set { this.date_call = value; }
        }

        private TimeSpan date_call_time_stamp = DateTime.Now.TimeOfDay;
        [Column("date_call_timestamp")]
        public TimeSpan Date_call_time_stamp
        {
            get => date_call_time_stamp;
            set => date_call_time_stamp = value;
        }

        private string ip_address;
        [Column("ip_address")]
        [StringLength(50)]
        public string Ip_address { get => ip_address; set => ip_address = value; }

    }
}