namespace GymRS_DB_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M02_DateError : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Request", "StatusUpdatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Request", "StatusUpdatedDate", c => c.DateTime(nullable: false));
        }
    }
}
