using DriverApplication.DTOs.DriverSettings;
using DriverApplication.Models.Settings;
using DriverApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Repositories.DriverSettings.MapApiKeySettings
{
    public class DriverMapApiKeySettingsRepository : RepositoryBase<DriverMapApiKeysSettings>, IDriverMapApiKeySettingsRepository
    {
        public DriverMapApiKeySettingsRepository(IDbFactory dbFactory)
           : base(dbFactory) { }

        public string UpdateDriverMapApiKeySettings(int id, DriverMapApiKeySettingsDto driverMapApiKeySettingsDto)
        {
            if (driverMapApiKeySettingsDto!=null)
            {

                DriverMapApiKeysSettings driverMapApiKeysSettingsInDb = this.DbContext.mt_driver_mapapikey_settings.Find(id);
                if (driverMapApiKeysSettingsInDb == null)
                {
                    throw new ArgumentException();
                }
                else
                {
                    driverMapApiKeysSettingsInDb.Map_provider = driverMapApiKeySettingsDto.Map_provider;
                    driverMapApiKeysSettingsInDb.Google_api_key = driverMapApiKeySettingsDto.Google_api_key;
                    driverMapApiKeysSettingsInDb.Enabled_curl = driverMapApiKeySettingsDto.Enabled_curl;
                    driverMapApiKeysSettingsInDb.Mapbox_access_token = driverMapApiKeySettingsDto.Mapbox_access_token;

                    this.DbContext.Entry(driverMapApiKeysSettingsInDb).State = System.Data.Entity.EntityState.Modified;
                    this.DbContext.SaveChanges();
                    return "error in updating map api key settings. please try again";
                }


            }
            else
                return "error in updating map api key settings. please try again";

        }
    }
}