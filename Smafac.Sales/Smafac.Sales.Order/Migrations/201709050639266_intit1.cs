namespace Smafac.Sales.Order.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intit1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderCharge", "IsTableColumn", c => c.Boolean(nullable: false));
            AddColumn("dbo.OrderCharge", "IsDeleteAssociations", c => c.Boolean(nullable: false));
            AddColumn("dbo.OrderProperty", "IsDeleteAssociations", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderProperty", "IsDeleteAssociations");
            DropColumn("dbo.OrderCharge", "IsDeleteAssociations");
            DropColumn("dbo.OrderCharge", "IsTableColumn");
        }
    }
}
