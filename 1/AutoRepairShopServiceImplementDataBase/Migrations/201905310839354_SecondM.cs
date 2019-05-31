namespace AutoRepairShopServiceImplementDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondM : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SOrders", "ImplementerId", "dbo.Implementers");
            DropIndex("dbo.SOrders", new[] { "ImplementerId" });
            DropColumn("dbo.SOrders", "ImplementerId");
            DropTable("dbo.Implementers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Implementers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImplementerFIO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.SOrders", "ImplementerId", c => c.Int());
            CreateIndex("dbo.SOrders", "ImplementerId");
            AddForeignKey("dbo.SOrders", "ImplementerId", "dbo.Implementers", "Id");
        }
    }
}
