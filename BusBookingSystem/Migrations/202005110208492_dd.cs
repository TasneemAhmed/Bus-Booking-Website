namespace BusBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Feedbacks", "From", c => c.String());
            AddColumn("dbo.Feedbacks", "To", c => c.String());
            AddColumn("dbo.Feedbacks", "Subject", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Feedbacks", "Subject");
            DropColumn("dbo.Feedbacks", "To");
            DropColumn("dbo.Feedbacks", "From");
        }
    }
}
