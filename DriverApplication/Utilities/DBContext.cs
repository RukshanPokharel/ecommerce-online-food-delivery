using DriverApplication.Mapping;
using DriverApplication.Mapping.EmailLogs;
using DriverApplication.Models;
using DriverApplication.Models.EmailLogs;
using DriverApplication.Models.RefreshToken;
using DriverApplication.Models.Settings;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DriverApplication.Utilities

{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DBContext : DbContext
    {
        public DBContext() : base("DBContext") { }

        public DbSet<Driver> mt_driver { get; set; }
        public DbSet<DriverTeam> mt_driver_team { get; set; }
        public DbSet<DriverTask> mt_driver_task { get; set; }
        public DbSet<DriverAssignment> mt_driver_assignment { get; set; }
        public DbSet<PushLog> mt_driver_pushlog { get; set; }
        public DbSet<BulkPush> mt_driver_bulk_push { get; set; }
        public DbSet<MapsApiCall> mt_driver_mapsapicall { get; set; }
        public DbSet<SmsLogs> mt_driver_sms_logs { get; set; }
        public DbSet<TaskPhoto> mt_driver_task_photo { get; set; }
        public DbSet<TrackLocation> mt_driver_track_location { get; set; }

        public DbSet<Order> mt_order { get; set; }
        public DbSet<EmailLogEntity> mt_email_log { get; set; }

        public DbSet<DriverAssignmentSettings> mt_driver_assignment_settings { get; set; }
        public DbSet<DriverNotificationSettings> mt_driver_notification_settings { get; set; }
        public DbSet<DriverGeneralSettings> mt_driver_general_settings { get; set; }
        public DbSet<DriverMapApiKeysSettings> mt_driver_mapapikey_settings { get; set; }
        public DbSet<DriverMapSettings> mt_driver_map_settings { get; set; }
        public DbSet<DriverPushLegacySettings> mt_driver_push_legacy_settings { get; set; }

        public DbSet<RefreshTokenEntity> mt_driver_refresh_token { get; set; }


        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>().ToTable("mt_driver");         //changing table name in database using fluentAPI
            modelBuilder.Entity<DriverTeam>().ToTable("mt_driver_team");
            modelBuilder.Entity<DriverTask>().ToTable("mt_driver_task");
            modelBuilder.Entity<DriverAssignment>().ToTable("mt_driver_assignment");
            modelBuilder.Entity<PushLog>().ToTable("mt_driver_pushlog");
            modelBuilder.Entity<BulkPush>().ToTable("mt_driver_bulk_push");
            modelBuilder.Entity<MapsApiCall>().ToTable("mt_driver_mapsapicall");
            modelBuilder.Entity<SmsLogs>().ToTable("mt_driver_sms_logs");
            modelBuilder.Entity<TaskPhoto>().ToTable("mt_driver_task_photo");
            modelBuilder.Entity<TrackLocation>().ToTable("mt_driver_track_location");
            modelBuilder.Entity<DriverAssignmentSettings>().ToTable("mt_driver_assignment_settings");
            modelBuilder.Entity<DriverNotificationSettings>().ToTable("mt_driver_notification_settings");
            modelBuilder.Entity<DriverGeneralSettings>().ToTable("mt_driver_general_settings");
            modelBuilder.Entity<DriverMapApiKeysSettings>().ToTable("mt_driver_mapapikey_settings");
            modelBuilder.Entity<DriverMapSettings>().ToTable("mt_driver_map_settings");
            modelBuilder.Entity<DriverPushLegacySettings>().ToTable("mt_driver_push_legacy_settings");
            modelBuilder.Entity<RefreshTokenEntity>().ToTable("mt_driver_refresh_token");

            modelBuilder.Configurations.Add(new OrderMapping());
            modelBuilder.Configurations.Add(new EmailLogsMapping());
            //-------//
            //adding foreign key through fluentAPI
            modelBuilder.Entity<Driver>()
                        .HasOptional<DriverTeam>(d => d.DriverTeam1)
                        .WithMany(dt => dt.Drivers)
                        .HasForeignKey(conf => conf.Team_id);
                //.WillCascadeOnDelete(false);   // specifiing cascade to false for this foreign key...

            // Configure DriverTask & Order entity
            modelBuilder.Entity<DriverTask>()
                        .HasRequired(s => s.Order1) // Mark Order property as must required in DriverTask entity. Cannot save driverTask without order.
                        .WithOptional(ad => ad.DriverTask1) // mark DriverTask property as optional in Order entity. Can save Order without DriverTask
                        .Map(t=>t.MapKey("order_id"));

             modelBuilder.Entity<DriverAssignment>()
                        .HasRequired(s => s.Driver1) 
                        .WithOptional(ad => ad.DriverAssignment1) 
                        .Map(t=>t.MapKey("driver_id"));

             modelBuilder.Entity<DriverAssignment>()
                        .HasRequired(s => s.DriverTask1) 
                        .WithOptional(ad => ad.DriverAssignment1) 
                        .Map(t=>t.MapKey("task_id"));

            modelBuilder.Entity<DriverTask>()
                        .HasOptional(s => s.DriverTeam1) 
                        .WithMany(ad => ad.DriverTask1) 
                        .HasForeignKey(conf => conf.Team_id);
                        
            modelBuilder.Entity<DriverTask>()
                        .HasOptional(s => s.Driver1) 
                        .WithMany(ad => ad.DriverTask1)
                        .HasForeignKey(conf => conf.Driver_id);

            modelBuilder.Entity<BulkPush>()
                        .HasRequired(s => s.DriverTeam1)
                        .WithMany(ad => ad.BulkPush1)
                        .HasForeignKey(conf => conf.Team_id);

            modelBuilder.Entity<PushLog>()
                        .HasOptional(s => s.Driver1)
                        .WithMany(ad => ad.PushLog1)
                        .HasForeignKey(conf => conf.Driver_id);

            modelBuilder.Entity<PushLog>()
                        .HasRequired(s => s.BulkPush1)
                        .WithMany(ad => ad.PushLog1)
                        .HasForeignKey(conf => conf.Bulk_id);

              modelBuilder.Entity<PushLog>()
                        .HasOptional(s => s.DriverTask1)
                        .WithMany(ad => ad.PushLog1)
                        .HasForeignKey(conf => conf.Task_id);

              modelBuilder.Entity<PushLog>()
                        .HasOptional(s => s.Order1)
                        .WithMany(ad => ad.PushLog1)
                        .HasForeignKey(conf => conf.Order_id);

            modelBuilder.Entity<TrackLocation>()
                        .HasOptional(s => s.Driver1)
                        .WithMany(ad => ad.TrackLocation1)
                        .HasForeignKey(conf => conf.Driver_id);



            //--------//

            // By default entity framework sets the action for foreign key relationships to cascade
            // to set the cascading referential integrity constraint to No action while deleting do the following..

            //foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
            //                                             .SelectMany(e => e.GetForeignKeys()))
            //{
            //    foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            //}

            // --------// 


        }
    }
}