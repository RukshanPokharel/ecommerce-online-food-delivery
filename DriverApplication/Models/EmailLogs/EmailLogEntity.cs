using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DriverApplication.Models.EmailLogs
{
    public class EmailLogEntity
    {
        private int id;
        public int Id { get => id; set => id = value; }

        private string email_address;
        public string Email_address { get => email_address; set => email_address = value; }

        private string sender;
        public string Sender { get => sender; set => sender = value; }

        private string subject;
        public string Subject { get => subject; set => subject = value; }

        private string content;
        public string Content { get => content; set => content = value; }

        private string status;
        public string Status { get => status; set => status = value; }

        private DateTime? date_created;
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
        public TimeSpan Created_time_stamp
        {
            get => created_time_stamp;
            set => created_time_stamp = value;
        }

        private string ip_address;
        public string Ip_address { get => ip_address; set => ip_address = value; }

        private string module_type;
        public string Module_type { get => module_type; set => module_type = value; }

        private string user_type;
        public string User_type { get => user_type; set => user_type = value; }

        private int user_id;
        public int User_id { get => user_id; set => user_id = value; }

        private int merchant_id;
        public int Merchant_id { get => merchant_id; set => merchant_id = value; }

        private string email_provider;
        public string Email_provider { get => email_provider; set => email_provider = value; }

    }
}