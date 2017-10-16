namespace Online_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartInitial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Cart_Id", c => c.Int());
            CreateIndex("dbo.Products", "Cart_Id");
            AddForeignKey("dbo.Products", "Cart_Id", "dbo.Carts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.Products", new[] { "Cart_Id" });
            DropColumn("dbo.Products", "Cart_Id");
        }
    }
}
