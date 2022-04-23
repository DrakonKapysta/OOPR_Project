using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2_OOPR
{
   public interface IDisease
    {
        string DiseaseName { get; set; }
        string Symptoms { get; set; }
        int DiseaseDegree { get; set; }
    }
}
