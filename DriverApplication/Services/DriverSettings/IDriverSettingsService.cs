using DriverApplication.DTOs;
using DriverApplication.DTOs.DriverSettings;
using DriverApplication.DTOs.NotificationsTriggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Services.DriverAssignmentSettings
{
    public interface IDriverSettingsService
    {
        string UpdateDriverAssignmentSettings(DriverAssignmentSettingsDto driverAssignmentSettingsDto);
        void SaveDriverAssignmentSettings();

        string UpdateDriverNotificationSettings(DriverNotificationSettingsDto driverNotificationSettingsDto);
        void SaveDriverNotificationSettings();

        string UpdateDriverGeneralSettings(DriverGeneralSettingsDto driverGeneralSettingsDto);
        void SaveDriverGeneralSettings();

        string UpdateDriverMapApiKeySettings(int id, DriverMapApiKeySettingsDto driverMapApiKeySettingsDto);
        void SaveDriverMapApiSettings();

        string UpdateDriverMapSettings(int id, DriverMapSettingsDto driverMapSettingsDto);
        void SaveDriverMapSettings();

        string UpdateDriverPushLegacySettings(int id, DriverPushLegacySettingsDto driverPushLegacySettingsDto);
        void SaveDriverPushLegacySettings();

        PickupRequestReceivedTriggerDto GetPickupRequestReceivedMessage(string settingName);

    }
}