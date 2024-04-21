namespace JewelryShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedSlugInCategory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Category", "Slug", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Category", "Slug", c => c.String(nullable: false));
        }
    }
}
