namespace BusBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddNewUser : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Users (EMail, UserName, UserPassword, PhoneNumber, Address) values ('testUser@gmail.com', 'test', 'toot123', 08646, 'Giza')");
        }


        public override void Down()
        {

        }
    }    
}

