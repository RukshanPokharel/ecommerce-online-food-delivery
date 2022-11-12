using DriverApplication.DTOs;
using DriverApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Services
{
    public interface IDriverTasksService
    {
        IEnumerable<DriverTask> GetDriverTasks();
        DriverTask GetDriverTask(int id);
        void CreateDriverTask(DriverTaskDto driverTaskDto);
        string PutDriverTask(int id, DriverTaskDto driverTaskDto);
        void DeleteDriverTask(DriverTask driverTask);
        void SaveDriverTask();
        void PutDriverTaskStatus(int id, string status);
        void SaveDriverTaskStatus();
        void UpdateDriverReassignTask(int id, int driverTeamId, int driverId);
        void SaveDriverReassignTask();
    }
}