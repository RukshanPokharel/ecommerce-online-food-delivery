using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.DTOs.MapsApiLogs
{
    public class MapsApiLogDto
    {
        private string map_provider;
        public string Map_provider { get => map_provider; set => map_provider = value; }

        private string api_functions;
        public string Api_functions { get => api_functions; set => api_functions = value; }

        private string api_response;
        public string Api_response { get => api_response; set => api_response = value; }

    }
}