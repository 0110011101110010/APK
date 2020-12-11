using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace akademine_sistema
{
    class Admin : User
    {
        public Admin(string name, string surname, string username, string password) : base(name, surname, username, password)
        {
        }
    }
}
