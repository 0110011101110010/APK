﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using akademine_sistema.Backend.Repositories;
using akademine_sistema.Repositories;
using akademine_sistema.Backend.Models;

namespace akademine_sistema.Backend.Other.AdminControl.Students
{
    public partial class AdminControlStudentsAttach : UserControl
    {
        private Panel sideMenuPanel;
        private Panel contentPanel;
        private GradesRepository gradesRepository;
        private UsersRepository usersRepository;
        public AdminControlStudentsAttach(Panel sideMenuPanel, Panel contentPanel)
        {
            this.sideMenuPanel = sideMenuPanel;
            this.contentPanel = contentPanel;
            usersRepository = new UsersRepository();
            gradesRepository = new GradesRepository();
            InitializeComponent();
            List<Student> students = usersRepository.GetStudents(0);
            foreach (Student student in students)
            {
                listBox1.Items.Add(student.Name + " " + student.Surname);
            }
            List<Group> groups = gradesRepository.GetGroups();
            foreach (Group group in groups)
            {
                listBox2.Items.Add(group.Name);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null && listBox2.SelectedItem != null)
            {
                usersRepository.AttachStudent(listBox1.SelectedItem.ToString(), gradesRepository.GetGroupId(listBox2.SelectedItem.ToString()));
                listBox1.Items.Clear();
                List<Student> students = usersRepository.GetStudents(0);
                foreach (Student student in students)
                {
                    listBox1.Items.Add(student.Name + " " + student.Surname);
                }
                listBox2.Items.Clear();
                List<Group> groups = gradesRepository.GetGroups();
                foreach (Group group in groups)
                {
                    listBox2.Items.Add(group.Name);
                }
            }
        }
    }
}
