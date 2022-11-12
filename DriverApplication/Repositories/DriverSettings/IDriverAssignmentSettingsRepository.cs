using DriverApplication.DTOs;
using DriverApplication.DTOs.DriverSettings;
using DriverApplication.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Repositories.DriverSettings
{
    public interface IDriverAssignmentSettingsRepository : IRepository<DriverAssignmentSettings>
    {
        string UpdateDriverAssignmentSettings(DriverAssignmentSettingsDto driverAssignmentSettingsDto);
    }

}