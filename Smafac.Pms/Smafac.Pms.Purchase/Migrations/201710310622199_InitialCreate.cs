namespace Smafac.Pms.Purchase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseCategory",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Saleable = c.Boolean(nullable: false),
                        Purchaseable = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 100),
                        ParentId = c.Guid(nullable: false),
                        NodeType = c.Int(nullable: false),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PurchaseCategoryProperty",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PropertyId = c.Guid(nullable: false),
                        CategoryId = c.Guid(nullable: false),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PurchaseProperty",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.Int(nullable: false),
                        Name = c.String(maxLength: 20),
                        IsTableColumn = c.Boolean(nullable: false),
                        IsDeleteAssociations = c.Boolean(nullable: false),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PurchasePropertyValue",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PurchaseId = c.Guid(nullable: false),
                        PropertyId = c.Guid(nullable: false),
                        Value = c.String(maxLength: 100),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Purchase",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        GoodsId = c.Guid(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryId = c.Guid(nullable: false),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Purchase");
            DropTable("dbo.PurchasePropertyValue");
            DropTable("dbo.PurchaseProperty");
            DropTable("dbo.PurchaseCategoryProperty");
            DropTable("dbo.PurchaseCategory");
        }
    }
}
