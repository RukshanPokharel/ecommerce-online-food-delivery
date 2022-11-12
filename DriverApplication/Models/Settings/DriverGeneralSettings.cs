using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DriverApplication.Models.Settings
{
    public class DriverGeneralSettings
    {
        private int general_id;
        [Column("general_id")]
        [Key]
        public int General_id { get => general_id; set => general_id = value; }

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