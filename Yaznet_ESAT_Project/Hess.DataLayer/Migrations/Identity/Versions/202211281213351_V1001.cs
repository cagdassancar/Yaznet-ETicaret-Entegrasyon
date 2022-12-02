namespace Hess.DataLayer.Migrations.Identity
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V1001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBL_CompanyLogins",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Company_ID = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Password = c.String(maxLength: 500),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TBL_Companys", t => t.Company_ID, cascadeDelete: true)
                .Index(t => t.Company_ID);
            
            CreateTable(
                "dbo.TBL_Companys",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        CompanyCode = c.String(maxLength: 50, unicode: false),
                        CompanyName = c.String(maxLength: 50, unicode: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TBL_CompanyShops",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Company_ID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TBL_Companys", t => t.Company_ID, cascadeDelete: true)
                .Index(t => t.Company_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBL_CompanyShops", "Company_ID", "dbo.TBL_Companys");
            DropForeignKey("dbo.TBL_CompanyLogins", "Company_ID", "dbo.TBL_Companys");
            DropIndex("dbo.TBL_CompanyShops", new[] { "Company_ID" });
            DropIndex("dbo.TBL_CompanyLogins", new[] { "Company_ID" });
            DropTable("dbo.TBL_CompanyShops");
            DropTable("dbo.TBL_Companys");
            DropTable("dbo.TBL_CompanyLogins");
        }
    }
}
