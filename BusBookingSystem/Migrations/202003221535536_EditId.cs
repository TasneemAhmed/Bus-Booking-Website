namespace BusBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Drivers");
            DropPrimaryKey("dbo.Users");
            AddColumn("dbo.Drivers", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Drivers", "Id");
            AddPrimaryKey("dbo.Users", "Id");
            DropColumn("dbo.Drivers", "PersonId");
            DropColumn("dbo.Users", "PersonId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "PersonId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Drivers", "PersonId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Drivers");
            DropColumn("dbo.Users", "Id");
            DropColumn("dbo.Drivers", "Id");
            AddPrimaryKey("dbo.Users", "PersonId");
            AddPrimaryKey("dbo.Drivers", "PersonId");
        }
    }
}
