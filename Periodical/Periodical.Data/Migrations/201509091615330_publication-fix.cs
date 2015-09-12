namespace Periodical.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class publicationfix : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Publications", "Number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Publications", "Number", c => c.Int(nullable: false));
        }
    }
}
