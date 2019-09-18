namespace MovieRentalAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctedPropertyNameInRentalClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "DateReturned", c => c.DateTime());
            DropColumn("dbo.Rentals", "DareReturned");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "DareReturned", c => c.DateTime());
            DropColumn("dbo.Rentals", "DateReturned");
        }
    }
}
