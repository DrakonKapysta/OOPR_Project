using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laba2_OOPR.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laba2_OOPR.Models
{
    public class PatientProfile : BaseRepo
    {
        [ForeignKey("PatientUser")]
        public override int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string State { get; set; }

        public int Age { get; set; }

        public string Problem_description { get; set; } = "None";

        public PatientUser PatientUser { get; set; }

        public virtual ICollection<Extracts> Extracts { get; set; }

    }
}
