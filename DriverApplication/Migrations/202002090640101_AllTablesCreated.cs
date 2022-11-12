namespace DriverApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllTablesCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.mt_driver",
                c => new
                    {
                        driver_id = c.Int(nullable: false, identity: true),
                        on_duty = c.Boolean(nullable: false),
                        first_name = c.String(maxLength: 255, storeType: "nvarchar"),
                        last_name = c.String(maxLength: 255, storeType: "nvarchar"),
                        email = c.String(maxLength: 100, storeType: "nvarchar"),
                        phone = c.String(maxLength: 20, storeType: "nvarchar"),
                        username = c.String(maxLength: 100, storeType: "nvarchar"),
                        password = c.String(maxLength: 100, storeType: "nvarchar"),
                        team_id = c.Int(),
                        transport_type_id = c.String(maxLength: 50, storeType: "nvarchar"),
                        transport_description = c.String(maxLength: 255, storeType: "nvarchar"),
                        licence_plate = c.String(maxLength: 255, storeType: "nvarchar"),
                        color = c.String(maxLength: 255, storeType: "nvarchar"),
                        status = c.String(maxLength: 255, storeType: "nvarchar"),
                        last_login = c.DateTime(storeType: "date"),
                        last_login_timestamp = c.Time(nullable: false, precision: 0),
                        last_online = c.Int(nullable: false),
                        location_address = c.String(unicode: false),
                        location_lat = c.String(maxLength: 50, storeType: "nvarchar"),
                        location_lng = c.String(maxLength: 50, storeType: "nvarchar"),
                        forgot_pass_code = c.String(maxLength: 10, storeType: "nvarchar"),
                        token = c.String(maxLength: 255, storeType: "nvarchar"),
                        device_id = c.String(unicode: false),
                        device_platform = c.String(maxLength: 50, storeType: "nvarchar"),
                        enabled_push = c.Boolean(nullable: false),
                        profile_photo = c.String(maxLength: 255, storeType: "nvarchar"),
                        is_signup = c.Int(nullable: false),
                        app_version = c.String(maxLength: 14, storeType: "nvarchar"),
                        last_onduty = c.String(maxLength: 50, storeType: "nvarchar"),
                        date_created = c.DateTime(storeType: "date"),
                        created_timestamp = c.Time(nullable: false, precision: 0),
                        date_modified = c.DateTime(storeType: "date"),
                        modified_timestamp = c.Time(nullable: false, precision: 0),
                        user_type = c.String(maxLength: 50, storeType: "nvarchar"),
                        user_id = c.Int(nullable: false),
                        ip_address = c.String(maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.driver_id)
                .ForeignKey("dbo.mt_driver_team", t => t.team_id)
                .Index(t => t.team_id);
            
            CreateTable(
                "dbo.mt_driver_assignment",
                c => new
                    {
                        assignment_id = c.Int(nullable: false, identity: true),
                        automatic_assign_type = c.Boolean(nullable: false),
                        first_name = c.String(maxLength: 255, storeType: "nvarchar"),
                        last_name = c.String(maxLength: 255, storeType: "nvarchar"),
                        status = c.String(maxLength: 100, storeType: "nvarchar"),
                        task_status = c.String(maxLength: 255, storeType: "nvarchar"),
                        date_created = c.DateTime(storeType: "date"),
                        created_timestamp = c.Time(nullable: false, precision: 0),
                        date_process = c.DateTime(storeType: "date"),
                        process_timestamp = c.Time(nullable: false, precision: 0),
                        ip_address = c.String(maxLength: 50, storeType: "nvarchar"),
                        driver_id = c.Int(nullable: false),
                        task_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.assignment_id)
                .ForeignKey("dbo.mt_driver", t => t.driver_id)
                .ForeignKey("dbo.mt_driver_task", t => t.task_id)
                .Index(t => t.driver_id)
                .Index(t => t.task_id);
            
            CreateTable(
                "dbo.mt_driver_task",
                c => new
                    {
                        task_id = c.Int(nullable: false, identity: true),
                        task_description = c.String(maxLength: 255, storeType: "nvarchar"),
                        trans_type = c.String(maxLength: 255, storeType: "nvarchar"),
                        contact_number = c.String(maxLength: 50, storeType: "nvarchar"),
                        email_address = c.String(maxLength: 200, storeType: "nvarchar"),
                        customer_name = c.String(maxLength: 255, storeType: "nvarchar"),
                        delivery_date = c.DateTime(storeType: "date"),
                        delivery_date_timestamp = c.Time(nullable: false, precision: 0),
                        delivery_address = c.String(maxLength: 255, storeType: "nvarchar"),
                        team_id = c.Int(),
                        driver_id = c.Int(),
                        task_lat = c.String(maxLength: 50, storeType: "nvarchar"),
                        task_lng = c.String(maxLength: 50, storeType: "nvarchar"),
                        customer_signature = c.String(maxLength: 255, storeType: "nvarchar"),
                        status = c.String(maxLength: 255, storeType: "nvarchar"),
                        auto_assign_type = c.String(maxLength: 255, storeType: "nvarchar"),
                        assign_started = c.DateTime(storeType: "date"),
                        assign_started_timestamp = c.Time(nullable: false, precision: 0),
                        assignment_status = c.String(maxLength: 255, storeType: "nvarchar"),
                        dropoff_merchant = c.Int(nullable: false),
                        dropoff_contact_name = c.String(maxLength: 255, storeType: "nvarchar"),
                        dropoff_contact_number = c.String(maxLength: 20, storeType: "nvarchar"),
                        drop_address = c.String(maxLength: 255, storeType: "nvarchar"),
                        dropoff_lat = c.String(maxLength: 30, storeType: "nvarchar"),
                        dropoff_lng = c.String(maxLength: 30, storeType: "nvarchar"),
                        recipient_name = c.String(maxLength: 255, storeType: "nvarchar"),
                        critical = c.Int(nullable: false),
                        date_created = c.DateTime(storeType: "date"),
                        created_timestamp = c.Time(nullable: false, precision: 0),
                        date_modified = c.DateTime(storeType: "date"),
                        modified_timestamp = c.Time(nullable: false, precision: 0),
                        user_type = c.String(maxLength: 50, storeType: "nvarchar"),
                        user_id = c.Int(nullable: false),
                        ip_address = c.String(maxLength: 50, storeType: "nvarchar"),
                        order_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.task_id)
                .ForeignKey("dbo.mt_driver", t => t.driver_id)
                .ForeignKey("dbo.mt_driver_team", t => t.team_id)
                .ForeignKey("dbo.mt_order", t => t.order_id)
                .Index(t => t.team_id)
                .Index(t => t.driver_id)
                .Index(t => t.order_id);
            
            CreateTable(
                "dbo.mt_driver_team",
                c => new
                    {
                        team_id = c.Int(nullable: false, identity: true),
                        team_name = c.String(maxLength: 255, storeType: "nvarchar"),
                        location_accuracy = c.String(maxLength: 50, storeType: "nvarchar"),
                        status = c.String(maxLength: 255, storeType: "nvarchar"),
                        date_created = c.DateTime(storeType: "date"),
                        created_timestamp = c.Time(nullable: false, precision: 0),
                        date_modified = c.DateTime(storeType: "date"),
                        modified_timestamp = c.Time(nullable: false, precision: 0),
                        user_type = c.String(maxLength: 50, storeType: "nvarchar"),
                        user_id = c.Int(nullable: false),
                        ip_address = c.String(maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.team_id);
            
            CreateTable(
                "dbo.mt_driver_bulk_push",
                c => new
                    {
                        bulk_id = c.Int(nullable: false, identity: true),
                        push_title = c.String(maxLength: 255, storeType: "nvarchar"),
                        push_message = c.String(unicode: false),
                        status = c.String(maxLength: 255, storeType: "nvarchar"),
                        date_created = c.DateTime(storeType: "date"),
                        created_timestamp = c.Time(nullable: false, precision: 0),
                        date_process = c.DateTime(storeType: "date"),
                        process_timestamp = c.Time(nullable: false, precision: 0),
                        ip_address = c.String(maxLength: 50, storeType: "nvarchar"),
                        team_id = c.Int(nullable: false),
                        user_type = c.String(maxLength: 50, storeType: "nvarchar"),
                        user_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.bulk_id)
                .ForeignKey("dbo.mt_driver_team", t => t.team_id, cascadeDelete: true)
                .Index(t => t.team_id);
            
            CreateTable(
                "dbo.mt_driver_pushlog",
                c => new
                    {
                        push_id = c.Int(nullable: false, identity: true),
                        device_platform = c.String(maxLength: 50, storeType: "nvarchar"),
                        device_id = c.String(maxLength: 255, storeType: "nvarchar"),
                        push_title = c.String(maxLength: 255, storeType: "nvarchar"),
                        push_message = c.String(maxLength: 255, storeType: "nvarchar"),
                        push_type = c.String(maxLength: 50, storeType: "nvarchar"),
                        actions = c.String(maxLength: 255, storeType: "nvarchar"),
                        status = c.String(maxLength: 255, storeType: "nvarchar"),
                        json_response = c.String(maxLength: 255, storeType: "nvarchar"),
                        order_id = c.Int(),
                        driver_id = c.Int(),
                        task_id = c.Int(),
                        date_created = c.DateTime(storeType: "date"),
                        created_timestamp = c.Time(nullable: false, precision: 0),
                        date_process = c.DateTime(storeType: "date"),
                        process_timestamp = c.Time(nullable: false, precision: 0),
                        ip_address = c.String(maxLength: 50, storeType: "nvarchar"),
                        is_read = c.Int(nullable: false),
                        bulk_id = c.Int(nullable: false),
                        user_type = c.String(maxLength: 50, storeType: "nvarchar"),
                        user_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.push_id)
                .ForeignKey("dbo.mt_driver_bulk_push", t => t.bulk_id, cascadeDelete: true)
                .ForeignKey("dbo.mt_driver", t => t.driver_id)
                .ForeignKey("dbo.mt_driver_task", t => t.task_id)
                .ForeignKey("dbo.mt_order", t => t.order_id)
                .Index(t => t.order_id)
                .Index(t => t.driver_id)
                .Index(t => t.task_id)
                .Index(t => t.bulk_id);
            
            CreateTable(
                "dbo.mt_order",
                c => new
                    {
                        Order_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Order_id);
            
            CreateTable(
                "dbo.mt_driver_track_location",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        user_type = c.String(maxLength: 50, storeType: "nvarchar"),
                        user_id = c.Int(nullable: false),
                        driver_id = c.Int(),
                        latitude = c.String(maxLength: 50, storeType: "nvarchar"),
                        longitude = c.String(maxLength: 50, storeType: "nvarchar"),
                        altitude = c.String(maxLength: 50, storeType: "nvarchar"),
                        accuracy = c.String(maxLength: 50, storeType: "nvarchar"),
                        altitudeAccuracy = c.String(maxLength: 50, storeType: "nvarchar"),
                        heading = c.String(maxLength: 50, storeType: "nvarchar"),
                        speed = c.String(maxLength: 50, storeType: "nvarchar"),
                        date_created = c.DateTime(storeType: "date"),
                        created_timestamp = c.Time(nullable: false, precision: 0),
                        ip_address = c.String(maxLength: 50, storeType: "nvarchar"),
                        track_type = c.String(maxLength: 100, storeType: "nvarchar"),
                        device_platform = c.String(maxLength: 50, storeType: "nvarchar"),
                        date_log = c.DateTime(storeType: "date"),
                        date_log_timestamp = c.Time(nullable: false, precision: 0),
                        full_request = c.String(maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.mt_driver", t => t.driver_id)
                .Index(t => t.driver_id);
            
            CreateTable(
                "dbo.mt_driver_assignment_settings",
                c => new
                    {
                        option_id = c.Int(nullable: false, identity: true),
                        merchant_id = c.Int(nullable: false),
                        option_name = c.String(maxLength: 255, storeType: "nvarchar"),
                        option_value = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.option_id);
            
            CreateTable(
                "dbo.mt_driver_general_settings",
                c => new
                    {
                        general_id = c.Int(nullable: false, identity: true),
                        option_name = c.String(maxLength: 255, storeType: "nvarchar"),
                        option_value = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.general_id);
            
            CreateTable(
                "dbo.mt_driver_map_settings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        default_map_country = c.String(maxLength: 255, storeType: "nvarchar"),
                        disable_activity_tracking = c.String(maxLength: 255, storeType: "nvarchar"),
                        activity_refresh_interval = c.String(maxLength: 255, storeType: "nvarchar"),
                        driver_activity_refresh = c.String(maxLength: 255, storeType: "nvarchar"),
                        auto_geocode_address = c.String(maxLength: 255, storeType: "nvarchar"),
                        include_offline_driver_map = c.String(maxLength: 255, storeType: "nvarchar"),
                        hide_pickup_task = c.String(maxLength: 255, storeType: "nvarchar"),
                        hide_delivery_task = c.String(maxLength: 255, storeType: "nvarchar"),
                        hide_successful_task = c.String(maxLength: 255, storeType: "nvarchar"),
                        google_map_style = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.mt_driver_mapapikey_settings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        map_provider = c.String(maxLength: 255, storeType: "nvarchar"),
                        google_api_key = c.String(maxLength: 255, storeType: "nvarchar"),
                        enabled_curl = c.String(maxLength: 255, storeType: "nvarchar"),
                        mapbox_access_token = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.mt_driver_mapsapicall",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        map_provider = c.String(maxLength: 100, storeType: "nvarchar"),
                        api_functions = c.String(maxLength: 255, storeType: "nvarchar"),
                        api_response = c.String(maxLength: 255, storeType: "nvarchar"),
                        date_created = c.DateTime(storeType: "date"),
                        created_timestamp = c.Time(nullable: false, precision: 0),
                        date_call = c.DateTime(storeType: "date"),
                        date_call_timestamp = c.Time(nullable: false, precision: 0),
                        ip_address = c.String(maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.mt_driver_notification_settings",
                c => new
                    {
                        notification_id = c.Int(nullable: false, identity: true),
                        trigger_name = c.String(maxLength: 255, storeType: "nvarchar"),
                        mobile_push = c.String(maxLength: 255, storeType: "nvarchar"),
                        sms = c.String(maxLength: 255, storeType: "nvarchar"),
                        email = c.String(maxLength: 255, storeType: "nvarchar"),
                        action_mobile = c.String(maxLength: 255, storeType: "nvarchar"),
                        action_sms = c.String(maxLength: 255, storeType: "nvarchar"),
                        action_email = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.notification_id);
            
            CreateTable(
                "dbo.mt_driver_push_legacy_settings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        legacy_server_key = c.String(maxLength: 255, storeType: "nvarchar"),
                        ios_push_mode = c.String(maxLength: 255, storeType: "nvarchar"),
                        ios_push_certificate_passphrase = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.mt_driver_sms_logs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        user_type = c.String(maxLength: 50, storeType: "nvarchar"),
                        user_id = c.Int(nullable: false),
                        contact_phone = c.String(maxLength: 50, storeType: "nvarchar"),
                        sms_message = c.String(maxLength: 255, storeType: "nvarchar"),
                        status = c.String(maxLength: 255, storeType: "nvarchar"),
                        gateway_response = c.String(maxLength: 255, storeType: "nvarchar"),
                        gateway = c.String(maxLength: 100, storeType: "nvarchar"),
                        date_created = c.DateTime(storeType: "date"),
                        created_timestamp = c.Time(nullable: false, precision: 0),
                        ip_address = c.String(maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.mt_driver_task_photo",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        task_id = c.Int(),
                        photo_name = c.String(maxLength: 255, storeType: "nvarchar"),
                        date_created = c.DateTime(storeType: "date"),
                        created_timestamp = c.Time(nullable: false, precision: 0),
                        ip_address = c.String(maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.mt_driver_task", t => t.task_id)
                .Index(t => t.task_id);
            
            CreateTable(
                "dbo.mt_email_log",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        email_address = c.String(unicode: false),
                        sender = c.String(unicode: false),
                        subject = c.String(unicode: false),
                        content = c.String(unicode: false),
                        status = c.String(unicode: false),
                        date_created = c.DateTime(precision: 0),
                        Created_time_stamp = c.Time(nullable: false, precision: 0),
                        ip_address = c.String(unicode: false),
                        module_type = c.String(unicode: false),
                        user_type = c.String(unicode: false),
                        user_id = c.Int(nullable: false),
                        merchant_id = c.Int(nullable: false),
                        email_provider = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.mt_driver_task_photo", "task_id", "dbo.mt_driver_task");
            DropForeignKey("dbo.mt_driver_track_location", "driver_id", "dbo.mt_driver");
            DropForeignKey("dbo.mt_driver", "team_id", "dbo.mt_driver_team");
            DropForeignKey("dbo.mt_driver_assignment", "task_id", "dbo.mt_driver_task");
            DropForeignKey("dbo.mt_driver_task", "order_id", "dbo.mt_order");
            DropForeignKey("dbo.mt_driver_task", "team_id", "dbo.mt_driver_team");
            DropForeignKey("dbo.mt_driver_pushlog", "order_id", "dbo.mt_order");
            DropForeignKey("dbo.mt_driver_pushlog", "task_id", "dbo.mt_driver_task");
            DropForeignKey("dbo.mt_driver_pushlog", "driver_id", "dbo.mt_driver");
            DropForeignKey("dbo.mt_driver_pushlog", "bulk_id", "dbo.mt_driver_bulk_push");
            DropForeignKey("dbo.mt_driver_bulk_push", "team_id", "dbo.mt_driver_team");
            DropForeignKey("dbo.mt_driver_task", "driver_id", "dbo.mt_driver");
            DropForeignKey("dbo.mt_driver_assignment", "driver_id", "dbo.mt_driver");
            DropIndex("dbo.mt_driver_task_photo", new[] { "task_id" });
            DropIndex("dbo.mt_driver_track_location", new[] { "driver_id" });
            DropIndex("dbo.mt_driver_pushlog", new[] { "bulk_id" });
            DropIndex("dbo.mt_driver_pushlog", new[] { "task_id" });
            DropIndex("dbo.mt_driver_pushlog", new[] { "driver_id" });
            DropIndex("dbo.mt_driver_pushlog", new[] { "order_id" });
            DropIndex("dbo.mt_driver_bulk_push", new[] { "team_id" });
            DropIndex("dbo.mt_driver_task", new[] { "order_id" });
            DropIndex("dbo.mt_driver_task", new[] { "driver_id" });
            DropIndex("dbo.mt_driver_task", new[] { "team_id" });
            DropIndex("dbo.mt_driver_assignment", new[] { "task_id" });
            DropIndex("dbo.mt_driver_assignment", new[] { "driver_id" });
            DropIndex("dbo.mt_driver", new[] { "team_id" });
            DropTable("dbo.mt_email_log");
            DropTable("dbo.mt_driver_task_photo");
            DropTable("dbo.mt_driver_sms_logs");
            DropTable("dbo.mt_driver_push_legacy_settings");
            DropTable("dbo.mt_driver_notification_settings");
            DropTable("dbo.mt_driver_mapsapicall");
            DropTable("dbo.mt_driver_mapapikey_settings");
            DropTable("dbo.mt_driver_map_settings");
            DropTable("dbo.mt_driver_general_settings");
            DropTable("dbo.mt_driver_assignment_settings");
            DropTable("dbo.mt_driver_track_location");
            DropTable("dbo.mt_order");
            DropTable("dbo.mt_driver_pushlog");
            DropTable("dbo.mt_driver_bulk_push");
            DropTable("dbo.mt_driver_team");
            DropTable("dbo.mt_driver_task");
            DropTable("dbo.mt_driver_assignment");
            DropTable("dbo.mt_driver");
        }
    }
}
