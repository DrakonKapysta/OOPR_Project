using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2_OOPR
{
    public class Hospital : IEnumerable
    {
        public Hospital() { }

        public Hospital(Doctor[] doctors, string hospitalName = "MedicHome")
        {
            Doctors = doctors;
            HospitalName = hospitalName;
        }

        public string HospitalName { get; }

        public Doctor[] Doctors; 

        public Doctor this[int index]
        {
            get => Doctors[index];
            set => Doctors[index] = value;
        }
        IEnumerator IEnumerable.GetEnumerator() => Doctors.GetEnumerator();
    }
}
