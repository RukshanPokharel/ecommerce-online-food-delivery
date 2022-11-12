using DriverApplication.DTOs.DriverSettings;
using DriverApplication.DTOs.NotificationsTriggers;
using DriverApplication.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Repositories.DriverSettings.NotificationSettings
{
    public interface IDriverNotificationSettingsRepository : IRepository<DriverNotificationSettings>
    {

        string UpdateDriverNotificationSettings(DriverNotificationSettingsDto driverNotificationSettingsDto);
        PickupRequestReceivedTriggerDto GetPickupRequestReceivedMessage(string settingName);

    }
}