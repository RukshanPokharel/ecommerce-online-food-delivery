using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DriverApplication.DTOs.DriverSettings;
using DriverApplication.Models.Settings;

namespace DriverApplication.Repositories.DriverSettings.MapApiKeySettings
{
    public interface IDriverMapApiKeySettingsRepository : IRepository<DriverMapApiKeysSettings>
    {
        string UpdateDriverMapApiKeySettings(int id, DriverMapApiKeySettingsDto driverMapApiKeySettingsDto);
    }
}