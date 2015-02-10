namespace Clinika.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Diseases", "MedicineId", "dbo.Medicines");
            DropForeignKey("dbo.Treatments", "ADiseases_DiseasesId", "dbo.Diseases");
            DropForeignKey("dbo.Treatments", "DoctorId", "dbo.DoctorEntries");
            DropForeignKey("dbo.Treatments", "DoseId", "dbo.Doses");
            DropForeignKey("dbo.Treatments", "MealId", "dbo.Meals");
            DropForeignKey("dbo.Treatments", "MedicineId", "dbo.Medicines");
            DropIndex("dbo.Diseases", new[] { "MedicineId" });
            DropIndex("dbo.Treatments", new[] { "DoctorId" });
            DropIndex("dbo.Treatments", new[] { "MedicineId" });
            DropIndex("dbo.Treatments", new[] { "DoseId" });
            DropIndex("dbo.Treatments", new[] { "MealId" });
            DropIndex("dbo.Treatments", new[] { "ADiseases_DiseasesId" });
            CreateTable(
                "dbo.DieaseAffectInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DistrictId = c.Int(nullable: false),
                        DiseasesId = c.Int(nullable: false),
                        FromDateTime = c.DateTime(nullable: false),
                        ToDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Medicines", "Power", c => c.String(nullable: false));
            AddColumn("dbo.Medicines", "PowerUnit", c => c.String(nullable: false));
            AddColumn("dbo.Districts", "Population", c => c.Int(nullable: false));
            AddColumn("dbo.Diseases", "PreferdMedicien", c => c.String(nullable: false));
            AlterColumn("dbo.Medicines", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Diseases", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Diseases", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Diseases", "TreatmentProcedure", c => c.String(nullable: false));
            DropColumn("dbo.Medicines", "Weight");
            DropColumn("dbo.Upazilas", "Population");
            DropColumn("dbo.Diseases", "MedicineId");
            DropTable("dbo.Treatments");
        }
        
        public override void Down()
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
                        DiseaseId = c.Int(nullable: false),
                        MedicineId = c.Int(nullable: false),
                        DoseId = c.Int(nullable: false),
                        MealId = c.Int(nullable: false),
                        QuantityGiven = c.String(),
                        Note = c.String(),
                        ADiseases_DiseasesId = c.Int(),
                    })
                .PrimaryKey(t => t.TreatmentId);
            
            AddColumn("dbo.Diseases", "MedicineId", c => c.Int(nullable: false));
            AddColumn("dbo.Upazilas", "Population", c => c.Int(nullable: false));
            AddColumn("dbo.Medicines", "Weight", c => c.String());
            AlterColumn("dbo.Diseases", "TreatmentProcedure", c => c.String());
            AlterColumn("dbo.Diseases", "Description", c => c.String());
            AlterColumn("dbo.Diseases", "Name", c => c.String());
            AlterColumn("dbo.Medicines", "Name", c => c.String());
            DropColumn("dbo.Diseases", "PreferdMedicien");
            DropColumn("dbo.Districts", "Population");
            DropColumn("dbo.Medicines", "PowerUnit");
            DropColumn("dbo.Medicines", "Power");
            DropTable("dbo.DieaseAffectInfoes");
            CreateIndex("dbo.Treatments", "ADiseases_DiseasesId");
            CreateIndex("dbo.Treatments", "MealId");
            CreateIndex("dbo.Treatments", "DoseId");
            CreateIndex("dbo.Treatments", "MedicineId");
            CreateIndex("dbo.Treatments", "DoctorId");
            CreateIndex("dbo.Diseases", "MedicineId");
            AddForeignKey("dbo.Treatments", "MedicineId", "dbo.Medicines", "MedicineId", cascadeDelete: true);
            AddForeignKey("dbo.Treatments", "MealId", "dbo.Meals", "MealId", cascadeDelete: true);
            AddForeignKey("dbo.Treatments", "DoseId", "dbo.Doses", "DoseId", cascadeDelete: true);
            AddForeignKey("dbo.Treatments", "DoctorId", "dbo.DoctorEntries", "DoctorId", cascadeDelete: true);
            AddForeignKey("dbo.Treatments", "ADiseases_DiseasesId", "dbo.Diseases", "DiseasesId");
            AddForeignKey("dbo.Diseases", "MedicineId", "dbo.Medicines", "MedicineId", cascadeDelete: true);
        }
    }
}
