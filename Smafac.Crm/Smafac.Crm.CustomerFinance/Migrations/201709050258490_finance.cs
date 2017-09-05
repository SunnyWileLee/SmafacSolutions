namespace Smafac.Crm.CustomerFinance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerFinanceProperty", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.CustomerFinanceProperty", "IsTableColumn", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerFinanceProperty", "IsTableColumn");
            DropColumn("dbo.CustomerFinanceProperty", "Type");
        }
    }
}
