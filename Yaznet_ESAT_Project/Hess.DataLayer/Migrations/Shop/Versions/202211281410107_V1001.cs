namespace Hess.DataLayer.Migrations.Shop
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V1001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBL_ProductDetails",
                c => new
                    {
                        Product_ID = c.Long(nullable: false),
                        HBCode = c.String(maxLength: 200, unicode: false),
                        TYCode = c.String(maxLength: 200, unicode: false),
                        NOCode = c.String(maxLength: 200, unicode: false),
                        EBCode = c.String(maxLength: 200, unicode: false),
                        AZCode = c.String(maxLength: 200, unicode: false),
                        GoogleCode = c.String(maxLength: 200, unicode: false),
                        ERPCode = c.String(maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.Product_ID)
                .ForeignKey("dbo.TBL_Products", t => t.Product_ID)
                .Index(t => t.Product_ID);
            
            CreateTable(
                "dbo.TBL_Products",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ProductCode = c.String(maxLength: 50, unicode: false),
                        ProductName = c.String(maxLength: 500),
                        BrandName = c.String(maxLength: 200),
                        ModelName = c.String(maxLength: 200),
                        Detail = c.String(maxLength: 4000),
                        OldPrice = c.Decimal(precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedDate = c.DateTime(nullable: false),
                        Is_Deleted = c.Boolean(nullable: false),
                        Is_Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBL_ProductDetails", "Product_ID", "dbo.TBL_Products");
            DropIndex("dbo.TBL_ProductDetails", new[] { "Product_ID" });
            DropTable("dbo.TBL_Products");
            DropTable("dbo.TBL_ProductDetails");
        }
    }
}
