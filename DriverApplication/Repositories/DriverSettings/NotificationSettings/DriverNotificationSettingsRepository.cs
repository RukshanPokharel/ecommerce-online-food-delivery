using DriverApplication.DTOs.DriverSettings;
using DriverApplication.DTOs.NotificationsTriggers;
using DriverApplication.Models.Settings;
using DriverApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.Repositories.DriverSettings.NotificationSettings
{
    public class DriverNotificationSettingsRepository : RepositoryBase<DriverNotificationSettings>, IDriverNotificationSettingsRepository
    {
        public DriverNotificationSettingsRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public string UpdateDriverNotificationSettings(DriverNotificationSettingsDto driverNotificationSettingsDto)
        {
            if (driverNotificationSettingsDto != null)
            {
                var triggerName = this.DbContext.mt_driver_notification_settings.Where(c => c.Trigger_name.Equals("pickup_request_received")).FirstOrDefault();
                triggerName.Mobile_push = driverNotificationSettingsDto.pickupRequestReceivedTriggerDto.mobile_push;
                triggerName.Sms = driverNotificationSettingsDto.pickupRequestReceivedTriggerDto.sms;
                triggerName.Email = driverNotificationSettingsDto.pickupRequestReceivedTriggerDto.email;
                triggerName.Action_mobile = driverNotificationSettingsDto.pickupRequestReceivedTriggerDto.action_mobile;
                triggerName.Action_sms = driverNotificationSettingsDto.pickupRequestReceivedTriggerDto.action_sms;
                triggerName.Action_email = driverNotificationSettingsDto.pickupRequestReceivedTriggerDto.action_email;
                this.DbContext.Entry(triggerName).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var triggerName2 = this.DbContext.mt_driver_notification_settings.Where(c => c.Trigger_name.Equals("pickup_driver_started")).FirstOrDefault();
                triggerName2.Mobile_push = driverNotificationSettingsDto.pickupDriverStartedTriggerDto.mobile_push;
                triggerName2.Sms = driverNotificationSettingsDto.pickupDriverStartedTriggerDto.sms;
                triggerName2.Email = driverNotificationSettingsDto.pickupDriverStartedTriggerDto.email;
                triggerName2.Action_mobile = driverNotificationSettingsDto.pickupDriverStartedTriggerDto.action_mobile;
                triggerName2.Action_sms = driverNotificationSettingsDto.pickupDriverStartedTriggerDto.action_sms;
                triggerName2.Action_email = driverNotificationSettingsDto.pickupDriverStartedTriggerDto.action_email;
                this.DbContext.Entry(triggerName2).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var triggerName3 = this.DbContext.mt_driver_notification_settings.Where(c => c.Trigger_name.Equals("pickup_driver_arrived")).FirstOrDefault();
                triggerName3.Mobile_push = driverNotificationSettingsDto.pickupDriverArrivedTriggerDto.mobile_push;
                triggerName3.Sms = driverNotificationSettingsDto.pickupDriverArrivedTriggerDto.sms;
                triggerName3.Email = driverNotificationSettingsDto.pickupDriverArrivedTriggerDto.email;
                triggerName3.Action_mobile = driverNotificationSettingsDto.pickupDriverArrivedTriggerDto.action_mobile;
                triggerName3.Action_sms = driverNotificationSettingsDto.pickupDriverArrivedTriggerDto.action_sms;
                triggerName3.Action_email = driverNotificationSettingsDto.pickupDriverArrivedTriggerDto.action_email;
                this.DbContext.Entry(triggerName3).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var triggerName4 = this.DbContext.mt_driver_notification_settings.Where(c => c.Trigger_name.Equals("pickup_successful")).FirstOrDefault();
                triggerName4.Mobile_push = driverNotificationSettingsDto.pickupSuccessfulTriggerDto.mobile_push;
                triggerName4.Sms = driverNotificationSettingsDto.pickupSuccessfulTriggerDto.sms;
                triggerName4.Email = driverNotificationSettingsDto.pickupSuccessfulTriggerDto.email;
                triggerName4.Action_mobile = driverNotificationSettingsDto.pickupSuccessfulTriggerDto.action_mobile;
                triggerName4.Action_sms = driverNotificationSettingsDto.pickupSuccessfulTriggerDto.action_sms;
                triggerName4.Action_email = driverNotificationSettingsDto.pickupSuccessfulTriggerDto.action_email;
                this.DbContext.Entry(triggerName4).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var triggerName5 = this.DbContext.mt_driver_notification_settings.Where(c => c.Trigger_name.Equals("pickup_failed")).FirstOrDefault();
                triggerName5.Mobile_push = driverNotificationSettingsDto.pickupFailedTriggerDto.mobile_push;
                triggerName5.Sms = driverNotificationSettingsDto.pickupFailedTriggerDto.sms;
                triggerName5.Email = driverNotificationSettingsDto.pickupFailedTriggerDto.email;
                triggerName5.Action_mobile = driverNotificationSettingsDto.pickupFailedTriggerDto.action_mobile;
                triggerName5.Action_sms = driverNotificationSettingsDto.pickupFailedTriggerDto.action_sms;
                triggerName5.Action_email = driverNotificationSettingsDto.pickupFailedTriggerDto.action_email;
                this.DbContext.Entry(triggerName5).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var triggerName6 = this.DbContext.mt_driver_notification_settings.Where(c => c.Trigger_name.Equals("pickup_notes")).FirstOrDefault();
                triggerName6.Mobile_push = driverNotificationSettingsDto.pickupNotesTriggerDto.mobile_push;
                triggerName6.Sms = driverNotificationSettingsDto.pickupNotesTriggerDto.sms;
                triggerName6.Email = driverNotificationSettingsDto.pickupNotesTriggerDto.email;
                triggerName6.Action_mobile = driverNotificationSettingsDto.pickupNotesTriggerDto.action_mobile;
                triggerName6.Action_sms = driverNotificationSettingsDto.pickupNotesTriggerDto.action_sms;
                triggerName6.Action_email = driverNotificationSettingsDto.pickupNotesTriggerDto.action_email;
                this.DbContext.Entry(triggerName6).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var triggerName7 = this.DbContext.mt_driver_notification_settings.Where(c => c.Trigger_name.Equals("pickup_photo")).FirstOrDefault();
                triggerName7.Mobile_push = driverNotificationSettingsDto.pickupPhotoTriggerDto.mobile_push;
                triggerName7.Sms = driverNotificationSettingsDto.pickupPhotoTriggerDto.sms;
                triggerName7.Email = driverNotificationSettingsDto.pickupPhotoTriggerDto.email;
                triggerName7.Action_mobile = driverNotificationSettingsDto.pickupPhotoTriggerDto.action_mobile;
                triggerName7.Action_sms = driverNotificationSettingsDto.pickupPhotoTriggerDto.action_sms;
                triggerName7.Action_email = driverNotificationSettingsDto.pickupPhotoTriggerDto.action_email;
                this.DbContext.Entry(triggerName7).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var triggerName8 = this.DbContext.mt_driver_notification_settings.Where(c => c.Trigger_name.Equals("delivery_request_received")).FirstOrDefault();
                triggerName8.Mobile_push = driverNotificationSettingsDto.deliveryRequestReceivedTriggerDto.mobile_push;
                triggerName8.Sms = driverNotificationSettingsDto.deliveryRequestReceivedTriggerDto.sms;
                triggerName8.Email = driverNotificationSettingsDto.deliveryRequestReceivedTriggerDto.email;
                triggerName8.Action_mobile = driverNotificationSettingsDto.deliveryRequestReceivedTriggerDto.action_mobile;
                triggerName8.Action_sms = driverNotificationSettingsDto.deliveryRequestReceivedTriggerDto.action_sms;
                triggerName8.Action_email = driverNotificationSettingsDto.deliveryRequestReceivedTriggerDto.action_email;
                this.DbContext.Entry(triggerName8).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var triggerName9 = this.DbContext.mt_driver_notification_settings.Where(c => c.Trigger_name.Equals("delivery_driver_started")).FirstOrDefault();
                triggerName9.Mobile_push = driverNotificationSettingsDto.deliveryDriverStartedTriggerDto.mobile_push;
                triggerName9.Sms = driverNotificationSettingsDto.deliveryDriverStartedTriggerDto.sms;
                triggerName9.Email = driverNotificationSettingsDto.deliveryDriverStartedTriggerDto.email;
                triggerName9.Action_mobile = driverNotificationSettingsDto.deliveryDriverStartedTriggerDto.action_mobile;
                triggerName9.Action_sms = driverNotificationSettingsDto.deliveryDriverStartedTriggerDto.action_sms;
                triggerName9.Action_email = driverNotificationSettingsDto.deliveryDriverStartedTriggerDto.action_email;
                this.DbContext.Entry(triggerName9).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var triggerName10 = this.DbContext.mt_driver_notification_settings.Where(c => c.Trigger_name.Equals("delivery_driver_arrived")).FirstOrDefault();
                triggerName10.Mobile_push = driverNotificationSettingsDto.deliveryDriverArrivedTriggerDto.mobile_push;
                triggerName10.Sms = driverNotificationSettingsDto.deliveryDriverArrivedTriggerDto.sms;
                triggerName10.Email = driverNotificationSettingsDto.deliveryDriverArrivedTriggerDto.email;
                triggerName10.Action_mobile = driverNotificationSettingsDto.deliveryDriverArrivedTriggerDto.action_mobile;
                triggerName10.Action_sms = driverNotificationSettingsDto.deliveryDriverArrivedTriggerDto.action_sms;
                triggerName10.Action_email = driverNotificationSettingsDto.deliveryDriverArrivedTriggerDto.action_email;
                this.DbContext.Entry(triggerName10).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var triggerName11 = this.DbContext.mt_driver_notification_settings.Where(c => c.Trigger_name.Equals("delivery_successful")).FirstOrDefault();
                triggerName11.Mobile_push = driverNotificationSettingsDto.deliverySuccessfulTriggerDto.mobile_push;
                triggerName11.Sms = driverNotificationSettingsDto.deliverySuccessfulTriggerDto.sms;
                triggerName11.Email = driverNotificationSettingsDto.deliverySuccessfulTriggerDto.email;
                triggerName11.Action_mobile = driverNotificationSettingsDto.deliverySuccessfulTriggerDto.action_mobile;
                triggerName11.Action_sms = driverNotificationSettingsDto.deliverySuccessfulTriggerDto.action_sms;
                triggerName11.Action_email = driverNotificationSettingsDto.deliverySuccessfulTriggerDto.action_email;
                this.DbContext.Entry(triggerName11).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var triggerName12 = this.DbContext.mt_driver_notification_settings.Where(c => c.Trigger_name.Equals("delivery_failed")).FirstOrDefault();
                triggerName12.Mobile_push = driverNotificationSettingsDto.deliveryFailedTriggerDto.mobile_push;
                triggerName12.Sms = driverNotificationSettingsDto.deliveryFailedTriggerDto.sms;
                triggerName12.Email = driverNotificationSettingsDto.deliveryFailedTriggerDto.email;
                triggerName12.Action_mobile = driverNotificationSettingsDto.deliveryFailedTriggerDto.action_mobile;
                triggerName12.Action_sms = driverNotificationSettingsDto.deliveryFailedTriggerDto.action_sms;
                triggerName12.Action_email = driverNotificationSettingsDto.deliveryFailedTriggerDto.action_email;
                this.DbContext.Entry(triggerName12).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var triggerName13 = this.DbContext.mt_driver_notification_settings.Where(c => c.Trigger_name.Equals("delivery_notes")).FirstOrDefault();
                triggerName13.Mobile_push = driverNotificationSettingsDto.deliveryNotesTriggerDto.mobile_push;
                triggerName13.Sms = driverNotificationSettingsDto.deliveryNotesTriggerDto.sms;
                triggerName13.Email = driverNotificationSettingsDto.deliveryNotesTriggerDto.email;
                triggerName13.Action_mobile = driverNotificationSettingsDto.deliveryNotesTriggerDto.action_mobile;
                triggerName13.Action_sms = driverNotificationSettingsDto.deliveryNotesTriggerDto.action_sms;
                triggerName13.Action_email = driverNotificationSettingsDto.deliveryNotesTriggerDto.action_email;
                this.DbContext.Entry(triggerName13).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var triggerName14 = this.DbContext.mt_driver_notification_settings.Where(c => c.Trigger_name.Equals("delivery_photo")).FirstOrDefault();
                triggerName14.Mobile_push = driverNotificationSettingsDto.deliveryPhotoTriggerDto.mobile_push;
                triggerName14.Sms = driverNotificationSettingsDto.deliveryPhotoTriggerDto.sms;
                triggerName14.Email = driverNotificationSettingsDto.deliveryPhotoTriggerDto.email;
                triggerName14.Action_mobile = driverNotificationSettingsDto.deliveryPhotoTriggerDto.action_mobile;
                triggerName14.Action_sms = driverNotificationSettingsDto.deliveryPhotoTriggerDto.action_sms;
                triggerName14.Action_email = driverNotificationSettingsDto.deliveryPhotoTriggerDto.action_email;
                this.DbContext.Entry(triggerName14).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var triggerName15 = this.DbContext.mt_driver_notification_settings.Where(c => c.Trigger_name.Equals("assign_task")).FirstOrDefault();
                triggerName15.Mobile_push = driverNotificationSettingsDto.assignTaskTriggerDto.mobile_push;
                triggerName15.Sms = driverNotificationSettingsDto.assignTaskTriggerDto.sms;
                triggerName15.Email = driverNotificationSettingsDto.assignTaskTriggerDto.email;
                triggerName15.Action_mobile = driverNotificationSettingsDto.assignTaskTriggerDto.action_mobile;
                triggerName15.Action_sms = driverNotificationSettingsDto.assignTaskTriggerDto.action_sms;
                triggerName15.Action_email = driverNotificationSettingsDto.assignTaskTriggerDto.action_email;
                this.DbContext.Entry(triggerName15).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var triggerName16 = this.DbContext.mt_driver_notification_settings.Where(c => c.Trigger_name.Equals("deleted_task")).FirstOrDefault();
                triggerName16.Mobile_push = driverNotificationSettingsDto.deletedTaskTriggerDto.mobile_push;
                triggerName16.Sms = driverNotificationSettingsDto.deletedTaskTriggerDto.sms;
                triggerName16.Email = driverNotificationSettingsDto.deletedTaskTriggerDto.email;
                triggerName16.Action_mobile = driverNotificationSettingsDto.deletedTaskTriggerDto.action_mobile;
                triggerName16.Action_sms = driverNotificationSettingsDto.deletedTaskTriggerDto.action_sms;
                triggerName16.Action_email = driverNotificationSettingsDto.deletedTaskTriggerDto.action_email;
                this.DbContext.Entry(triggerName16).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var triggerName17 = this.DbContext.mt_driver_notification_settings.Where(c => c.Trigger_name.Equals("new_added_driver")).FirstOrDefault();
                triggerName17.Mobile_push = driverNotificationSettingsDto.newAddedDriverTriggerDto.mobile_push;
                triggerName17.Sms = driverNotificationSettingsDto.newAddedDriverTriggerDto.sms;
                triggerName17.Email = driverNotificationSettingsDto.newAddedDriverTriggerDto.email;
                triggerName17.Action_mobile = driverNotificationSettingsDto.newAddedDriverTriggerDto.action_mobile;
                triggerName17.Action_sms = driverNotificationSettingsDto.newAddedDriverTriggerDto.action_sms;
                triggerName17.Action_email = driverNotificationSettingsDto.newAddedDriverTriggerDto.action_email;
                this.DbContext.Entry(triggerName17).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var triggerName18 = this.DbContext.mt_driver_notification_settings.Where(c => c.Trigger_name.Equals("new_signup_welcome")).FirstOrDefault();
                triggerName18.Mobile_push = driverNotificationSettingsDto.newSignupWelcomeTriggerDto.mobile_push;
                triggerName18.Sms = driverNotificationSettingsDto.newSignupWelcomeTriggerDto.sms;
                triggerName18.Email = driverNotificationSettingsDto.newSignupWelcomeTriggerDto.email;
                triggerName18.Action_mobile = driverNotificationSettingsDto.newSignupWelcomeTriggerDto.action_mobile;
                triggerName18.Action_sms = driverNotificationSettingsDto.newSignupWelcomeTriggerDto.action_sms;
                triggerName18.Action_email = driverNotificationSettingsDto.newSignupWelcomeTriggerDto.action_email;
                this.DbContext.Entry(triggerName18).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var triggerName19 = this.DbContext.mt_driver_notification_settings.Where(c => c.Trigger_name.Equals("signup_approved")).FirstOrDefault();
                triggerName19.Mobile_push = driverNotificationSettingsDto.signupApprovedTriggerDto.mobile_push;
                triggerName19.Sms = driverNotificationSettingsDto.signupApprovedTriggerDto.sms;
                triggerName19.Email = driverNotificationSettingsDto.signupApprovedTriggerDto.email;
                triggerName19.Action_mobile = driverNotificationSettingsDto.signupApprovedTriggerDto.action_mobile;
                triggerName19.Action_sms = driverNotificationSettingsDto.signupApprovedTriggerDto.action_sms;
                triggerName19.Action_email = driverNotificationSettingsDto.signupApprovedTriggerDto.action_email;
                this.DbContext.Entry(triggerName19).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var triggerName20 = this.DbContext.mt_driver_notification_settings.Where(c => c.Trigger_name.Equals("signup_denied")).FirstOrDefault();
                triggerName20.Mobile_push = driverNotificationSettingsDto.signupDeniedTriggerDto.mobile_push;
                triggerName20.Sms = driverNotificationSettingsDto.signupDeniedTriggerDto.sms;
                triggerName20.Email = driverNotificationSettingsDto.signupDeniedTriggerDto.email;
                triggerName20.Action_mobile = driverNotificationSettingsDto.signupDeniedTriggerDto.action_mobile;
                triggerName20.Action_sms = driverNotificationSettingsDto.signupDeniedTriggerDto.action_sms;
                triggerName20.Action_email = driverNotificationSettingsDto.signupDeniedTriggerDto.action_email;
                this.DbContext.Entry(triggerName20).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var triggerName21 = this.DbContext.mt_driver_notification_settings.Where(c => c.Trigger_name.Equals("update_task")).FirstOrDefault();
                triggerName21.Mobile_push = driverNotificationSettingsDto.updateTaskTriggerDto.mobile_push;
                triggerName21.Sms = driverNotificationSettingsDto.updateTaskTriggerDto.sms;
                triggerName21.Email = driverNotificationSettingsDto.updateTaskTriggerDto.email;
                triggerName21.Action_mobile = driverNotificationSettingsDto.updateTaskTriggerDto.action_mobile;
                triggerName21.Action_sms = driverNotificationSettingsDto.updateTaskTriggerDto.action_sms;
                triggerName21.Action_email = driverNotificationSettingsDto.updateTaskTriggerDto.action_email;
                this.DbContext.Entry(triggerName21).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var triggerName22 = this.DbContext.mt_driver_notification_settings.Where(c => c.Trigger_name.Equals("auto_assign_accepted")).FirstOrDefault();
                triggerName22.Mobile_push = driverNotificationSettingsDto.autoAssignAcceptedTriggerDto.mobile_push;
                triggerName22.Sms = driverNotificationSettingsDto.autoAssignAcceptedTriggerDto.sms;
                triggerName22.Email = driverNotificationSettingsDto.autoAssignAcceptedTriggerDto.email;
                triggerName22.Action_mobile = driverNotificationSettingsDto.autoAssignAcceptedTriggerDto.action_mobile;
                triggerName22.Action_sms = driverNotificationSettingsDto.autoAssignAcceptedTriggerDto.action_sms;
                triggerName22.Action_email = driverNotificationSettingsDto.autoAssignAcceptedTriggerDto.action_email;
                this.DbContext.Entry(triggerName22).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                var triggerName23 = this.DbContext.mt_driver_notification_settings.Where(c => c.Trigger_name.Equals("failed_auto_assign")).FirstOrDefault();
                triggerName23.Mobile_push = driverNotificationSettingsDto.failedAutoAssignTriggerDto.mobile_push;
                triggerName23.Sms = driverNotificationSettingsDto.failedAutoAssignTriggerDto.sms;
                triggerName23.Email = driverNotificationSettingsDto.failedAutoAssignTriggerDto.email;
                triggerName23.Action_mobile = driverNotificationSettingsDto.failedAutoAssignTriggerDto.action_mobile;
                triggerName23.Action_sms = driverNotificationSettingsDto.failedAutoAssignTriggerDto.action_sms;
                triggerName23.Action_email = driverNotificationSettingsDto.failedAutoAssignTriggerDto.action_email;
                this.DbContext.Entry(triggerName23).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();

                return "Hey!! Shady your Driver Notification Settings Data Updated Successfully...";

            }
            else
                return "error in updating settings. please try again";
        }

        public PickupRequestReceivedTriggerDto GetPickupRequestReceivedMessage (string settingName)
        {
            PickupRequestReceivedTriggerDto pickupRequestReceivedMessage = new PickupRequestReceivedTriggerDto();

            var pickupRequestReceivedMessageInDb = this.DbContext.mt_driver_notification_settings.Where(c => c.Trigger_name == settingName).FirstOrDefault();

            if (pickupRequestReceivedMessageInDb != null)
            {
                pickupRequestReceivedMessage.action_mobile = pickupRequestReceivedMessageInDb.Action_mobile;
                pickupRequestReceivedMessage.action_sms = pickupRequestReceivedMessageInDb.Action_sms;
                pickupRequestReceivedMessage.action_email = pickupRequestReceivedMessageInDb.Action_email;
            }
            else
                throw new ArgumentNullException();

            return pickupRequestReceivedMessage;

        }
    }
}