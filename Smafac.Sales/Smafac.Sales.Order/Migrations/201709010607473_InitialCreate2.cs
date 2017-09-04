namespace Smafac.Sales.Order.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderCategoryCharge",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ChargeId = c.Guid(nullable: false),
                        CategoryId = c.Guid(nullable: false),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OrderCategoryCharge");
        }
    }
}
