using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace akademine_sistema.Repositories
{
    class UsersRepository
    {
        //private static List<User> users;
        private SqlConnection conn;

        public UsersRepository()
        {
            conn = new SqlConnection(@"Server=.;Database=akademine_sistema;Trusted_Connection=true;"); // prijungimas prie DB
        }

        public void Register(User user)
        {
            try
            {
                string sql = "insert into users(name, surname, username, password) " +
                    "values (@name, @surname, @username, @password)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", user.GetName());
                cmd.Parameters.AddWithValue("@surname", user.GetSurname());
                cmd.Parameters.AddWithValue("@username", user.GetName()); // prisijungimo vardui priskiriamas vardas (sąlyga)
                cmd.Parameters.AddWithValue("@password", user.GetSurname()); // slaptažodžiui priskiriama pavardė (sąlyga)
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        public List<Teacher> GetTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();
            string sql = "select id, name, surname, username, password, subjectId from teachers ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string name = reader["name"].ToString();
                    string surname = reader["surname"].ToString();
                    string username = reader["username"].ToString();
                    string password = reader["password"].ToString();
                    if (DBNull.Value.Equals(reader["subjectId"]))
                    {
                        teachers.Add(new Teacher(id, name, surname, username, password));
                    }
                    else
                    {
                        int subjectId = int.Parse(reader["subjectId"].ToString());
                        teachers.Add(new Teacher(id, name, surname, username, password, subjectId));
                    }
                }
            }
            conn.Close();
            return teachers;
        }

        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            string sql = "select id, name, surname, username, password, groupId from students ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string name = reader["name"].ToString();
                    string surname = reader["surname"].ToString();
                    string username = reader["username"].ToString();
                    string password = reader["password"].ToString();
                    if (DBNull.Value.Equals(reader["groupId"]))
                    {
                        students.Add(new Student(id, name, surname, username, password));
                    }
                    else
                    {
                        int groupId = int.Parse(reader["groupId"].ToString());
                        students.Add(new Student(id, name, surname, username, password, groupId));
                    }
                    /*
                    if (reader.IsDBNull(5))
                    {
                        users.Add(new Student(id, name, surname, username, password));
                    }
                    else
                    {
                        int groupId = int.Parse(reader["groupId"].ToString());
                        users.Add(new Student(id, name, surname, username, password, groupId));
                    }*/
                }
            }
            conn.Close();
            return students;
        }

        public List<Student> GetStudents(int group)
        {
            List<Student> students = new List<Student>();
            string sql = "select id, name, surname, username, password from students " +
                "WHERE groupId IS NULL ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string name = reader["name"].ToString();
                    string surname = reader["surname"].ToString();
                    string username = reader["username"].ToString();
                    string password = reader["password"].ToString();
                    students.Add(new Student(id, name, surname, username, password));
                }
            }
            conn.Close();
            return students;
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            //----------------------------------------------------------------------------------------------------
            // Administratoriai
            string sql = "select name, surname, username, password from admins ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string name = reader["name"].ToString();
                    string surname = reader["surname"].ToString();
                    string username = reader["username"].ToString();
                    string password = reader["password"].ToString();
                    users.Add(new Admin(name, surname, username, password));
                }
            }
            conn.Close();
            //----------------------------------------------------------------------------------------------------
            // Dėstytojai
            sql = "select id, name, surname, username, password, subjectId from teachers ";
            cmd = new SqlCommand(sql, conn);
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string name = reader["name"].ToString();
                    string surname = reader["surname"].ToString();
                    string username = reader["username"].ToString();
                    string password = reader["password"].ToString();
                    if (DBNull.Value.Equals(reader["subjectId"]))
                    {
                        users.Add(new Teacher(id, name, surname, username, password));
                    }
                    else
                    {
                        int subjectId = int.Parse(reader["subjectId"].ToString());
                        users.Add(new Teacher(id, name, surname, username, password, subjectId));
                    }
                }
            }
            conn.Close();
            //----------------------------------------------------------------------------------------------------
            // Studentai
            sql = "select id, name, surname, username, password, groupId from students ";
            cmd = new SqlCommand(sql, conn);
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string name = reader["name"].ToString();
                    string surname = reader["surname"].ToString();
                    string username = reader["username"].ToString();
                    string password = reader["password"].ToString();
                    if (DBNull.Value.Equals(reader["groupId"]))
                    {
                        users.Add(new Student(id, name, surname, username, password));
                    }
                    else
                    {
                        int groupId = int.Parse(reader["groupId"].ToString());
                        users.Add(new Student(id, name, surname, username, password, groupId));
                    }
                    /*
                    if (reader.IsDBNull(5))
                    {
                        users.Add(new Student(id, name, surname, username, password));
                    }
                    else
                    {
                        int groupId = int.Parse(reader["groupId"].ToString());
                        users.Add(new Student(id, name, surname, username, password, groupId));
                    }*/
                }
            }
            conn.Close();
            return users;
        }
        /*
        public List<User> SafeLogin(string username, string password)
        {
            try
            {
                List<User> users = new List<User>();
                string sql = "select name, surname, address, card, cvc, username from users " +
                    "where username = @username and password = @password ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader["name"].ToString();
                        string surname = reader["surname"].ToString();
                        string usrname = reader["username"].ToString();
                        string card = reader["card"].ToString();
                        string cvc = reader["cvc"].ToString();
                        string address = reader["address"].ToString();
                        users.Add(new User(name, surname, usrname, password));
                    }
                }

                conn.Close();
                if (users.Count <= 0)
                {
                    throw new Exception("Wrong username/password");
                }
                return users;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        */
        public User Login(string username, string password)
        {
            List<User> users = GetUsers();
            foreach (User u in users)
            {
                if (u.GetUsername().Equals(username) && u.GetPassword().Equals(password))
                {
                    return u;
                }
            }
            throw new Exception("Neteisingas slaptažodis arba vardas.");
        }

        public void AddStudent(string name, string surname)
        {
            try
            {
                string sql = "insert into students(name, surname, username, password) " +
                    "values (@name, @surname, @name, @surname) ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@surname", surname);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }
        public void RemoveStudent(string fullName)
        {
            try
            {
                string sql = "DELETE FROM students " +
                    "WHERE name + ' ' + surname = @string ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@string", fullName);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }
        public void AttachStudent(string fullName, int groupId)
        {
            try
            {
                string sql = "UPDATE students " +
                    "SET groupId = @groupId " +
                    "WHERE name + ' ' + surname = @string ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@string", fullName);
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
        public void AddTeacher(string name, string surname, string username, string password)
        {
            try
            {
                string sql = "insert into teachers(name, surname, username, password) " +
                    "values (@name, @surname, @username, @password) ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }
        public void RemoveTeacher(string fullName)
        {
            try
            {
                string sql = "DELETE FROM teachers " +
                    "WHERE name + ' ' + surname = @string ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@string", fullName);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }
        public List<Teacher> GetTeachers(int subjectId)
        {
            List<Teacher> teachers = new List<Teacher>();
            string sql = "select id, name, surname, username, password, subjectId from teachers " +
                "WHERE subjectId IS NULL ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string name = reader["name"].ToString();
                    string surname = reader["surname"].ToString();
                    string username = reader["username"].ToString();
                    string password = reader["password"].ToString();
                    teachers.Add(new Teacher(id, name, surname, username, password));
                }
            }
            conn.Close();
            return teachers;
        }
        public void AttachTeacher(string fullName, int subjectId)
        {
            try
            {
                string sql = "UPDATE teachers " +
                    "SET subjectId = @subjectId " +
                    "WHERE name + ' ' + surname = @string ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@string", fullName);
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
        public void UnattachTeachers(int subjectId)
        {
            try
            {
                string sql = "UPDATE teachers " +
                    "SET subjectId = NULL " +
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
        public Student GetStudent(string fullName)
        {
            string sql = "select id, name, surname, username, password from students " +
                "WHERE name + ' ' + surname = @fullName ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@fullName", fullName);
            conn.Open();
            cmd.ExecuteNonQuery();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string name = reader["name"].ToString();
                    string surname = reader["surname"].ToString();
                    string username = reader["username"].ToString();
                    string password = reader["password"].ToString();
                    Student student = new Student(id, name, surname, username, password);
                    conn.Close();
                    return student;
                }
                return null;
            }
        }
        public void UnattachStudents(int groupId)
        {
            try
            {
                string sql = "UPDATE students " +
                    "SET groupId = NULL " +
                    "WHERE groupId = @groupId ";
                SqlCommand cmd = new SqlCommand(sql, conn);
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
    }
}