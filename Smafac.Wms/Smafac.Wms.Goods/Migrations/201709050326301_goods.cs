namespace Smafac.Wms.Goods.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class goods : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GoodsProperty", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.GoodsProperty", "IsTableColumn", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GoodsProperty", "IsTableColumn");
            DropColumn("dbo.GoodsProperty", "Type");
        }
    }
}
