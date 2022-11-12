using DriverApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.DTOs
{
    public class DriverTaskDto
    {
        private int? order_id;
        public int? Order_id { get => order_id; set => order_id = value; }

        private string task_description;
        public string Task_description { get => task_description; set => task_description = value; }

        private string trans_type;
        public string Trans_type { get => trans_type; set => trans_type = value; }

        private string contact_number;
        public string Contact_number { get => contact_number; set => contact_number = value; }

        private string email_address;
        public string Email_address { get => email_address; set => email_address = value; }

        private string customer_name;
        public string Customer_name { get => customer_name; set => customer_name = value; }

        private DateTime? delivery_date;
        public DateTime? Delivery_date
        {
            get
            {
                return this.delivery_date.HasValue
                   ? this.delivery_date.Value
                   : DateTime.Now;
            }
            set { this.delivery_date = value; }
        }

        private string delivery_address;
        public string Delivery_address { get => delivery_address; set => delivery_address = value; }

        private int? team_id;
        public int? Team_id { get => team_id; set => team_id = value; }

        private int? driver_id;
        public int? Driver_id { get => driver_id; set => driver_id = value; }

        private int dropoff_merchant;
        public int Dropoff_merchant { get => dropoff_merchant; set => dropoff_merchant = value; }

        private string dropoff_contact_name;
        public string Dropoff_contact_name { get => dropoff_contact_name; set => dropoff_contact_name = value; }

        private string dropoff_contact_number;
        public string Dropoff_contact_number { get => dropoff_contact_number; set => dropoff_contact_number = value; }

        private string drop_address;
        public string Drop_address { get => drop_address; set => drop_address = value; }

        private string recipient_name;
        public string Recipient_name { get => recipient_name; set => recipient_name = value; }

    }
}