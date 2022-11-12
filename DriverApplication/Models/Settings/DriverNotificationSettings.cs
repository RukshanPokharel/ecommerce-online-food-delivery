using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DriverApplication.Models.Settings
{
    public class DriverNotificationSettings
    {
        private int notification_id;
        [Column("notification_id")]
        [Key]
        public int Notification_id { get => notification_id; set => notification_id = value; }

        private string trigger_name;
        [Column("trigger_name")]
        [StringLength(255)]
        public string Trigger_name { get => trigger_name; set => trigger_name = value; }

        private string mobile_push;
        [Column("mobile_push")]
        [StringLength(255)]
        public string Mobile_push { get => mobile_push; set => mobile_push = value; }

        private string sms;
        [Column("sms")]
        [StringLength(255)]
        public string Sms { get => sms; set => sms = value; }

        private string email;
        [Column("email")]
        [StringLength(255)]
        public string Email { get => email; set => email = value; }

        private string action_mobile;
        [Column("action_mobile")]
        [StringLength(255)]
        public string Action_mobile { get => action_mobile; set => action_mobile = value; }

        private string action_sms;
        [Column("action_sms")]
        [StringLength(255)]
        public string Action_sms { get => action_sms; set => action_sms = value; }

        private string action_email;
        [Column("action_email")]
        [StringLength(255)]
        public string Action_email { get => action_email; set => action_email = value; }

        
    }
}