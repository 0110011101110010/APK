using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using akademine_sistema.Backend.Repositories;
using akademine_sistema.Repositories;
using akademine_sistema.Backend.Models;

namespace akademine_sistema.Backend.Other.AdminControl.Teachers
{
    public partial class AdminControlTeachersAttach : UserControl
    {
        private Panel sideMenuPanel;
        private Panel contentPanel;
        private GradesRepository gradesRepository;
        private UsersRepository usersRepository;
        public AdminControlTeachersAttach(Panel sideMenuPanel, Panel contentPanel)
        {
            this.sideMenuPanel = sideMenuPanel;
            this.contentPanel = contentPanel;
            usersRepository = new UsersRepository();
            gradesRepository = new GradesRepository();
            InitializeComponent();
            List<Teacher> teachers = usersRepository.GetTeachers(0);
            foreach (Teacher teacher in teachers)
            {
                listBox1.Items.Add(teacher.Name + " " + teacher.Surname);
            }
            List<Subject> subjects = gradesRepository.GetSubjects();
            foreach (Subject subject in subjects)
            {
                listBox2.Items.Add(subject.Title);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null && listBox2.SelectedItem != null)
            {
                usersRepository.AttachTeacher(listBox1.SelectedItem.ToString(), gradesRepository.GetSubjectId(listBox2.SelectedItem.ToString()));
                listBox1.Items.Clear();
                List<Teacher> teachers = usersRepository.GetTeachers(0);
                foreach (Teacher teacher in teachers)
                {
                    listBox1.Items.Add(teacher.Name + " " + teacher.Surname);
                }
                listBox2.Items.Clear();
                List<Subject> subjects = gradesRepository.GetSubjects();
                foreach (Subject subject in subjects)
                {
                    listBox2.Items.Add(subject.Title);
                }
            }
        }
    }
}
