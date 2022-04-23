using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laba2_OOPR.Models;
using Laba2_OOPR.Models.Base;
using Laba2_OOPR.Models.ModelsInit;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Laba2_OOPR.Models
{
    public class DischargedPatients :BaseRepo
    {

        public string PFirstName{ get; set; }

        public string PLastName { get; set; }

        [ForeignKey("DoctorProfiles")]
        public int Doctor_Id { get; set; }

        public ICollection<DoctorProfile> DoctorProfiles { get; set; }
    }
}
