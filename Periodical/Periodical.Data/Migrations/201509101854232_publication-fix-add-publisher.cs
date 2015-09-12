namespace Periodical.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class publicationfixaddpublisher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Publications", "Publisher", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Publications", "Publisher");
        }
    }
}
