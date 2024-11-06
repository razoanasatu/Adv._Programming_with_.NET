namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(),
                        Location = c.String(),
                        AdminId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Users", t => t.AdminId, cascadeDelete: true)
                .Index(t => t.AdminId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false),
                        Role = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.RSVPs",
                c => new
                    {
                        RSVPId = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RSVPId)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.EventId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Reminders",
                c => new
                    {
                        ReminderId = c.Int(nullable: false, identity: true),
                        ReminderDate = c.DateTime(nullable: false),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReminderId)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reminders", "EventId", "dbo.Events");
            DropForeignKey("dbo.Events", "AdminId", "dbo.Users");
            DropForeignKey("dbo.RSVPs", "UserId", "dbo.Users");
            DropForeignKey("dbo.RSVPs", "EventId", "dbo.Events");
            DropIndex("dbo.Reminders", new[] { "EventId" });
            DropIndex("dbo.RSVPs", new[] { "UserId" });
            DropIndex("dbo.RSVPs", new[] { "EventId" });
            DropIndex("dbo.Events", new[] { "AdminId" });
            DropTable("dbo.Reminders");
            DropTable("dbo.RSVPs");
            DropTable("dbo.Users");
            DropTable("dbo.Events");
        }
    }
}
