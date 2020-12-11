using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using akademine_sistema;
using akademine_sistema.Repositories;
using akademine_sistema.Backend.Repositories;

namespace akademine_sistema.Backend.Other.AdminControl.Students
{
    public partial class AdminControlStudentsRemove : UserControl
    {
        private Panel sideMenuPanel;
        private Panel contentPanel;
        private UsersRepository usersRepository;
        private GradesRepository gradesRepository;
        public AdminControlStudentsRemove(Panel sideMenuPanel, Panel contentPanel)
        {
            this.sideMenuPanel = sideMenuPanel;
            this.contentPanel = contentPanel;
            usersRepository = new UsersRepository();
            InitializeComponent();
            List<Student> students = usersRepository.GetStudents();
            foreach (Student student in students)
            {
                listBox2.Items.Add(student.Name + " " + student.Surname);
            }
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            gradesRepository = new GradesRepository();
            Student student1 = usersRepository.GetStudent(listBox2.SelectedItem.ToString());
            gradesRepository.RemoveGradesByStudent(student1.Id);
            usersRepository.RemoveStudent(listBox2.SelectedItem.ToString());
            listBox2.Items.Clear();
            List<Student> students = usersRepository.GetStudents();
            foreach (Student student in students)
            {
                listBox2.Items.Add(student.Name + " " + student.Surname);
            }
        }
    }
}
