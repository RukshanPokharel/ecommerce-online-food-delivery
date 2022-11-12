using DriverApplication.DTOs.MapsApiLogs;
using DriverApplication.Models;
using DriverApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Repositories.MapsApiLogs
{
    public class DriverMapsApiLogRepository: RepositoryBase<MapsApiCall>, IDriverMapsApiLogRepository
    {
        public DriverMapsApiLogRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public void AddDriverMapsApiLogs(MapsApiLogDto mapsApiCallDto)
        {
            if (mapsApiCallDto != null)
            {
                MapsApiCall mapsApiLogs = new MapsApiCall();
                mapsApiLogs.Map_provider = mapsApiCallDto.Map_provider;
                mapsApiLogs.Api_functions = mapsApiCallDto.Api_functions;
                mapsApiLogs.Api_response = mapsApiCallDto.Api_response;
               
                this.DbContext.mt_driver_mapsapicall.Add(mapsApiLogs);
                this.DbContext.SaveChanges();

            }
            else
                throw new ArgumentException();
        }
    }
}