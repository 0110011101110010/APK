using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using akademine_sistema.Backend.Other.AdminControl.Groups;

namespace akademine_sistema.Backend.Other
{
    public partial class AdminMenuControlGroups : UserControl
    {
        private Panel sideMenuPanel;
        private Panel contentPanel;
        public AdminMenuControlGroups(Panel sideMenuPanel, Panel contentPanel)
        {
            this.sideMenuPanel = sideMenuPanel;
            this.contentPanel = contentPanel;
            InitializeComponent();
        }
        // Į contentPanel įdedam UserControl'ą kiekvienai funkcijai:
        private void Button1_Click(object sender, EventArgs e) // "Kurti"
        {
            contentPanel.Controls.Clear();
            AdminControlGroupsAdd ACGA = new AdminControlGroupsAdd(sideMenuPanel, contentPanel);
            contentPanel.Controls.Add(ACGA);
        }

        private void Button2_Click(object sender, EventArgs e) // "Šalinti"
        {
            contentPanel.Controls.Clear();
            AdminControlGroupsRemove ACGR = new AdminControlGroupsRemove(sideMenuPanel, contentPanel);
            contentPanel.Controls.Add(ACGR);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            AdminMenuControl AMC = new AdminMenuControl(sideMenuPanel, contentPanel);
            sideMenuPanel.Controls.Clear();
            contentPanel.Controls.Clear();
            sideMenuPanel.Controls.Add(AMC);
        }
    }
}
