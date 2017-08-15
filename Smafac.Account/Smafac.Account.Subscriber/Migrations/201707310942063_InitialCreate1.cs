namespace Smafac.Account.Subscriber.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SignIn",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Token = c.String(maxLength: 50),
                        UserId = c.Guid(nullable: false),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SignIn");
        }
    }
}
