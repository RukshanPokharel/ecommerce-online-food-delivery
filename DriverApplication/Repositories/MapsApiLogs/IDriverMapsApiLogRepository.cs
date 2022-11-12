using DriverApplication.DTOs.MapsApiLogs;
using DriverApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Repositories.MapsApiLogs
{
    public interface IDriverMapsApiLogRepository : IRepository<MapsApiCall>
    {
        void AddDriverMapsApiLogs(MapsApiLogDto mapsApiCallDto);
    }
}