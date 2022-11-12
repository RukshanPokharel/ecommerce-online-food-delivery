using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverApplication.DTOs.DriverSettings
{
    public class DriverPushLegacySettingsDto
    {
        private string legacy_server_key;
        public string Legacy_server_key { get => legacy_server_key; set => legacy_server_key = value; }

        private string ios_push_mode;
        public string Ios_push_mode { get => ios_push_mode; set => ios_push_mode = value; }

        private string ios_push_certificate_passphrase;
        public string Ios_push_certificate_passphrase { get => ios_push_certificate_passphrase; set => ios_push_certificate_passphrase = value; }

    }
}