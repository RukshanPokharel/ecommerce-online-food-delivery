using DriverApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DriverApplication.DTOs.Driver
{
    public class DriverDto
    {
        
        private string first_name;
        public string First_name { get => first_name; set => first_name = value; }

        private string last_name;
        public string Last_name { get => last_name; set => last_name = value; }

        private string email;
        public string Email { get => email; set => email = value; }

        private string phone;
        public string Phone { get => phone; set => phone = value; }

        private string username;
        public string Username { get => username; set => username = value; }

        private string password;
        public string Password { get => password; set => password = value; }

        private int? team_id;
        public int? Team_id { get => team_id; set => team_id = value; }

        private string transport_type_id;
        public string Transport_type_id { get => transport_type_id; set => transport_type_id = value; }

        private string transport_description;
        public string Transport_description { get => transport_description; set => transport_description = value; }

        private string licence_plate;
        public string Licence_plate { get => licence_plate; set => licence_plate = value; }

        private string color;
        public string Color { get => color; set => color = value; }

        
    }
}