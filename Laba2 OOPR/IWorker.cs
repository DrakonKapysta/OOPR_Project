using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laba2_OOPR.Models;

namespace Laba2_OOPR
{
   public interface IWorker
    {

        void Work();

        PatientProfile this[int index]
        {
            get;
            set;
        }
    }
}
