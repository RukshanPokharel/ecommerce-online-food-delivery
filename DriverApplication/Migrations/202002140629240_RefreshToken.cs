namespace DriverApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefreshToken : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.mt_driver_refresh_token",
                c => new
                    {
                        refresh_id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        subject = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        client_id = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        issued_utc = c.DateTime(nullable: false, precision: 0),
                        expires_utc = c.DateTime(nullable: false, precision: 0),
                        protected_ticket = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.refresh_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.mt_driver_refresh_token");
        }
    }
}
