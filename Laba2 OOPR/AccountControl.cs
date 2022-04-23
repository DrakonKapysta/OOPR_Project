using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Laba2_OOPR
{
     public enum AccountPath
    {
      Doctor,
      Patient
    }

    public class AccountControl
    {
        private static string pathForPatientAccounts = @"D:\Visual Studio Projects\Laba2 OOPR\Laba2 OOPR\PatientAccounts.txt";

        private static string pathForDoctorsAccounts = @"D:\Visual Studio Projects\Laba2 OOPR\Laba2 OOPR\DoctorAccounts.txt";

        public static void RegisterAccount(mainForm formInfo, AccountPath path)
        {
            string pathForWrtie = "";
            if(path == AccountPath.Doctor)
            {
                pathForWrtie = pathForDoctorsAccounts;
            }
            else
                pathForWrtie = pathForPatientAccounts;

            try
            {
                using (StreamWriter sw = new StreamWriter(pathForWrtie, true))
                {
                    sw.WriteLine("Ім'я: " + formInfo.textBox3.Text + "  Прізвище: " + formInfo.textBox4.Text);
                    sw.WriteLine("Логін: " + formInfo.textBox5.Text + "  Пароль: " + formInfo.textBox6.Text);
                    sw.WriteLine("Стать: " + formInfo.comboBox1.SelectedItem.ToString());
                    sw.WriteLine("Вік: " + formInfo.textBox7.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public static void EnterAccount(mainForm formInfo, AccountPath path)
        {
            string pathForRead = "";
            if (path == AccountPath.Doctor)
            {
                pathForRead = pathForDoctorsAccounts;
            }
            else
                pathForRead = pathForPatientAccounts;
            try
            {
                var info = new List<string>();
                var LoginAngPass = new List<string>();
                using (StreamReader sr = new StreamReader(pathForRead))
                {
                    while(!sr.EndOfStream)
                    {
                        info.Add(sr.ReadLine().ToString());
                    }
                }
                var TrueInfo = from p in info
                               where p.Contains(formInfo.textBox1.Text) && p.Contains(formInfo.textBox2.Text)
                               select p.Split(' ').Where(u => u.Contains(formInfo.textBox1.Text) || u.Contains(formInfo.textBox2.Text));
                foreach (var item in TrueInfo)
                {
                    foreach (var RegInfo in item)
                    {
                        LoginAngPass.Add(RegInfo);
                    };
                }
                if (LoginAngPass.Count == 0 || LoginAngPass[0] != formInfo.textBox1.Text || LoginAngPass[1] != formInfo.textBox2.Text)
                {
                    MessageBox.Show("Перевірте правильність ввода пароля та логіна.");
                }
                else
                {
                    if(path == AccountPath.Doctor)
                    {
                        formInfo.AccountExists = true;
                        formInfo._doc.Login = LoginAngPass[0];
                        formInfo._doc.Password = LoginAngPass[1];
                        FillDoctorAccount(formInfo._doc);
                    }
                    else
                    {
                        formInfo.AccountExists = true;
                    }
                    
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public static void FillDoctorAccount(Doctor person)
        {
            if(person != null)
            {
                var buffer = new List<string>();
                var info = new List<string>();
                using (StreamReader sr = new StreamReader(pathForDoctorsAccounts))
                {
                    while(!sr.EndOfStream)
                    {
                        info.Add(sr.ReadLine());
                    }
                }
                var test1 = from i in info
                            where i.Contains(person.Login) && i.Contains(person.Password)
                            select i;
                int teset;
                foreach (var item in test1)
                {
                    if (item.Count() != 0)
                    {
                        teset = info.IndexOf(item);
                        buffer.Add(info[teset - 1]);
                        buffer.Add(info[teset + 1]);
                        buffer.Add(info[teset + 2]);
                    }
                    else
                        break;
                }
                person.Name = buffer[0].Split(' ')[1];
                person.Surname = buffer[0].Split(' ')[4];
                person.Age =Convert.ToInt32(buffer[2].Split(' ')[1]);
                person.State = buffer[1].Split(' ')[1];
                //MessageBox.Show(person.Name);
                //MessageBox.Show(person.Surname);
                //MessageBox.Show(person.State);
                //MessageBox.Show(person.Age.ToString());
            }
        }

        public static void FillPatientAccount(Patient person)
        {

        }
    }
}
