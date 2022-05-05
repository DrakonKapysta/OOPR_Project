namespace Laba2_OOPR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Age : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DischargedPatients", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DischargedPatients", "Age");
        }
    }
}
