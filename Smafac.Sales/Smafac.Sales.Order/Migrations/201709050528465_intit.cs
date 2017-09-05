namespace Smafac.Sales.Order.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderProperty", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.OrderProperty", "IsTableColumn", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderProperty", "IsTableColumn");
            DropColumn("dbo.OrderProperty", "Type");
        }
    }
}
