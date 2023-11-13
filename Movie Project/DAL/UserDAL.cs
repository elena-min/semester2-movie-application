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
            string salt;
            var hashedPassword = HashPassword.GenerateHash(newUser.Password, out salt);
            string commandSql = "INSERT INTO Users (firstName, lastName, username, password, saltedPassword, email, gender) VALUES ( @u_fname, @u_lname, @u_username, @u_password, @u_saltedPassword, @u_email, @u_gender);";
                conn.Open();
                SqlCommand cmd = new SqlCommand(commandSql, conn);
                cmd.Parameters.AddWithValue("@u_username", newUser.Username);
                cmd.Parameters.AddWithValue("@u_password", hashedPassword);
            cmd.Parameters.AddWithValue("@u_saltedPassword", salt);
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
                    string salt = reader.GetString(5);  
                    string email = reader.GetString(6);
                    string string_gender = reader.GetString(7);
                    string profileDescription = null;
                    if (!reader.IsDBNull(9))
                    {
                        profileDescription = reader.GetString(9);
                    }
                    Gender gender = (Gender)Enum.Parse(typeof(Gender), string_gender);
                    if (!string.IsNullOrWhiteSpace(profileDescription))
                    {
                        newUser = new User(firstName, lastName, username, email, password, salt, gender, profileDescription);

                    }
                    else
                    {
                        newUser = new User(firstName, lastName, username, email, password, salt, gender);

                    }
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
                    string salt = reader.GetString(5);
                    string email = reader.GetString(6);
                    string string_gender = reader.GetString(7);
                    string profileDescription = null;
                    if (!reader.IsDBNull(9))
                    {
                        profileDescription = reader.GetString(9);
                    }
                    Gender gender = (Gender)Enum.Parse(typeof(Gender), string_gender);
                    if (!string.IsNullOrWhiteSpace(profileDescription))
                    {
                        newUser = new User(firstName, lastName, u_username, email, password, salt, gender, profileDescription);

                    }
                    else
                    {
                        newUser = new User(firstName, lastName, u_username, email, password, salt, gender);

                    }
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
                    string salt = reader.GetString(5);
                    string u_email = reader.GetString(6);
                    string string_gender = reader.GetString(7);
                    string profileDescription = null;
                    if (!reader.IsDBNull(9))
                    {
                        profileDescription = reader.GetString(9);
                    }
                    Gender gender = (Gender)Enum.Parse(typeof(Gender), string_gender);
                    if (!string.IsNullOrWhiteSpace(profileDescription))
                    {
                        newUser = new User(firstName, lastName, username, email, password, salt, gender, profileDescription);

                    }
                    else
                    {
                        newUser = new User(firstName, lastName, username, email, password, salt, gender);

                    }
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
            string query = "select * from Users";
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
                        string salt = reader.GetString(5);
                        string email = reader.GetString(6);
                        string string_gender = reader.GetString(7);
                        string profileDescription = null;
                    if (!reader.IsDBNull(9))
                    {
                            profileDescription = reader.GetString(9);
                        }
                        Gender gender = (Gender)Enum.Parse(typeof(Gender), string_gender);
                        User newUser = null;
                        if (!string.IsNullOrWhiteSpace(profileDescription))
                        {
                             newUser= new User(firstName, lastName, username, email, password, salt, gender, profileDescription);

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
                conn.Close();
                return users.ToArray();
            //}
            //catch (Exception)
            //{
            //    return null;
            //}
        }

        public bool UpdateUser(User user)
        {
            SqlConnection conn = CreateConnection();
            // try
            //{
            conn.Open();
            string commandSql;

            if (user.ProfileDescription != null)
            {
                commandSql = "UPDATE Users SET firstName = @e_fname, lastName = @e_lname, username = @e_username, gender = @e_gender, profileDescription = @profileDescription WHERE id = @e_id;";
            }
            else
            {
                commandSql = "UPDATE Users SET firstName = @e_fname, lastName = @e_lname, username = @e_username, gender = @e_gender WHERE id = @e_id;";
            }

            SqlCommand cmd = new SqlCommand(commandSql, conn);
            cmd.Parameters.AddWithValue("@e_id", user.GetId());
            cmd.Parameters.AddWithValue("@e_username", user.Username);
            cmd.Parameters.AddWithValue("@e_fname", user.FirstName);
            cmd.Parameters.AddWithValue("@e_lname", user.LastName);
            cmd.Parameters.AddWithValue("@e_gender", user.Gender.ToString());

            if (user.ProfileDescription != null)
            {
                cmd.Parameters.AddWithValue("@profileDescription", user.ProfileDescription);
            }

            cmd.ExecuteNonQuery();
            conn.Close();
            return true;


            //}
            //catch (Exception ex)
            //{
            //    return failed;
            //}
        }
        public string DeleteUser(int id)
        {
            SqlConnection conn = CreateConnection();
            using (conn)
            {
                try
                {
                    string query = "DELETE FROM Users WHERE id = @id";
                    SqlCommand commandSql = new SqlCommand(query, conn);
                    commandSql.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    int rowsAffected = commandSql.ExecuteNonQuery();
                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        return "User deleted successfully";
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
        
        public bool SetProfilePicture(int id, byte[] imageArray)
        {
            SqlConnection conn = CreateConnection();
            //try
            //{
            conn.Open();
            string commandSql = "UPDATE Users SET profilePicture = @profilePicture WHERE id = @id";
            SqlCommand cmd = new SqlCommand(commandSql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@profilePicture", imageArray);
            cmd.ExecuteNonQuery();

            conn.Close();
            return true;
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}
        }

        public string GetProfilePicByID(int id)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            string query = "SELECT profilePicture FROM Users WHERE id = @id";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
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

        public bool AddProductToFavorite(int mediaID, int userID)
        {
            SqlConnection conn = CreateConnection();
            // try
            // {
            string commandSql = "INSERT INTO FavoritesList (userID, mediaID) VALUES (@userID, @mediaID);";
            conn.Open();
            SqlCommand cmd = new SqlCommand(commandSql, conn);
            cmd.Parameters.AddWithValue("@userID", userID);
            cmd.Parameters.AddWithValue("@mediaID", mediaID);
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}
        }
        public bool CheckIfProductIsInFavorites(int mediaID, int userID)
        {
            SqlConnection conn = CreateConnection();
            string query = "SELECT * FROM FavoritesList WHERE userID = @userID AND mediaID = @mediaID";
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@userID", userID);
            command.Parameters.AddWithValue("@mediaID", mediaID);

            object result = command.ExecuteScalar();

            if (result == null || string.IsNullOrEmpty(result.ToString()))
            {
                conn.Close();
                return false;

            }
            else
            {
                conn.Close();
                return true;
            }
        }
        public MediaItem[] GetAllFavorites(int userID)
        {
            SqlConnection conn = CreateConnection();
            string query = "select f.mediaID, MI.title, MI.description, MI.rating, MI.releaseDate, MI.countryOfOrigin, MI.genres, MI.cast, MI.numberOfViews, M.director, M.writer, M.duration, S.seasons, S.episodes " +
                "from FavoritesList as f " +
                "inner join  MediaItem as MI on f.mediaID = MI.id " +
                "LEFT JOIN Movie as M ON MI.id = M.id " +
                "LEFT JOIN Serie as S ON MI.id = S.id " +
                "where f.userID = @userID";
            List<MediaItem> favs = new List<MediaItem>();
            try
            {
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@userID", userID);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int mediaItemId = reader.GetInt32(0);
                    string title = reader.GetString(1);
                    string description = reader.GetString(2);
                    double rating = (double)reader.GetDecimal(3);
                    DateTime releaseDate = reader.GetDateTime(4);
                    string countryOfOrigin = reader.GetString(5);
                    string string_cast = reader.GetString(7);
                    string genres_string = reader.GetString(6);
                    string[] string_genres = genres_string.Split(',');
                    string[] cast = string_cast.Split(',');
                        int numberOfViews = reader.GetInt32(8);


                        MediaItem mediaItem;

                    if (reader["director"] != DBNull.Value)
                    {
                        string director = reader.GetString(9);
                        string writer = reader.GetString(10);
                        int duration = reader.GetInt32(11);

                        mediaItem = new Movie(title, description, releaseDate, countryOfOrigin, rating,numberOfViews, director, writer, duration);
                    }
                    else if (reader["seasons"] != DBNull.Value)
                    {
                        int seasons = reader.GetInt32(12);
                        int episodes = reader.GetInt32(13);

                        mediaItem = new Serie(title, description, releaseDate, countryOfOrigin, rating, numberOfViews, seasons, episodes);
                    }
                    else
                    {
                        mediaItem = new MediaItem(title, description, releaseDate, countryOfOrigin, rating, numberOfViews);
                    }

                    mediaItem.SetId(mediaItemId);
                    foreach (string string_genre in string_genres)
                    {
                        if (Enum.TryParse(string_genre, out Genre enum_genre))
                        {
                            mediaItem.AddGenre(enum_genre);
                        }
                    }
                    foreach (string actor in cast)
                    {
                        mediaItem.Cast.AddToCast(actor);
                    }

                    favs.Add(mediaItem);
                }
            }

            reader.Close();
            conn.Close();
            return favs.ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public MediaItem[] GetAllFavoriteMovies(int userID)
        {
            SqlConnection conn = CreateConnection();
            string query = "select f.mediaID, MI.title, MI.description, MI.rating, MI.releaseDate, MI.countryOfOrigin, MI.genres, MI.cast, M.director, M.writer, M.duration, MI.numberOfViews " +
                "from FavoritesList as f " +
                "inner join  MediaItem as MI on f.mediaID = MI.id " +
                "inner JOIN Movie as M ON MI.id = M.id " +
                "where f.userID = @userID";
            List<MediaItem> favs = new List<MediaItem>();
            //try
            //{
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@userID", userID);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int mediaItemId = reader.GetInt32(0);
                        string title = reader.GetString(1);
                        string description = reader.GetString(2);
                        double rating = (double)reader.GetDecimal(3);
                        DateTime releaseDate = reader.GetDateTime(4);
                        string countryOfOrigin = reader.GetString(5);
                        string string_cast = reader.GetString(7);
                        string genres_string = reader.GetString(6);
                        string[] string_genres = genres_string.Split(',');
                        string[] cast = string_cast.Split(',');
                        string director = reader.GetString(8);
                        string writer = reader.GetString(9);
                       int duration = reader.GetInt32(10);
                    int numberOfViews = reader.GetInt32(11);
                    MediaItem mediaItem;
                        mediaItem = new Movie(title, description, releaseDate, countryOfOrigin, rating, numberOfViews, director, writer, duration);


                        mediaItem.SetId(mediaItemId);
                        foreach (string string_genre in string_genres)
                        {
                            if (Enum.TryParse(string_genre, out Genre enum_genre))
                            {
                                mediaItem.AddGenre(enum_genre);
                            }
                        }
                        foreach (string actor in cast)
                        {
                            mediaItem.Cast.AddToCast(actor);
                        }

                        favs.Add(mediaItem);
                    }
                }

                reader.Close();
                conn.Close();
                return favs.ToArray();
            //}
            //catch (Exception)
            //{
            //    return null;
            //}
        }

        public string RemoveFromFavorites(int mediaID, int userID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                string query = "DELETE FROM FavoritesList WHERE userID = @userID AND mediaID = @mediaID";
                SqlCommand commandSql = new SqlCommand(query, conn);
                commandSql.Parameters.AddWithValue("@userID", userID);
                commandSql.Parameters.AddWithValue("@mediaID", mediaID);
                conn.Open();
                int rowsAffected = commandSql.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return "Removed successfully";
                }
                else
                {
                    return "No data found.";
                }
            }
        }

        public void UpdateUserRecordInDatabase(int e_id, string hashedPassword, string salt)
        {
            SqlConnection conn = CreateConnection();
            // try
            //{
            conn.Open();
            string commandSql;
                commandSql = "UPDATE Users SET password = @password, saltedPassword = @saltedPassword WHERE id = @e_id;";


            SqlCommand cmd = new SqlCommand(commandSql, conn);
            cmd.Parameters.AddWithValue("@password", hashedPassword);
            cmd.Parameters.AddWithValue("@saltedPassword", salt);
            cmd.Parameters.AddWithValue("@e_id", e_id);


            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}

