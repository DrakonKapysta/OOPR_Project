namespace Laba2_OOPR.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Entity;
    using System.Data;
    using System.Data.SqlClient;
    using Laba2_OOPR.Models;
    using Laba2_OOPR.Models.Base;
    using Laba2_OOPR.Models.ModelsInit;
    using Laba2_OOPR.EF;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<UserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UserContext context)
        {
            var patientUserList = new List<PatientUser>
           {
               new PatientUser{Id = 1,Login = "DrakonKapysta", Password = "123"},
               new PatientUser{Id = 2,Login = "Tonni", Password = "123"},
               new PatientUser{Id = 3,Login = "Versetti", Password = "123"},
               new PatientUser{Id = 4,Login = "Chudo", Password = "123"},
               new PatientUser{Id = 5,Login = "Antony", Password = "123"}
           };

            context.PatientUsers.AddOrUpdate(x => new { x.Login, x.Password }, patientUserList.ToArray());

            var patientProfileList = new List<PatientProfile>
           {
               new PatientProfile{ Id = patientUserList[0].Id, FirstName="Вася", LastName="Кушнір", Age = 19, State = "Male"},
               new PatientProfile{ Id = patientUserList[1].Id, FirstName="Денис", LastName="Смішко", Age = 20, State = "Male"},
               new PatientProfile{ Id = patientUserList[2].Id, FirstName="Харітон", LastName="Шульга", Age = 21, State = "Male"},
               new PatientProfile{ Id = patientUserList[3].Id, FirstName="Коля", LastName="Поліщук", Age = 22, State = "Male"},
               new PatientProfile{ Id = patientUserList[4].Id, FirstName="Назар", LastName="Дудка", Age = 23, State = "Male"},
           };

            context.PatientProfiles.AddOrUpdate(x => new { x.FirstName, x.LastName }, patientProfileList.ToArray());

            var doctorUserList = new List<DoctorUser>
            {
               new DoctorUser{Id = 1, Login = "Oleg2002",Password ="123"},
               new DoctorUser{Id = 2, Login = "Antony20",Password ="123"}
            };

            context.DoctorUsers.AddOrUpdate(x => new { x.Login, x.Password }, doctorUserList.ToArray());

            var doctorProfileList = new List<DoctorProfile>
           {
               new DoctorProfile{ Id = doctorUserList[0].Id, FirstName="Олег", LastName="Матьокін", Age = 19, State = "Male", Catagery="Dantistn"},
               new DoctorProfile{ Id = doctorUserList[1].Id, FirstName="Антон", LastName="Смішко", Age = 20, State = "Male", Catagery = "Dantist"}
           };
            context.DoctorProfiles.AddOrUpdate(x => new { x.FirstName, x.LastName }, doctorProfileList.ToArray());
            
            var extracts = new List<Extracts>
            {
                new Extracts{extracts="Drink more water", Doctor_Id = doctorUserList[0].Id, Patient_Id = patientUserList[0].Id},
                new Extracts{extracts="Eat more vegetables", Doctor_Id = doctorUserList[0].Id, Patient_Id = patientUserList[0].Id},
                new Extracts{extracts="Take vitamins", Doctor_Id = doctorUserList[1].Id, Patient_Id = patientUserList[1].Id},
                new Extracts{extracts="More sleep", Doctor_Id = doctorUserList[1].Id, Patient_Id = patientUserList[2].Id}
            };
            context.Extracts.AddOrUpdate(x => new { x.Doctor_Id, x.Patient_Id }, extracts.ToArray());
            var dispPatients = new List<DischargedPatients>
            {
                new DischargedPatients{ PFirstName ="Толік", PLastName ="Анаболік", Doctor_Id = doctorUserList[0].Id, Age = 35},
                new DischargedPatients{ PFirstName ="Ігорь", PLastName ="Маркс", Doctor_Id = doctorUserList[0].Id, Age = 25},
                new DischargedPatients{ PFirstName ="Максім", PLastName ="Клун", Doctor_Id = doctorUserList[1].Id, Age = 19},
                new DischargedPatients{ PFirstName ="Валентин", PLastName ="Сорока", Doctor_Id = doctorUserList[1].Id, Age = 31},
            };

            context.DischargedPatients.AddOrUpdate(x => new { x.PFirstName }, dispPatients.ToArray());
        }

    }
}
