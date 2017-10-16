namespace Online_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initcommitagain : DbMigration
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
                        Instock = c.Boolean(nullable: false),
                        Feedback_Id = c.Int(),
                        PaymentMethod_Id = c.Int(),
                        Sale_Id = c.Int(),
                        Seller_UserId = c.Int(),
                        ShippingDetails_Id = c.Int(),
                        Cart_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Feedbacks", t => t.Feedback_Id)
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethod_Id)
                .ForeignKey("dbo.Sales", t => t.Sale_Id)
                .ForeignKey("dbo.Sellers", t => t.Seller_UserId)
                .ForeignKey("dbo.ShippingDetails", t => t.ShippingDetails_Id)
                .ForeignKey("dbo.Carts", t => t.Cart_Id)
                .Index(t => t.Feedback_Id)
                .Index(t => t.PaymentMethod_Id)
                .Index(t => t.Sale_Id)
                .Index(t => t.Seller_UserId)
                .Index(t => t.ShippingDetails_Id)
                .Index(t => t.Cart_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
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
                "dbo.PaymentMethods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentMethodName = c.String(),
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
            
            CreateTable(
                "dbo.CategoryProducts",
                c => new
                    {
                        Category_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_Id, t.Product_Id })
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.Products", "ShippingDetails_Id", "dbo.ShippingDetails");
            DropForeignKey("dbo.Products", "Seller_UserId", "dbo.Sellers");
            DropForeignKey("dbo.Sellers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.Products", "Sale_Id", "dbo.Sales");
            DropForeignKey("dbo.Products", "PaymentMethod_Id", "dbo.PaymentMethods");
            DropForeignKey("dbo.Products", "Feedback_Id", "dbo.Feedbacks");
            DropForeignKey("dbo.CategoryProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.CategoryProducts", "Category_Id", "dbo.Categories");
            DropIndex("dbo.CategoryProducts", new[] { "Product_Id" });
            DropIndex("dbo.CategoryProducts", new[] { "Category_Id" });
            DropIndex("dbo.Users", new[] { "Cart_Id" });
            DropIndex("dbo.Sellers", new[] { "UserId" });
            DropIndex("dbo.Products", new[] { "Cart_Id" });
            DropIndex("dbo.Products", new[] { "ShippingDetails_Id" });
            DropIndex("dbo.Products", new[] { "Seller_UserId" });
            DropIndex("dbo.Products", new[] { "Sale_Id" });
            DropIndex("dbo.Products", new[] { "PaymentMethod_Id" });
            DropIndex("dbo.Products", new[] { "Feedback_Id" });
            DropTable("dbo.CategoryProducts");
            DropTable("dbo.ShippingDetails");
            DropTable("dbo.Users");
            DropTable("dbo.Sellers");
            DropTable("dbo.Sales");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Carts");
        }
    }
}
