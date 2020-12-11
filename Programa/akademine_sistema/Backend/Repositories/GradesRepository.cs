using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using akademine_sistema.Backend.Models;
using System.Diagnostics;

namespace akademine_sistema.Backend.Repositories
{
    class GradesRepository
    {
        private SqlConnection conn;
        public GradesRepository()
        {
            conn = new SqlConnection(@"Server=.;Database=akademine_sistema;Trusted_Connection=true;");
        }
        /*
        public List<Grade> GetGrades()
        {
            List<Grade> gradesList = new List<Grade>();
            try
            {
                string sql = "select subjectId, studentId, grade from grades";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int subjectId = int.Parse(reader["subjectID"].ToString());
                    int studentId = int.Parse(reader["studentID"].ToString());
                    int number = int.Parse(reader["grade"].ToString());
                    gradesList.Add(new Grade(subjectId, studentId, number));
                }

                conn.Close();
            }
            catch (Exception exc)
            {
               Debug.WriteLine(exc.Message);
            }
            return gradesList;
        }
        */
        public List<Subject> GetSubjects()
        {
            List<Subject> subjectsList = new List<Subject>();
            try
            {
                string sql = "select id, title, groupId from subjects";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string title = reader["title"].ToString();
                    if (DBNull.Value.Equals(reader["groupId"]))
                    {
                        subjectsList.Add(new Subject(id, title));
                    }
                    else
                    {
                        int groupid = int.Parse(reader["groupId"].ToString());
                        subjectsList.Add(new Subject(id, title, groupid));
                    }
                }

                conn.Close();
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message);
            }

            foreach (Subject s in subjectsList)
                s.SetGrades(GetGrades(s.Id)); // KLAIDA - ištaisyta
            return subjectsList;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //
        public List<Group> GetGroups()
        {
            List<Group> groupsList = new List<Group>();
            try
            {
                string sql = "select id, name from groups";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string name = reader["name"].ToString();
                    groupsList.Add(new Group(id, name));
                }

                conn.Close();
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message);
            }

            foreach (Group g in groupsList)
                g.SetSubjects(GetSubjects(g.Id));
            return groupsList;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private List<Subject> GetSubjects(int groupId)
        {
            List<Subject> subjectsList = new List<Subject>();
            try
            {
                string sql = "select id, title, groupId from subjects " +
                    "where groupId = @groupId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@groupId", groupId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string title = reader["title"].ToString();
                    if (DBNull.Value.Equals(reader["groupId"]))
                    {
                        subjectsList.Add(new Subject(id, title));
                    }
                    else
                    {
                        int groupid = int.Parse(reader["groupId"].ToString());
                        subjectsList.Add(new Subject(id, title, groupid));
                    }
                }

                conn.Close();
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message);
            }

            foreach (Subject s in subjectsList)
                s.SetGrades(GetGrades(s.Id));
            return subjectsList;
        }
        //
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private List<Grade> GetGrades(int subjectId) //
        {
            List<Grade> gradesList = new List<Grade>();
            try
            {
                string sql = "select subjectId, studentId, grade from grades " +
                    "where subjectId = @subjectId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@subjectId", subjectId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int subjectid = int.Parse(reader["subjectID"].ToString());
                    int studentId = int.Parse(reader["studentID"].ToString());
                    int number = int.Parse(reader["grade"].ToString());
                    gradesList.Add(new Grade(subjectid, studentId, number));
                }

                conn.Close();
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message);
            }
            return gradesList;
        }

        public void EditGrade(Grade grade, int number)
        {
            try
            {
                grade.SetGrade(number);
                string sql = "UPDATE grades " +
                    "SET grade = @grade " +
                    "WHERE subjectId = @subjectID AND studentId = @studentId ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@grade", grade.Number);
                cmd.Parameters.AddWithValue("@subjectID", grade.SubjectId);
                cmd.Parameters.AddWithValue("@studentId", grade.StudentId);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        public void AddGrade(Student student, Subject subject, int number)
        {
            try
            {
                Grade grade = new Grade(subject.Id, student.Id, number);
                string sql = "INSERT INTO grades " +
                    "VALUES(@subjectId, @studentId, @grade) ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@grade", grade.Number);
                cmd.Parameters.AddWithValue("@subjectID", grade.SubjectId);
                cmd.Parameters.AddWithValue("@studentId", grade.StudentId);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        public void AddGroup(string name) // padaryt, kad neitų sukurt tokių pačių naudotojų
        {
            try
            {
                //Group group = new Group()
                string sql = "INSERT INTO groups(name) " +
                    "VALUES(@name)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", name);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        public void RemoveGroup(string name)
        {
            try
            {
                string sql = "DELETE FROM groups " +
                    "WHERE name = @name";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", name);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        public int GetGroupId(string name)
        {
            try
            {
                string sql = "SELECT id FROM groups " +
                    "WHERE name = @name";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", name);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    conn.Close();
                    return id;
                }

                conn.Close();
                return 0;
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        public void AddSubject(string title)
        {
            try
            {
                string sql = "INSERT INTO subjects(title) " +
                    "VALUES(@title)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@title", title);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        public void RemoveSubject(string title)
        {
            try
            {
                string sql = "DELETE FROM subjects " +
                    "WHERE title = @title";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@title", title);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        public List<Subject> GetSubjects(bool test)
        {
            List<Subject> subjectsList = new List<Subject>();
            try
            {
                string sql = "select id, title from subjects " +
                    "WHERE groupId IS NULL ";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string title = reader["title"].ToString();
                    subjectsList.Add(new Subject(id, title));
                }

                conn.Close();
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message);
            }

            foreach (Subject s in subjectsList)
                s.SetGrades(GetGrades(s.Id));
            return subjectsList;
        }

        public void AttachSubject(string title, int groupId)
        {
            try
            {
                string sql = "UPDATE subjects " +
                    "SET groupId = @groupId " +
                    "WHERE title = @title ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@groupId", groupId);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }
        public int GetSubjectId(string title)
        {
            try
            {
                string sql = "SELECT id FROM subjects " +
                    "WHERE title = @title";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@title", title);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    conn.Close();
                    return id;
                }

                conn.Close();
                return 0;
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }
        public void RemoveGradesByStudent(int studentId)
        {
            try
            {
                string sql = "DELETE FROM grades " +
                    "WHERE studentId = @studentId ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@studentId", studentId);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }
        public void RemoveGradesBySubject(int subjectId)
        {
            try
            {
                string sql = "DELETE FROM grades " +
                    "WHERE subjectId = @subjectId ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@subjectId", subjectId);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }
        public void UnattachSubjects(int groupId)
        {
            try
            {
                string sql = "UPDATE subjects " +
                    "SET groupId = NULL " +
                    "WHERE groupId  = @groupId  ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@groupId ", groupId);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }
    }
}