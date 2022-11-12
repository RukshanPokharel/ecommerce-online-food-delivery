using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DriverApplication.Models.RefreshToken
{
    public class RefreshTokenEntity
    {
        private string id;
        [Column("refresh_id")]
        [Key]
        public string Id { get => id; set => id = value; }

        private string subject;
        [Column("subject")]
        [Required]
        [StringLength(50)]
        public string Subject1 { get => subject; set => subject = value; }

        private string clientId;
        [Column("client_id")]
        [Required]
        [StringLength(50)]
        public string ClientId1 { get => clientId; set => clientId = value; }

        private DateTime issuedUtc;
        [Column("issued_utc")]
        public DateTime IssuedUtc1 { get => issuedUtc; set => issuedUtc = value; }

        private DateTime expiresUtc;
        [Column("expires_utc")]
        public DateTime ExpiresUtc1 { get => expiresUtc; set => expiresUtc = value; }

        private string protectedTicket;
        [Column("protected_ticket")]
        [Required]
        public string ProtectedTicket1 { get => protectedTicket; set => protectedTicket = value; }

    }
}