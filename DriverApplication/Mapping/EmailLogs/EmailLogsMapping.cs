using DriverApplication.Models.EmailLogs;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DriverApplication.Mapping.EmailLogs
{
    public class EmailLogsMapping : EntityTypeConfiguration<EmailLogEntity>
    {
        public EmailLogsMapping()
        {
            //Primary Key
            this.HasKey(t => t.Id);
            //Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            this.ToTable("mt_email_log");
            this.Property(t => t.Email_address).HasColumnName("email_address");
            this.Property(t => t.Sender).HasColumnName("sender");
            this.Property(t => t.Subject).HasColumnName("subject");
            this.Property(t => t.Content).HasColumnName("content");
            this.Property(t => t.Status).HasColumnName("status");
            this.Property(t => t.Date_created).HasColumnName("date_created");
            this.Property(t => t.Ip_address).HasColumnName("ip_address");
            this.Property(t => t.Module_type).HasColumnName("module_type");
            this.Property(t => t.User_type).HasColumnName("user_type");
            this.Property(t => t.User_id).HasColumnName("user_id");
            this.Property(t => t.Merchant_id).HasColumnName("merchant_id");
            this.Property(t => t.Email_provider).HasColumnName("email_provider");
            
        }
    }
}