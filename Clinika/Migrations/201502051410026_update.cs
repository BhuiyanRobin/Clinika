namespace Clinika.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoctorEntries",
                c => new
                    {
                        DoctorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Degree = c.String(),
                        Specialization = c.String(),
                    })
                .PrimaryKey(t => t.DoctorId);
            
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
                        DiseaseId = c.Int(nullable: false),
                        MedicineId = c.Int(nullable: false),
                        DoseId = c.Int(nullable: false),
                        MealId = c.Int(nullable: false),
                        QuantityGiven = c.String(),
                        Note = c.String(),
                        ADiseases_DiseasesId = c.Int(),
                    })
                .PrimaryKey(t => t.TreatmentId)
                .ForeignKey("dbo.Diseases", t => t.ADiseases_DiseasesId)
                .ForeignKey("dbo.DoctorEntries", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Doses", t => t.DoseId, cascadeDelete: true)
                .ForeignKey("dbo.Meals", t => t.MealId, cascadeDelete: true)
                .ForeignKey("dbo.Medicines", t => t.MedicineId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.MedicineId)
                .Index(t => t.DoseId)
                .Index(t => t.MealId)
                .Index(t => t.ADiseases_DiseasesId);
            
            CreateTable(
                "dbo.Doses",
                c => new
                    {
                        DoseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DoseId);
            
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        MealId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.MealId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Treatments", "MedicineId", "dbo.Medicines");
            DropForeignKey("dbo.Treatments", "MealId", "dbo.Meals");
            DropForeignKey("dbo.Treatments", "DoseId", "dbo.Doses");
            DropForeignKey("dbo.Treatments", "DoctorId", "dbo.DoctorEntries");
            DropForeignKey("dbo.Treatments", "ADiseases_DiseasesId", "dbo.Diseases");
            DropIndex("dbo.Treatments", new[] { "ADiseases_DiseasesId" });
            DropIndex("dbo.Treatments", new[] { "MealId" });
            DropIndex("dbo.Treatments", new[] { "DoseId" });
            DropIndex("dbo.Treatments", new[] { "MedicineId" });
            DropIndex("dbo.Treatments", new[] { "DoctorId" });
            DropTable("dbo.Meals");
            DropTable("dbo.Doses");
            DropTable("dbo.Treatments");
            DropTable("dbo.DoctorEntries");
        }
    }
}
