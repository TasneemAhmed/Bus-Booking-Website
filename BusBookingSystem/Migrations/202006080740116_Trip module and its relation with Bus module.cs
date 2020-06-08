namespace BusBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TripmoduleanditsrelationwithBusmodule : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        tripStart = c.String(nullable: false),
                        tripDestination = c.String(nullable: false),
                        price = c.Int(nullable: false),
                        time = c.String(nullable: false),
                        date = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buses", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trips", "Id", "dbo.Buses");
            DropIndex("dbo.Trips", new[] { "Id" });
            DropTable("dbo.Trips");
        }
    }
}
