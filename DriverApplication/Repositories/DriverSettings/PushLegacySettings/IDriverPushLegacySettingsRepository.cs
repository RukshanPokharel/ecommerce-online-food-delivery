using DriverApplication.DTOs.DriverSettings;
using DriverApplication.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Repositories.DriverSettings.PushLegacySettings
{
    public interface IDriverPushLegacySettingsRepository : IRepository<DriverPushLegacySettings>
    {
        string UpdateDriverPushLegacySettings(int id, DriverPushLegacySettingsDto driverPushLegacySettingsDto);
    }
}