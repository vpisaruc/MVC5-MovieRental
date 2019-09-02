namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MinorChangesInUserTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String(nullable: false, maxLength: 15));
        }
    }
}
