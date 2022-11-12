using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.DTOs.PushLog
{
    public class PushLogDto
    {
        private string device_platform;
        public string Device_platform { get => device_platform; set => device_platform = value; }

        private string device_id;
        public string Device_id { get => device_id; set => device_id = value; }

        private string push_title;
        public string Push_title { get => push_title; set => push_title = value; }

        private string push_message;
        public string Push_message { get => push_message; set => push_message = value; }

        private string push_type;
        public string Push_type { get => push_type; set => push_type = value; }

        private string actions;
        public string Actions { get => actions; set => actions = value; }

        private string status;
        public string Status { get => status; set => status = value; }

        private int? order_id;
        public int? Order_id { get => order_id; set => order_id = value; }

        private int? driver_id;
        public int? Driver_id { get => driver_id; set => driver_id = value; }

        private int? task_id;
        public int? Task_id { get => task_id; set => task_id = value; }
        
        private int is_read;
        public int Is_read { get => is_read; set => is_read = value; }

        private int bulk_id;
        public int Bulk_id { get => bulk_id; set => bulk_id = value; }

    }
}