namespace OppositeEnds.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkcheck : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "furniture_FurnitureId", "dbo.Furnitures");
            DropIndex("dbo.OrderDetails", new[] { "furniture_FurnitureId" });
            RenameColumn(table: "dbo.OrderDetails", name: "furniture_FurnitureId", newName: "FurnitureId");
            AlterColumn("dbo.OrderDetails", "FurnitureId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderDetails", "FurnitureId");
            AddForeignKey("dbo.OrderDetails", "FurnitureId", "dbo.Furnitures", "FurnitureId", cascadeDelete: true);
            DropColumn("dbo.OrderDetails", "Furnitured");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "Furnitured", c => c.Int(nullable: false));
            DropForeignKey("dbo.OrderDetails", "FurnitureId", "dbo.Furnitures");
            DropIndex("dbo.OrderDetails", new[] { "FurnitureId" });
            AlterColumn("dbo.OrderDetails", "FurnitureId", c => c.Int());
            RenameColumn(table: "dbo.OrderDetails", name: "FurnitureId", newName: "furniture_FurnitureId");
            CreateIndex("dbo.OrderDetails", "furniture_FurnitureId");
            AddForeignKey("dbo.OrderDetails", "furniture_FurnitureId", "dbo.Furnitures", "FurnitureId");
        }
    }
}
