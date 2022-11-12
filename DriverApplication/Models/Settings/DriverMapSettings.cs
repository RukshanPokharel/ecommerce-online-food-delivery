using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DriverApplication.Models.Settings
{
    public class DriverMapSettings
    {
        private int id;
        [Column("id")]
        [Key]
        public int Id { get => id; set => id = value; }

        private string default_map_country="Nepal";
        [Column("default_map_country")]
        [StringLength(255)]
        public string Default_map_country { get => default_map_country; set => default_map_country = value; }

        private string disable_activity_tracking;
        [Column("disable_activity_tracking")]
        [StringLength(255)]
        public string Disable_activity_tracking { get => disable_activity_tracking; set => disable_activity_tracking = value; }

        private string activity_refresh_interval;
        [Column("activity_refresh_interval")]
        [StringLength(255)]
        public string Activity_refresh_interval { get => activity_refresh_interval; set => activity_refresh_interval = value; }

        private string driver_activity_refresh;
        [Column("driver_activity_refresh")]
        [StringLength(255)]
        public string Driver_activity_refresh { get => driver_activity_refresh; set => driver_activity_refresh = value; }

        private string auto_geocode_address;
        [Column("auto_geocode_address")]
        [StringLength(255)]
        public string Auto_geocode_address { get => auto_geocode_address; set => auto_geocode_address = value; }

        private string include_offline_driver_map;
        [Column("include_offline_driver_map")]
        [StringLength(255)]
        public string Include_offline_driver_map { get => include_offline_driver_map; set => include_offline_driver_map = value; }

        private string hide_pickup_task;
        [Column("hide_pickup_task")]
        [StringLength(255)]
        public string Hide_pickup_task { get => hide_pickup_task; set => hide_pickup_task = value; }

        private string hide_delivery_task;
        [Column("hide_delivery_task")]
        [StringLength(255)]
        public string Hide_delivery_task { get => hide_delivery_task; set => hide_delivery_task = value; }

        private string hide_successful_task;
        [Column("hide_successful_task")]
        [StringLength(255)]
        public string Hide_successful_task { get => hide_successful_task; set => hide_successful_task = value; }

        private string google_map_style;
        [Column("google_map_style")]
        [StringLength(255)]
        public string Google_map_style { get => google_map_style; set => google_map_style = value; }

    }
}