using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Laba2_OOPR.Events;
using Laba2_OOPR.Models;

namespace Laba2_OOPR
{
    public class Doctor : Human, IWorker 
    {
        public Doctor(int age, string name, string surname, string state) : base(age, name, surname, state){}

        public Doctor() { }

        public Doctor(string name) => Name = name;

        //public static event EventHandler<TreatmentArgs> PrescribedTreatment;

        public string Password { get; set; }
        
        public string Login { get; set; }

        public int Salary { get; set; } = 2000;

        public PatientProfile this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //string IWorker<string>.this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
       // public IWorker this[int index] { get => _patientList[index]; set =>_patientList[index] = (Patient)value; }

        private List<Patient> _patientList = new List<Patient>();

        public new void BeHealthy() => base.BeHealthy();

        public int GetPatientAmount() => _patientList.Count;

        public void AddPatient(Patient newPatient) => _patientList.Add(newPatient);

        public void PrescribeTreatment(Patient patient)
        {
            //PrescribedTreatment?.Invoke(this, new TreatmentArgs($"The treatment was Prescribed for{patient.Name}"));
        }

        public void GetPatientInfo(Patient patient)
        {
            patient.ChangeHealthState += PatientInfo;
        }
        private void PatientInfo(Patient patient)
        {
            MessageBox.Show($"Patient name: {patient.Name}, surname: {patient.Surname}\n Disease name: {patient.DiseaseName}, Disease degree: {patient.DiseaseDegree}");
        }

        public void Work()
        {
            DischargePatient.Discharge(_patientList[_patientList.Count-1].Name, _patientList[_patientList.Count - 1].Surname);
            DischargePatient.DischargeTherapy(_patientList[_patientList.Count - 1].Name, _patientList[_patientList.Count - 1].Surname);
            _patientList.RemoveAt(_patientList.Count - 1);
        }
    }
}
