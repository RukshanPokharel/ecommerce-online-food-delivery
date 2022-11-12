using DriverApplication.DTOs;
using DriverApplication.DTOs.DriverTeam;
using DriverApplication.Models;
using DriverApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Repositories
{
    public class DriverTeamsRepository: RepositoryBase<DriverTeam>, IDriverTeamsRepository
    {
        public DriverTeamsRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public void DeleteDriverTeam(DriverTeam driverTeam)
        {
            //DriverTeam driverTeam = this.DbContext.mt_driver_team.Find(id);
            IEnumerable<Driver> drivers = this.DbContext.mt_driver.Where(dt => dt.Team_id == driverTeam.Team_id).ToList();
            IEnumerable<DriverTask> driverTask = this.DbContext.mt_driver_task.Where(dt => dt.Team_id == driverTeam.Team_id).ToList();

            if (driverTeam == null)
            {
                throw new ArgumentException();
            }
            else
            {
                if (drivers.Count() == 0 && driverTask.Count() == 0)
                {
                    this.DbContext.mt_driver_team.Remove(driverTeam);
                }
                else if (drivers.Count() == 0 && driverTask.Count() != 0)
                {
                    driverTask.FirstOrDefault().Team_id = null;
                    this.DbContext.mt_driver_team.Remove(driverTeam);
                }
                else if (drivers.Count() != 0 && driverTask.Count() == 0)
                {
                    drivers.FirstOrDefault().Team_id = null;
                    this.DbContext.mt_driver_team.Remove(driverTeam);
                }
                else
                {
                    drivers.FirstOrDefault().Team_id = null;
                    driverTask.FirstOrDefault().Team_id = null;
                    this.DbContext.mt_driver_team.Remove(driverTeam);
                }
            }

        }

        public void AddDriverTeam(DriverTeamDto driverTeamDto)
        {
            if (driverTeamDto != null)
            {
               
                DriverTeam driverTeam = new DriverTeam();
                driverTeam.Team_name = driverTeamDto.Team_name;
                driverTeam.Location_accuracy = driverTeamDto.Location_accuracy;
                driverTeam.Status = driverTeamDto.Status;
                
                if(driverTeamDto.Drivers == null)
                {
                    this.DbContext.mt_driver_team.Add(driverTeam);
                    this.DbContext.SaveChanges();
                }
                else
                {
                    List<Driver> driver = new List<Driver>();
                    foreach (var item in driverTeamDto.Drivers)
                    {
                        Driver driver1 = this.DbContext.mt_driver.Find(item.Driver_id);
                        driver1.DriverTeam1 = driverTeam;
                        driver.Add(driver1);
                    }

                    this.DbContext.mt_driver_team.Add(driverTeam);
                    this.DbContext.SaveChanges();

                }

            }
            else
                throw new ArgumentException();

        }

        public string UpdateDriverTeam(int id, DriverTeamDto driverTeamDto)
        {
            var driverTeamInDb = this.DbContext.mt_driver_team.Find(id);
            if (driverTeamInDb == null)
            {
                throw new ArgumentException();
            }
            else
            {
                
                driverTeamInDb.Team_name = driverTeamDto.Team_name;
                driverTeamInDb.Location_accuracy = driverTeamDto.Location_accuracy;
                driverTeamInDb.Status = driverTeamDto.Status;
                driverTeamInDb.Date_modified = DateTime.Now.Date;
                driverTeamInDb.Modified_time_stamp = DateTime.Now.TimeOfDay;
                //driverTeamInDb.Drivers = driverTeamDto.Drivers;

                List<Driver> driver = new List<Driver>();
                foreach (var item in driverTeamDto.Drivers)
                {
                    Driver driver1 = this.DbContext.mt_driver.Find(item.Driver_id);
                    driver1.DriverTeam1 = driverTeamInDb;
                    driver.Add(driver1);
                }

            }

            this.DbContext.Entry(driverTeamInDb).State = System.Data.Entity.EntityState.Modified;
            this.DbContext.SaveChanges();
            return "Hey!! Shady your Driver Team Data Updated Successfully...";
        }
    }
}