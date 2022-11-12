using DriverApplication.DTOs;
using DriverApplication.DTOs.Driver;
using DriverApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DriverApplication.Services
{
    public interface IDriverService
    {
        IEnumerable<Driver> GetDrivers();
        Driver GetDriver(int id);
        Driver GetDriver(string name);
        void AddDriver(DriverDto driverDto);
        string  PutDriver(int id, DriverDto driverDto);
        void  DeleteDriver(Driver driver);
        void SaveDriver();
        //string DriverLogin(DriverLoginDto driverLoginDto);
    }

}