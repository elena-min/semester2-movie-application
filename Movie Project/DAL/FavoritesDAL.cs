using LogicLayer.Classes;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Interfaces;
using Microsoft.Extensions.Logging;

namespace DAL
{
    public class FavoritesDAL : IFavoritesDAL
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

        public bool AddProductToFavorite(MediaItem mediaItem, User user)
        {
            SqlConnection conn = CreateConnection();
            try
            {
                string commandSql = "INSERT INTO FavoritesList (userID, mediaID) VALUES (@userID, @mediaID);";
                conn.Open();
                SqlCommand cmd = new SqlCommand(commandSql, conn);
                cmd.Parameters.AddWithValue("@userID", user.GetId());
                cmd.Parameters.AddWithValue("@mediaID", mediaItem.GetId());
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding to the database", ex);
            }
            finally
            {
                conn.Close();
            }
        }
        public bool CheckIfProductIsInFavorites(MediaItem mediaItem, User user)
        {
            SqlConnection conn = CreateConnection();
            try
            {
                string query = "SELECT * FROM FavoritesList WHERE userID = @userID AND mediaID = @mediaID";
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@userID", user.GetId());
                command.Parameters.AddWithValue("@mediaID", mediaItem.GetId());

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
        public MediaItem[] GetAllFavorites(User user)
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
                command.Parameters.AddWithValue("@userID", user.GetId());
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



                        if (reader["director"] != DBNull.Value)
                        {
                            string director = reader.GetString(9);
                            string writer = reader.GetString(10);
                            int duration = reader.GetInt32(11);

                            MediaItem mediaItem = new Movie(title, description, releaseDate, countryOfOrigin, rating, director, writer, duration);
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
                        else if (reader["seasons"] != DBNull.Value)
                        {
                            int seasons = reader.GetInt32(12);
                            int episodes = reader.GetInt32(13);

                            MediaItem mediaItem = new Serie(title, description, releaseDate, countryOfOrigin, rating, seasons, episodes);
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
                }

                reader.Close();
                return favs.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting favorites", ex);
            }
            finally
            {
                conn.Close();
            }
        }
        public MediaItem[] GetAllFavoriteMovies(User user)
        {
            SqlConnection conn = CreateConnection();
            string query = "select f.mediaID, MI.title, MI.description, MI.rating, MI.releaseDate, MI.countryOfOrigin, MI.genres, MI.cast, M.director, M.writer, M.duration " +
                "from FavoritesList as f " +
                "inner join  MediaItem as MI on f.mediaID = MI.id " +
                "inner JOIN Movie as M ON MI.id = M.id " +
                "where f.userID = @userID";
            List<MediaItem> favs = new List<MediaItem>();
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@userID", user.GetId());
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
                        MediaItem mediaItem;
                        mediaItem = new Movie(title, description, releaseDate, countryOfOrigin, rating, director, writer, duration);


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
                return favs.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving favorite movies", ex);
            }
            finally
            {
                conn.Close();
            }
        }

        public string RemoveFromFavorites(MediaItem mediaItem, User user)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    string query = "DELETE FROM FavoritesList WHERE userID = @userID AND mediaID = @mediaID";
                    SqlCommand commandSql = new SqlCommand(query, conn);
                    commandSql.Parameters.AddWithValue("@userID", user.GetId());
                    commandSql.Parameters.AddWithValue("@mediaID", mediaItem.GetId());
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
                catch (Exception ex)
                {
                    throw new Exception("Error removing from database", ex);
                }
                finally
                {
                    conn.Close();
                }

            }
        }

        public bool DeletedMediaItem(MediaItem mediaItem)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    string query = "DELETE FROM FavoritesList WHERE mediaID = @mediaID";
                    SqlCommand commandSql = new SqlCommand(query, conn);
                    commandSql.Parameters.AddWithValue("@mediaID", mediaItem.GetId());
                    conn.Open();
                    int rowsAffected = commandSql.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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

        public bool DeletedUser(User user)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    string query = "DELETE FROM FavoritesList WHERE userID = @userID";
                    SqlCommand commandSql = new SqlCommand(query, conn);
                    commandSql.Parameters.AddWithValue("@userID", user.GetId());
                    conn.Open();
                    int rowsAffected = commandSql.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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

    }
}
