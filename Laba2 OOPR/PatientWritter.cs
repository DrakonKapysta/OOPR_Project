using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Laba2_OOPR
{
    public sealed class PatientWritter
    {
        public PatientWritter() { }

        public readonly static string PathForPatients = @"D:\Visual Studio Projects\Laba2 OOPR\Laba2 OOPR\Patients.txt";

        public readonly static string PathForTherapy = @"D:\Visual Studio Projects\Laba2 OOPR\Laba2 OOPR\PatientsTherapy.txt";

        public static void WritePatient(Patient patient)
        {
            if (patient.ProblemDescription == "")
                patient.ProblemDescription = "No description";
            using (StreamWriter sw = new StreamWriter(PathForPatients, true))
            {
                sw.WriteLine("Name: "+patient.Name + " " +"Surname: "+ patient.Surname);
                sw.WriteLine("Age: " + patient.Age);
                sw.WriteLine("State: " + patient.State);
                sw.WriteLine("Healer: None");
                sw.WriteLine("Problem desription: " + patient.ProblemDescription);
            }
        }

        public static void AppointDoctor(doctorForm form)
        {
            string info = "", buffer = "";
            using (StreamReader file = new StreamReader(PatientWritter.PathForPatients))
            {
                while (!file.EndOfStream)
                {
                    if (!(buffer = file.ReadLine()).Contains(form.textBox1.Text) && !buffer.Contains(form.textBox2.Text))
                    {
                        info += buffer + "\n";
                    }
                    else
                    {
                        info += buffer + "\n";
                        info += file.ReadLine() + "\n";
                        info += file.ReadLine() + "\n";
                        info += "Healer: " + form.comboBox2.SelectedText + "\n";
                        file.ReadLine();
                    }
                }
                buffer = "";
            }
            RewritePatients(info, PatientWritter.PathForPatients);
        }

        public static void RewritePatients(string info, string path)
        {
            File.Delete(path);
            File.WriteAllText(path, info);
        }
        public void WriteTherapy(doctorForm docForm, treatmentForm treatForm)
        {
            using (StreamWriter sw = new StreamWriter(PathForTherapy, true))
            {
                sw.WriteLine("Name: " + docForm.textBox1.Text + " " + "Surname: " + docForm.textBox2.Text);
                sw.WriteLine("Treatment: " + treatForm.richTextBox1.Text);
            }
        }

    }
}
