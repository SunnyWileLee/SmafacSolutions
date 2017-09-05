namespace Smafac.Crm.Customer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerProperty", "IsDeleteAssociations", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerProperty", "IsDeleteAssociations");
        }
    }
}
