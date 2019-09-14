namespace MovieRentalAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a73d40de-e901-4f76-b766-17d9c27709a3', N'admin@gmail.com', 0, N'ALxgFINcWJ+ZErlEwQInlGlw/SJY8senAvD8rLr9G8xsuLbZKGTNBTiGiLXOtlBATA==', N'9c988405-7d82-4d2c-9b16-abf359c6da9f', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd3ebdc28-3816-4d54-9d0e-27c8d4008390', N'guest1@gmail.com', 0, N'AGkq3N59JkCWMOX4ZI3WJUH5k4ENNaiU7MtmvZeSCnPuntE+UF7va3+MOWm66y3bOA==', N'06203573-c591-431e-9bd1-8a49f83206b3', NULL, 0, 0, NULL, 1, 0, N'guest1@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ad8a7b62-c797-40cf-918d-716def4beec0', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a73d40de-e901-4f76-b766-17d9c27709a3', N'ad8a7b62-c797-40cf-918d-716def4beec0')

");
        }
        
        public override void Down()
        {
        }
    }
}
