namespace TrueCodeTraining.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeInUsers : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String(maxLength: 200));
            AlterColumn("dbo.Users", "UserName", c => c.String(maxLength: 200));
            AlterColumn("dbo.Users", "FirstName", c => c.String(maxLength: 200));
        }
    }
}
