namespace BusBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BusandTriprelationupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trips", "licensePlateNo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trips", "licensePlateNo", c => c.String());
        }
    }
}
