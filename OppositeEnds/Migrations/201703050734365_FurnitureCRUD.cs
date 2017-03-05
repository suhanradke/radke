namespace OppositeEnds.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FurnitureCRUD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Furnitures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Category = c.String(),
                        Picture = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Furnitures");
        }
    }
}
