using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using akademine_sistema.Backend.Models;
using akademine_sistema.Backend.Repositories;

namespace akademine_sistema.Backend.Other
{
    public partial class GradePublicControl : UserControl
    {
        private GradesRepository gradesRepository;
        private Student student1;
        public GradePublicControl(Subject subject, Student student)
        {
            InitializeComponent();
            student1 = student;
            textBox1.Hide();
            button2.Hide();
            button3.Hide();
            label1.Text = "Vertinimas: nėra";
            button1.Text = "Įvesti";
            button1.Tag = subject;
            button1.Show();
        }
        public GradePublicControl(Subject subject, Grade grade)
        {
            InitializeComponent();
            textBox1.Hide();
            button2.Hide();
            button3.Hide();
            label1.Text = "Vertinimas: " + grade.Number;
            button1.Text = "Redaguoti";
            button1.Tag = grade;
            button1.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            button1.Hide();
            textBox1.Text = "";
            textBox1.Show();
            button2.Show();
            button3.Show();
            Button button = (Button)sender;
            button3.Tag = button1.Tag;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Hide();
            button2.Hide();
            button3.Hide();
            button1.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            gradesRepository = new GradesRepository();
            gradesRepository.GetGroups();

            if (button1.Text == "Įvesti")
            {
                Button button = (Button)sender;
                Subject subject = (Subject)button3.Tag;
                int number;
                bool success = int.TryParse(textBox1.Text, out number);

                if (success)
                {
                    if (number >= 0 && number <= 10)
                    {
                        gradesRepository.AddGrade(student1, subject, number);
                        label1.Text = "Vertinimas: " + number;
                    }

                    else
                    {
                        MessageBox.Show("Vertinimas gali būti tik sveikasis skaičius tarp 0 ir 10!");
                    }
                }

                else
                {
                    MessageBox.Show("Vertinimas gali būti tik sveikasis skaičius tarp 0 ir 10!");
                }
            }

            else
            {
                Button button = (Button)sender;
                Grade grade = (Grade)button1.Tag;
                int number;
                bool success = int.TryParse(textBox1.Text, out number);

                if (success)
                {
                    if (number >= 0 && number <= 10)
                    {
                        gradesRepository.EditGrade(grade, number);
                        label1.Text = "Vertinimas: " + grade.Number;
                    }
                    else
                {
                    MessageBox.Show("Vertinimas gali būti tik sveikasis skaičius tarp 0 ir 10!");
                }

                }

                else
                {
                    MessageBox.Show("Vertinimas gali būti tik sveikasis skaičius tarp 0 ir 10!");
                }
            }
        }
    }
}
