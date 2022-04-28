namespace Laba2_OOPR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedModelBuilder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DoctorProfiles", "Id", "dbo.DoctorUsers");
            DropForeignKey("dbo.PatientProfiles", "Id", "dbo.PatientUsers");
            DropPrimaryKey("dbo.DoctorUsers");
            DropPrimaryKey("dbo.PatientUsers");
            AlterColumn("dbo.DoctorUsers", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.PatientUsers", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.DoctorUsers", "Id");
            AddPrimaryKey("dbo.PatientUsers", "Id");
            AddForeignKey("dbo.DoctorProfiles", "Id", "dbo.DoctorUsers", "Id");
            AddForeignKey("dbo.PatientProfiles", "Id", "dbo.PatientUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientProfiles", "Id", "dbo.PatientUsers");
            DropForeignKey("dbo.DoctorProfiles", "Id", "dbo.DoctorUsers");
            DropPrimaryKey("dbo.PatientUsers");
            DropPrimaryKey("dbo.DoctorUsers");
            AlterColumn("dbo.PatientUsers", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.DoctorUsers", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.PatientUsers", "Id");
            AddPrimaryKey("dbo.DoctorUsers", "Id");
            AddForeignKey("dbo.PatientProfiles", "Id", "dbo.PatientUsers", "Id");
            AddForeignKey("dbo.DoctorProfiles", "Id", "dbo.DoctorUsers", "Id");
        }
    }
}
