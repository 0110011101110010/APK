using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using akademine_sistema.Backend.Other.AdminControl.Students;

namespace akademine_sistema.Backend.Other
{
    public partial class AdminMenuControlStudents : UserControl
    {
        private Panel sideMenuPanel;
        private Panel contentPanel;
        public AdminMenuControlStudents(Panel sideMenuPanel, Panel contentPanel)
        {
            this.sideMenuPanel = sideMenuPanel;
            this.contentPanel = contentPanel;
            InitializeComponent();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            AdminMenuControl AMC = new AdminMenuControl(sideMenuPanel, contentPanel);
            sideMenuPanel.Controls.Clear();
            contentPanel.Controls.Clear();
            sideMenuPanel.Controls.Add(AMC);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AdminControlStudentsAdd ACSAdd = new AdminControlStudentsAdd(sideMenuPanel, contentPanel);
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(ACSAdd);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            AdminControlStudentsRemove ACSR = new AdminControlStudentsRemove(sideMenuPanel, contentPanel);
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(ACSR);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            AdminControlStudentsAttach ACSAtt = new AdminControlStudentsAttach(sideMenuPanel, contentPanel);
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(ACSAtt);
        }
    }
}
