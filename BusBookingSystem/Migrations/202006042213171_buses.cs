namespace BusBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class buses : DbMigration
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
                        Did = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Drivers", t => t.Did)
                .Index(t => t.Did);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Buses", "Did", "dbo.Drivers");
            DropIndex("dbo.Buses", new[] { "Did" });
            DropTable("dbo.Buses");
        }
    }
}
