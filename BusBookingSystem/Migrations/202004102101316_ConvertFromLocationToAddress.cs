namespace BusBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConvertFromLocationToAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Address", c => c.String(nullable: false));
            DropColumn("dbo.Drivers", "Location");
            DropColumn("dbo.Users", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Location", c => c.String(nullable: false));
            AddColumn("dbo.Drivers", "Location", c => c.String(nullable: false));
            DropColumn("dbo.Users", "Address");
            DropColumn("dbo.Drivers", "Address");
        }
    }
}
