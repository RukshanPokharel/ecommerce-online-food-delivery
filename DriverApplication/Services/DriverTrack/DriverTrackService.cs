using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DriverApplication.DTOs.DriverTrack;
using DriverApplication.Repositories.DriverTrack;
using DriverApplication.Utilities;

namespace DriverApplication.Services.DriverTrack
{
    public class DriverTrackService : IDriverTrackService
    {
        private readonly IDriverTrackLocationRepository driverTrackLocationRepository;
        private readonly IUnitOfWork unitOfWork;

        public DriverTrackService(IDriverTrackLocationRepository driverTrackLocationRepository, IUnitOfWork unitOfWork)
        {
            this.driverTrackLocationRepository = driverTrackLocationRepository;
            this.unitOfWork = unitOfWork;
        }

        public DriverTrackLocationDto CreateDriverTrackLocation(DriverTrackLocationDto driverTrackLocationDto)
        {
            return driverTrackLocationRepository.AddDriverTrackLocation(driverTrackLocationDto);
        }

        public void SaveDriverTrackLocation()
        {
            unitOfWork.Commit();
        }

        public DriverTrackLocationDto UpdateDriverTrackLocation(DriverTrackLocationDto driverTrackLocationDto)
        {
            return driverTrackLocationRepository.UpdateDriverTrackLocation(driverTrackLocationDto);
        }
    }
}