using DriverApplication.DTOs.DriverSettings;
using DriverApplication.Models.Settings;
using DriverApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Repositories.DriverSettings.PushLegacySettings
{
    public class DriverPushLegacySettingsRepository:RepositoryBase<DriverPushLegacySettings>, IDriverPushLegacySettingsRepository
    {
        public DriverPushLegacySettingsRepository(IDbFactory dbFactory)
           : base(dbFactory) { }

        public string UpdateDriverPushLegacySettings(int id, DriverPushLegacySettingsDto driverPushLegacySettingsDto)
        {
            if (driverPushLegacySettingsDto != null)
            {
                DriverPushLegacySettings driverPushLegacySettingsInDb = this.DbContext.mt_driver_push_legacy_settings.Find(id);
                if (driverPushLegacySettingsInDb == null)
                {
                    throw new ArgumentException();
                }
                else
                {
                    driverPushLegacySettingsInDb.Legacy_server_key = driverPushLegacySettingsDto.Legacy_server_key;
                    driverPushLegacySettingsInDb.Ios_push_mode = driverPushLegacySettingsDto.Ios_push_mode;
                    driverPushLegacySettingsInDb.Ios_push_certificate_passphrase = driverPushLegacySettingsDto.Ios_push_certificate_passphrase;
                   
                    this.DbContext.Entry(driverPushLegacySettingsInDb).State = System.Data.Entity.EntityState.Modified;
                    this.DbContext.SaveChanges();
                    return "error in updating map settings. please try again";
                }


            }
            else
                return "error in updating map settings. please try again";

        }
    }
}