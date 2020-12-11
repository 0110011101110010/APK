using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace akademine_sistema
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            Login l = new Login(sideMenuPanel, contentPanel);
            contentPanel.Controls.Add(l);
        }
    }
}
