using DriverApplication.DTOs.DriverSettings;
using DriverApplication.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Repositories.DriverSettings.MapSettings
{
    public interface IDriverMapSettingsRepository : IRepository<DriverMapSettingsRepository>
    {
        string UpdateDriverMapSettings(int id, DriverMapSettingsDto driverMapSettingsDto);
    }
}