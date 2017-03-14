namespace OppositeEnds.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validations1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Furnitures", "Name", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Furnitures", "Name", c => c.String());
        }
    }
}
