using LogicLayer;
using LogicLayer.Classes;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAL : IUserDAL
    {
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection("server=mssqlstud.fhict.local;Database=dbi500809_movieapp;User Id=dbi500809_movieapp;Password=movieapp;");
        }
        public bool InsertUser(User newUser)
        {
            SqlConnection conn = CreateConnection();
            //try
            //{
                var hashedPassword = HashPassword.GenerateHash(newUser.Password);
                string commandSql = "INSERT INTO Users (firstName, lastName, username, password, email, gender) VALUES ( @u_fname, @u_lname, @u_username, @u_password, @u_email, @u_gender);";
                conn.Open();
                SqlCommand cmd = new SqlCommand(commandSql, conn);
                cmd.Parameters.AddWithValue("@u_username", newUser.Username);
                cmd.Parameters.AddWithValue("@u_password", hashedPassword);
                cmd.Parameters.AddWithValue("@u_email", newUser.Email);
                cmd.Parameters.AddWithValue("@u_fname", newUser.FirstName);
                cmd.Parameters.AddWithValue("@u_lname", newUser.LastName);
                cmd.Parameters.AddWithValue("@u_gender", newUser.Gender.ToString());
                cmd.ExecuteNonQuery();

                conn.Close();
                return true;
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}
        }
        public User GetUserByID(int id)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            string query = "select * from Users where id = @id";
            //try
            //{
            User newUser = null;
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
                    string email = reader.GetString(6);
                    string string_gender = reader.GetString(7);
                    Gender gender = (Gender)Enum.Parse(typeof(Gender), string_gender);
                    newUser = new User(firstName, lastName, username, email, password, gender);
                    newUser.SetId(e_id);
                }
            }

            reader.Close();
            conn.Close();
            return newUser;
            //}
            //catch (Exception)
            //{
            //    return null;
            //}
        }

        public User GetUserByUsername(string givenUsername)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            string query = "select * from Users where username = @username";

            User newUser = null;

            //try
            //{
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@username", givenUsername);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string firstName = reader.GetString(1);
                    string lastName = reader.GetString(2);
                    string u_username = reader.GetString(3);
                    string password = reader.GetString(4);
                    string email = reader.GetString(6);
                    string string_gender = reader.GetString(7);
                    Gender gender = (Gender)Enum.Parse(typeof(Gender), string_gender);
                    newUser = new User(firstName, lastName, u_username, email, password, gender);
                    newUser.SetId(id);
                }
            }

            reader.Close();
            conn.Close();
            return newUser;
            //}
            //catch (Exception)
            //{
            //    return null;
            //}
        }
        public User GetUserByEmail(string email)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            string query = "select * from Users where email = @email";
            //try
            //{
            User newUser = null;
            CreateConnection().Open();
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
                    string u_email = reader.GetString(6);
                    string string_gender = reader.GetString(7);
                    Gender gender = (Gender)Enum.Parse(typeof(Gender), string_gender);
                    newUser = new User(firstName, lastName, username, u_email, password, gender);
                    newUser.SetId(id);
                }
            }

            reader.Close();
            conn.Close();
            return newUser;
            //}
            //catch (Exception)
            //{
            //    return null;
            //}
        }
        public User[] GetAll()
        {
            SqlConnection conn = CreateConnection();
            string query = "select * from User";
            List<User> users = new List<User>();
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
                        string email = reader.GetString(6);
                        string string_gender = reader.GetString(7);
                        Gender gender = (Gender)Enum.Parse(typeof(Gender), string_gender);
                        int age = reader.GetInt32(8);
                        User newUser = new User(firstName, lastName, username, email, password, gender);
                        newUser.SetId(id);
                        users.Add(newUser);
                    }
                }

                reader.Close();
                conn.Close();
                return users.ToArray();
            //}
            //catch (Exception)
            //{
            //    return null;
            //}
        }

        public void UpdateUser(User user)
        {
        }
        public void DeleteUser(int id)
        {
        }
    }
}
