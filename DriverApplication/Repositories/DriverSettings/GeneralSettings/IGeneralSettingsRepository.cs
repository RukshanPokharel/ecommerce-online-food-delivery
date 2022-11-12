using DriverApplication.DTOs.DriverSettings;
using DriverApplication.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Repositories.DriverSettings.GeneralSettings
{
    public interface IGeneralSettingsRepository : IRepository<DriverGeneralSettings>
    {
        string UpdateDriverGeneralSettings(DriverGeneralSettingsDto driverGeneralSettingsDto);
    }
}