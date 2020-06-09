namespace BusBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationbetweenTripmoduleandBusmodulev2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Trips", "Id", "dbo.Buses");
            DropIndex("dbo.Trips", new[] { "Id" });
            AddColumn("dbo.Trips", "licensePlateNo", c => c.String());
            AddColumn("dbo.Trips", "Bus_id", c => c.Int());
            CreateIndex("dbo.Trips", "Bus_id");
            AddForeignKey("dbo.Trips", "Bus_id", "dbo.Buses", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trips", "Bus_id", "dbo.Buses");
            DropIndex("dbo.Trips", new[] { "Bus_id" });
            DropColumn("dbo.Trips", "Bus_id");
            DropColumn("dbo.Trips", "licensePlateNo");
            CreateIndex("dbo.Trips", "Id");
            AddForeignKey("dbo.Trips", "Id", "dbo.Buses", "id");
        }
    }
}
