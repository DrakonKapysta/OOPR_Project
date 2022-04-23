using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laba2_OOPR.Models.Base;

namespace Laba2_OOPR.Models
{
    public class PatientUser : BaseRepo
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public virtual PatientProfile Profile { get; set; }
    }
}
