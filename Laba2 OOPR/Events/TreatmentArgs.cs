using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laba2_OOPR.Models;

namespace Laba2_OOPR.Events
{
    public class TreatmentArgs : EventArgs
    {
        public TreatmentArgs(PatientProfile profile, string msg)
        {
            message = msg;
            this.profile = profile;
        }

        public readonly string message;
        public readonly PatientProfile profile;
    }
}
