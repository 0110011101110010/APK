using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace akademine_sistema.Backend.Models
{
    class Group
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<Subject> Subjects { get; private set; }

        public Group(int id, string name)
        {
            Id = id;
            Name = name;
        }
        
        public void SetSubjects(List<Subject> subjects)
        {
            Subjects = subjects;
        }
    }
}
