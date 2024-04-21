namespace JewelryShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCategory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Category", "Slug", c => c.String(nullable: false));
            AlterColumn("dbo.tb_Category", "Description", c => c.String());
            AlterColumn("dbo.tb_Category", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Category", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.tb_Category", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.tb_Category", "Slug", c => c.String());
        }
    }
}
