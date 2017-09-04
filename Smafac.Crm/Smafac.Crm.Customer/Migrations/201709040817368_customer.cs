namespace Smafac.Crm.Customer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customer : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.CustomerContactProperty");
            DropTable("dbo.CustomerContactPropertyValue");
            DropTable("dbo.CustomerContact");
            DropTable("dbo.CustomerLevel");
            DropTable("dbo.CustomerPayType");
            DropTable("dbo.CustomerReceive");
            DropTable("dbo.CustomerScore");
            DropTable("dbo.CustomerVisit");
        }
        
        public override void Down()
        {
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
                "dbo.CustomerContactProperty",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
