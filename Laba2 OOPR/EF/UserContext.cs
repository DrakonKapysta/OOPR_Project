using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Laba2_OOPR.Models;
using System.Data.Entity.Migrations;

namespace Laba2_OOPR.EF
{
    public class UserContext : DbContext
    {
        public UserContext() : base("Dbconnection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
    //        modelBuilder.Entity<PatientUser>().Property(p => p.Id)
    //.HasDatabaseGeneratedOption(System.ComponentModel
    //.DataAnnotations.Schema.DatabaseGeneratedOption.None);
    //        modelBuilder.Entity<DoctorUser>().Property(p => p.Id)
    //.HasDatabaseGeneratedOption(System.ComponentModel
    //.DataAnnotations.Schema.DatabaseGeneratedOption.None);
        }
        public virtual DbSet<PatientProfile> PatientProfiles { get; set; }

        public virtual DbSet<PatientUser> PatientUsers { get; set; }

        public virtual DbSet<DoctorProfile> DoctorProfiles { get; set; }

        public virtual DbSet<DoctorUser> DoctorUsers { get; set; }

        public virtual DbSet<Extracts> Extracts { get; set; }

        public virtual DbSet<DischargedPatients> DischargedPatients {get; set;}

    }
}
