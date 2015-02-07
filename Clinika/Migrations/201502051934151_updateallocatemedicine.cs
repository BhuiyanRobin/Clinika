namespace Clinika.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateallocatemedicine : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AllocateMedicines", "ADistrict_Id", "dbo.Districts");
            DropForeignKey("dbo.AllocateMedicines", "AUpazila_Id", "dbo.Upazilas");
            DropIndex("dbo.AllocateMedicines", new[] { "ADistrict_Id" });
            DropIndex("dbo.AllocateMedicines", new[] { "AUpazila_Id" });
            DropColumn("dbo.AllocateMedicines", "ADistrict_Id");
            DropColumn("dbo.AllocateMedicines", "AUpazila_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AllocateMedicines", "AUpazila_Id", c => c.Int());
            AddColumn("dbo.AllocateMedicines", "ADistrict_Id", c => c.Int());
            CreateIndex("dbo.AllocateMedicines", "AUpazila_Id");
            CreateIndex("dbo.AllocateMedicines", "ADistrict_Id");
            AddForeignKey("dbo.AllocateMedicines", "AUpazila_Id", "dbo.Upazilas", "Id");
            AddForeignKey("dbo.AllocateMedicines", "ADistrict_Id", "dbo.Districts", "Id");
        }
    }
}
