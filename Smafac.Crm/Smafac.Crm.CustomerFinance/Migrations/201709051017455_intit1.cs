namespace Smafac.Crm.CustomerFinance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intit1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CustomerFinanceCategoryPropertyEntities", newName: "CustomerFinanceCategoryProperty");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.CustomerFinanceCategoryProperty", newName: "CustomerFinanceCategoryPropertyEntities");
        }
    }
}
