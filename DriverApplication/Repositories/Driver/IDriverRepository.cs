using DriverApplication.DTOs;
using DriverApplication.DTOs.Driver;
using DriverApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Repositories
{
    public interface IDriverRepository : IRepository<Driver>
    {
        Driver GetDriverByName(string driverName);
        string UpdateDriver(int id, DriverDto driverDto);
        void AddDriver(DriverDto driverDto);
        //string CheckCredentials(DriverLoginDto driverLoginDto);
    }
}