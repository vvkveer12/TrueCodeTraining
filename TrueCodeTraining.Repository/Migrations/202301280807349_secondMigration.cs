namespace TrueCodeTraining.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "LastName", c => c.String(maxLength: 200));
        }
    }
}
