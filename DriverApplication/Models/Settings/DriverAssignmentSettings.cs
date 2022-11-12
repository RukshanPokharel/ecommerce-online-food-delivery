using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DriverApplication.Models.Settings
{
    public class DriverAssignmentSettings
    {
        private int option_id;
        [Column("option_id")]
        [Key]
        public int Option_id { get => option_id; set => option_id = value; }

        private int merchant_id;
        [Column("merchant_id")]
        public int Merchant_id { get => merchant_id; set => merchant_id = value; }

        private string option_name;
        [Column("option_name")]
        [StringLength(255)]
        public string Option_name { get => option_name; set => option_name = value; }

        private string option_value;
        [Column("option_value")]
        [StringLength(255)]
        public string Option_value { get => option_value; set => option_value = value; }
        
    }
}