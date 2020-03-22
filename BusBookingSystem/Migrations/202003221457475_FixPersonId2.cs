namespace BusBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixPersonId2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Drivers");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Drivers", "PersonId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Users", "PersonId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Drivers", "PersonId");
            AddPrimaryKey("dbo.Users", "PersonId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Drivers");
            AlterColumn("dbo.Users", "PersonId", c => c.Int(nullable: false));
            AlterColumn("dbo.Drivers", "PersonId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Users", "PersonId");
            AddPrimaryKey("dbo.Drivers", "PersonId");
        }
    }
}
