using DriverApplication.DTOs.DriverAssignment;
using DriverApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Services
{
    public interface IDriverAssignmentService
    {
        IEnumerable<DriverAssignment> GetDriverAssignments();
        DriverAssignment GetDriverAssignment(int id);
        void CreateDriverAssignment(DriverAssignmentDto driverAssignmentDto);
        string PutDriverAssignment(int id, DriverAssignmentDto driverAssignment);
        void DeleteDriverAssignment(DriverAssignment driverAssignment);
        void SaveDriverAssignment();
    }
}