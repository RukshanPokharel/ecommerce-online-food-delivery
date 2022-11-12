using DriverApplication.DTOs;
using DriverApplication.Models;
using DriverApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Repositories
{
    public class DriverTasksRepository : RepositoryBase<DriverTask>, IDriverTasksRepository
    {
        public DriverTasksRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public void AddDriverTask(DriverTaskDto driverTaskDto)
        {
            DriverTeam driverTeam = this.DbContext.mt_driver_team.Find(driverTaskDto.Team_id);
            Order order = this.DbContext.mt_order.Find(driverTaskDto.Order_id);
            Driver driver = this.DbContext.mt_driver.Find(driverTaskDto.Driver_id);

            if (driverTeam != null && order != null && driver != null)
            {
                DriverTask driverTask = new DriverTask();
                driverTask.Task_description = driverTaskDto.Task_description;
                driverTask.Trans_type = driverTaskDto.Trans_type;
                driverTask.Contact_number = driverTaskDto.Contact_number;
                driverTask.Email_address = driverTaskDto.Email_address;
                driverTask.Customer_name = driverTaskDto.Customer_name;
                driverTask.Delivery_date = driverTaskDto.Delivery_date;
                driverTask.Delivery_address = driverTaskDto.Delivery_address;
                driverTask.Dropoff_merchant = driverTaskDto.Dropoff_merchant;
                driverTask.Dropoff_contact_name = driverTaskDto.Dropoff_contact_name;
                driverTask.Dropoff_contact_number = driverTaskDto.Dropoff_contact_number;
                driverTask.Drop_address = driverTaskDto.Drop_address;
                driverTask.Recipient_name = driverTaskDto.Recipient_name;
                driverTask.DriverTeam1 = driverTeam;
                driverTask.Driver1 = driver;
                driverTask.Order1 = order;

                this.DbContext.mt_driver_task.Add(driverTask);

            }
            else if (driverTeam == null && order != null && driver == null)
            {
                DriverTask driverTask = new DriverTask();
                driverTask.Task_description = driverTaskDto.Task_description;
                driverTask.Trans_type = driverTaskDto.Trans_type;
                driverTask.Contact_number = driverTaskDto.Contact_number;
                driverTask.Email_address = driverTaskDto.Email_address;
                driverTask.Customer_name = driverTaskDto.Customer_name;
                driverTask.Delivery_date = driverTaskDto.Delivery_date;
                driverTask.Delivery_address = driverTaskDto.Delivery_address;
                driverTask.Dropoff_merchant = driverTaskDto.Dropoff_merchant;
                driverTask.Dropoff_contact_name = driverTaskDto.Dropoff_contact_name;
                driverTask.Dropoff_contact_number = driverTaskDto.Dropoff_contact_number;
                driverTask.Drop_address = driverTaskDto.Drop_address;
                driverTask.Recipient_name = driverTaskDto.Recipient_name;
                driverTask.DriverTeam1 = null;
                driverTask.Driver1 = null;
                driverTask.Order1 = order;

                this.DbContext.mt_driver_task.Add(driverTask);

            }
            else
                throw new ArgumentException();
        }

        public void UpdateDriverReassignTask(int id, int driverTeamId, int driverId)
        {
            DriverTeam driverTeam = this.DbContext.mt_driver_team.Find(driverTeamId);
            Driver driver = this.DbContext.mt_driver.Find(driverId);

            var driverTaskInDb = this.DbContext.mt_driver_task.Find(id);
            if (driverTaskInDb == null)
            {
                throw new ArgumentException();
            }
            else
            {
                driverTaskInDb.DriverTeam1 = driverTeam;
                driverTaskInDb.Driver1 = driver;

                this.DbContext.Entry(driverTaskInDb).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();
            }
        }

        public string UpdateDriverTask(int id, DriverTaskDto driverTaskDto)
        {
            DriverTeam driverTeam = this.DbContext.mt_driver_team.Find(driverTaskDto.Team_id);
            Order order = this.DbContext.mt_order.Find(driverTaskDto.Order_id);
            Driver driver = this.DbContext.mt_driver.Find(driverTaskDto.Driver_id);

            var driverTaskInDb = this.DbContext.mt_driver_task.Find(id);
            if (driverTaskInDb == null)
            {
                throw new ArgumentException();
            }
            else
            {

                driverTaskInDb.Task_description = driverTaskDto.Task_description;
                driverTaskInDb.Trans_type = driverTaskDto.Trans_type;
                driverTaskInDb.Contact_number = driverTaskDto.Contact_number;
                driverTaskInDb.Email_address = driverTaskDto.Email_address;
                driverTaskInDb.Customer_name = driverTaskDto.Customer_name;
                driverTaskInDb.Delivery_date = driverTaskDto.Delivery_date;
                driverTaskInDb.Delivery_address = driverTaskDto.Delivery_address;
                driverTaskInDb.Dropoff_merchant = driverTaskDto.Dropoff_merchant;
                driverTaskInDb.Dropoff_contact_name = driverTaskDto.Dropoff_contact_name;
                driverTaskInDb.Dropoff_contact_number = driverTaskDto.Dropoff_contact_number;
                driverTaskInDb.Drop_address = driverTaskDto.Drop_address;
                driverTaskInDb.Recipient_name = driverTaskDto.Recipient_name;
                driverTaskInDb.Date_modified = DateTime.Now.Date;
                driverTaskInDb.Modified_time_stamp = DateTime.Now.TimeOfDay;
                driverTaskInDb.DriverTeam1 = driverTeam;
                driverTaskInDb.Driver1 = driver;
                driverTaskInDb.Order1 = order;

                this.DbContext.Entry(driverTaskInDb).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();
                return "Hey!! Shady your Driver Task Data Updated Successfully...";
            }

        }

        public void UpdateDriverTaskStatus(int id, string status)
        {
            var driverTaskInDb = this.DbContext.mt_driver_task.Find(id);
            if (driverTaskInDb == null)
            {
                throw new ArgumentException();
            }
            else
            {

                driverTaskInDb.Status = status;
                
                this.DbContext.Entry(driverTaskInDb).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();
            }
        }
    }
}