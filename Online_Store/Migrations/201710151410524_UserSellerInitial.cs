namespace Online_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserSellerInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category = c.String(),
                        Date = c.DateTime(nullable: false),
                        PaymentMethod = c.String(),
                        Instock = c.Boolean(nullable: false),
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
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sellers", "UserId", "dbo.Users");
            DropIndex("dbo.Sellers", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Sellers");
            DropTable("dbo.Products");
        }
    }
}
