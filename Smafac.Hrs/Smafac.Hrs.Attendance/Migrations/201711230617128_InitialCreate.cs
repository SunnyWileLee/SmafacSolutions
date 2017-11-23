namespace Smafac.Hrs.Attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AttendanceCategory",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 100),
                        ParentId = c.Guid(nullable: false),
                        NodeType = c.Int(nullable: false),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AttendanceCategoryProperty",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PropertyId = c.Guid(nullable: false),
                        CategoryId = c.Guid(nullable: false),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AttendanceProperty",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.Int(nullable: false),
                        Name = c.String(maxLength: 20),
                        IsTableColumn = c.Boolean(nullable: false),
                        IsDeleteAssociations = c.Boolean(nullable: false),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AttendancePropertyValue",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AttendanceId = c.Guid(nullable: false),
                        PropertyId = c.Guid(nullable: false),
                        Value = c.String(maxLength: 100),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Attendance",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        EmployeeId = c.Guid(nullable: false),
                        BeginTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        CategoryId = c.Guid(nullable: false),
                        SubscriberId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Attendance");
            DropTable("dbo.AttendancePropertyValue");
            DropTable("dbo.AttendanceProperty");
            DropTable("dbo.AttendanceCategoryProperty");
            DropTable("dbo.AttendanceCategory");
        }
    }
}
