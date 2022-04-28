namespace Laba2_OOPR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Final : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DoctorProfiles", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.DischargedPatients", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.DoctorUsers", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Extracts", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.PatientProfiles", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.PatientUsers", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PatientUsers", "Timestamp");
            DropColumn("dbo.PatientProfiles", "Timestamp");
            DropColumn("dbo.Extracts", "Timestamp");
            DropColumn("dbo.DoctorUsers", "Timestamp");
            DropColumn("dbo.DischargedPatients", "Timestamp");
            DropColumn("dbo.DoctorProfiles", "Timestamp");
        }
    }
}
