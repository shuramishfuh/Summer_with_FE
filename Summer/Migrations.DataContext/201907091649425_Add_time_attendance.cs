namespace Summer.Migrations.DataContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_time_attendance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendance", "Time", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attendance", "Time");
        }
    }
}
