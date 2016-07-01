namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeQuantityTypeInProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Cantidad", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Cantidad");
        }
    }
}
