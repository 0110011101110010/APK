using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using akademine_sistema.Backend.Other.AdminControl.Subjects;

namespace akademine_sistema.Backend.Other
{
    public partial class AdminMenuControlSubjects : UserControl
    {
        private Panel sideMenuPanel;
        private Panel contentPanel;
        public AdminMenuControlSubjects(Panel sideMenuPanel, Panel contentPanel)
        {
            this.sideMenuPanel = sideMenuPanel;
            this.contentPanel = contentPanel;
            InitializeComponent();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            AdminMenuControl menu = new AdminMenuControl(sideMenuPanel, contentPanel);
            sideMenuPanel.Controls.Clear();
            contentPanel.Controls.Clear();
            sideMenuPanel.Controls.Add(menu);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AdminControlSubjectsAdd add = new AdminControlSubjectsAdd(sideMenuPanel, contentPanel);
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(add);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            AdminControlSubjectsRemove remove = new AdminControlSubjectsRemove(sideMenuPanel, contentPanel);
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(remove);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            AdminControlSubjectsAttach attach = new AdminControlSubjectsAttach(sideMenuPanel, contentPanel);
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(attach);
        }
    }
}
