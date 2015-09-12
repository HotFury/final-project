namespace Periodical.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class publicationubdateaddfieldTimesInYear : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Publications", "TimesInYear", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Publications", "TimesInYear");
        }
    }
}
