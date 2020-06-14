using System;

namespace Summer.Migrations.DataContext
{
    using System.Data.Entity.Migrations;

    public partial class Initial_Datacontext_Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdvanceLevel",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Subject_1 = c.String(nullable: false, storeType: "ntext"),
                    Subject_2 = c.String(nullable: false, storeType: "ntext"),
                    Subject_3 = c.String(storeType: "ntext"),
                    Subject_4 = c.String(storeType: "ntext"),
                    Subject_5 = c.String(storeType: "ntext"),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Student", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);

            CreateTable(
                "dbo.Student",
                c => new
                {
                    StudentId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 100),
                    Sex = c.String(nullable: false, maxLength: 6, fixedLength: true),
                    Age = c.Byte(nullable: false),
                    School = c.String(nullable: false, maxLength: 300),
                    FutureCareerChoice = c.String(maxLength: 150),
                    Tel = c.String(nullable: false, maxLength: 10),
                    YearOfAttendance = c.DateTime(nullable: false, storeType: "date"),
                })
                .PrimaryKey(t => t.StudentId);

            CreateTable(
                "dbo.Attendance",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    WeekNumber = c.Int(nullable: false),
                    StudentId = c.Int(nullable: false),
                    Date = c.DateTime(nullable: false, storeType: "date"),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WeekNumber", t => t.WeekNumber)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.WeekNumber)
                .Index(t => t.StudentId);

            CreateTable(
                "dbo.WeekNumber",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Number = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.OrdinaryLevel",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Subject_1 = c.String(nullable: false, storeType: "ntext"),
                    Subject_2 = c.String(nullable: false, storeType: "ntext"),
                    Subject_3 = c.String(nullable: false, storeType: "ntext"),
                    Subject_4 = c.String(nullable: false, storeType: "ntext"),
                    Subject_5 = c.String(storeType: "ntext"),
                    Subject_6 = c.String(storeType: "ntext"),
                    Subject_7 = c.String(storeType: "ntext"),
                    Subject_8 = c.String(storeType: "ntext"),
                    Subject_9 = c.String(storeType: "ntext"),
                    Subject_10 = c.String(storeType: "ntext"),
                    Subject_11 = c.String(storeType: "ntext"),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Student", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);

            CreateTable(
                "dbo.TestScore",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CourseId = c.Int(nullable: false),
                    StudentId = c.Int(nullable: false),
                    StudentScore = c.Double(nullable: false),
                    Comment = c.String(storeType: "ntext"),
                    DateTime = c.DateTime(nullable: false, storeType: "date"),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.CourseId)
                .Index(t => t.StudentId);

            CreateTable(
                "dbo.Course",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CourseName = c.String(nullable: false, maxLength: 200),
                    CourseDescription = c.String(nullable: false, storeType: "ntext"),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Codes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    type = c.String(nullable: false),
                    code = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Events",
                c => new
                {
                    EventId = c.Short(nullable: false, identity: true),
                    EventName = c.String(),
                    Description = c.String(),
                    EventDate = c.DateTime(nullable: false, storeType: "date"),
                })
                .PrimaryKey(t => t.EventId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.TestScore", "StudentId", "dbo.Student");
            DropForeignKey("dbo.TestScore", "CourseId", "dbo.Course");
            DropForeignKey("dbo.OrdinaryLevel", "Id", "dbo.Student");
            DropForeignKey("dbo.Attendance", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Attendance", "WeekNumber", "dbo.WeekNumber");
            DropForeignKey("dbo.AdvanceLevel", "Id", "dbo.Student");
            DropIndex("dbo.TestScore", new[] { "StudentId" });
            DropIndex("dbo.TestScore", new[] { "CourseId" });
            DropIndex("dbo.OrdinaryLevel", new[] { "Id" });
            DropIndex("dbo.Attendance", new[] { "StudentId" });
            DropIndex("dbo.Attendance", new[] { "WeekNumber" });
            DropIndex("dbo.AdvanceLevel", new[] { "Id" });
            DropTable("dbo.Events");
            DropTable("dbo.Codes");
            DropTable("dbo.Course");
            DropTable("dbo.TestScore");
            DropTable("dbo.OrdinaryLevel");
            DropTable("dbo.WeekNumber");
            DropTable("dbo.Attendance");
            DropTable("dbo.Student");
            DropTable("dbo.AdvanceLevel");
        }
    }
}
