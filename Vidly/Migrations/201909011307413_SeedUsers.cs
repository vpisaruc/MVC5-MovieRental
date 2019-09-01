namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4ad88deb-52e4-4928-a922-5a17a1c964a6', N'admin@vidly.com', 0, N'AKh5JDJh3kK1av97r9s/88xy5+ALt5J3EIxlJOQMd/qANdjVj1cSajz9kv6cye4kZA==', N'855be2b7-4ba3-4d44-a2ba-71f957277826', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e77e1f6d-0c6b-4d50-92ba-651c7c6cf0fe', N'guest@vidly.com', 0, N'AAPj3eKeEPy0pi0OGH8cEF0IbSMPZaiTlUU+mFZ8g2xHzihdFmBFPo21534ydAcd4A==', N'bb8e7618-ca7d-42b6-810d-f3227ffbdb33', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'25c80fe1-1a31-41fe-8fb5-2b9b0d1fd601', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4ad88deb-52e4-4928-a922-5a17a1c964a6', N'25c80fe1-1a31-41fe-8fb5-2b9b0d1fd601')

");
        }
        
        public override void Down()
        {
        }
    }
}
