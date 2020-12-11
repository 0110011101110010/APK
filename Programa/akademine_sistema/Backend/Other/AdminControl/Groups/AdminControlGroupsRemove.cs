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

namespace akademine_sistema.Backend.Other.AdminControl.Groups
{
    public partial class AdminControlGroupsRemove : UserControl
    {
        private Panel sideMenuPanel;
        private Panel contentPanel;
        private GradesRepository gradesRepository;
        private UsersRepository usersRepository;
        public AdminControlGroupsRemove(Panel sideMenuPanel, Panel contentPanel)
        {
            this.sideMenuPanel = sideMenuPanel;
            this.contentPanel = contentPanel;
            gradesRepository = new GradesRepository();
            InitializeComponent();
            List<Group> groups = gradesRepository.GetGroups();
            foreach(Group group in groups)
            {
                listBox2.Items.Add(group.Name);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            usersRepository = new UsersRepository();
            usersRepository.UnattachStudents(gradesRepository.GetGroupId(listBox2.SelectedItem.ToString()));

            gradesRepository.UnattachSubjects(gradesRepository.GetGroupId(listBox2.SelectedItem.ToString()));
            gradesRepository.RemoveGroup(listBox2.SelectedItem.ToString());
            listBox2.Items.Clear();
            List<Group> groups = gradesRepository.GetGroups();
            foreach (Group group in groups)
            {
                listBox2.Items.Add(group.Name);
            }
        }
    }
}
