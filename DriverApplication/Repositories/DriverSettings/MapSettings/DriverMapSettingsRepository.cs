using DriverApplication.DTOs.DriverSettings;
using DriverApplication.Models.Settings;
using DriverApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Repositories.DriverSettings.MapSettings
{
    public class DriverMapSettingsRepository:RepositoryBase<DriverMapSettingsRepository>, IDriverMapSettingsRepository
    {
        public DriverMapSettingsRepository(IDbFactory dbFactory)
          : base(dbFactory) { }

        public string UpdateDriverMapSettings(int id, DriverMapSettingsDto driverMapSettingsDto)
        {
            if (driverMapSettingsDto != null)
            {
                DriverMapSettings driverMapSettingsInDb = this.DbContext.mt_driver_map_settings.Find(id);
                if (driverMapSettingsInDb == null)
                {
                    throw new ArgumentException();
                }
                else
                {
                    driverMapSettingsInDb.Default_map_country = driverMapSettingsDto.Default_map_country;
                    driverMapSettingsInDb.Disable_activity_tracking = driverMapSettingsDto.Disable_activity_tracking;
                    driverMapSettingsInDb.Activity_refresh_interval = driverMapSettingsDto.Activity_refresh_interval;
                    driverMapSettingsInDb.Driver_activity_refresh = driverMapSettingsDto.Driver_activity_refresh;
                    driverMapSettingsInDb.Auto_geocode_address = driverMapSettingsDto.Auto_geocode_address;
                    driverMapSettingsInDb.Include_offline_driver_map = driverMapSettingsDto.Include_offline_driver_map;
                    driverMapSettingsInDb.Hide_pickup_task = driverMapSettingsDto.Hide_pickup_task;
                    driverMapSettingsInDb.Hide_delivery_task = driverMapSettingsDto.Hide_delivery_task;
                    driverMapSettingsInDb.Hide_successful_task = driverMapSettingsDto.Hide_successful_task;
                    driverMapSettingsInDb.Google_map_style = driverMapSettingsDto.Google_map_style;

                    this.DbContext.Entry(driverMapSettingsInDb).State = System.Data.Entity.EntityState.Modified;
                    this.DbContext.SaveChanges();
                    return "error in updating map settings. please try again";
                }


            }
            else
                return "error in updating map settings. please try again";

        }
    }
}