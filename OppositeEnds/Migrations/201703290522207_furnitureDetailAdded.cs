namespace OppositeEnds.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class furnitureDetailAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Furnitures", "Details", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Furnitures", "Details");
        }
    }
}
