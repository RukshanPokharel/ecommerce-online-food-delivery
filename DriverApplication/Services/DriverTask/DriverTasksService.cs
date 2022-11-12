using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DriverApplication.DTOs;
using DriverApplication.Models;
using DriverApplication.Repositories;
using DriverApplication.Utilities;

namespace DriverApplication.Services
{
    public class DriverTasksService : IDriverTasksService
    {
        private readonly IDriverTasksRepository driversTasksRepository;
        private readonly IUnitOfWork unitOfWork;

        public DriverTasksService(IDriverTasksRepository driversTasksRepository, IUnitOfWork unitOfWork)
        {
            this.driversTasksRepository = driversTasksRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateDriverTask(DriverTaskDto driverTaskDto)
        {
            driversTasksRepository.AddDriverTask(driverTaskDto);
        }

        public void DeleteDriverTask(DriverTask driverTask)
        {
            driversTasksRepository.Delete(driverTask);
        }

        public DriverTask GetDriverTask(int id)
        {
            return driversTasksRepository.GetById(id);
        }

        public IEnumerable<DriverTask> GetDriverTasks()
        {
            return driversTasksRepository.GetAll();
        }

        public string PutDriverTask(int id, DriverTaskDto driverTaskDto)
        {
            return driversTasksRepository.UpdateDriverTask(id, driverTaskDto);
        }

        public void PutDriverTaskStatus(int id, string status)
        {
            driversTasksRepository.UpdateDriverTaskStatus(id, status);
        }

        public void SaveDriverReassignTask()
        {
            unitOfWork.Commit();
        }

        public void SaveDriverTask()
        {
            unitOfWork.Commit();
        }

        public void SaveDriverTaskStatus()
        {
            unitOfWork.Commit();
        }

        public void UpdateDriverReassignTask(int id, int driverTeamId, int driverId)
        {
            driversTasksRepository.UpdateDriverReassignTask(id, driverTeamId, driverId);
        }
    }
}