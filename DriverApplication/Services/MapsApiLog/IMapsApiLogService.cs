using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DriverApplication.DTOs.MapsApiLogs;

namespace DriverApplication.Services.MapsApiLog
{
    public interface IMapsApiLogService
    {
        void AddDriverMapsApiLogs(MapsApiLogDto mapsApiCallDto);
        void SaveDriverMapsApiLogs();
    }
}