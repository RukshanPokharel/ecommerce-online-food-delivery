using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.DTOs
{
    public class BulkPushDto
    {
        private int bulk_id;
        public int Bulk_id { get => bulk_id; set => bulk_id = value; }

        private string push_title;
        public string Push_title { get => push_title; set => push_title = value; }

        private string push_message;        //text--Nullable
        public string Push_message { get => push_message; set => push_message = value; }

        private DateTime? date_created;
        public DateTime? Date_created
        {
            get
            {
                return this.date_created.HasValue
                   ? this.date_created.Value
                   : DateTime.Now;
            }
            set { this.date_created = value; }
        }

        private string status;
        public string Status { get => status; set => status = value; }
      
        private int? team_id;
        public int? Team_id { get => team_id; set => team_id = value; }

    }
}