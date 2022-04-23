using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2_OOPR.Models.ModelsInit
{
    public class PatientUserRepo : Userinitializer<PatientUser>
    {
        public PatientUser GetOne(string login)
        {
            try
            {
                return Context.PatientUsers.First(x => x.Login == login);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
