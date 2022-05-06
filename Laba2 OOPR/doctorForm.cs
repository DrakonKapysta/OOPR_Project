﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Laba2_OOPR.Models.Base;
using Laba2_OOPR.Models;
using Laba2_OOPR.EF;
using Laba2_OOPR.Models.ModelsInit;
using System.Data.Entity;

namespace Laba2_OOPR
{
    public partial class doctorForm : Form
    {
        protected internal DoctorUser _doctor = null;

        public doctorForm(mainForm form, BaseRepo user)
        {
            _doctor = (DoctorUser)user;
            _mainForm = form;
            InitializeComponent();
        }

        private mainForm _mainForm;

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void doctorForm_Load(object sender, EventArgs e)
        {
            this.Text = _doctor.Profile.FirstName + " " + _doctor.Profile.LastName;
            using (var _db = new PatientProfileRepo())
            {
                var patientList = _db.GetAll();
                foreach (var patient in patientList)
                {
                    comboBox1.Items.Add(patient.FirstName + " " + patient.LastName);
                }
            }
            menuStrip1.Visible = true;
        }

        private void doctorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _mainForm.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = comboBox1.SelectedItem.ToString().Split(' ')[0];
            using (var _db = new PatientProfileRepo())
            {
                var patient = _db.GetOne(name);
                textBox1.Text = patient.FirstName;
                textBox2.Text = patient.LastName;
                textBox3.Text = patient.Age.ToString();
                textBox4.Text = patient.State;
            }
            //PatientReader.ReadPatientInfo(this);
            //if(проблемаToolStripMenuItem1.Text == "Приховати проблему")
            //{
            //    PatientReader.ReadPatientProblemDescription(this);
            //}

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void проблемаToolStripMenuItem1_Click(object sender, EventArgs e)
        {   
            if(comboBox1.SelectedIndex < 0 && проблемаToolStripMenuItem1.Text == "Показати проблему")
            {
                MessageBox.Show("Виберіть пацієнта.");
            }
            else if (проблемаToolStripMenuItem1.Text == "Приховати проблему")
            {
                panel1.Visible = false;
                panel2.Visible = true;
                richTextBox1.Clear();
                проблемаToolStripMenuItem1.Text = "Показати проблему";
            }
            else 
            {
                if (проблемаToolStripMenuItem1.Text == "Показати проблему")
                {
                    panel1.Visible = true;
                    panel2.Visible = false;
                    using (var _db = new PatientProfileRepo())
                    {
                        var problem = _db.GetOne(textBox1.Text).Problem_description;
                        richTextBox1.Text = problem;
                    }
                    проблемаToolStripMenuItem1.Text = "Приховати проблему";
                }
                else
                {
                    panel1.Visible = false;
                    panel2.Visible = true;
                    richTextBox1.Clear();
                    проблемаToolStripMenuItem1.Text = "Показати проблему";
                }
            }
        }

        private void назначитиДоглядальникаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBox2.SelectAll();
            if (comboBox2.SelectedText == "Медсестра" || comboBox2.SelectedText == "Лікар")
            {
                MessageBox.Show("Доглядача призначенно.");
            }
            else
            {
                MessageBox.Show("Вибиріть доглядача!");
            }
        }

        private void назначитиЛікуванняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text =="")
            {
                MessageBox.Show("Виберіть пацієнта.");
            }
            else
            {
                treatmentForm treatment = new treatmentForm(this);
                treatment.TreatmentDescribed += Treatment_TreatmentDescribed;
                treatment.Visible = true;
            }
        }

        private void Treatment_TreatmentDescribed(object sender, string e)
        {
            MessageBox.Show(e);
            PatientProfile patient = new PatientProfile();
            using (var _db = new PatientProfileRepo())
            {
                patient = _db.GetOne(textBox1.Text);
            }
            Extracts extracts = new Extracts { extracts = e, Doctor_Id = _doctor.Id, Patient_Id = patient.Id };
            using (var _db = new ExtractsRepo())
            {
                _db.Add(extracts);
            }
            _doctor.Profile.PrescribeTreatment(patient, e);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void виписатиПацієнтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idToDel;
            PatientProfile patientToDischarg = null;
            using (var _db = new PatientProfileRepo())
            {
                PatientProfile patientToDel = _db.GetOne(textBox1.Text);
                idToDel = patientToDel.Id;
                patientToDischarg = patientToDel;
                _db.Delete(patientToDel);
            }
            using (var _db = new PatientUserRepo())
            {
                var userToDel = _db.GetOne(idToDel);
                
                _db.Delete(userToDel);
            }
            using (var _db = new DischargedPatientsRepo())
            {
                var dPerson = new DischargedPatients { PFirstName = patientToDischarg.FirstName, PLastName = patientToDischarg.LastName, Doctor_Id = _doctor.Id, Age = patientToDischarg.Age };
                _db.Add(dPerson);
            }
            comboBox1.Items.Remove(comboBox1.SelectedItem);
            comboBox2.Items.Remove(comboBox2.SelectedItem);
            richTextBox1.Clear();
            if (comboBox1.Items.Count == 0)
            {
                comboBox1.SelectedIndex = -1;
                comboBox1.Text = "";
                comboBox1.Enabled = false;
                comboBox2.SelectedIndex = -1;
                comboBox2.Text = "";
                comboBox2.Enabled = false;
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            CheckProblem();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            CheckProblem();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }
        private void CheckProblem()
        {
            if (comboBox1.SelectedIndex < 0 && проблемаToolStripMenuItem1.Text == "Показати проблему")
            {
                MessageBox.Show("Виберіть пацієнта.");
            }
            else if (проблемаToolStripMenuItem1.Text == "Приховати проблему")
            {
                panel1.Visible = false;
                panel2.Visible = true;
                richTextBox1.Clear();
                проблемаToolStripMenuItem1.Text = "Показати проблему";
            }
            else
            {
                if (проблемаToolStripMenuItem1.Text == "Показати проблему")
                {
                    panel1.Visible = true;
                    panel2.Visible = false;
                    using (var _db = new PatientProfileRepo())
                    {
                        var problem = _db.GetOne(textBox1.Text).Problem_description;
                        richTextBox1.Text = problem;
                    }
                    проблемаToolStripMenuItem1.Text = "Приховати проблему";
                }
                else
                {
                    panel1.Visible = false;
                    panel2.Visible = true;
                    richTextBox1.Clear();
                    проблемаToolStripMenuItem1.Text = "Показати проблему";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var _db = new PatientProfileRepo())
            {
                var pList = _db.GetAll();
                foreach (var item in pList)
                {
                    _doctor.Profile.AddPatient(item);
                }
                for (int i = 0; i < _doctor.Profile.GetPatientAmount(); i++)
                {
                    MessageBox.Show(_doctor.Profile[i].FirstName + " " + _doctor.Profile[i].LastName);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            _mainForm.Visible = true;
            this.Hide();
        }

        private void виписаніПацієнтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var _db = new DischargedPatientsRepo())
            {
                var dPatient = _db.GetAll().Where(x => x.Doctor_Id == _doctor.Id);
                int count = _db.GetAll().Count(x => x.Doctor_Id == _doctor.Id);
                MessageBox.Show("Загальна к-сть виписаних пацієнтів: " + count, _doctor.Profile.FirstName + " " + _doctor.Profile.LastName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                foreach (var item in dPatient)
                {
                    MessageBox.Show(item.PFirstName + " " + item.PLastName);
                }
            }
        }

        private void найстаршийПацієнтToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (var _db = new UserContext())
            {
                var maxAge = _db.DischargedPatients.Where(p => p.Doctor_Id == _doctor.Id).Max(x => x.Age);
                MessageBox.Show($"Найстарший виписаний пацієнт {maxAge} років.");
            }
        }

        private void наймолодшийПацієнтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var _db = new UserContext())
            {
                var minAge = _db.DischargedPatients.Where(p => p.Doctor_Id == _doctor.Id).Min(x => x.Age);
                MessageBox.Show($"Наймолодший виписаний пацієнт {minAge} років.");
            }
        }

        private void середнійВікПацієнтівToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var _db = new UserContext())
            {
                var averageAge = _db.DischargedPatients.Where(p => p.Doctor_Id == _doctor.Id).Average(x => x.Age);
                MessageBox.Show($"Середній вік виписаних пацієнтів {averageAge} років.");
            }
        }

        private void обєднанняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var _db = new UserContext())
            {
                var union = _db.DischargedPatients.Where(p => p.Doctor_Id == 2).Union(_db.DischargedPatients.Where(x => x.Age >= 18));
                foreach (var item in union)
                {
                    MessageBox.Show($"{item.PFirstName} {item.PLastName} {item.Age}");
                }
            }
        }

        private void перетинToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var _db = new UserContext())
            {
                var intersect = _db.DischargedPatients.Where(x => x.Doctor_Id == _doctor.Id).Intersect(_db.DischargedPatients.Where(p => p.Age > 30));
                foreach (var item in intersect)
                {
                    MessageBox.Show($"{item.PFirstName} {item.PLastName} {item.Age}");
                }
            }
        }

        private void виключенняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var _db = new UserContext())
            {
                var except = _db.DischargedPatients.Where(x => x.Age > 15).Except(_db.DischargedPatients.Where(p => p.Doctor_Id == _doctor.Id));
                foreach (var item in except)
                {
                    MessageBox.Show($"{item.PFirstName} {item.PLastName} {item.Age}");
                }
            }
        }

        private void зєднанняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var _db = new UserContext())
            {
                var join = _db.DoctorProfiles.Join(_db.DischargedPatients, p => p.Id, c => c.Doctor_Id, (p, c) => new { p.FirstName, p.LastName, c.PFirstName, c.PLastName, c.Age });
                foreach (var item in join)
                {
                    MessageBox.Show($"Пацієнт: {item.PFirstName} {item.PLastName} {item.Age}", $"Доктор: {item.FirstName} {item.LastName}");
                }
            }
        }

        private void групуванняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var _db = new UserContext())
            {
                var group = _db.Extracts.GroupBy(p => p.DoctorProfile.FirstName);
                foreach (var item in group)
                {
                    MessageBox.Show(item.Key);
                    foreach (var item2 in item)
                    {
                        MessageBox.Show(item2.extracts);
                    }
                }
            }
        }

        private void сортуванняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var _db = new UserContext())
            {
                //var sortByAge = _db.DischargedPatients.OrderBy(x => x.Age);
                var sortByAge = from s in _db.DischargedPatients
                                orderby s.Age
                                select s;
                foreach (var item in sortByAge)
                {
                    MessageBox.Show($"Ім'я: {item.PFirstName} прізвище: {item.PLastName} вік: {item.Age}");
                }
            }
        }
    }
}
