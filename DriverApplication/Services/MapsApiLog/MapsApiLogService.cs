using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DriverApplication.DTOs.MapsApiLogs;
using DriverApplication.Repositories.MapsApiLogs;
using DriverApplication.Utilities;

namespace DriverApplication.Services.MapsApiLog
{
    public class MapsApiLogService : IMapsApiLogService
    {
        private readonly IDriverMapsApiLogRepository driverMapsApiLogRepository;
        private readonly IUnitOfWork unitOfWork;


        public MapsApiLogService(IDriverMapsApiLogRepository driverMapsApiLogRepository, IUnitOfWork unitOfWork)
        {
            this.driverMapsApiLogRepository = driverMapsApiLogRepository;
            this.unitOfWork = unitOfWork;
        }

        public void AddDriverMapsApiLogs(MapsApiLogDto mapsApiCallDto)
        {
            driverMapsApiLogRepository.AddDriverMapsApiLogs(mapsApiCallDto);

        }

        public void SaveDriverMapsApiLogs()
        {
            unitOfWork.Commit();
        }
    }
}