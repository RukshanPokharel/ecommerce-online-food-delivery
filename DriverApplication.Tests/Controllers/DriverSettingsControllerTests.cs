using DriverApplication.Controllers.APIs.AssignmentSettings;
using DriverApplication.DTOs;
using DriverApplication.DTOs.DriverSettings;
using DriverApplication.Services.DriverAssignmentSettings;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Xunit;

namespace DriverApplication.Tests.Controllers
{
    public class DriverSettingsControllerTests
    {
        private readonly Mock<IDriverSettingsService> mockService;
        private readonly DriverSettingsController driverSettingsCont;

        public DriverSettingsControllerTests()
        {
            mockService = new Mock<IDriverSettingsService>();
            driverSettingsCont = new DriverSettingsController(mockService.Object);
        }

        [Fact]
        public void Update_ValidDriverSettingsIdAndDto_ComparisonShouldBeEqual()
        {
            var driverSettingsMock = new DriverAssignmentSettingsDto { enabled_auto_assign = "a", include_offline_driver = "a", autoassign_notify_email="a", request_expire = "a", auto_assign_retry = "a", driver_auto_assign_type = "a", assign_request_expire="a", within_radius = "a", within_radius_unit = "a" };

            var actionResult = driverSettingsCont.PutDriverAssignmentSettings(driverSettingsMock);
            var response = actionResult as OkNegotiatedContentResult<DriverAssignmentSettingsDto>;

            Assert.NotNull(response);

            var newDriverAssignmentSettings = response.Content;

            Assert.Equal("a", newDriverAssignmentSettings.enabled_auto_assign);
            Assert.Equal("a", newDriverAssignmentSettings.include_offline_driver);
            Assert.Equal("a", newDriverAssignmentSettings.autoassign_notify_email);
            Assert.Equal("a", newDriverAssignmentSettings.request_expire);
            Assert.Equal("a", newDriverAssignmentSettings.auto_assign_retry);
            Assert.Equal("a", newDriverAssignmentSettings.driver_auto_assign_type);
            Assert.Equal("a", newDriverAssignmentSettings.assign_request_expire);
            Assert.Equal("a", newDriverAssignmentSettings.within_radius_unit);
            Assert.Equal("a", newDriverAssignmentSettings.within_radius);
        }

        [Fact]
        public void Update_ValidDriverGeneralSettingsIdAndDto_ComparisonShouldBeEqual()
        {
            var driverGeneralSettingsMock = new DriverGeneralSettingsDto { website_title = "a", mobile_api_url = "a", api_hash_key="a", language = "a", app_default_language = "a", allow_admin_by_merchant = "a", allow_merchant_useby_admin = "a", choose_merchant = "a" };

            var actionResult = driverSettingsCont.PutDriverGeneralSettings(driverGeneralSettingsMock);
            var response = actionResult as OkNegotiatedContentResult<DriverGeneralSettingsDto>;

            Assert.NotNull(response);

            var newdriverGeneralSettings = response.Content;

            Assert.Equal("a", newdriverGeneralSettings.website_title);
            Assert.Equal("a", newdriverGeneralSettings.mobile_api_url);
            Assert.Equal("a", newdriverGeneralSettings.api_hash_key);
            Assert.Equal("a", newdriverGeneralSettings.language);
            Assert.Equal("a", newdriverGeneralSettings.app_default_language);
            Assert.Equal("a", newdriverGeneralSettings.allow_admin_by_merchant);
            Assert.Equal("a", newdriverGeneralSettings.allow_merchant_useby_admin);
            Assert.Equal("a", newdriverGeneralSettings.choose_merchant);
        }

        [Fact]
        public void Update_ValidDriverMapApiSettingsIdAndDto_ComparisonShouldBeEqual()
        {
            var driverMapApiSettingsMock = new DriverMapApiKeySettingsDto { Map_provider = "a", Google_api_key = "a", Enabled_curl ="a", Mapbox_access_token = "a"};

            var actionResult = driverSettingsCont.PutDriverMapApiKeySettings(1, driverMapApiSettingsMock);
            var response = actionResult as OkNegotiatedContentResult<DriverMapApiKeySettingsDto>;

            Assert.NotNull(response);

            var newDriverMapApiSettings = response.Content;

            Assert.Equal("a", newDriverMapApiSettings.Map_provider);
            Assert.Equal("a", newDriverMapApiSettings.Google_api_key);
            Assert.Equal("a", newDriverMapApiSettings.Enabled_curl);
            Assert.Equal("a", newDriverMapApiSettings.Mapbox_access_token);
            
        }

        [Fact]
        public void Update_ValidDriverMapSettingsIdAndDto_ComparisonShouldBeEqual()
        {
            var driverMapSettingsMock = new DriverMapSettingsDto {Default_map_country = "a", Disable_activity_tracking = "a", Activity_refresh_interval="a", Auto_geocode_address="a", Driver_activity_refresh="a", Google_map_style="a", Hide_delivery_task="a", Hide_pickup_task="a", Hide_successful_task="a", Include_offline_driver_map="a" };

            var actionResult = driverSettingsCont.PutDriverMapSettings(1, driverMapSettingsMock);
            var response = actionResult as OkNegotiatedContentResult<DriverMapSettingsDto>;

            Assert.NotNull(response);

            var newDriverMapSettings = response.Content;

            Assert.Equal("a", newDriverMapSettings.Default_map_country);
            Assert.Equal("a", newDriverMapSettings.Disable_activity_tracking);
            Assert.Equal("a", newDriverMapSettings.Activity_refresh_interval);
            Assert.Equal("a", newDriverMapSettings.Auto_geocode_address);
            Assert.Equal("a", newDriverMapSettings.Driver_activity_refresh);
            Assert.Equal("a", newDriverMapSettings.Google_map_style);
            Assert.Equal("a", newDriverMapSettings.Hide_delivery_task);
            Assert.Equal("a", newDriverMapSettings.Hide_pickup_task);
            Assert.Equal("a", newDriverMapSettings.Hide_successful_task);
            Assert.Equal("a", newDriverMapSettings.Include_offline_driver_map);
            
        }

        [Fact]
        public void Update_ValidDriverPushLegacySettingsIdAndDto_ComparisonShouldBeEqual()
        {
            var driverPushLegacySettingsMock = new DriverPushLegacySettingsDto {Legacy_server_key = "a", Ios_push_mode ="a", Ios_push_certificate_passphrase = "a"};

            var actionResult = driverSettingsCont.PutDriverPushLegacySettings(1, driverPushLegacySettingsMock);
            var response = actionResult as OkNegotiatedContentResult<DriverPushLegacySettingsDto>;

            Assert.NotNull(response);

            var newDriverPushLegacySettings = response.Content;

            Assert.Equal("a", newDriverPushLegacySettings.Legacy_server_key);
            Assert.Equal("a", newDriverPushLegacySettings.Ios_push_mode);
            Assert.Equal("a", newDriverPushLegacySettings.Ios_push_certificate_passphrase);
            
        }

        //[Fact]
        //public void Update_ValidDriverNotificationSettingsIdAndDto_ComparisonShouldBeEqual()
        //{
        //    var driverNotificationSettingsMock = new DriverNotificationSettingsDto { };

        //    var actionResult = driverSettingsCont.PutDriverNotificationSettings(driverNotificationSettingsMock);
        //    var response = actionResult as OkNegotiatedContentResult<DriverNotificationSettingsDto>;

        //    Assert.NotNull(response);

        //    var newDriverAssignmentSettings = response.Content;
        //    //Assert.Equal(1, newDriver.id);
        //    Assert.Equal("a", newDriverAssignmentSettings.enabled_auto_assign);
        //    Assert.Equal("a", newDriverAssignmentSettings.include_offline_driver);
        //    Assert.Equal("a", newDriverAssignmentSettings.autoassign_notify_email);
        //    Assert.Equal("a", newDriverAssignmentSettings.request_expire);
        //    Assert.Equal("a", newDriverAssignmentSettings.auto_assign_retry);
        //    Assert.Equal("a", newDriverAssignmentSettings.driver_auto_assign_type);
        //    Assert.Equal("a", newDriverAssignmentSettings.assign_request_expire);
        //    Assert.Equal("a", newDriverAssignmentSettings.within_radius_unit);
        //    Assert.Equal("a", newDriverAssignmentSettings.within_radius);
        //}

    }
}
