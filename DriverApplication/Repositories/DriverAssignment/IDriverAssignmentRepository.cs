using DriverApplication.DTOs.DriverAssignment;
using DriverApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Repositories
{
    public interface IDriverAssignmentRepository: IRepository<DriverAssignment>
    {
        string UpdateDriverAssignment(int id, DriverAssignmentDto driverAssignmentDto);
        void AddDriverAssignment(DriverAssignmentDto driverAssignmentDto);
    }
}