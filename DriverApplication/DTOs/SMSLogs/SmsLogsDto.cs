using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.DTOs.SMSLogs
{
    public class SmsLogsDto
    {        
        private string contact_phone;
        public string Contact_phone { get => contact_phone; set => contact_phone = value; }

        private string sms_message;
        public string Sms_message { get => sms_message; set => sms_message = value; }

        private string status;
        public string Status { get => status; set => status = value; }

        private string gateway_response;
        public string Gateway_response { get => gateway_response; set => gateway_response = value; }

        private string gateway;
        public string Gateway { get => gateway; set => gateway = value; }

    }
}