namespace Smafac.Crm.CustomerFinance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerFinanceCategoryPropertyEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PropertyId = c.Guid(nullable: false),
                        CategoryId = c.Guid(nullable: false),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerFinanceCategoryPropertyEntities");
        }
    }
}
