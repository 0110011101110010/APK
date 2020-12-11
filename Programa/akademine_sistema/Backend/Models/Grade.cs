using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace akademine_sistema.Backend.Models
{
    public class Grade
    {
        public int SubjectId { get; private set; }
        public int StudentId { get; private set; }
        public int Number { get; private set; }
        
        public Grade (int subjectId, int studentId, int number)
        {
            SubjectId = subjectId;
            StudentId = studentId;
            Number = number;
        }

        public void SetGrade(int number)
        {
            if (number >= 0 && number <= 10)
            {
                Number = number;
            }
        }
    }
}
