using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DriverApplication.Models.Settings
{
    public class DriverMapApiKeysSettings
    {
        private int id;
        [Column("id")]
        [Key]
        public int Id { get => id; set => id = value; }

        private string map_provider = "Mapbox";
        [Column("map_provider")]
        [StringLength(255)]
        public string Map_provider { get => map_provider; set => map_provider = value; }

        private string google_api_key;
        [Column("google_api_key")]
        [StringLength(255)]
        public string Google_api_key { get => google_api_key; set => google_api_key = value; }

        private string enabled_curl;
        [Column("enabled_curl")]
        [StringLength(255)]
        public string Enabled_curl { get => enabled_curl; set => enabled_curl = value; }

        private string mapbox_access_token;
        [Column("mapbox_access_token")]
        [StringLength(255)]
        public string Mapbox_access_token { get => mapbox_access_token; set => mapbox_access_token = value; }

    }
}