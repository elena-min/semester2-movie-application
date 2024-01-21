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
    public class BannedUserDAL : IBannedUserDAL
    {
        public static SqlConnection CreateConnection()
        {
            try
            {
                return new SqlConnection("server=mssqlstud.fhict.local;Database=dbi500809_movieapp;User Id=dbi500809_movieapp;Password=movieapp;");
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating database connection", ex);
            }
        }
        public bool BanUserAccount(User user, string reasonForBanning)
        {
            SqlConnection conn = CreateConnection();
            try
            {
                conn.Open();
                string commandSql;
                commandSql = "INSERT INTO BannedUsers (userID, reasonForBanning, dateOfBanning) VALUES (@userID, @reasonForBanning, @dateOfBanning);";

                SqlCommand cmd = new SqlCommand(commandSql, conn);
                cmd.Parameters.AddWithValue("@userID", user.GetId());
                cmd.Parameters.AddWithValue("@reasonForBanning", reasonForBanning);
                cmd.Parameters.AddWithValue("@dateOfBanning", DateTime.Now);


                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error banning user's acccount", ex);
            }
            finally
            {
                conn.Close();
            }
        }

        public bool CheckIfUserIsBanned(User user)
        {
            SqlConnection conn = CreateConnection();
            try
            {
                string query = "SELECT * FROM BannedUsers WHERE userID = @userID";
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@userID", user.GetId());

                object result = command.ExecuteScalar();

                if (result == null || string.IsNullOrEmpty(result.ToString()))
                {
                    return false;

                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database error", ex);
            }
            finally
            {
                conn.Close();
            }
        }

        public string GetReasonForBanning(User user)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            string query = "SELECT reasonForBanning FROM BannedUsers WHERE userID = @id";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@id", user.GetId());
                    var result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        return result.ToString();
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Database error", ex);
                }
                finally
                {
                    conn.Close();
                }

            }
        }
        public DateTime? GetDateOfBanning(User user)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            string query = "SELECT dateOfBanning FROM BannedUsers WHERE userID = @id";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@id", user.GetId());
                    object resultObj = cmd.ExecuteScalar();
                    if (resultObj != DBNull.Value && resultObj != null)
                    {
                        DateTime result = (DateTime)resultObj;
                        return result;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Database error", ex);
                }
                finally
                {
                    conn.Close();
                }

            }
        }

        public string UnBanUserAccount(User user)
        {
            SqlConnection conn = CreateConnection();
            using (conn)
            {
                try
                {
                    string query = "DELETE FROM BannedUsers WHERE userID = @id";
                    SqlCommand commandSql = new SqlCommand(query, conn);
                    commandSql.Parameters.AddWithValue("@id", user.GetId());
                    conn.Open();
                    int rowsAffected = commandSql.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return "User unbanned successfully";
                    }
                    else
                    {
                        return "No data found.";
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Database error", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public User[] GetAllBannedUser()
        {
            SqlConnection conn = CreateConnection();
            string query = "select p.id, p.firstName, p.lastName, p.username, p.password, p.saltedPassword, p.email, p.gender, p.profileDescription " +
                "from Person as p inner join BannedUsers as b on p.id = b.userID";
            List<User> users = new List<User>();
            try
            {
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
                        string profileDescription = null;
                        if (!reader.IsDBNull(8))
                        {
                            profileDescription = reader.GetString(8);
                        }
                        Gender gender = (Gender)Enum.Parse(typeof(Gender), string_gender);
                        User newUser = null;
                        if (!string.IsNullOrWhiteSpace(profileDescription))
                        {
                            newUser = new User(firstName, lastName, username, email, password, salt, gender, profileDescription);

                        }
                        else
                        {
                            newUser = new User(firstName, lastName, username, email, password, salt, gender);

                        }
                        newUser.SetId(id);
                        users.Add(newUser);
                    }
                }

                reader.Close();
                return users.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception("Database error", ex);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
