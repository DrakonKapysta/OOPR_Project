using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2_OOPR
{
   public abstract class Human
    {
        public Human() { }

        public Human(int age, string name, string surname, string state)
        {
            Age = age;
            Name = name;
            Surname = surname;
            State = state;
        }

        public string _helth { get; set; } = "You are not healty!";

        public int Age { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string State { get; set; }

        public void BeHealthy() => _helth = "You are helthe!";
       
    }
}
