using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DriverApplication.DTOs;
using DriverApplication.DTOs.DriverSettings;
using DriverApplication.DTOs.NotificationsTriggers;
using DriverApplication.Repositories.DriverSettings;
using DriverApplication.Repositories.DriverSettings.GeneralSettings;
using DriverApplication.Repositories.DriverSettings.MapApiKeySettings;
using DriverApplication.Repositories.DriverSettings.MapSettings;
using DriverApplication.Repositories.DriverSettings.NotificationSettings;
using DriverApplication.Repositories.DriverSettings.PushLegacySettings;
using DriverApplication.Utilities;

namespace DriverApplication.Services.DriverAssignmentSettings
{
    public class DriverSettingsService : IDriverSettingsService
    {
        private readonly IDriverAssignmentSettingsRepository driverAssignmentSettingsRepository;
        private readonly IDriverNotificationSettingsRepository driverNotificationSettingsRepository;
        private readonly IGeneralSettingsRepository driverGeneralSettingsRepository;
        private readonly IDriverMapApiKeySettingsRepository driverMapApiKeySettingsRepository;
        private readonly IDriverMapSettingsRepository driverMapSettingsRepository;
        private readonly IDriverPushLegacySettingsRepository driverPushLegacySettingsRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IUnitOfWork unitOfWork2;
        private readonly IUnitOfWork unitOfWork3;
        private readonly IUnitOfWork unitOfWork4;
        private readonly IUnitOfWork unitOfWork5;
        private readonly IUnitOfWork unitOfWork6;

        public DriverSettingsService(IDriverAssignmentSettingsRepository driverAssignmentSettingsRepository, IDriverNotificationSettingsRepository driverNotificationSettingsRepository, IGeneralSettingsRepository driverGeneralSettingsRepository, IDriverMapApiKeySettingsRepository driverMapApiKeySettingsRepository, IDriverMapSettingsRepository driverMapSettingsRepository, IDriverPushLegacySettingsRepository driverPushLegacySettingsRepository, IUnitOfWork unitOfWork, IUnitOfWork unitOfWork2, IUnitOfWork unitOfWork3, IUnitOfWork unitOfWork4, IUnitOfWork unitOfWork5, IUnitOfWork unitOfWork6)
        {
            this.driverAssignmentSettingsRepository = driverAssignmentSettingsRepository;
            this.driverNotificationSettingsRepository = driverNotificationSettingsRepository;
            this.driverGeneralSettingsRepository = driverGeneralSettingsRepository;
            this.driverMapApiKeySettingsRepository = driverMapApiKeySettingsRepository;
            this.driverMapSettingsRepository = driverMapSettingsRepository;
            this.driverPushLegacySettingsRepository = driverPushLegacySettingsRepository;
            this.unitOfWork = unitOfWork;
            this.unitOfWork2 = unitOfWork2;
            this.unitOfWork3 = unitOfWork3;
            this.unitOfWork4 = unitOfWork4;
            this.unitOfWork5 = unitOfWork5;
            this.unitOfWork6 = unitOfWork6;
        }

        public PickupRequestReceivedTriggerDto GetPickupRequestReceivedMessage(string settingName)
        {
            return driverNotificationSettingsRepository.GetPickupRequestReceivedMessage(settingName);
        }

        public void SaveDriverAssignmentSettings()
        {
            unitOfWork.Commit();
        }

        public void SaveDriverGeneralSettings()
        {
            unitOfWork3.Commit();
        }

        public void SaveDriverMapApiSettings()
        {
            unitOfWork5.Commit();
        }

        public void SaveDriverMapSettings()
        {
            unitOfWork4.Commit();
        }
    
        public void SaveDriverNotificationSettings()
        {
            unitOfWork2.Commit();
        }

        public void SaveDriverPushLegacySettings()
        {
            unitOfWork6.Commit();
        }

        public string UpdateDriverAssignmentSettings(DriverAssignmentSettingsDto driverAssignmentSettingsDto)
        {
            return driverAssignmentSettingsRepository.UpdateDriverAssignmentSettings(driverAssignmentSettingsDto);
        }

        public string UpdateDriverGeneralSettings(DriverGeneralSettingsDto driverGeneralSettingsDto)
        {
            return driverGeneralSettingsRepository.UpdateDriverGeneralSettings(driverGeneralSettingsDto);
        }

        public string UpdateDriverMapApiKeySettings(int id, DriverMapApiKeySettingsDto driverMapApiKeySettingsDto)
        {
            return driverMapApiKeySettingsRepository.UpdateDriverMapApiKeySettings(id, driverMapApiKeySettingsDto);
        }

        public string UpdateDriverMapSettings(int id, DriverMapSettingsDto driverMapSettingsDto)
        {
            return driverMapSettingsRepository.UpdateDriverMapSettings(id, driverMapSettingsDto);
        }

        public string UpdateDriverNotificationSettings(DriverNotificationSettingsDto driverNotificationSettingsDto)
        {
            return driverNotificationSettingsRepository.UpdateDriverNotificationSettings(driverNotificationSettingsDto);
        }

        public string UpdateDriverPushLegacySettings(int id, DriverPushLegacySettingsDto driverPushLegacySettingsDto)
        {
            return driverPushLegacySettingsRepository.UpdateDriverPushLegacySettings(id, driverPushLegacySettingsDto);
        }
    }
}