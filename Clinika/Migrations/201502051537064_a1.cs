namespace Clinika.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AllocateMedicines", "AMedicine_MedicineId", "dbo.Medicines");
            DropIndex("dbo.AllocateMedicines", new[] { "AMedicine_MedicineId" });
            RenameColumn(table: "dbo.AllocateMedicines", name: "AMedicine_MedicineId", newName: "MedicineId");
            AlterColumn("dbo.AllocateMedicines", "MedicineId", c => c.Int(nullable: false));
            CreateIndex("dbo.AllocateMedicines", "MedicineId");
            AddForeignKey("dbo.AllocateMedicines", "MedicineId", "dbo.Medicines", "MedicineId", cascadeDelete: true);
            DropColumn("dbo.AllocateMedicines", "MedicinId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AllocateMedicines", "MedicinId", c => c.Int(nullable: false));
            DropForeignKey("dbo.AllocateMedicines", "MedicineId", "dbo.Medicines");
            DropIndex("dbo.AllocateMedicines", new[] { "MedicineId" });
            AlterColumn("dbo.AllocateMedicines", "MedicineId", c => c.Int());
            RenameColumn(table: "dbo.AllocateMedicines", name: "MedicineId", newName: "AMedicine_MedicineId");
            CreateIndex("dbo.AllocateMedicines", "AMedicine_MedicineId");
            AddForeignKey("dbo.AllocateMedicines", "AMedicine_MedicineId", "dbo.Medicines", "MedicineId");
        }
    }
}
