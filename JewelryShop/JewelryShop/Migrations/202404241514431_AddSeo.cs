namespace JewelryShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Category", "SeoTitle", c => c.String());
            AddColumn("dbo.tb_Category", "SeoDescription", c => c.String());
            AddColumn("dbo.tb_Category", "SeoKeywords", c => c.String());
            AddColumn("dbo.tb_Category", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.tb_Product", "SKU", c => c.String());
            AddColumn("dbo.tb_Product", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.tb_Product", "IsPublished", c => c.Boolean(nullable: false));
            AddColumn("dbo.tb_Product", "SeoTitle", c => c.String());
            AddColumn("dbo.tb_Product", "SeoDescription", c => c.String());
            AddColumn("dbo.tb_Product", "SeoKeywords", c => c.String());
            AlterColumn("dbo.tb_Product", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Product", "Image", c => c.String(nullable: false));
            DropColumn("dbo.tb_Product", "SeoKeywords");
            DropColumn("dbo.tb_Product", "SeoDescription");
            DropColumn("dbo.tb_Product", "SeoTitle");
            DropColumn("dbo.tb_Product", "IsPublished");
            DropColumn("dbo.tb_Product", "Quantity");
            DropColumn("dbo.tb_Product", "SKU");
            DropColumn("dbo.tb_Category", "IsActive");
            DropColumn("dbo.tb_Category", "SeoKeywords");
            DropColumn("dbo.tb_Category", "SeoDescription");
            DropColumn("dbo.tb_Category", "SeoTitle");
        }
    }
}
