namespace BusBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocationToPersonInsteadOfAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "Location", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Location", c => c.String(nullable: false));
            DropColumn("dbo.Drivers", "Address");
            DropColumn("dbo.Users", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Address", c => c.String(nullable: false));
            AddColumn("dbo.Drivers", "Address", c => c.String(nullable: false));
            DropColumn("dbo.Users", "Location");
            DropColumn("dbo.Drivers", "Location");
        }
    }
}
