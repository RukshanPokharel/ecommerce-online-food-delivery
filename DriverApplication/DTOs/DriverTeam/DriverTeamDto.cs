using DriverApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.DTOs.DriverTeam
{
    public class DriverTeamDto
    {
        
        private string team_name;
        public string Team_name { get => team_name; set => team_name = value; }

        private string location_accuracy;
        public string Location_accuracy { get => location_accuracy; set => location_accuracy = value; }

        private string status;
        public string Status { get => status; set => status = value; }

        //[JsonIgnore]
        public virtual ICollection<DriverApplication.Models.Driver> Drivers { get; set; }
    }
}