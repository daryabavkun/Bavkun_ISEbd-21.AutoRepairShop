namespace AutoRepairShopServiceImplementDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SClients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientFIO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ImplementerId = c.Int(),
                        Count = c.Int(nullable: false),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        DateImplement = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SClients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Implementers", t => t.ImplementerId)
                .ForeignKey("dbo.Goods", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.ProductId)
                .Index(t => t.ImplementerId);
            
            CreateTable(
                "dbo.Implementers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImplementerFIO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Goods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SComponents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ComponentName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GoodComponents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ComponentId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Good_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Goods", t => t.Good_Id)
                .ForeignKey("dbo.SComponents", t => t.ComponentId, cascadeDelete: true)
                .Index(t => t.ComponentId)
                .Index(t => t.Good_Id);
            
            CreateTable(
                "dbo.SStockComponents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StockId = c.Int(nullable: false),
                        ComponentId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SComponents", t => t.ComponentId, cascadeDelete: true)
                .ForeignKey("dbo.SStocks", t => t.StockId, cascadeDelete: true)
                .Index(t => t.StockId)
                .Index(t => t.ComponentId);
            
            CreateTable(
                "dbo.SStocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StockName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SStockComponents", "StockId", "dbo.SStocks");
            DropForeignKey("dbo.SStockComponents", "ComponentId", "dbo.SComponents");
            DropForeignKey("dbo.GoodComponents", "ComponentId", "dbo.SComponents");
            DropForeignKey("dbo.GoodComponents", "Good_Id", "dbo.Goods");
            DropForeignKey("dbo.SOrders", "ProductId", "dbo.Goods");
            DropForeignKey("dbo.SOrders", "ImplementerId", "dbo.Implementers");
            DropForeignKey("dbo.SOrders", "ClientId", "dbo.SClients");
            DropIndex("dbo.SStockComponents", new[] { "ComponentId" });
            DropIndex("dbo.SStockComponents", new[] { "StockId" });
            DropIndex("dbo.GoodComponents", new[] { "Good_Id" });
            DropIndex("dbo.GoodComponents", new[] { "ComponentId" });
            DropIndex("dbo.SOrders", new[] { "ImplementerId" });
            DropIndex("dbo.SOrders", new[] { "ProductId" });
            DropIndex("dbo.SOrders", new[] { "ClientId" });
            DropTable("dbo.SStocks");
            DropTable("dbo.SStockComponents");
            DropTable("dbo.GoodComponents");
            DropTable("dbo.SComponents");
            DropTable("dbo.Goods");
            DropTable("dbo.Implementers");
            DropTable("dbo.SOrders");
            DropTable("dbo.SClients");
        }
    }
}
