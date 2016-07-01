namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(maxLength: 70),
                        Descripcion = c.String(maxLength: 100),
                        CategoryID = c.String(maxLength: 128),
                        SupplierID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Category", t => t.CategoryID)
                .ForeignKey("dbo.Supplier", t => t.SupplierID)
                .Index(t => t.CategoryID)
                .Index(t => t.SupplierID);
            
            CreateTable(
                "dbo.Supplier",
                c => new
                    {
                        SupplierID = c.String(nullable: false, maxLength: 128),
                        RUC = c.String(maxLength: 11),
                        Razon = c.String(maxLength: 100),
                        Email = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.SupplierID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "SupplierID", "dbo.Supplier");
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Category");
            DropIndex("dbo.Product", new[] { "SupplierID" });
            DropIndex("dbo.Product", new[] { "CategoryID" });
            DropTable("dbo.Supplier");
            DropTable("dbo.Product");
            DropTable("dbo.Category");
        }
    }
}
