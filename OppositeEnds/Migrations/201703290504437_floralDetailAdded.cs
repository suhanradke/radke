namespace OppositeEnds.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class floralDetailAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Florals", "Details", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Florals", "Details");
        }
    }
}
