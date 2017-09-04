namespace Smafac.Sales.Order.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderCategory",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 100),
                        ParentId = c.Guid(nullable: false),
                        NodeType = c.Int(nullable: false),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderCategoryProperty",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CategoryId = c.Guid(nullable: false),
                        PropertyId = c.Guid(nullable: false),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderCharge",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 20),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderChargeValue",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OrderId = c.Guid(nullable: false),
                        ChargeId = c.Guid(nullable: false),
                        Charge = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderProperty",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 20),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderPropertyValue",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OrderId = c.Guid(nullable: false),
                        PropertyId = c.Guid(nullable: false),
                        Value = c.String(maxLength: 100),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerId = c.Guid(nullable: false),
                        GoodsId = c.Guid(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Charge = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalCharge = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDate = c.DateTime(nullable: false),
                        HopeDate = c.DateTime(nullable: false),
                        Memo = c.String(maxLength: 500),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderStatusChanged",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StatusBefore = c.Guid(nullable: false),
                        StatusAfter = c.Guid(nullable: false),
                        Memo = c.String(),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 10),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OrderStatus");
            DropTable("dbo.OrderStatusChanged");
            DropTable("dbo.Order");
            DropTable("dbo.OrderPropertyValue");
            DropTable("dbo.OrderProperty");
            DropTable("dbo.OrderChargeValue");
            DropTable("dbo.OrderCharge");
            DropTable("dbo.OrderCategoryProperty");
            DropTable("dbo.OrderCategory");
        }
    }
}
