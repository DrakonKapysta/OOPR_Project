using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laba2_OOPR.Models.Base;
using Laba2_OOPR.Events;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Laba2_OOPR.Models
{
    public class DoctorProfile : BaseRepo, IWorker
    {
        [ForeignKey("DoctorUser")]
        public override int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string State { get; set; }

        public event EventHandler<TreatmentArgs> PrescribedTreatment;

        public void PrescribeTreatment(PatientProfile patient, string treatment)
        {
            PrescribedTreatment?.Invoke(this, new TreatmentArgs(patient,treatment));
        }

        public void Work()
        {
            throw new NotImplementedException();
        }

        public int Age { get; set; }

        public string Catagery { get; set; } = "Intern";

        public virtual DoctorUser DoctorUser { get; set; }

        private List<PatientProfile> _patientList = new List<PatientProfile>();

        public void AddPatient(PatientProfile newPatient) => _patientList.Add(newPatient);

        public PatientProfile this[int index] { get => _patientList[index]; set => _patientList[index] = value; }

        public int GetPatientAmount() => _patientList.Count;

        public virtual DischargedPatients DischargedPatients { get; set; }
    }
}
