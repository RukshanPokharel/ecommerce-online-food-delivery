using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DriverApplication.Models.Settings
{
    public class DriverPushLegacySettings
    {
        private int id;
        [Column("id")]
        [Key]
        public int Id { get => id; set => id = value; }

        private string legacy_server_key;
        [Column("legacy_server_key")]
        [StringLength(255)]
        public string Legacy_server_key { get => legacy_server_key; set => legacy_server_key = value; }

        private string ios_push_mode;
        [Column("ios_push_mode")]
        [StringLength(255)]
        public string Ios_push_mode { get => ios_push_mode; set => ios_push_mode = value; }

        private string ios_push_certificate_passphrase;
        [Column("ios_push_certificate_passphrase")]
        [StringLength(255)]
        public string Ios_push_certificate_passphrase { get => ios_push_certificate_passphrase; set => ios_push_certificate_passphrase = value; }

    }
}