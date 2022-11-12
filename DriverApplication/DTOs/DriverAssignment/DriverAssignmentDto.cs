using DriverApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.DTOs.DriverAssignment
{
    public class DriverAssignmentDto
    {
        private bool automatic_assign_type;
        public bool Automatic_assign_type { get => automatic_assign_type; set => automatic_assign_type = value; }

        private int? task_id;
        public int? Task_id { get => task_id; set => task_id = value; }

        private int? driver_id;
        public int? Driver_id { get => driver_id; set => driver_id = value; }

        private string first_name;
        public string First_name { get => first_name; set => first_name = value; }

        private string last_name;
        public string Last_name { get => last_name; set => last_name = value; }

        private string status;
        public string Status { get => status; set => status = value; }

        private string task_status;
        public string Task_status { get => task_status; set => task_status = value; }

    }
}