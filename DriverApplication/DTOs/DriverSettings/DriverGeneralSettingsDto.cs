using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.DTOs.DriverSettings
{
    public class DriverGeneralSettingsDto
    {
        public string website_title;
        public string mobile_api_url;
        public string api_hash_key;

        public string language;
        public string app_default_language;

        public string allow_admin_by_merchant;
        public string allow_merchant_useby_admin;
        public string choose_merchant;

        public string task_owner;
        public string merchant_task_owner_to_admin;
        public string show_only_admin_task;
        public string allow_merchant_delete_task;
        public string days_to_delete_task;
        public string block_merchant;

        public string order_status_accepted;
        public string order_status_cancel;
        public string delivery_time;
        public string hide_total_order_amount;

        public string app_name; 
        public string send_push_to_online_driver; 
        public string enable_notes; 
        public string enable_signature; 
        public string mandatory_signature; 
        public string enabled_signup; 
        public string enable_take_picture; 
        public string enable_resize_picture; 
        public string resize_picture_width; 
        public string resize_picture_height; 
        public string device_vibration;

        public string signup_status;
        public string signup_send_notification_email;

        public string localize_calender_language;

        public string driver_tracking_option;
        public string records_driver_location;
        public string disable_background_tracking;
        public string track_interval;

        public string task_critical_option_enable;
        public string minutes;




        


    }
}