namespace Clinika.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AllocateMedicines", "ADistrict_Id", c => c.Int());
            AddColumn("dbo.AllocateMedicines", "AUpazila_Id", c => c.Int());
            CreateIndex("dbo.AllocateMedicines", "ADistrict_Id");
            CreateIndex("dbo.AllocateMedicines", "AUpazila_Id");
            AddForeignKey("dbo.AllocateMedicines", "ADistrict_Id", "dbo.Districts", "Id");
            AddForeignKey("dbo.AllocateMedicines", "AUpazila_Id", "dbo.Upazilas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AllocateMedicines", "AUpazila_Id", "dbo.Upazilas");
            DropForeignKey("dbo.AllocateMedicines", "ADistrict_Id", "dbo.Districts");
            DropIndex("dbo.AllocateMedicines", new[] { "AUpazila_Id" });
            DropIndex("dbo.AllocateMedicines", new[] { "ADistrict_Id" });
            DropColumn("dbo.AllocateMedicines", "AUpazila_Id");
            DropColumn("dbo.AllocateMedicines", "ADistrict_Id");
        }
    }
}
