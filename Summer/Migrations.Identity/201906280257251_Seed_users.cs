namespace Summer.Migrations.Identity
{
    using System.Data.Entity.Migrations;

    public partial class Seed_users : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1303d84f-83b5-4a85-9f24-4951c3e20762', N'Hoffman200@gmail.com', 0, N'AK9agzdMONuqKiEPqorFzgi6bVWtoAoFTff7JmOcFlk3eRjuboG6+x3ei21Gxtrvpw==', N'3a098d0c-46cd-43b7-a089-a3f8a3cb36b3', NULL, 0, 0, NULL, 1, 0, N'Hoffman200@gmail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'66541714-bb47-43da-bc5d-7a2a960e20ed', N'Tutor401@gmail.com', 0, N'AAGUtxlqLs/KC53m7Xen62K0LPfgAN6rLGuZOMcQ+83lV2r5tR+jVUpNkzwYUdI76Q==', N'555787e5-8aac-4bae-85c3-568fe4f7c08d', NULL, 0, 0, NULL, 1, 0, N'Tutor401@gmail.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c2ed247d-be92-4935-96ec-ea7b90d52da5', N'Admin')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1303d84f-83b5-4a85-9f24-4951c3e20762', N'c2ed247d-be92-4935-96ec-ea7b90d52da5')


            ");
        }

        public override void Down()
        {
        }
    }
}
