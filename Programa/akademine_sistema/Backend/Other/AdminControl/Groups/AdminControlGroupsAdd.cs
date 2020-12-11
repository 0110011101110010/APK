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

namespace akademine_sistema.Backend.Other.AdminControl.Groups
{
    public partial class AdminControlGroupsAdd : UserControl
    {
        private Panel sideMenuPanel;
        private Panel contentPanel;
        private GradesRepository gradesRepository;
        public AdminControlGroupsAdd(Panel sideMenuPanel, Panel contentPanel)
        {
            this.sideMenuPanel = sideMenuPanel;
            this.contentPanel = contentPanel;
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text) == true)
                MessageBox.Show("Neteisingai įvestas pavadinimas.");
            else
            {
                gradesRepository = new GradesRepository();
                gradesRepository.AddGroup(textBox2.Text);
                MessageBox.Show("Grupė " + textBox2.Text + " sukurta.");
            }
        }
    }
}
