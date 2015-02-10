namespace Clinika.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Treatments", "QuantityGiven", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Treatments", "QuantityGiven", c => c.String());
        }
    }
}
