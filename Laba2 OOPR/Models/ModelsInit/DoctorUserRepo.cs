using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2_OOPR.Models.ModelsInit
{
    public class DoctorUserRepo : Userinitializer<DoctorUser>
    {
        public DoctorUser GetOne(string login)
        {
            try
            {
                return Context.DoctorUsers.First(x => x.Login == login);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
