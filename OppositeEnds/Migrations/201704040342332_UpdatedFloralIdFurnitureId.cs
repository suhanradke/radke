namespace OppositeEnds.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdatedFloralIdFurnitureId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Florals");
            DropPrimaryKey("dbo.Furnitures");
            DropPrimaryKey("dbo.Users");
            DropColumn("dbo.Florals", "Id");
            DropColumn("dbo.Furnitures", "Id");
            DropColumn("dbo.Users", "Id");
            AddColumn("dbo.Florals", "FloralId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Furnitures", "FurnitureId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Users", "UserId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Florals", "FloralId");
            AddPrimaryKey("dbo.Furnitures", "FurnitureId");
            AddPrimaryKey("dbo.Users", "UserId");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Furnitures", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Florals", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Furnitures");
            DropPrimaryKey("dbo.Florals");
            DropColumn("dbo.Users", "UserId");
            DropColumn("dbo.Furnitures", "FurnitureId");
            DropColumn("dbo.Florals", "FloralId");
            AddPrimaryKey("dbo.Users", "Id");
            AddPrimaryKey("dbo.Furnitures", "Id");
            AddPrimaryKey("dbo.Florals", "Id");
        }
    }
}
