using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.DTOs
{
    public class DriverAssignmentSettingsDto
    {
        public string enabled_auto_assign;
        public string include_offline_driver;
        public string autoassign_notify_email;
        public string request_expire;
        public string auto_assign_retry;
        public string driver_auto_assign_type;
        public string assign_request_expire;
        public string within_radius;
        public string within_radius_unit;

    }
}