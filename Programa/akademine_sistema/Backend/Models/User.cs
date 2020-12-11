using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace akademine_sistema
{
    public class User : Person
    {
        protected string username;
        protected string password;
        protected string picture;
        protected string path1 = @"C:\Users\DG\Desktop\New folder\VIKO\2020-2021 (antras kursas)\Objektinis programavimas (Mindaugas Liogys)\3. PD ( iš 60)\file.bmp";
        public User(string name, string surname, string username, string password) : base(name, surname)
        {
            // patikrinam ar nėra klaidos:
            if (string.IsNullOrWhiteSpace(name) != true && string.IsNullOrWhiteSpace(surname) == false && string.IsNullOrWhiteSpace(username) != true && string.IsNullOrWhiteSpace(password) == false) // ieškom klaidos
            {
                // jei nėra klaidos, apibrėžiam reikšmes:
                this.name = name;
                this.surname = surname;
                //this.birthDate = birthDate;
                this.username = username;
                this.password = password;
                picture = path1;
            }
            // apibrėžiam klaidą:
            else
            {
                // neteisingai įvestas kažkuris arba kažkurie laukai:
                if (string.IsNullOrWhiteSpace(name) == true || string.IsNullOrWhiteSpace(surname) == true || string.IsNullOrWhiteSpace(username) == true || string.IsNullOrWhiteSpace(password) != false)
                    throw new Exception("Neteisingai įvesti teksto laukai arba laukas." + Environment.NewLine + "Laukai negali būti tušti.");
                // tikrinam ar neusgadinom if:
                else
                    throw new Exception("Neapibrėžta klaida (klaida kode).");
            }
        }
        public void SetPassword(string password)
        {
            this.password = password;
        }

        public void SetPicture(string picture)
        {
            this.picture = picture;
        }

        public string GetPicture()
        {
            return picture;
        }

        public string GetPassword()
        {
            return password;
        }

        public string GetUsername()
        {
            return username;
        }
        public string GetFullInfo()
        {
            return name + " " + surname + " " + username + " " + password;
        }
    }
}
