using DriverApplication.DTOs.DriverSettings;
using DriverApplication.Models.Settings;
using DriverApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Repositories.DriverSettings.GeneralSettings
{
    public class GeneralSettingsRepository:RepositoryBase<DriverGeneralSettings>, IGeneralSettingsRepository
    {
        public GeneralSettingsRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public string UpdateDriverGeneralSettings(DriverGeneralSettingsDto driverGeneralSettingsDto)
        {
            if (driverGeneralSettingsDto!=null)
            {
                var website_title = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("website_title")).FirstOrDefault();
                website_title.Option_value = driverGeneralSettingsDto.website_title;
                this.DbContext.Entry(website_title).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var mobile_api_url = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("mobile_api_url")).FirstOrDefault();
                mobile_api_url.Option_value = driverGeneralSettingsDto.mobile_api_url;
                this.DbContext.Entry(mobile_api_url).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var api_hash_key = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("api_hash_key")).FirstOrDefault();
                api_hash_key.Option_value = driverGeneralSettingsDto.api_hash_key;
                this.DbContext.Entry(api_hash_key).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var language = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("language")).FirstOrDefault();
                language.Option_value = driverGeneralSettingsDto.language;
                this.DbContext.Entry(language).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var app_default_language = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("app_default_language")).FirstOrDefault();
                app_default_language.Option_value = driverGeneralSettingsDto.app_default_language;
                this.DbContext.Entry(app_default_language).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var allow_admin_by_merchant = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("allow_admin_by_merchant")).FirstOrDefault();
                allow_admin_by_merchant.Option_value = driverGeneralSettingsDto.allow_admin_by_merchant;
                this.DbContext.Entry(allow_admin_by_merchant).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var allow_merchant_useby_admin = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("allow_merchant_useby_admin")).FirstOrDefault();
                allow_merchant_useby_admin.Option_value = driverGeneralSettingsDto.allow_merchant_useby_admin;
                this.DbContext.Entry(allow_merchant_useby_admin).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var choose_merchant = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("choose_merchant")).FirstOrDefault();
                choose_merchant.Option_value = driverGeneralSettingsDto.choose_merchant;
                this.DbContext.Entry(choose_merchant).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var task_owner = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("task_owner")).FirstOrDefault();
                task_owner.Option_value = driverGeneralSettingsDto.task_owner;
                this.DbContext.Entry(task_owner).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var merchant_task_owner_to_admin = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("merchant_task_owner_to_admin")).FirstOrDefault();
                merchant_task_owner_to_admin.Option_value = driverGeneralSettingsDto.merchant_task_owner_to_admin;
                this.DbContext.Entry(merchant_task_owner_to_admin).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var show_only_admin_task = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("show_only_admin_task")).FirstOrDefault();
                show_only_admin_task.Option_value = driverGeneralSettingsDto.show_only_admin_task;
                this.DbContext.Entry(show_only_admin_task).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var allow_merchant_delete_task = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("allow_merchant_delete_task")).FirstOrDefault();
                allow_merchant_delete_task.Option_value = driverGeneralSettingsDto.allow_merchant_delete_task;
                this.DbContext.Entry(allow_merchant_delete_task).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var days_to_delete_task = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("days_to_delete_task")).FirstOrDefault();
                days_to_delete_task.Option_value = driverGeneralSettingsDto.days_to_delete_task;
                this.DbContext.Entry(days_to_delete_task).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var block_merchant = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("block_merchant")).FirstOrDefault();
                block_merchant.Option_value = driverGeneralSettingsDto.block_merchant;
                this.DbContext.Entry(block_merchant).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var order_status_accepted = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("order_status_accepted")).FirstOrDefault();
                order_status_accepted.Option_value = driverGeneralSettingsDto.order_status_accepted;
                this.DbContext.Entry(order_status_accepted).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var order_status_cancel = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("order_status_cancel")).FirstOrDefault();
                order_status_cancel.Option_value = driverGeneralSettingsDto.order_status_cancel;
                this.DbContext.Entry(order_status_cancel).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var delivery_time = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("delivery_time")).FirstOrDefault();
                delivery_time.Option_value = driverGeneralSettingsDto.delivery_time;
                this.DbContext.Entry(delivery_time).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var hide_total_order_amount = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("hide_total_order_amount")).FirstOrDefault();
                hide_total_order_amount.Option_value = driverGeneralSettingsDto.hide_total_order_amount;
                this.DbContext.Entry(hide_total_order_amount).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var app_name = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("app_name")).FirstOrDefault();
                app_name.Option_value = driverGeneralSettingsDto.app_name;
                this.DbContext.Entry(app_name).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var send_push_to_online_driver = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("send_push_to_online_driver")).FirstOrDefault();
                send_push_to_online_driver.Option_value = driverGeneralSettingsDto.send_push_to_online_driver;
                this.DbContext.Entry(send_push_to_online_driver).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var enable_notes = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("enable_notes")).FirstOrDefault();
                enable_notes.Option_value = driverGeneralSettingsDto.enable_notes;
                this.DbContext.Entry(enable_notes).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var enable_signature = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("enable_signature")).FirstOrDefault();
                enable_signature.Option_value = driverGeneralSettingsDto.enable_signature;
                this.DbContext.Entry(enable_signature).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var mandatory_signature = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("mandatory_signature")).FirstOrDefault();
                mandatory_signature.Option_value = driverGeneralSettingsDto.mandatory_signature;
                this.DbContext.Entry(mandatory_signature).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var enabled_signup = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("enabled_signup")).FirstOrDefault();
                enabled_signup.Option_value = driverGeneralSettingsDto.enabled_signup;
                this.DbContext.Entry(enabled_signup).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var enable_take_picture = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("enable_take_picture")).FirstOrDefault();
                enable_take_picture.Option_value = driverGeneralSettingsDto.enable_take_picture;
                this.DbContext.Entry(enable_take_picture).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var enable_resize_picture = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("enable_resize_picture")).FirstOrDefault();
                enable_resize_picture.Option_value = driverGeneralSettingsDto.enable_resize_picture;
                this.DbContext.Entry(enable_resize_picture).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var resize_picture_width = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("resize_picture_width")).FirstOrDefault();
                resize_picture_width.Option_value = driverGeneralSettingsDto.resize_picture_width;
                this.DbContext.Entry(resize_picture_width).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var resize_picture_height = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("resize_picture_height")).FirstOrDefault();
                resize_picture_height.Option_value = driverGeneralSettingsDto.resize_picture_height;
                this.DbContext.Entry(resize_picture_height).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var device_vibration = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("device_vibration")).FirstOrDefault();
                device_vibration.Option_value = driverGeneralSettingsDto.device_vibration;
                this.DbContext.Entry(device_vibration).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var signup_status = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("signup_status")).FirstOrDefault();
                signup_status.Option_value = driverGeneralSettingsDto.signup_status;
                this.DbContext.Entry(signup_status).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var signup_send_notification_email = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("signup_send_notification_email")).FirstOrDefault();
                signup_send_notification_email.Option_value = driverGeneralSettingsDto.signup_send_notification_email;
                this.DbContext.Entry(signup_send_notification_email).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var localize_calender_language = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("localize_calender_language")).FirstOrDefault();
                localize_calender_language.Option_value = driverGeneralSettingsDto.localize_calender_language;
                this.DbContext.Entry(localize_calender_language).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var driver_tracking_option = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("driver_tracking_option")).FirstOrDefault();
                driver_tracking_option.Option_value = driverGeneralSettingsDto.driver_tracking_option;
                this.DbContext.Entry(driver_tracking_option).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var records_driver_location = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("records_driver_location")).FirstOrDefault();
                records_driver_location.Option_value = driverGeneralSettingsDto.records_driver_location;
                this.DbContext.Entry(records_driver_location).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var disable_background_tracking = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("disable_background_tracking")).FirstOrDefault();
                disable_background_tracking.Option_value = driverGeneralSettingsDto.disable_background_tracking;
                this.DbContext.Entry(disable_background_tracking).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var track_interval = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("track_interval")).FirstOrDefault();
                track_interval.Option_value = driverGeneralSettingsDto.track_interval;
                this.DbContext.Entry(track_interval).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var task_critical_option_enable = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("task_critical_option_enable")).FirstOrDefault();
                task_critical_option_enable.Option_value = driverGeneralSettingsDto.task_critical_option_enable;
                this.DbContext.Entry(task_critical_option_enable).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var minutes = this.DbContext.mt_driver_general_settings.Where(c => c.Option_name.Equals("minutes")).FirstOrDefault();
                minutes.Option_value = driverGeneralSettingsDto.minutes;
                this.DbContext.Entry(minutes).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                return "Hey!! Shady your Driver General Settings Data Updated Successfully...";

            }
            else
                throw new ArgumentException();
        }
    }
}