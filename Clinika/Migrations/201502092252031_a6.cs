namespace Clinika.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Treatments",
                c => new
                    {
                        TreatmentId = c.Int(nullable: false, identity: true),
                        VoterId = c.String(),
                        Name = c.String(),
                        Address = c.String(),
                        DateOfBirht = c.DateTime(nullable: false),
                        ServiceGiven = c.Int(nullable: false),
                        Observation = c.String(),
                        Date = c.DateTime(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        DiseasesId = c.Int(nullable: false),
                        MedicineId = c.Int(nullable: false),
                        DoseId = c.Int(nullable: false),
                        MealId = c.Int(nullable: false),
                        QuantityGiven = c.String(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.TreatmentId)
                .ForeignKey("dbo.Diseases", t => t.DiseasesId, cascadeDelete: true)
                .ForeignKey("dbo.DoctorEntries", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Doses", t => t.DoseId, cascadeDelete: true)
                .ForeignKey("dbo.Meals", t => t.MealId, cascadeDelete: true)
                .ForeignKey("dbo.Medicines", t => t.MedicineId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.DiseasesId)
                .Index(t => t.MedicineId)
                .Index(t => t.DoseId)
                .Index(t => t.MealId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Treatments", "MedicineId", "dbo.Medicines");
            DropForeignKey("dbo.Treatments", "MealId", "dbo.Meals");
            DropForeignKey("dbo.Treatments", "DoseId", "dbo.Doses");
            DropForeignKey("dbo.Treatments", "DoctorId", "dbo.DoctorEntries");
            DropForeignKey("dbo.Treatments", "DiseasesId", "dbo.Diseases");
            DropIndex("dbo.Treatments", new[] { "MealId" });
            DropIndex("dbo.Treatments", new[] { "DoseId" });
            DropIndex("dbo.Treatments", new[] { "MedicineId" });
            DropIndex("dbo.Treatments", new[] { "DiseasesId" });
            DropIndex("dbo.Treatments", new[] { "DoctorId" });
            DropTable("dbo.Treatments");
        }
    }
}
