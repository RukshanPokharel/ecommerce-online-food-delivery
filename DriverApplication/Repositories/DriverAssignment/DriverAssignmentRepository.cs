using DriverApplication.DTOs.DriverAssignment;
using DriverApplication.Models;
using DriverApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Repositories
{
    public class DriverAssignmentRepository : RepositoryBase<DriverAssignment>, IDriverAssignmentRepository
    {
        public DriverAssignmentRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public void AddDriverAssignment(DriverAssignmentDto driverAssignmentDto)
        {
            Driver driver = this.DbContext.mt_driver.Find(driverAssignmentDto.Driver_id);
            DriverTask driverTask = this.DbContext.mt_driver_task.Find(driverAssignmentDto.Task_id);

            if (driverAssignmentDto != null)
            {
                DriverAssignment driverAssignment = new DriverAssignment();
                driverAssignment.Automatic_assign_type = driverAssignmentDto.Automatic_assign_type;
                driverAssignment.First_name = driverAssignmentDto.First_name;
                driverAssignment.Last_name = driverAssignmentDto.Last_name;
                driverAssignment.Status = driverAssignmentDto.Status;
                driverAssignment.Task_status = driverAssignmentDto.Task_status;
                driverAssignment.DriverTask1 = driverTask;
                driverAssignment.Driver1 = driver;
                
                this.DbContext.mt_driver_assignment.Add(driverAssignment);

            }
            else
                throw new ArgumentException();

        }

        public string UpdateDriverAssignment(int id, DriverAssignmentDto driverAssignmentDto)
        {
            Driver driver = this.DbContext.mt_driver.Find(driverAssignmentDto.Driver_id);
            DriverTask driverTask = this.DbContext.mt_driver_task.Find(driverAssignmentDto.Task_id);

            var driverAssignmentInDb = this.DbContext.mt_driver_assignment.Find(id);

            driverAssignmentInDb.Automatic_assign_type = driverAssignmentDto.Automatic_assign_type;
            driverAssignmentInDb.DriverTask1 = driverTask;
            driverAssignmentInDb.Driver1 = driver;
            driverAssignmentInDb.First_name = driverAssignmentDto.First_name;
            driverAssignmentInDb.Last_name = driverAssignmentDto.Last_name;
            driverAssignmentInDb.Status = driverAssignmentDto.Status;
            driverAssignmentInDb.Task_status = driverAssignmentDto.Task_status;

            this.DbContext.Entry(driverAssignmentInDb).State = System.Data.Entity.EntityState.Modified;
            this.DbContext.SaveChanges();
            return "Hey!! Shady your Driver Assignment data Updated Successfully...";
        }
    }
}