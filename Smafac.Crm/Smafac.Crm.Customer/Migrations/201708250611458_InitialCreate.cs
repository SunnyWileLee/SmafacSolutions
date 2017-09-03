namespace Smafac.Crm.Customer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerContactProperty",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerContactPropertyValue",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ContactId = c.Guid(nullable: false),
                        PropertyId = c.Guid(nullable: false),
                        Value = c.String(),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerContact",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        Name = c.String(),
                        MobileNumber = c.String(),
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
                "dbo.CustomerLevel",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Buttom = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Top = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerPayType",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerProperty",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 20),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerPropertyValue",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        PropertyId = c.Guid(nullable: false),
                        Value = c.String(maxLength: 100),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerReceive",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        InvokerId = c.Guid(nullable: false),
                        ReceiveTime = c.DateTime(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Content = c.String(),
                        Memo = c.String(),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        KnownDate = c.DateTime(nullable: false),
                        MobileNumber = c.String(),
                        LevelId = c.Guid(nullable: false),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerScore",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        Score = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LevelId = c.Guid(nullable: false),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerVisit",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        InvokerId = c.Guid(nullable: false),
                        VisitTime = c.DateTime(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Content = c.String(),
                        Memo = c.String(),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerVisit");
            DropTable("dbo.CustomerScore");
            DropTable("dbo.Customer");
            DropTable("dbo.CustomerReceive");
            DropTable("dbo.CustomerPropertyValue");
            DropTable("dbo.CustomerProperty");
            DropTable("dbo.CustomerPayType");
            DropTable("dbo.CustomerLevel");
            DropTable("dbo.CustomerFinancialType");
            DropTable("dbo.CustomerFinancialStatus");
            DropTable("dbo.CustomerFinancial");
            DropTable("dbo.CustomerContact");
            DropTable("dbo.CustomerContactPropertyValue");
            DropTable("dbo.CustomerContactProperty");
        }
    }
}
