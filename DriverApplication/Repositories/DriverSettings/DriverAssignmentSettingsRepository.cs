using DriverApplication.DTOs;
using DriverApplication.DTOs.DriverSettings;
using DriverApplication.Models.Settings;
using DriverApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Repositories.DriverSettings
{
    public class DriverAssignmentSettingsRepository : RepositoryBase<DriverAssignmentSettings>, IDriverAssignmentSettingsRepository
    {
        public DriverAssignmentSettingsRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public string UpdateDriverAssignmentSettings(DriverAssignmentSettingsDto driverAssignmentSettingsDto)
        {
            if (driverAssignmentSettingsDto!=null)
            {
                var enabled_auto_assign = this.DbContext.mt_driver_assignment_settings.Where(c => c.Option_name.Equals("enabled_auto_assign")).FirstOrDefault();
                enabled_auto_assign.Option_value = driverAssignmentSettingsDto.enabled_auto_assign;
                this.DbContext.Entry(enabled_auto_assign).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var include_offline_driver = this.DbContext.mt_driver_assignment_settings.Where(c => c.Option_name.Equals("include_offline_driver")).FirstOrDefault();
                include_offline_driver.Option_value = driverAssignmentSettingsDto.include_offline_driver;
                this.DbContext.Entry(include_offline_driver).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var autoassign_notify_email = this.DbContext.mt_driver_assignment_settings.Where(c => c.Option_name.Equals("autoassign_notify_email")).FirstOrDefault();
                autoassign_notify_email.Option_value = driverAssignmentSettingsDto.autoassign_notify_email;
                this.DbContext.Entry(autoassign_notify_email).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var request_expire = this.DbContext.mt_driver_assignment_settings.Where(c => c.Option_name.Equals("request_expire")).FirstOrDefault();
                request_expire.Option_value = driverAssignmentSettingsDto.request_expire;
                this.DbContext.Entry(request_expire).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var auto_assign_retry = this.DbContext.mt_driver_assignment_settings.Where(c => c.Option_name.Equals("auto_assign_retry")).FirstOrDefault();
                auto_assign_retry.Option_value = driverAssignmentSettingsDto.auto_assign_retry;
                this.DbContext.Entry(auto_assign_retry).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var driver_auto_assign_type = this.DbContext.mt_driver_assignment_settings.Where(c => c.Option_name.Equals("driver_auto_assign_type")).FirstOrDefault();
                driver_auto_assign_type.Option_value = driverAssignmentSettingsDto.driver_auto_assign_type;
                this.DbContext.Entry(driver_auto_assign_type).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var assign_request_expire = this.DbContext.mt_driver_assignment_settings.Where(c => c.Option_name.Equals("assign_request_expire")).FirstOrDefault();
                assign_request_expire.Option_value = driverAssignmentSettingsDto.assign_request_expire;
                this.DbContext.Entry(assign_request_expire).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var within_radius = this.DbContext.mt_driver_assignment_settings.Where(c => c.Option_name.Equals("within_radius")).FirstOrDefault();
                within_radius.Option_value = driverAssignmentSettingsDto.within_radius;
                this.DbContext.Entry(within_radius).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var within_radius_unit = this.DbContext.mt_driver_assignment_settings.Where(c => c.Option_name.Equals("within_radius_unit")).FirstOrDefault();
                within_radius_unit.Option_value = driverAssignmentSettingsDto.within_radius_unit;
                this.DbContext.Entry(within_radius_unit).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();


                return "Hey!! Shady your Driver Settings Data Updated Successfully...";
            }
            else
                throw new ArgumentException();

        }

    }
}