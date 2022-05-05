namespace Laba2_OOPR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class next : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DischargedPatients", "Doctor_Id");
            DropForeignKey("dbo.DoctorProfiles", "DischargedPatients_Id", "dbo.DischargedPatients");
            DropIndex("dbo.DoctorProfiles", new[] { "DischargedPatients_Id" });
            RenameColumn(table: "dbo.DischargedPatients", name: "DischargedPatients_Id", newName: "Doctor_Id");
            CreateIndex("dbo.DischargedPatients", "Doctor_Id");
            AddForeignKey("dbo.DischargedPatients", "Doctor_Id", "dbo.DoctorProfiles", "Id", cascadeDelete: true);
            DropColumn("dbo.DoctorProfiles", "DischargedPatients_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DoctorProfiles", "DischargedPatients_Id", c => c.Int());
            DropForeignKey("dbo.DischargedPatients", "Doctor_Id", "dbo.DoctorProfiles");
            DropIndex("dbo.DischargedPatients", new[] { "Doctor_Id" });
            RenameColumn(table: "dbo.DischargedPatients", name: "Doctor_Id", newName: "DischargedPatients_Id");
            AddColumn("dbo.DischargedPatients", "Doctor_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.DoctorProfiles", "DischargedPatients_Id");
            AddForeignKey("dbo.DoctorProfiles", "DischargedPatients_Id", "dbo.DischargedPatients", "Id");
        }
    }
}
