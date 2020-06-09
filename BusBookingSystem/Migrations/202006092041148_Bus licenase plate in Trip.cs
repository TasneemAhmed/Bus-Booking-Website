namespace BusBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuslicenaseplateinTrip : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Trips", name: "Bid", newName: "Bus_id");
            RenameIndex(table: "dbo.Trips", name: "IX_Bid", newName: "IX_Bus_id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Trips", name: "IX_Bus_id", newName: "IX_Bid");
            RenameColumn(table: "dbo.Trips", name: "Bus_id", newName: "Bid");
        }
    }
}
