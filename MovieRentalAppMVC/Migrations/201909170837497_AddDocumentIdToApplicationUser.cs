namespace MovieRentalAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDocumentIdToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DocumentID", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DocumentID");
        }
    }
}
