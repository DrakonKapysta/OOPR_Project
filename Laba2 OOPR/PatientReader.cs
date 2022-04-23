using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Laba2_OOPR
{

    static class PatientReader
    {
        private static Patient patient = new Patient();

        public static void ReadPatientToComboBox(doctorForm form)
        {
            try
            {
                using (StreamReader file = new StreamReader(PatientWritter.PathForPatients))
                {
                    string msg;
                    while (!file.EndOfStream)
                    {
                        msg = file.ReadLine();
                        if(msg.Contains("Name: "))
                        {
                            msg = msg.Split(':')[1].Split(' ')[1] + msg.Split(':')[2];
                            form.comboBox1.Items.Add(msg);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ReadPatientProblemDescription(doctorForm form)
        {
            form.richTextBox1.Text = patient.ProblemDescription;
        }

        public static void ReadPatientInfo(doctorForm form)
        {
            string[] splitter = { "Name: ", "Surname: ","Age: ", "State: ", "Healer: ", "Problem desription: " };
            List<string> patientInfo = new List<string>();
            form.textBox1.Text = form.comboBox1.SelectedItem.ToString().Split(' ')[0];
            form.textBox2.Text = form.comboBox1.SelectedItem.ToString().Split(' ')[1];
            try
            {
                using (StreamReader file = new StreamReader(PatientWritter.PathForPatients))
                {
                    string msg;
                    while (!file.EndOfStream)
                    {
                        msg = file.ReadLine();
                        if (msg.Contains(form.textBox1.Text))
                        {
                            patientInfo.Add(msg);
                            while (!file.EndOfStream)
                            {
                                msg = file.ReadLine();
                                if (!msg.Contains("Name: "))
                                    patientInfo.Add(msg);
                                else
                                    break;
                            }
                            patient.Name = patientInfo[0].Split(splitter, StringSplitOptions.None)[1];
                            patient.Surname = patientInfo[0].Split(splitter, StringSplitOptions.None)[2];
                            patient.Age = int.Parse(patientInfo[1].Split(splitter, StringSplitOptions.None)[1]);
                            patient.State = patientInfo[2].Split(splitter, StringSplitOptions.None)[1];
                            patient.HealingDoctor = patientInfo[3].Split(splitter, StringSplitOptions.None)[1];
                            patient.ProblemDescription = patientInfo[4].Split(splitter, StringSplitOptions.None)[1];
                            for (int i = 5; i < patientInfo.Count; i++)
                            {
                                patient.ProblemDescription += " " + patientInfo[i];
                            }
                            form.textBox3.Text = Convert.ToString(patient.Age);
                            form.textBox4.Text = patient.State;
                            form.comboBox2.SelectAll();
                            form.comboBox2.SelectedText = patient.HealingDoctor;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
