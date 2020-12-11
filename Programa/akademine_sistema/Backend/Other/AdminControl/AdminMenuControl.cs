using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace akademine_sistema.Backend.Other
{
    public partial class AdminMenuControl : UserControl
    {
        private Panel sideMenuPanel;
        private Panel contentPanel;
        public AdminMenuControl(Panel sideMenuPanel, Panel contentPanel)
        {
            this.sideMenuPanel = sideMenuPanel;
            this.contentPanel = contentPanel;
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AdminMenuControlGroups AMCG = new AdminMenuControlGroups(sideMenuPanel, contentPanel);
            sideMenuPanel.Controls.Clear();
            sideMenuPanel.Controls.Add(AMCG);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            AdminMenuControlSubjects AMCSub = new AdminMenuControlSubjects(sideMenuPanel, contentPanel);
            sideMenuPanel.Controls.Clear();
            sideMenuPanel.Controls.Add(AMCSub);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            AdminMenuControlTeachers AMCT = new AdminMenuControlTeachers(sideMenuPanel, contentPanel);
            sideMenuPanel.Controls.Clear();
            sideMenuPanel.Controls.Add(AMCT);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            AdminMenuControlStudents AMCStud = new AdminMenuControlStudents(sideMenuPanel, contentPanel);
            sideMenuPanel.Controls.Clear();
            sideMenuPanel.Controls.Add(AMCStud);
        }
    }
}
