using LogicLayer;
using LogicLayer.Classes;
using LogicLayer.Interfaces;
using System.Data.Common;
using System.Data.SqlClient;

namespace DAL
{
    public class EmployeeDAL : IEmployeeDAL
    {
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection("server=mssqlstud.fhict.local;Database=dbi500809_movieapp;User Id=dbi500809_movieapp;Password=movieapp;");
        }
        public bool InsertEmployee(Employee newEmployee)
        {
            SqlConnection conn = CreateConnection();
            //try
            //{
            string salt;

            var hashedPassword = HashPassword.GenerateHash(newEmployee.Password, out salt);
            string commandSql = "INSERT INTO Person (firstName, lastName, username, password,saltedPassword, email, gender, age, profilePicture, role) VALUES (@firstName, @lastName, @username, @password, @saltedPassword, @email, @gender, @age, @profilePicture, @role);";
            conn.Open();
            SqlCommand cmd = new SqlCommand(commandSql, conn);
            cmd.Parameters.AddWithValue("@firstName", newEmployee.FirstName);
            cmd.Parameters.AddWithValue("@lastName", newEmployee.LastName);
            cmd.Parameters.AddWithValue("@username", newEmployee.Username);
            cmd.Parameters.AddWithValue("@password", hashedPassword);
            cmd.Parameters.AddWithValue("@saltedPassword", salt);
            cmd.Parameters.AddWithValue("@email", newEmployee.Email);
            cmd.Parameters.AddWithValue("@gender", newEmployee.Gender.ToString());
            cmd.Parameters.AddWithValue("@age", newEmployee.Age);
            cmd.Parameters.AddWithValue("@profilePicture", new byte[0]);
            cmd.Parameters.AddWithValue("@role", "Employee");

            cmd.ExecuteNonQuery();

            conn.Close();
            return true;
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}
        }
        public Employee GetEmployeeByID(int id)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            string query = "select * from Person where id = @id";
            //try
            //{
            Employee newEmp = null;
            CreateConnection().Open();
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int e_id = reader.GetInt32(0);
                    string firstName = reader.GetString(1);
                    string lastName = reader.GetString(2);
                    string username = reader.GetString(3);
                    string password = reader.GetString(4);
                    string salt = reader.GetString(5);
                    string email = reader.GetString(6);
                    string string_gender = reader.GetString(7);
                    Gender gender = (Gender)Enum.Parse(typeof(Gender), string_gender);
                    int age = reader.GetInt32(8);
                    newEmp = new Employee(firstName, lastName, username, email, password, salt, gender, age);
                    newEmp.SetId(e_id);
                }
            }

            reader.Close();
            conn.Close();
            return newEmp;
            //}
            //catch (Exception)
            //{
            //    return null;
            //}
        }
        public Employee GetEmployeeByUsername(string username)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            string query = "select * from Person where username = @username and role = 'Employee'";
            //try
            //{
            Employee newEmp = null;
            CreateConnection().Open();
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@username", username);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string firstName = reader.GetString(1);
                    string lastName = reader.GetString(2);
                    string e_username = reader.GetString(3);
                    string password = reader.GetString(4);
                    string salt = reader.GetString(5);
                    string email = reader.GetString(6);
                    string string_gender = reader.GetString(7);
                    Gender gender = (Gender)Enum.Parse(typeof(Gender), string_gender);
                    int age = reader.GetInt32(8);
                    newEmp = new Employee(firstName, lastName, e_username, email, password,salt,  gender, age);
                    newEmp.SetId(id);
                }
            }

            reader.Close();
            conn.Close();
            return newEmp;
        }
        public Employee GetEmployeeByEmail(string email)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            string query = "select * from Person where email = @email and age is not null";
            //try
            //{
            Employee newEmp = null;
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@email", email);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string firstName = reader.GetString(1);
                    string lastName = reader.GetString(2);
                    string username = reader.GetString(3);
                    string password = reader.GetString(4);
                    string salt = reader.GetString(5);
                    string e_email = reader.GetString(6);
                    string string_gender = reader.GetString(7);
                    Gender gender = (Gender)Enum.Parse(typeof(Gender), string_gender);
                    int age = reader.GetInt32(8);
                    newEmp = new Employee(firstName, lastName, username, e_email, password, salt, gender, age);
                    newEmp.SetId(id);
                }
            }

            reader.Close();
            conn.Close();
            return newEmp;
        }
        public Employee[] GetAll()
        {
            SqlConnection conn = CreateConnection();
            string query = "select * from Person where age is not null";
            List<Employee> employees = new List<Employee>();
            //try
            //{

                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string firstName = reader.GetString(1);
                        string lastName = reader.GetString(2);
                        string username = reader.GetString(3);
                        string password = reader.GetString(4);
                    string salt = reader.GetString(5);
                    string email = reader.GetString(6);
                        string string_gender = reader.GetString(7);
                        Gender gender = (Gender)Enum.Parse(typeof(Gender), string_gender);
                        int age = reader.GetInt32(8);
                         Employee newEmp = new Employee(firstName, lastName, username, email, password, salt, gender, age);
                        newEmp.SetId(id);
                        employees.Add(newEmp);
                    }
                }

                reader.Close();
                conn.Close();
                return employees.ToArray();
            //}
            //catch (Exception)
            //{
            //    return null;
            //}
        }
        public bool UpdateEmployee(Employee employee, byte[] pictureBytes)
        {
            SqlConnection conn = CreateConnection();
            try
            {
                string commandSql = "UPDATE Person SET firstName = @e_fname, lastName = @e_lname, username = @e_username, email = @e_email, gender = @e_gender, age = @e_age, profilePicture = @profilePicture WHERE id = @e_id;";
                conn.Open();
                SqlCommand cmd = new SqlCommand(commandSql, conn);
                cmd.Parameters.AddWithValue("@e_id", employee.GetId());
                cmd.Parameters.AddWithValue("@e_username", employee.Username);
                cmd.Parameters.AddWithValue("@e_email", employee.Email);
                cmd.Parameters.AddWithValue("@e_fname", employee.FirstName);
                cmd.Parameters.AddWithValue("@e_lname", employee.LastName);
                cmd.Parameters.AddWithValue("@e_gender", employee.Gender.ToString());
                cmd.Parameters.AddWithValue("@e_age", employee.Age.ToString());
                cmd.Parameters.AddWithValue("@profilePicture", pictureBytes);

                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string DeleteEmployee(Employee emp)
        {
        SqlConnection conn = CreateConnection();
        using (conn)
            {
                try
                {
                    string query = "DELETE FROM Person WHERE id = @id";
                    SqlCommand commandSql = new SqlCommand(query, conn);
                    commandSql.Parameters.AddWithValue("@id", emp.GetId());
                    conn.Open();
                    int rowsAffected = commandSql.ExecuteNonQuery();      
                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        return "Employee deleted successfully";
                    }
                    else
                    {
                        return "No data found.";
                    }
                }
                catch (Exception ex)
                {
                    return "Operation failed.";
                }
            }
        }
        public string GetProfilePicByID(Employee emp)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            string query = "SELECT profilePicture FROM Person WHERE id = @id";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", emp.GetId());
                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                {
                    byte[] imageData = (byte[])result;
                    string base64StringImage = Convert.ToBase64String(imageData);
                    return base64StringImage;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool DeleteUserAccount(User user, string reasonForDeleting)
        {
            SqlConnection conn = CreateConnection();
            // try
            //{
            conn.Open();
            string commandSql;

          
            commandSql = "UPDATE Person SET isAccountDeleted = 1, reasonForDeleting = @reasonForDeleting WHERE id = @u_id;";
            

            SqlCommand cmd = new SqlCommand(commandSql, conn);
            cmd.Parameters.AddWithValue("@u_id", user.GetId());
            cmd.Parameters.AddWithValue("@reasonForDeleting", reasonForDeleting);

            cmd.ExecuteNonQuery();
            conn.Close();
            return true;


            //}
            //catch (Exception ex)
            //{
            //    return failed;
            //}
        }

        public string GetPasswords(int id)
        {
            SqlConnection conn = CreateConnection();
            string query = "select password from Person where saltedPassword is null and id = @id";
            string passwords = null;
            //try
            //{
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                     passwords = reader.GetString(0);
                }
            }

            reader.Close();
            conn.Close();
            return passwords;
            //}
            //catch (Exception)
            //{
            //    return null;
            //}
        }
        public void UpdatePasswordInDatabase(string hashedPassword, string salt, int id)
        {
            SqlConnection conn = CreateConnection();

                string commandSql = "UPDATE Person SET password = @password, saltedPassword = @saltedPassword WHERE id = @e_id;";
                conn.Open();
                SqlCommand cmd = new SqlCommand(commandSql, conn);
                cmd.Parameters.AddWithValue("@password", hashedPassword);
                cmd.Parameters.AddWithValue("@saltedPassword", salt);
                cmd.Parameters.AddWithValue("@e_id", id);

                cmd.ExecuteNonQuery();
                conn.Close();

        }

    }
}
