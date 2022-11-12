using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using DriverApplication.DTOs;
using DriverApplication.DTOs.Driver;
using DriverApplication.Models;
using DriverApplication.Repositories;
using DriverApplication.Utilities;

namespace DriverApplication.Services
{
    public class DriverServices : IDriverService
    {
        private readonly IDriverRepository driversRepository;
        private readonly IUnitOfWork unitOfWork;

        public DriverServices(IDriverRepository driversRepository, IUnitOfWork unitOfWork)
        {
            this.driversRepository = driversRepository;
            this.unitOfWork = unitOfWork;
        }

        public void AddDriver(DriverDto driverDto)
        {
            //use password hashing and validation here for adding...
            driversRepository.AddDriver(driverDto);
        }

        public void DeleteDriver(Driver driver)
        {
            driversRepository.Delete(driver);
        }

        //public string DriverLogin(DriverLoginDto driverLoginDto)
        //{
        //   return driversRepository.CheckCredentials(driverLoginDto);

        //}

        public Driver GetDriver(int id)
        {
            return driversRepository.GetById(id);
        }

        public Driver GetDriver(string name)
        {
           return driversRepository.GetDriverByName(name);
        }

        public IEnumerable<Driver> GetDrivers()
        {
            return driversRepository.GetAll();
        }

        public string PutDriver(int id, DriverDto driverDto)
        {
            return driversRepository.UpdateDriver(id, driverDto);
        }

        public void SaveDriver()
        {
            unitOfWork.Commit();
        }

    }
}