namespace GymRS_DB_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M01Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonalTrainer",
                c => new
                    {
                        PersonalTrainerID = c.Int(nullable: false, identity: true),
                        PTCode = c.String(nullable: false, maxLength: 5),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.PersonalTrainerID);
            
            CreateTable(
                "dbo.Request",
                c => new
                    {
                        RequestID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        PersonalTrainerID = c.Int(nullable: false),
                        RequestStatusID = c.Int(nullable: false),
                        SessionDate = c.DateTime(nullable: false),
                        SessionHour = c.DateTime(nullable: false),
                        StatusUpdatedDate = c.DateTime(nullable: false),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.RequestID)
                .ForeignKey("dbo.PersonalTrainer", t => t.PersonalTrainerID, cascadeDelete: true)
                .ForeignKey("dbo.RequestStatus", t => t.RequestStatusID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.PersonalTrainerID)
                .Index(t => t.RequestStatusID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.RequestStatus",
                c => new
                    {
                        RequestStatusID = c.Int(nullable: false, identity: true),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RequestStatusID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Request", "UserID", "dbo.User");
            DropForeignKey("dbo.Request", "RequestStatusID", "dbo.RequestStatus");
            DropForeignKey("dbo.Request", "PersonalTrainerID", "dbo.PersonalTrainer");
            DropIndex("dbo.Request", new[] { "UserID" });
            DropIndex("dbo.Request", new[] { "RequestStatusID" });
            DropIndex("dbo.Request", new[] { "PersonalTrainerID" });
            DropTable("dbo.User");
            DropTable("dbo.RequestStatus");
            DropTable("dbo.Request");
            DropTable("dbo.PersonalTrainer");
        }
    }
}
