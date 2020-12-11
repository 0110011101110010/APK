using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace akademine_sistema.Backend.Models
{
    public class Subject
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public int GroupId { get; private set; }
        public List<Grade> Grades { get; private set; }

        public Subject(int id, string title, int groupId)
        {
            Id = id;
            Title = title;
            GroupId = groupId;
        }

        public Subject(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public void SetGrades(List<Grade> grades)
        {
            Grades = grades;
        }
    }
}
