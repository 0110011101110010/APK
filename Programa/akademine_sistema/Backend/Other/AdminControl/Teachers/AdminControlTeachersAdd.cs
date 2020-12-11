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
    public partial class AdminControlTeachersAdd : UserControl
    {
        private Panel sideMenuPanel;
        private Panel contentPanel;
        private UsersRepository usersRepository;
        public AdminControlTeachersAdd(Panel sideMenuPanel, Panel contentPanel)
        {
            this.sideMenuPanel = sideMenuPanel;
            this.contentPanel = contentPanel;
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) == true || string.IsNullOrWhiteSpace(textBox2.Text) == true || string.IsNullOrWhiteSpace(textBox3.Text) == true || string.IsNullOrWhiteSpace(textBox4.Text) == true)
                MessageBox.Show("Neteisingai įvesti duomenys.");
            else
            {
                usersRepository = new UsersRepository();
                usersRepository.AddTeacher(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                MessageBox.Show("Naudotojas " + textBox2.Text + " " + textBox1.Text + " sukurtas.");
            }
        }
    }
}
