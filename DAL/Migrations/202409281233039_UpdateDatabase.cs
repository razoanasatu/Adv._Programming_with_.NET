namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RSVPs", "EventId", "dbo.Events");
            DropForeignKey("dbo.RSVPs", "UserId", "dbo.Users");
            AddForeignKey("dbo.RSVPs", "EventId", "dbo.Events", "EventId");
            AddForeignKey("dbo.RSVPs", "UserId", "dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RSVPs", "UserId", "dbo.Users");
            DropForeignKey("dbo.RSVPs", "EventId", "dbo.Events");
            AddForeignKey("dbo.RSVPs", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.RSVPs", "EventId", "dbo.Events", "EventId", cascadeDelete: true);
        }
    }
}
