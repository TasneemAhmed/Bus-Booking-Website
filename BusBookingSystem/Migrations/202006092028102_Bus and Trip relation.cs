namespace BusBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BusandTriprelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trips", "licensePlateNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trips", "licensePlateNo");
        }
    }
}
