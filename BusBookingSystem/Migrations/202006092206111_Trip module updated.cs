namespace BusBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tripmoduleupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buses", "image", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buses", "image");
        }
    }
}
