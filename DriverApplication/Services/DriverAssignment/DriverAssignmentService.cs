using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DriverApplication.DTOs.DriverAssignment;
using DriverApplication.Models;
using DriverApplication.Repositories;
using DriverApplication.Utilities;

namespace DriverApplication.Services
{
    public class DriverAssignmentService : IDriverAssignmentService
    {
        private readonly IDriverAssignmentRepository driverAssignmentRepository;
        private readonly IUnitOfWork unitOfWork;

        public DriverAssignmentService(IDriverAssignmentRepository driverAssignmentRepository, IUnitOfWork unitOfWork)
        {
            this.driverAssignmentRepository = driverAssignmentRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateDriverAssignment(DriverAssignmentDto driverAssignmentDto)
        {
            driverAssignmentRepository.AddDriverAssignment(driverAssignmentDto);
        }

        public void DeleteDriverAssignment(DriverAssignment driverAssignment)
        {
            driverAssignmentRepository.Delete(driverAssignment);
        }

        public DriverAssignment GetDriverAssignment(int id)
        {
            return driverAssignmentRepository.GetById(id);
        }

        public IEnumerable<DriverAssignment> GetDriverAssignments()
        {
            return driverAssignmentRepository.GetAll();
        }

        public string PutDriverAssignment(int id, DriverAssignmentDto driverAssignmentDto)
        {
            return driverAssignmentRepository.UpdateDriverAssignment(id, driverAssignmentDto);
        }

        public void SaveDriverAssignment()
        {
            unitOfWork.Commit();
        }
    }
}