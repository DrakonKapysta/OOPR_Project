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
               new PatientUser{Login = "DrakonKapysta", Password = "123"},
               new PatientUser{Login = "Tonni", Password = "123"},
               new PatientUser{Login = "Versetti", Password = "123"},
               new PatientUser{Login = "Chudo", Password = "123"},
               new PatientUser{Login = "Antony", Password = "123"}
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
               new DoctorUser{ Login = "Oleg2002",Password ="123"},
               new DoctorUser{ Login = "Antony20",Password ="123"}
            };

            context.DoctorUsers.AddOrUpdate(x => new { x.Login, x.Password }, doctorUserList.ToArray());

            var doctorProfileList = new List<DoctorProfile>
           {
               new DoctorProfile{ Id = doctorUserList[0].Id, FirstName="Олег", LastName="Матьокін", Age = 19, State = "Male", Catagery="Dantistn"},
               new DoctorProfile{ Id = doctorUserList[1].Id, FirstName="Антон", LastName="Смішко", Age = 20, State = "Male", Catagery = "Dantist"}
           };
            context.DoctorProfiles.AddOrUpdate(x => new { x.FirstName, x.LastName }, doctorProfileList.ToArray());
            var dispPatients = new List<DischargedPatients>
            {
                new DischargedPatients{ PFirstName ="Толік", PLastName ="Анаболік", Doctor_Id = doctorUserList[0].Id},
                new DischargedPatients{ PFirstName ="Ігорь", PLastName ="Маркс", Doctor_Id = doctorUserList[0].Id},
                new DischargedPatients{ PFirstName ="Максім", PLastName ="Клун", Doctor_Id = doctorUserList[1].Id},
                new DischargedPatients{ PFirstName ="Валентин", PLastName ="Сорока", Doctor_Id = doctorUserList[1].Id},
            };
            
        }
        
    }
}
