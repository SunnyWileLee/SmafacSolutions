namespace Smafac.Account.Subscriber.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Passport", "UserName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Passport", "Password", c => c.String(maxLength: 100));
            AlterColumn("dbo.Subscriber", "Name", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subscriber", "Name", c => c.String());
            AlterColumn("dbo.Passport", "Password", c => c.String());
            AlterColumn("dbo.Passport", "UserName", c => c.String());
        }
    }
}
