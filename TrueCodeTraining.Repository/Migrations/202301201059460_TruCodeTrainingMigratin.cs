namespace TrueCodeTraining.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TruCodeTrainingMigratin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(maxLength: 200),
                        Address = c.String(maxLength: 300),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
