namespace BusBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserStateAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserState", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UserState");
        }
    }
}
