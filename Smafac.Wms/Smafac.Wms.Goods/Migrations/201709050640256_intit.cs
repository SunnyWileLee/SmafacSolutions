namespace Smafac.Wms.Goods.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GoodsProperty", "IsDeleteAssociations", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GoodsProperty", "IsDeleteAssociations");
        }
    }
}
