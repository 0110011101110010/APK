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
using akademine_sistema.Backend.Models;
using akademine_sistema.Repositories;

namespace akademine_sistema.Backend.Other.AdminControl.Subjects
{
    public partial class AdminControlSubjectsRemove : UserControl
    {
        private Panel sideMenuPanel;
        private Panel contentPanel;
        private GradesRepository gradesRepository;
        private UsersRepository usersRepository;
        public AdminControlSubjectsRemove(Panel sideMenuPanel, Panel contentPanel)
        {
            this.sideMenuPanel = sideMenuPanel;
            this.contentPanel = contentPanel;
            gradesRepository = new GradesRepository();
            InitializeComponent();
            List<Subject> subjects = gradesRepository.GetSubjects();
            foreach (Subject subject in subjects)
            {
                listBox2.Items.Add(subject.Title);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            usersRepository = new UsersRepository();
            int subjectId = gradesRepository.GetSubjectId(listBox2.SelectedItem.ToString());
            usersRepository.UnattachTeachers(subjectId);
            gradesRepository.RemoveGradesBySubject(subjectId);
            gradesRepository.RemoveSubject(listBox2.SelectedItem.ToString());
            listBox2.Items.Clear();
            List<Subject> subjects = gradesRepository.GetSubjects();
            foreach (Subject subject in subjects)
            {
                listBox2.Items.Add(subject.Title);
            }
        }
    }
}
