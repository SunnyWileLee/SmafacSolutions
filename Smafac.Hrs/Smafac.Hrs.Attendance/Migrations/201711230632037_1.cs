namespace Smafac.Hrs.Attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendance", "Memo", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attendance", "Memo");
        }
    }
}
