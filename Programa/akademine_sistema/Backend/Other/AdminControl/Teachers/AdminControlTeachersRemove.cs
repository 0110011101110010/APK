using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using akademine_sistema.Repositories;

namespace akademine_sistema.Backend.Other.AdminControl.Teachers
{
    public partial class AdminControlTeachersRemove : UserControl
    {
        private Panel sideMenuPanel;
        private Panel contentPanel;
        private UsersRepository usersRepository;
        public AdminControlTeachersRemove(Panel sideMenuPanel, Panel contentPanel)
        {
            this.sideMenuPanel = sideMenuPanel;
            this.contentPanel = contentPanel;
            usersRepository = new UsersRepository();
            InitializeComponent();
            List<Teacher> teachers = usersRepository.GetTeachers();
            foreach (Teacher teacher in teachers)
            {
                listBox2.Items.Add(teacher.Name + " " + teacher.Surname);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            usersRepository.RemoveTeacher(listBox2.SelectedItem.ToString());
            listBox2.Items.Clear();
            List<Teacher> teachers = usersRepository.GetTeachers();
            foreach (Teacher teacher in teachers)
            {
                listBox2.Items.Add(teacher.Name + " " + teacher.Surname);
            }
        }
    }
}
