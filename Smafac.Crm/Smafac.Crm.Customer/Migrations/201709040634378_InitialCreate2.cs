namespace Smafac.Crm.Customer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerProperty", "IsTableColumn", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerProperty", "IsTableColumn");
        }
    }
}
