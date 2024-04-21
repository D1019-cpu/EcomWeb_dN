namespace JewelryShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifierDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Category", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tb_Product", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tb_ProductImage", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tb_ProductReview", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tb_Promotion", "UpdatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Promotion", "UpdatedAt", c => c.String());
            AlterColumn("dbo.tb_ProductReview", "UpdatedAt", c => c.String());
            AlterColumn("dbo.tb_ProductImage", "UpdatedAt", c => c.String());
            AlterColumn("dbo.tb_Product", "UpdatedAt", c => c.String());
            AlterColumn("dbo.tb_Category", "UpdatedAt", c => c.String());
        }
    }
}
