using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace akademine_sistema
{
    public class Student : User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public int GroupId { get; private set; }
        public Student(int id, string name, string surname, string username, string password, int groupId) : base(name, surname, username, password)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Username = username;
            Password = password;
            GroupId = groupId;
        }
        public Student(int id, string name, string surname, string username, string password) : base(name, surname, username, password)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Username = username;
            Password = password;
        }
    }
}
