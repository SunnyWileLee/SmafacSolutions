namespace Smafac.Pms.Purchase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PurchaseCategory", "Saleable");
            DropColumn("dbo.PurchaseCategory", "Purchaseable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchaseCategory", "Purchaseable", c => c.Boolean(nullable: false));
            AddColumn("dbo.PurchaseCategory", "Saleable", c => c.Boolean(nullable: false));
        }
    }
}
