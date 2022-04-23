using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2_OOPR.Models.ModelsInit
{
    public class PatientProfileRepo : Userinitializer<PatientProfile>
    {
        public PatientProfile GetOne(string Name)
        {
            try
            {
                return Context.PatientProfiles.First(x => x.FirstName == Name);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
