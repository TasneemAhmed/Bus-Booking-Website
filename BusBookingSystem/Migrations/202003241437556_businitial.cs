namespace BusBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class businitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        MLicensePlateNo = c.String(nullable: false, maxLength: 5),
                        MBusCapacity = c.Int(nullable: false),
                        MBusType = c.String(nullable: false),
                        Driverid_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Drivers", t => t.Driverid_Id)
                .Index(t => t.Driverid_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Buses", "Driverid_Id", "dbo.Drivers");
            DropIndex("dbo.Buses", new[] { "Driverid_Id" });
            DropTable("dbo.Buses");
        }
    }
}
