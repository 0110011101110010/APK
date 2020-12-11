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

namespace akademine_sistema.Backend.Other.AdminControl.Subjects
{
    public partial class AdminControlSubjectsAttach : UserControl
    {
        private Panel sideMenuPanel;
        private Panel contentPanel;
        private GradesRepository gradesRepository;
        public AdminControlSubjectsAttach(Panel sideMenuPanel, Panel contentPanel)
        {
            this.sideMenuPanel = sideMenuPanel;
            this.contentPanel = contentPanel;
            gradesRepository = new GradesRepository();
            InitializeComponent();
            List<Subject> subjects = gradesRepository.GetSubjects(false);
            foreach (Subject subject in subjects)
            {
                listBox1.Items.Add(subject.Title);
            }
            List<Group> groups = gradesRepository.GetGroups();
            foreach (Group group in groups)
            {
                listBox2.Items.Add(group.Name);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null && listBox2.SelectedItem != null)
            {
                //MessageBox.Show();
                gradesRepository.AttachSubject(listBox1.SelectedItem.ToString(), gradesRepository.GetGroupId(listBox2.SelectedItem.ToString()));
                listBox1.Items.Clear();
                List<Subject> subjects = gradesRepository.GetSubjects(false);
                foreach (Subject subject in subjects)
                {
                    listBox1.Items.Add(subject.Title);
                }
                listBox2.Items.Clear();
                List<Group> groups = gradesRepository.GetGroups();
                foreach (Group group in groups)
                {
                    listBox2.Items.Add(group.Name);
                }
            }
        }
    }
}
