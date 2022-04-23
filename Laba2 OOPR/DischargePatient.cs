using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Laba2_OOPR
{
    static class DischargePatient
    {
        public static void Discharge(string name, string surname)
        {
            string info = "", buffer = "";
            using (StreamReader file = new StreamReader(PatientWritter.PathForPatients))
            {
                while (!file.EndOfStream)
                {
                    if (!(buffer = file.ReadLine()).Contains(name) && !buffer.Contains(surname))
                    {
                        info += buffer + "\n";
                    }
                    else
                    {
                        buffer = file.ReadLine();
                        while (!file.EndOfStream)
                        {
                            if(!buffer.Contains("Name: ") && !buffer.Contains("Surname: "))
                            {
                                buffer = file.ReadLine();
                            }
                            else
                            {
                                info += buffer+"\n";
                                break;
                            }
                        }
                    }
                }
                buffer = "";
            }
           PatientWritter.RewritePatients(info, PatientWritter.PathForPatients);
        }

        public static void DischargeTherapy(string name, string surname)
        {
            string info = "", buffer = "";
            using (StreamReader file = new StreamReader(PatientWritter.PathForTherapy))
            {
                while (!file.EndOfStream)
                {
                    if (!(buffer = file.ReadLine()).Contains(name) && !buffer.Contains(surname))
                    {
                        info += buffer + "\n";
                    }
                    else
                    {
                        buffer = file.ReadLine();
                        while (!file.EndOfStream)
                        {
                            if (!buffer.Contains("Name: ") && !buffer.Contains("Surname: "))
                            {
                                buffer = file.ReadLine();
                            }
                            else
                            {
                                info += buffer + "\n";
                                break;
                            }
                        }
                    }
                }
                buffer = "";
            }
            PatientWritter.RewritePatients(info, PatientWritter.PathForTherapy);
        }
    }
}
