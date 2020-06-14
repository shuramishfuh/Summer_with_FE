namespace Summer.Migrations.DataContext
{
    using System.Data.Entity.Migrations;

    public partial class Seed_Codes : DbMigration
    {
        public override void Up()
        {
            Sql(@"
SET IDENTITY_INSERT [dbo].[Codes] ON
INSERT INTO [dbo].[Codes] ([Id], [type], [code]) VALUES (1, N'Admin', N'Everything')
INSERT INTO [dbo].[Codes] ([Id], [type], [code]) VALUES (2, N'Tutor', N'None')
SET IDENTITY_INSERT [dbo].[Codes] OFF

            ");
        }

        public override void Down()
        {
        }
    }
}
