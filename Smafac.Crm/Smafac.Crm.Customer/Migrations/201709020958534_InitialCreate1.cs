namespace Smafac.Crm.Customer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.CustomerFinancial");
            DropTable("dbo.CustomerFinancialStatus");
            DropTable("dbo.CustomerFinancialType");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CustomerFinancialType",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerFinancialStatus",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerFinancial",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Evidence = c.String(),
                        Memo = c.String(),
                        PayTime = c.DateTime(nullable: false),
                        TypeId = c.Guid(nullable: false),
                        StatusId = c.Guid(nullable: false),
                        PayTypeId = c.Guid(nullable: false),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
