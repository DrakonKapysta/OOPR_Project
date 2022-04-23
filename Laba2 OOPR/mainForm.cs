using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using Laba2_OOPR.EF;
using Laba2_OOPR.Models;
using Laba2_OOPR.Models.Base;
using Laba2_OOPR.Models.ModelsInit;

namespace Laba2_OOPR
{
    public partial class mainForm : Form
    {
        public bool AccountExists = false;
        public Doctor _doc = new Doctor();
        protected PatientForm _myPatient;
        protected doctorForm _myDoctor;
        protected UserContext _db = null;
        public mainForm()
        {
            _db = new UserContext();
            InitializeComponent();
            _db.DoctorProfiles.Load();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            //_myPatient = new PatientForm(this);
            //this.Hide();
            //_myPatient.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
           
            //_myDoctor = new doctorForm(this);
            //_myDoctor.Visible = true;
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(212, 51, 78);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(39, 125, 217);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(!(textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || comboBox1.SelectedIndex != 0 && comboBox1.SelectedIndex != 1))
            {
                DoctorUser doctorUser = new DoctorUser { Login = textBox5.Text, Password = textBox6.Text };
                using (var context = new DoctorUserRepo())
                {
                    context.Add(doctorUser);
                }
                DoctorProfile doctorProfile = new DoctorProfile { Id = doctorUser.Id, FirstName = textBox3.Text, LastName = textBox4.Text, Age = Int32.Parse(textBox7.Text), State = comboBox1.SelectedItem.ToString(), Catagery = textBox8.Text };
                using (var context = new DoctorProfileRepo())
                {
                    context.Add(doctorProfile);
                }

                MessageBox.Show("Ваш аккаунт було зареєстровано.");
                panel2.Visible = false;
                panel1.Visible = true;
                //AccountControl.RegisterAccount(this, AccountPath.Doctor);
            }
            else 
            {
                MessageBox.Show("Заповніть всі поля!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Visible == true)
            {
                panel2.Visible = true;
                panel1.Visible = false;
            }
            else
            {
                PatientRegisterPanel.Visible = true;
                panel1.Visible = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox2.PasswordChar = (char)0;
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Пароль або логін не вірний.");
            }
            else
            {
                #region txtFormat
                //AccountControl.EnterAccount(this, AccountPath.Doctor);
                //if (AccountExists)
                //{
                //    _myDoctor = new doctorForm(this, _doc);
                //    _myDoctor.Visible = true;
                //    this.Hide();
                //}
                #endregion
                if(pictureBox1.Visible==true)
                {
                    using (var context = new DoctorUserRepo())
                    {
                        var user = context.GetOne(textBox1.Text);
                        if (user != null && user.Password == textBox2.Text)
                        {
                            _myDoctor = new doctorForm(this, user);
                            _myDoctor._doctor.Profile.PrescribedTreatment += Profile_PrescribedTreatment;
                            _myDoctor.Visible = true;
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Пароль або логін не вірний.");
                        }
                    }
                }
                else
                {
                    using (var context = new PatientUserRepo())
                    {
                        var user = context.GetOne(textBox1.Text);
                        if(user != null && user.Password == textBox2.Text)
                        {
                            _myPatient = new PatientForm(this, user);
                            _myPatient.Visible = true;
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Пароль або логін не вірний.");
                        }
                    }
                }
            }

        }

        private void Profile_PrescribedTreatment(object sender, Events.TreatmentArgs e)
        {
            if (sender is DoctorProfile doc)
            {
                MessageBox.Show($"From doctor {doc.FirstName}, to patient {e.profile.LastName}\n Treatment: {e.message}");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (AccessPassword.Text != "1337")
            {
                MessageBox.Show("Пароль не вірний!");
            }
            else
            {
                panel1.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
                panel3.Visible = false;
                pictureBox1.Visible = true;
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (!(PatientLoginReg.Text == "" || PatientPasswordReg.Text == ""|| PatientNameReg.Text == "" || PatientSurnameReg.Text ==""))
            {
                PatientUser patientUser = new PatientUser { Login = PatientLoginReg.Text, Password = PatientPasswordReg.Text };
                using (var context = new PatientUserRepo())
                {
                    context.Add(patientUser);
                }
                PatientProfile patientProfile = new PatientProfile { Id = patientUser.Id,FirstName = PatientNameReg.Text, LastName = PatientSurnameReg.Text};
                using (var context = new PatientProfileRepo())
                {
                    context.Add(patientProfile);
                }
                MessageBox.Show("Ваш аккаунт було зареєстровано.");
                PatientRegisterPanel.Visible = false;
                panel1.Visible = true;
                //AccountControl.RegisterAccount(this, AccountPath.Doctor);
            }
            else
            {
                MessageBox.Show("Заповніть всі поля!");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PatientRegisterPanel.Visible = false;
            panel1.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Visible)
            {
                pictureBox1.Visible = false;
            }
            panel1.Visible = false;
            button1.Visible = true;
            button2.Visible = true;

        }

    }
}
