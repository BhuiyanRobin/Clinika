namespace Clinika.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceCenters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        Password = c.String(),
                        DistrictId = c.Int(nullable: false),
                        UpazilaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .ForeignKey("dbo.Upazilas", t => t.UpazilaId, cascadeDelete: true)
                .Index(t => t.DistrictId)
                .Index(t => t.UpazilaId);
            
            CreateTable(
                "dbo.Upazilas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Population = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DistrictUpazilas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DistrictId = c.Int(nullable: false),
                        UpazilaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        MedicineId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Weight = c.String(),
                    })
                .PrimaryKey(t => t.MedicineId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceCenters", "UpazilaId", "dbo.Upazilas");
            DropForeignKey("dbo.ServiceCenters", "DistrictId", "dbo.Districts");
            DropIndex("dbo.ServiceCenters", new[] { "UpazilaId" });
            DropIndex("dbo.ServiceCenters", new[] { "DistrictId" });
            DropTable("dbo.Medicines");
            DropTable("dbo.DistrictUpazilas");
            DropTable("dbo.Upazilas");
            DropTable("dbo.ServiceCenters");
            DropTable("dbo.Districts");
        }
    }
}
