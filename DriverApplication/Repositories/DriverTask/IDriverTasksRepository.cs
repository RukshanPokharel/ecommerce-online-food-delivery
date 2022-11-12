using DriverApplication.DTOs;
using DriverApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Repositories
{
    public interface IDriverTasksRepository : IRepository<DriverTask>
    {
        string UpdateDriverTask(int id, DriverTaskDto driverTaskDto);
        void AddDriverTask(DriverTaskDto driverTaskDto);
        void UpdateDriverTaskStatus(int id, string status);
        void UpdateDriverReassignTask(int id, int driverTeamId, int driverId);
    }
}