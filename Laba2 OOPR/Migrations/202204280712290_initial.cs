namespace Laba2_OOPR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoctorProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        State = c.String(),
                        Age = c.Int(nullable: false),
                        Catagery = c.String(),
                        DischargedPatients_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DischargedPatients", t => t.DischargedPatients_Id)
                .ForeignKey("dbo.DoctorUsers", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.DischargedPatients_Id);
            
            CreateTable(
                "dbo.DischargedPatients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PFirstName = c.String(),
                        PLastName = c.String(),
                        Doctor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DoctorUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Extracts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        extracts = c.String(),
                        Doctor_Id = c.Int(nullable: false),
                        Patient_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DoctorProfiles", t => t.Doctor_Id, cascadeDelete: true)
                .ForeignKey("dbo.PatientProfiles", t => t.Patient_Id, cascadeDelete: true)
                .Index(t => t.Doctor_Id)
                .Index(t => t.Patient_Id);
            
            CreateTable(
                "dbo.PatientProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        State = c.String(),
                        Age = c.Int(nullable: false),
                        Problem_description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PatientUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.PatientUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Extracts", "Patient_Id", "dbo.PatientProfiles");
            DropForeignKey("dbo.PatientProfiles", "Id", "dbo.PatientUsers");
            DropForeignKey("dbo.Extracts", "Doctor_Id", "dbo.DoctorProfiles");
            DropForeignKey("dbo.DoctorProfiles", "Id", "dbo.DoctorUsers");
            DropForeignKey("dbo.DoctorProfiles", "DischargedPatients_Id", "dbo.DischargedPatients");
            DropIndex("dbo.PatientProfiles", new[] { "Id" });
            DropIndex("dbo.Extracts", new[] { "Patient_Id" });
            DropIndex("dbo.Extracts", new[] { "Doctor_Id" });
            DropIndex("dbo.DoctorProfiles", new[] { "DischargedPatients_Id" });
            DropIndex("dbo.DoctorProfiles", new[] { "Id" });
            DropTable("dbo.PatientUsers");
            DropTable("dbo.PatientProfiles");
            DropTable("dbo.Extracts");
            DropTable("dbo.DoctorUsers");
            DropTable("dbo.DischargedPatients");
            DropTable("dbo.DoctorProfiles");
        }
    }
}
