using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.DTOs.DriverSettings
{
    public class DriverMapSettingsDto
    {
        private string default_map_country = "Nepal";
        public string Default_map_country { get => default_map_country; set => default_map_country = value; }

        private string disable_activity_tracking;
        public string Disable_activity_tracking { get => disable_activity_tracking; set => disable_activity_tracking = value; }

        private string activity_refresh_interval;
        public string Activity_refresh_interval { get => activity_refresh_interval; set => activity_refresh_interval = value; }

        private string driver_activity_refresh;
        public string Driver_activity_refresh { get => driver_activity_refresh; set => driver_activity_refresh = value; }

        private string auto_geocode_address;
        public string Auto_geocode_address { get => auto_geocode_address; set => auto_geocode_address = value; }

        private string include_offline_driver_map;
        public string Include_offline_driver_map { get => include_offline_driver_map; set => include_offline_driver_map = value; }

        private string hide_pickup_task;
        public string Hide_pickup_task { get => hide_pickup_task; set => hide_pickup_task = value; }

        private string hide_delivery_task;
        public string Hide_delivery_task { get => hide_delivery_task; set => hide_delivery_task = value; }

        private string hide_successful_task;
        public string Hide_successful_task { get => hide_successful_task; set => hide_successful_task = value; }

        private string google_map_style;
        public string Google_map_style { get => google_map_style; set => google_map_style = value; }

    }
}