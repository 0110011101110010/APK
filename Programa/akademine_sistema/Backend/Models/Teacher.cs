using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace akademine_sistema
{
    class Teacher : User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public int SubjectId { get; private set; }
        public Teacher(int id, string name, string surname, string username, string password, int subjectId) : base(name, surname, username, password)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Username = username;
            Password = password;
            SubjectId = subjectId;
        }
        public Teacher(int id, string name, string surname, string username, string password) : base(name, surname, username, password)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Username = username;
            Password = password;
        }
    }
}
