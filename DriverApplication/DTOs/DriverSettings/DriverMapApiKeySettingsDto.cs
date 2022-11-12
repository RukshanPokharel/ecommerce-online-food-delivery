using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.DTOs.DriverSettings
{
    public class DriverMapApiKeySettingsDto
    {
        private string map_provider;
        public string Map_provider { get => map_provider; set => map_provider = value; }

        private string google_api_key;
        public string Google_api_key { get => google_api_key; set => google_api_key = value; }

        private string enabled_curl;
        public string Enabled_curl { get => enabled_curl; set => enabled_curl = value; }

        private string mapbox_access_token;
        public string Mapbox_access_token { get => mapbox_access_token; set => mapbox_access_token = value; }

    }
}