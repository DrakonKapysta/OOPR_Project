using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Laba2_OOPR.Models;
using Laba2_OOPR.Models.Base;
using Laba2_OOPR.Models.ModelsInit;
using System.Data.Entity;

namespace Laba2_OOPR
{
    public partial class PatientForm : Form
    {
        public PatientForm(mainForm myMainForm, BaseRepo user)
        {
            _mainForm = myMainForm;
            _patientUser = (PatientUser)user;
            InitializeComponent();
            this.FormClosing += Patient_FormClosing;
            textBox3.KeyPress +=(s,e)=>
            {
                if (Char.IsDigit(e.KeyChar) || e.KeyChar == 8)
                    return;
                else
                    e.Handled = true;
            };
            System.Drawing.Drawing2D.GraphicsPath myPath =
    new System.Drawing.Drawing2D.GraphicsPath();
            myPath.AddEllipse(0, 0, label5.Width, label5.Height);

            Region myRegion = new Region(myPath);
            label5.Region = myRegion;
        }

        private PatientUser _patientUser = null;

        private mainForm _mainForm;

        protected DoctorUser _doctorUser= null;

        private void Patient_FormClosing(object sender, FormClosingEventArgs e)
        {
            _mainForm.Visible = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                richTextBox1.Enabled = true;
            else
            {
                richTextBox1.Enabled = false;
                richTextBox1.Clear();
            }
        }

        private void Patient_Load(object sender, EventArgs e)
        { 
            richTextBox1.Enabled = false;
            this.Text = _patientUser.Profile.FirstName + " " + _patientUser.Profile.LastName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new PatientProfileRepo())
            {
                if (textBox1.Text != "")
                {
                    _patientUser.Profile.FirstName = textBox1.Text;
                }
                if (textBox2.Text != "")
                {
                    _patientUser.Profile.LastName = textBox2.Text;
                }
                if (textBox3.Text != "")
                {
                    _patientUser.Profile.Age = Int32.Parse(textBox3.Text);
                }
                if (comboBox1.SelectedIndex != -1)
                {
                    _patientUser.Profile.State = comboBox1.SelectedItem.ToString();
                }
                if (richTextBox1.Text != "")
                {
                    _patientUser.Profile.Problem_description = richTextBox1.Text.ToString();
                }
                db.Save(_patientUser.Profile);
            }
            
            MessageBox.Show("Данні було успішно зміненно.");
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            _mainForm.Visible = true;
            this.Hide();
        }
    }
}
