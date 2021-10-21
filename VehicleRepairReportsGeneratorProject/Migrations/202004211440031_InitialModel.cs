namespace VehicleRepairReportsGeneratorProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Vin = c.String(),
                        LicensePlate = c.String(),
                        Engine_Id = c.Int(),
                        Model_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Engines", t => t.Engine_Id)
                .ForeignKey("dbo.Models", t => t.Model_Id)
                .Index(t => t.Engine_Id)
                .Index(t => t.Model_Id);
            
            CreateTable(
                "dbo.Engines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Displacement = c.Int(nullable: false),
                        HorsePower = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        VinSymbol = c.String(),
                        YearProductionStart = c.Int(nullable: false),
                        YearProductionEnd = c.Int(nullable: false),
                        Make_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Makes", t => t.Make_Id)
                .Index(t => t.Make_Id);
            
            CreateTable(
                "dbo.Makes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        VinSymbol = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ModelEngines",
                c => new
                    {
                        Model_Id = c.Int(nullable: false),
                        Engine_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Model_Id, t.Engine_Id })
                .ForeignKey("dbo.Models", t => t.Model_Id, cascadeDelete: true)
                .ForeignKey("dbo.Engines", t => t.Engine_Id, cascadeDelete: true)
                .Index(t => t.Model_Id)
                .Index(t => t.Engine_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "Model_Id", "dbo.Models");
            DropForeignKey("dbo.Cars", "Engine_Id", "dbo.Engines");
            DropForeignKey("dbo.Models", "Make_Id", "dbo.Makes");
            DropForeignKey("dbo.ModelEngines", "Engine_Id", "dbo.Engines");
            DropForeignKey("dbo.ModelEngines", "Model_Id", "dbo.Models");
            DropIndex("dbo.ModelEngines", new[] { "Engine_Id" });
            DropIndex("dbo.ModelEngines", new[] { "Model_Id" });
            DropIndex("dbo.Models", new[] { "Make_Id" });
            DropIndex("dbo.Cars", new[] { "Model_Id" });
            DropIndex("dbo.Cars", new[] { "Engine_Id" });
            DropTable("dbo.ModelEngines");
            DropTable("dbo.Makes");
            DropTable("dbo.Models");
            DropTable("dbo.Engines");
            DropTable("dbo.Cars");
        }
    }
}
