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
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Buses");
        }
    }
}
