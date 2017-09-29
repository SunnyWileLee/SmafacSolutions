namespace Smafac.Wms.Goods.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GoodsCategory", "Saleable", c => c.Boolean(nullable: false));
            AddColumn("dbo.GoodsCategory", "Purchaseable", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GoodsCategory", "Purchaseable");
            DropColumn("dbo.GoodsCategory", "Saleable");
        }
    }
}
