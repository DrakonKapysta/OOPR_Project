using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laba2_OOPR.EF;
using Laba2_OOPR.Models;
using Laba2_OOPR.Models.Base;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laba2_OOPR.Models
{
    public class Extracts : BaseRepo
    {
        public string extracts { get; set; }
        [ForeignKey("DoctorProfile")]
        public int Doctor_Id { get; set; }
        [ForeignKey("PatientProfile")]
        public int Patient_Id { get; set; }


        public DoctorProfile DoctorProfile { get; set; }

        public PatientProfile PatientProfile { get; set; }
    }
}
