namespace Clinika.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allocateMedicine : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AllocateMedicines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceCenterId = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        MedicinId = c.Int(nullable: false),
                        DistrictUpazilaId = c.Int(nullable: false),
                        ADistrict_Id = c.Int(),
                        AUpazila_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Districts", t => t.ADistrict_Id)
                .ForeignKey("dbo.ServiceCenters", t => t.ServiceCenterId, cascadeDelete: true)
                .ForeignKey("dbo.Upazilas", t => t.AUpazila_Id)
                .Index(t => t.ServiceCenterId)
                .Index(t => t.ADistrict_Id)
                .Index(t => t.AUpazila_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AllocateMedicines", "AUpazila_Id", "dbo.Upazilas");
            DropForeignKey("dbo.AllocateMedicines", "ServiceCenterId", "dbo.ServiceCenters");
            DropForeignKey("dbo.AllocateMedicines", "ADistrict_Id", "dbo.Districts");
            DropIndex("dbo.AllocateMedicines", new[] { "AUpazila_Id" });
            DropIndex("dbo.AllocateMedicines", new[] { "ADistrict_Id" });
            DropIndex("dbo.AllocateMedicines", new[] { "ServiceCenterId" });
            DropTable("dbo.AllocateMedicines");
        }
    }
}
