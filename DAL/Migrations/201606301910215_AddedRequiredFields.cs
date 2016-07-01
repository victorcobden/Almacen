namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequiredFields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.Product", "SupplierID", "dbo.Supplier");
            DropIndex("dbo.Product", new[] { "CategoryID" });
            DropIndex("dbo.Product", new[] { "SupplierID" });
            AlterColumn("dbo.Category", "Nombre", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Product", "Nombre", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.Product", "CategoryID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Product", "SupplierID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Supplier", "RUC", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Supplier", "Razon", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Product", "CategoryID");
            CreateIndex("dbo.Product", "SupplierID");
            AddForeignKey("dbo.Product", "CategoryID", "dbo.Category", "CategoryID", cascadeDelete: true);
            AddForeignKey("dbo.Product", "SupplierID", "dbo.Supplier", "SupplierID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "SupplierID", "dbo.Supplier");
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Category");
            DropIndex("dbo.Product", new[] { "SupplierID" });
            DropIndex("dbo.Product", new[] { "CategoryID" });
            AlterColumn("dbo.Supplier", "Razon", c => c.String(maxLength: 100));
            AlterColumn("dbo.Supplier", "RUC", c => c.String(maxLength: 11));
            AlterColumn("dbo.Product", "SupplierID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Product", "CategoryID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Product", "Nombre", c => c.String(maxLength: 70));
            AlterColumn("dbo.Category", "Nombre", c => c.String(maxLength: 50));
            CreateIndex("dbo.Product", "SupplierID");
            CreateIndex("dbo.Product", "CategoryID");
            AddForeignKey("dbo.Product", "SupplierID", "dbo.Supplier", "SupplierID");
            AddForeignKey("dbo.Product", "CategoryID", "dbo.Category", "CategoryID");
        }
    }
}
