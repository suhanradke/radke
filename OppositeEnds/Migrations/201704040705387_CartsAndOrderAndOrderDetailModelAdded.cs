namespace OppositeEnds.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartsAndOrderAndOrderDetailModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        FloralId = c.Int(nullable: false),
                        FurnitureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Florals", t => t.FloralId, cascadeDelete: true)
                .ForeignKey("dbo.Furnitures", t => t.FurnitureId, cascadeDelete: true)
                .Index(t => t.FloralId)
                .Index(t => t.FurnitureId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        FloralId = c.Int(nullable: false),
                        Furnitured = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        furniture_FurnitureId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Florals", t => t.FloralId, cascadeDelete: true)
                .ForeignKey("dbo.Furnitures", t => t.furniture_FurnitureId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.FloralId)
                .Index(t => t.furniture_FurnitureId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Username = c.String(),
                        FirstName = c.String(nullable: false, maxLength: 160),
                        LastName = c.String(nullable: false, maxLength: 160),
                        Address = c.String(nullable: false, maxLength: 70),
                        City = c.String(nullable: false, maxLength: 40),
                        State = c.String(nullable: false, maxLength: 40),
                        PostalCode = c.String(nullable: false, maxLength: 10),
                        Country = c.String(nullable: false, maxLength: 40),
                        Phone = c.String(nullable: false, maxLength: 24),
                        Email = c.String(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "FurnitureId", "dbo.Furnitures");
            DropForeignKey("dbo.Carts", "FloralId", "dbo.Florals");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "furniture_FurnitureId", "dbo.Furnitures");
            DropForeignKey("dbo.OrderDetails", "FloralId", "dbo.Florals");
            DropIndex("dbo.OrderDetails", new[] { "furniture_FurnitureId" });
            DropIndex("dbo.OrderDetails", new[] { "FloralId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Carts", new[] { "FurnitureId" });
            DropIndex("dbo.Carts", new[] { "FloralId" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Carts");
        }
    }
}
