using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laba2_OOPR.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laba2_OOPR.Models
{
    public class DoctorUser :BaseRepo
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public virtual DoctorProfile Profile { get; set; }

    }
}
