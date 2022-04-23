using Laba2_OOPR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2_OOPR
{
     public class Patient : Human, IWorker, IDisease
    {
        public Patient(string name, string surname, string state, int age, string problemDec = "No description") : base(age, name, surname, state)
        {
            ProblemDescription = problemDec; 
        }
        public Patient() { }

        public Patient(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public delegate void HealthStateHandler(Patient patient);

        public string ProblemDescription { get; set; }

        public string HealingDoctor { get; set; }

        public new bool BeHealthy { get; set; } = false;

        public int Salary { get; set; }

        public string DiseaseName { get; set; } = "Cold";

        public string Symptoms { get; set; } = "Sore throat";

        public int DiseaseDegree { get; set; } = 1;

        PatientProfile IWorker.this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IWorker this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Work(){}

        public HealthStateHandler ChangeHealthState;

        //public void GetTreatmentInfo()
        //{
        //    Doctor.PrescribedTreatment += delegate (object sender, Events.TreatmentArgs e)
        //    {
        //        if (sender is Doctor doc)
        //        {
        //            System.Windows.Forms.MessageBox.Show(e.message + $" was delivered by {doc.Name}");
        //        }
        //    };
        //}

        public void ChangeDieseaseDegree(int degree)
        {
            DiseaseDegree = degree;
            ChangeHealthState?.Invoke(this);
        }
    }
}
