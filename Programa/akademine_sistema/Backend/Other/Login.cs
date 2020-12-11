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
using akademine_sistema.Backend.Repositories;
using akademine_sistema.Backend.Models;
using akademine_sistema.Backend.Other;

namespace akademine_sistema
{
    public partial class Login : UserControl
    {
        private Panel sideMenuPanel;
        private Panel contentPanel;
        private UsersRepository usersRepository;
        private GradesRepository gradesRepository;
        private Student student;
        private Teacher teacher;
        static private Admin admin;
        public Login(Panel sideMenuPanel, Panel contentPanel)
        {
            this.sideMenuPanel = sideMenuPanel;
            this.contentPanel = contentPanel;
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                usersRepository = new UsersRepository();
                User user = usersRepository.Login(textBox1.Text, textBox2.Text);
                List<Student> studentsList = usersRepository.GetStudents();
                gradesRepository = new GradesRepository();
                List<Subject> subjectsList = gradesRepository.GetSubjects();
                List<Group> groupsList = gradesRepository.GetGroups();

                if (user is Admin)
                {
                    admin = (Admin)user;
                    AdminMenuControl AMC = new AdminMenuControl(sideMenuPanel, contentPanel);
                    contentPanel.Controls.Clear(); // pašalinam prisijungimo lauką (konteinerį)
                    sideMenuPanel.Controls.Add(AMC);
                }

                else if (user is Teacher)
                {
                    teacher = (Teacher)user;
                    int width = sideMenuPanel.Width;
                    foreach (Student student in studentsList)
                    {
                        foreach (Subject subject in subjectsList)
                        {
                            if (teacher.SubjectId == subject.Id && subject.GroupId == student.GroupId)
                            {
                                Button subjectButton2 = new Button();
                                subjectButton2.Text = student.Name + " " + student.Surname;
                                subjectButton2.Width = width - 5;
                                subjectButton2.Height = 35;
                                subjectButton2.Tag = student;
                                subjectButton2.Click += SubjectButton2_Click;
                                sideMenuPanel.Controls.Add(subjectButton2);
                            }
                        }
                    }
                    contentPanel.Controls.Clear();
                }
                else if (user is Student)
                {
                    student = (Student)user;
                    contentPanel.Controls.Clear();
                    int width = sideMenuPanel.Width;
                    foreach (Group group in groupsList)
                    {
                        if (group.Id == student.GroupId)
                        {
                            foreach (Subject subject in group.Subjects)
                            {
                                if (student.GroupId == subject.GroupId)
                                {
                                    Button subjectButton = new Button();
                                    subjectButton.Text = subject.Title;
                                    subjectButton.Width = width - 5;
                                    subjectButton.Height = 35;
                                    subjectButton.Tag = subject;
                                    subjectButton.Click += SubjectButton_Click;
                                    sideMenuPanel.Controls.Add(subjectButton);
                                }
                            }
                        }
                    }
                }
                else
                {
                    contentPanel.Controls.Clear();
                    MessageBox.Show("You are not assigned to any user group. Contact administrator.");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Klaida"); // išvedam (atspausdinam) klaidą
            }
        }

        private void SubjectButton2_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            Button button = (Button)sender;
            Student student = (Student)button.Tag;
            List<Subject> subjectsList = gradesRepository.GetSubjects();
            foreach (Subject subject in subjectsList)
            {
                if (subject.Id == teacher.SubjectId)
                {
                    if (subject.Grades.Count != 0)
                    {
                        // v1
                        int x = 1;
                        foreach (Grade grade in subject.Grades)
                        {
                            if (student.Id == grade.StudentId)
                            {
                                GradePublicControl GPC = new GradePublicControl(subject, grade);
                                contentPanel.Controls.Add(GPC);
                                break;
                            }

                            if (subject.Grades.Count == x)
                            {
                                GradePublicControl GPC = new GradePublicControl(subject, student);
                                contentPanel.Controls.Add(GPC);
                                x = 1;
                            }
                            x++;
                        }
                        //

                        /* v2
                        for (int x = 0; x < subject.Grades.Count; x++)
                        {
                            Grade grade[x] = subject.Grades.
                        }
                        */
                    }
                    else
                    {
                        GradePublicControl GPC = new GradePublicControl(subject, student);
                        contentPanel.Controls.Add(GPC);
                    }
                }
            }
        }

        private void SubjectButton_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            Button button = (Button)sender;
            Subject subject = (Subject)button.Tag;
            List<Group> groupsList = gradesRepository.GetGroups();
            int width = contentPanel.Width;
            int height = contentPanel.Height;
            Label label = new Label();
            if (subject.Grades.Count != 0)
            {
                foreach (Grade grade in subject.Grades) // tokiu būdu patikrinamas tik paskutinis pažymis KLAIDA S.O.S.
                {
                    if (student.Id == grade.StudentId)
                    {
                        label.Text = subject.Title + Environment.NewLine + "Vertinimas: " + grade.Number;
                        break;
                    }
                    else
                        label.Text = subject.Title + Environment.NewLine + "Vertinimas: nėra";
                }
            }
            else
                label.Text = subject.Title + Environment.NewLine + "Vertinimas: nėra";
            label.Width = width - 5;
            label.Height = height - 5;
            contentPanel.Controls.Add(label);
        }
    }
}
