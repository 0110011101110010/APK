// Gabrielius Radžiūnas PI19B -
// Praktinė užduotis Nr. 2    -
// (Klasė Person + GUI)       -
// Vertinimas: 30/30          -
// ----------------------------
// Šaltinis: https://www.howmanydaysuntilmybirthday.com/
using System;
using System.Collections.Generic;
using System.Text;

namespace akademine_sistema
{
    public abstract class Person //back-end
    {
        protected string name;
        protected string surname;

        public Person(string name, string surname)
        {
                this.name = name;
                this.surname = surname;
        }

        public string GetName()
        {
            return name;
        }

        public string GetSurname()
        {
            return surname;
        }
    }
}
