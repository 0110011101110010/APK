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

namespace akademine_sistema.Backend.Other.AdminControl.Students
{
    public partial class AdminControlStudentsAdd : UserControl
    {
        private Panel sideMenuPanel;
        private Panel contentPanel;
        private UsersRepository usersRepository;
        public AdminControlStudentsAdd(Panel sideMenuPanel, Panel contentPanel)
        {
            this.sideMenuPanel = sideMenuPanel;
            this.contentPanel = contentPanel;
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text) == true || string.IsNullOrWhiteSpace(textBox1.Text) == true)
                MessageBox.Show("Neteisingai įvestas vardas arba pavardė.");
            else
            {
                usersRepository = new UsersRepository();
                usersRepository.AddStudent(textBox2.Text, textBox1.Text);
                MessageBox.Show("Naudotojas " + textBox2.Text + " " + textBox1.Text + " sukurtas.");
            }
        }
    }
}
