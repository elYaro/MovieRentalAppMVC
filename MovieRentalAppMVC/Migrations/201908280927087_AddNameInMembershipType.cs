namespace MovieRentalAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameInMembershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
