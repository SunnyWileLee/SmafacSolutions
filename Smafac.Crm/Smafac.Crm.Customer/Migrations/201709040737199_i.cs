namespace Smafac.Crm.Customer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class i : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerProperty", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerProperty", "Type");
        }
    }
}
