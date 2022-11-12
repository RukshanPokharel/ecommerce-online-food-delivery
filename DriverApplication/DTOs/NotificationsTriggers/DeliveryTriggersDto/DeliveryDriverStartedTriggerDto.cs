using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.DTOs.NotificationsTriggers.DeliveryTriggersDto
{
    public class DeliveryDriverStartedTriggerDto
    {
        public string trigger_name;
        public string mobile_push;
        public string sms;
        public string email;
        public string action_mobile;
        public string action_sms;
        public string action_email;

    }
}