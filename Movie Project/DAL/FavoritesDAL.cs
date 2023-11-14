using LogicLayer.Classes;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Interfaces;

namespace DAL
{
    public class FavoritesDAL : IFavoritesDAL
    {
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection("server=mssqlstud.fhict.local;Database=dbi500809_movieapp;User Id=dbi500809_movieapp;Password=movieapp;");
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

                            mediaItem = new Movie(title, description, releaseDate, countryOfOrigin, rating, numberOfViews, director, writer, duration);
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
