namespace Online_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        PaymentMethod = c.Int(nullable: false),
                        Instock = c.Boolean(nullable: false),
                        Categories_Id = c.Int(),
                        Feedback_Id = c.Int(),
                        Sale_Id = c.Int(),
                        Seller_UserId = c.Int(),
                        ShippingDetails_Id = c.Int(),
                        Cart_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Categories_Id)
                .ForeignKey("dbo.Feedbacks", t => t.Feedback_Id)
                .ForeignKey("dbo.Sales", t => t.Sale_Id)
                .ForeignKey("dbo.Sellers", t => t.Seller_UserId)
                .ForeignKey("dbo.ShippingDetails", t => t.ShippingDetails_Id)
                .ForeignKey("dbo.Carts", t => t.Cart_Id)
                .Index(t => t.Categories_Id)
                .Index(t => t.Feedback_Id)
                .Index(t => t.Sale_Id)
                .Index(t => t.Seller_UserId)
                .Index(t => t.ShippingDetails_Id)
                .Index(t => t.Cart_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Comment = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        PriceReduction = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 12),
                        Password = c.String(nullable: false),
                        SellerId = c.Int(nullable: false),
                        Cart_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.Cart_Id)
                .Index(t => t.Cart_Id);
            
            CreateTable(
                "dbo.ShippingDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeliveryTIme = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.Products", "ShippingDetails_Id", "dbo.ShippingDetails");
            DropForeignKey("dbo.Products", "Seller_UserId", "dbo.Sellers");
            DropForeignKey("dbo.Sellers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.Products", "Sale_Id", "dbo.Sales");
            DropForeignKey("dbo.Products", "Feedback_Id", "dbo.Feedbacks");
            DropForeignKey("dbo.Products", "Categories_Id", "dbo.Categories");
            DropIndex("dbo.Users", new[] { "Cart_Id" });
            DropIndex("dbo.Sellers", new[] { "UserId" });
            DropIndex("dbo.Products", new[] { "Cart_Id" });
            DropIndex("dbo.Products", new[] { "ShippingDetails_Id" });
            DropIndex("dbo.Products", new[] { "Seller_UserId" });
            DropIndex("dbo.Products", new[] { "Sale_Id" });
            DropIndex("dbo.Products", new[] { "Feedback_Id" });
            DropIndex("dbo.Products", new[] { "Categories_Id" });
            DropTable("dbo.ShippingDetails");
            DropTable("dbo.Users");
            DropTable("dbo.Sellers");
            DropTable("dbo.Sales");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Carts");
        }
    }
}
