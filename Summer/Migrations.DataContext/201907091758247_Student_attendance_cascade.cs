namespace Summer.Migrations.DataContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Student_attendance_cascade : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendance", "StudentId", "dbo.Student");
            DropForeignKey("dbo.TestScore", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Attendance", "WeekNumber", "dbo.WeekNumber");
            DropForeignKey("dbo.TestScore", "CourseId", "dbo.Course");
            AddForeignKey("dbo.Attendance", "StudentId", "dbo.Student", "StudentId", cascadeDelete: true);
            AddForeignKey("dbo.TestScore", "StudentId", "dbo.Student", "StudentId", cascadeDelete: true);
            AddForeignKey("dbo.Attendance", "WeekNumber", "dbo.WeekNumber", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TestScore", "CourseId", "dbo.Course", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestScore", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Attendance", "WeekNumber", "dbo.WeekNumber");
            DropForeignKey("dbo.TestScore", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Attendance", "StudentId", "dbo.Student");
            AddForeignKey("dbo.TestScore", "CourseId", "dbo.Course", "Id");
            AddForeignKey("dbo.Attendance", "WeekNumber", "dbo.WeekNumber", "Id");
            AddForeignKey("dbo.TestScore", "StudentId", "dbo.Student", "StudentId");
            AddForeignKey("dbo.Attendance", "StudentId", "dbo.Student", "StudentId");
        }
    }
}
