using LogicLayer;
using LogicLayer.Classes;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static System.Net.Mime.MediaTypeNames;

namespace DAL
{
    public class MediaItemDAL : IMediaItemDAL
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
        public bool AddMediaItem(MediaItem newMediaItem, byte[] pictureBytes, byte[] pictureBytesCompressed)
        {
            bool addMediaItem = false;
            SqlConnection conn = CreateConnection();
            try
            {
                conn.Open();
                string commandSql = "INSERT INTO MediaItem (title, description, rating, releaseDate, countryOfOrigin, genres, cast, image, imageCompressed) VALUES (@title, @description, @rating, @releaseDate, @countryOfOrigin, @genres, @cast, @image, @imageCompressed); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(commandSql, conn);
                cmd.Parameters.AddWithValue("@title", newMediaItem.Title);
                cmd.Parameters.AddWithValue("@description", newMediaItem.Description);
                cmd.Parameters.AddWithValue("@rating", newMediaItem.Rating);
                cmd.Parameters.AddWithValue("@releaseDate", newMediaItem.ReleaseDate);
                cmd.Parameters.AddWithValue("@countryOfOrigin", newMediaItem.CountryOfOrigin);
                cmd.Parameters.AddWithValue("@cast", newMediaItem.Cast.ToString());
                cmd.Parameters.AddWithValue("@image", pictureBytes);
                cmd.Parameters.AddWithValue("@imageCompressed", pictureBytesCompressed);

                string stringGenres = "";
                foreach (Genre genre in newMediaItem.GetAllGenres())
                {
                    stringGenres += genre.ToString();
                    stringGenres += ",";
                }
                cmd.Parameters.AddWithValue("@genres", stringGenres);

                int productId = Convert.ToInt32(cmd.ExecuteScalar());

                if (newMediaItem is Movie)
                {

                    cmd = new SqlCommand("SET IDENTITY_INSERT Movie ON", conn);
                    cmd.ExecuteNonQuery();
                    string commandSqlMovie = "INSERT INTO Movie (id, director, writer, duration) VALUES (@m_id, @director, @writer, @duration)";
                    cmd = new SqlCommand(commandSqlMovie, conn);
                    cmd.Parameters.AddWithValue("@m_id", productId);
                    cmd.Parameters.AddWithValue("@director", ((Movie)newMediaItem).Director);
                    cmd.Parameters.AddWithValue("@writer", ((Movie)newMediaItem).Writer);
                    cmd.Parameters.AddWithValue("@duration", ((Movie)newMediaItem).Duration);
                    cmd.ExecuteNonQuery();
                    addMediaItem = true;
                    return addMediaItem;
                }
                if (newMediaItem is Serie)
                {

                    cmd = new SqlCommand("SET IDENTITY_INSERT Serie ON", conn);
                    cmd.ExecuteNonQuery();
                    string commandSqlMovie = "INSERT INTO Serie (id, seasons, episodes) VALUES (@m_id, @seasons, @episodes)";
                    cmd = new SqlCommand(commandSqlMovie, conn);
                    cmd.Parameters.AddWithValue("@m_id", productId);
                    cmd.Parameters.AddWithValue("@seasons", ((Serie)newMediaItem).Seasons);
                    cmd.Parameters.AddWithValue("@episodes", ((Serie)newMediaItem).Episodes);
                    cmd.ExecuteNonQuery();
                    addMediaItem = true;
                    return addMediaItem;
                }
                addMediaItem = true;
                return addMediaItem;
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting into database", ex);
            }
            finally
            {
                conn.Close();
            }
        }
        public MediaItem[] GetAll()
        {

            List<MediaItem> mediaItems = new List<MediaItem>();
            List<Exception> exceptions = new List<Exception>();
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    conn.Open();

                    string commandSql = "SELECT MI.id, MI.title, MI.description, MI.rating, MI.releaseDate, MI.countryOfOrigin, MI.genres, MI.cast, MI.image, " +
                                        "M.director, M.writer, M.duration, " +
                                        "S.seasons, S.episodes " +
                                        "FROM MediaItem as MI " +
                                        "LEFT JOIN Movie as M ON MI.id = M.id " +
                                        "LEFT JOIN Serie as S ON MI.id = S.id";
                    SqlCommand cmd = new SqlCommand(commandSql, conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
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

                                MediaItem mediaItem;

                                if (reader["director"] != DBNull.Value)
                                {
                                    string director = reader.GetString(9);
                                    string writer = reader.GetString(10);
                                    int duration = reader.GetInt32(11);

                                    mediaItem = new Movie(title, description, releaseDate, countryOfOrigin, rating, director, writer, duration);
                                }
                                else if (reader["seasons"] != DBNull.Value)
                                {
                                    int seasons = reader.GetInt32(12);
                                    int episodes = reader.GetInt32(13);

                                    mediaItem = new Serie(title, description, releaseDate, countryOfOrigin, rating, seasons, episodes);
                                }
                                else
                                {
                                    throw new Exception("Undetected type.");
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

                                mediaItems.Add(mediaItem);
                            }
                            catch (FormatException ex)
                            {
                                // Log the exception for the specific row
                                exceptions.Add(ex);
                                // Continue to the next iteration of the loop
                                continue;
                            }
                            catch (Exception ex)
                            {
                                // Log other exceptions
                                exceptions.Add(ex);
                            }
                        }
                    }
                



            // If there were exceptions, throw a single exception with details
            if (exceptions.Count > 0)
                {
                    string exceptionMessages = string.Join("\n", exceptions.Select(e => e.Message));
                    throw new InvalidObjectException($"Error processing some rows:\n{exceptionMessages}", exceptions[0]);
                }

                return mediaItems.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retriveing media items from database", ex);
            }
            finally
            {
                conn.Close();
            }
        }

        }

        public int[] GetAllGivenRatings(MediaItem mediaItem)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            string query = "select m.id, m.title, r.rating from MediaItem as m inner join Review as r on m.id = r.mediaItemID where m.id = @mediaID";
            List<int> givenRatings = new List<int>();
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@mediaID", mediaItem.GetId());
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int givenRating = reader.GetInt32(2);
                        givenRatings.Add(givenRating);
                    }
                }
                reader.Close();
                return givenRatings.ToArray();
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

        public MediaItem GetMediaItem(string title)
        {
            SqlConnection conn = CreateConnection();
            try
            {
                conn.Open();

                string commandSql = "SELECT MI.id, MI.title, MI.description, MI.rating, MI.releaseDate, MI.countryOfOrigin, MI.genres, MI.cast, MI.image, " +
                                    "M.director, M.writer, M.duration, " +
                                    "S.seasons, S.episodes " +
                                    "FROM MediaItem as MI " +
                                    "LEFT JOIN Movie as M ON MI.id = M.id " +
                                    "LEFT JOIN Serie as S ON MI.id = S.id " +
                                    "WHERE MI.title = @Title";
                SqlCommand cmd = new SqlCommand(commandSql, conn);
                cmd.Parameters.AddWithValue("@Title", title);

                MediaItem mediaItem = null;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int mediaItemId = reader.GetInt32(0);
                        string retrievedTitle = reader.GetString(1);
                        string description = reader.GetString(2);
                        double rating = (double)reader.GetDecimal(3);
                        DateTime releaseDate = reader.GetDateTime(4);
                        string countryOfOrigin = reader.GetString(5);
                        string string_cast = reader.GetString(7);
                        string genresString = reader.GetString(reader.GetOrdinal("genres"));
                        List<Genre> genres = genresString.Split(',').Select(s => Enum.Parse<Genre>(s)).ToList();
                        string[] cast = string_cast.Split(',');

                        if (reader["director"] != DBNull.Value)
                        {
                            string director = reader.GetString(9);
                            string writer = reader.GetString(10);
                            int duration = reader.GetInt32(11);

                             mediaItem = new Movie(retrievedTitle, description, releaseDate, countryOfOrigin, rating, director, writer, duration);
                        }
                        else if (reader["seasons"] != DBNull.Value)
                        {
                            int seasons = reader.GetInt32(12);
                            int episodes = reader.GetInt32(13);

                             mediaItem = new Serie(retrievedTitle, description, releaseDate, countryOfOrigin, rating, seasons, episodes);
                        }
                        else
                        {
                            throw new Exception("Undetected type.");
                        }

                        mediaItem.SetId(mediaItemId);
                        mediaItem.Cast = new Cast(retrievedTitle);
                        foreach (Genre genre in genres)
                        {
                            mediaItem.AddGenre(genre);
                        }
                        foreach (string actor in cast)
                        {
                            mediaItem.Cast.AddToCast(actor);
                        }

                    }
                }
                return mediaItem;
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

        public MediaItem GetMediaItemById(int id)
        {
            SqlConnection conn = CreateConnection();
            try
            {
                conn.Open();

                string commandSql = "SELECT MI.id, MI.title, MI.description, MI.rating, MI.releaseDate, MI.countryOfOrigin, MI.genres, MI.cast, MI.image, " +
                                    "M.director, M.writer, M.duration, " +
                                    "S.seasons, S.episodes " +
                                    "FROM MediaItem as MI " +
                                    "LEFT JOIN Movie as M ON MI.id = M.id " +
                                    "LEFT JOIN Serie as S ON MI.id = S.id " +
                                    "WHERE MI.id = @id";
                SqlCommand cmd = new SqlCommand(commandSql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                MediaItem mediaItem = null;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int mediaItemId = reader.GetInt32(0);
                        string retrievedTitle = reader.GetString(1);
                        string description = reader.GetString(2);
                        double rating = (double)reader.GetDecimal(3);
                        DateTime releaseDate = reader.GetDateTime(4);
                        string countryOfOrigin = reader.GetString(5);
                        string string_cast = reader.GetString(7);
                        string genresString = reader.GetString(6);
                        //List<Genre> genres = genresString.Split(',').Select(s => Enum.Parse<Genre>(s)).ToList();
                        string[] string_genres = genresString.Split(',');


                        string[] cast = string_cast.Split(',');

                        if (reader["director"] != DBNull.Value)
                        {
                            string director = reader.GetString(9);
                            string writer = reader.GetString(10);
                            int duration = reader.GetInt32(11);

                            mediaItem = new Movie(retrievedTitle, description, releaseDate, countryOfOrigin, rating, director, writer, duration);
                        }
                        else if (reader["seasons"] != DBNull.Value)
                        {
                            int seasons = reader.GetInt32(12);
                            int episodes = reader.GetInt32(13);

                            mediaItem = new Serie(retrievedTitle, description, releaseDate, countryOfOrigin, rating, seasons, episodes);
                        }
                        else
                        {
                            throw new Exception("Undetected type.");
                        }

                        mediaItem.SetId(mediaItemId);
                        mediaItem.Cast = new Cast(retrievedTitle);
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
                    }
                }
                return mediaItem;
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
        public string GetMediaItemImageByID(MediaItem mediaItem)
        {
            SqlConnection conn = CreateConnection();
            
            try
            {
                conn.Open();
                string query = "select image from MediaItem where id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", mediaItem.GetId());
                byte[] imageData = (byte[])cmd.ExecuteScalar();

                string base64StringImage = Convert.ToBase64String(imageData);
                return base64StringImage;
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
        public string GetMediaItemCompressedImageByID(MediaItem mediaItem)
        {
            SqlConnection conn = CreateConnection();

            try
            {
                conn.Open();
                string query = "select imageCompressed from MediaItem where id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", mediaItem.GetId());
                byte[] imageData = (byte[])cmd.ExecuteScalar();

                string base64StringImage = Convert.ToBase64String(imageData);
                return base64StringImage;
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

        public bool RemoveMediaItem(MediaItem mediaItem)
        {
            SqlConnection conn = CreateConnection();
            using (conn)
            {
                try
                {
                    string query = "DELETE FROM Movie WHERE id = @id";
                    SqlCommand commandSql = new SqlCommand(query, conn);
                    commandSql.Parameters.AddWithValue("@id", mediaItem.GetId());
                    conn.Open();
                    int rowsAffected = commandSql.ExecuteNonQuery();

                    string query2 = "DELETE FROM Serie WHERE id = @id";
                    SqlCommand commandSql2 = new SqlCommand(query2, conn);
                    commandSql2.Parameters.AddWithValue("@id", mediaItem.GetId());
                    int rowsAffected2 = commandSql2.ExecuteNonQuery();

                    string query3 = "DELETE FROM MediaItem WHERE id = @id";
                    SqlCommand commandSql3 = new SqlCommand(query3, conn);
                    commandSql3.Parameters.AddWithValue("@id", mediaItem.GetId());
                    int rowsAffected3 = commandSql3.ExecuteNonQuery();
                    conn.Close();

                    if (rowsAffected3 > 0 || rowsAffected > 0)
                    {
                        return true;
                    }
                    else if (rowsAffected3 > 0 || rowsAffected2 > 0)
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
                    throw new Exception("Error deleting form database", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public bool UpdateMediaItem(MediaItem mediaItem, byte[] pictureBytes, byte[] pictureBytesCompressed)
        {
            bool updateMediaItem = false;
            SqlConnection conn = CreateConnection();
            try
            {
                conn.Open();
                string commandSql = "UPDATE MediaItem SET title = @title, description = @description, rating = @rating, releaseDate = @releaseDate, countryOfOrigin = @countryOfOrigin, genres = @genres,  cast = @cast, image = @image, imageCompressed = @imageCompressed WHERE id = @id";
                SqlCommand cmd = new SqlCommand(commandSql, conn);
                cmd.Parameters.AddWithValue("@id", mediaItem.GetId());
                cmd.Parameters.AddWithValue("@title", mediaItem.Title);
                cmd.Parameters.AddWithValue("@description", mediaItem.Description);
                cmd.Parameters.AddWithValue("@rating", mediaItem.Rating);
                cmd.Parameters.AddWithValue("@releaseDate", mediaItem.ReleaseDate);
                cmd.Parameters.AddWithValue("@countryOfOrigin", mediaItem.CountryOfOrigin);
                cmd.Parameters.AddWithValue("@cast", mediaItem.Cast.ToString());
                cmd.Parameters.AddWithValue("@image", pictureBytes);
                cmd.Parameters.AddWithValue("@imageCompressed", pictureBytesCompressed);

                string stringGenres = "";
                foreach (Genre genre in mediaItem.GetAllGenres())
                {
                    stringGenres += genre.ToString();
                    stringGenres += ",";
                }
                cmd.Parameters.AddWithValue("@genres", stringGenres);
                cmd.ExecuteNonQuery();
                if (mediaItem is Movie)
                {
                    string updateMovieSql = "UPDATE Movie SET director = @director, writer = @writer, duration = @duration WHERE id = @id";
                    SqlCommand movieCmd = new SqlCommand(updateMovieSql, conn);
                    movieCmd.Parameters.AddWithValue("@id", mediaItem.GetId());
                    movieCmd.Parameters.AddWithValue("@director", ((Movie)mediaItem).Director);
                    movieCmd.Parameters.AddWithValue("@writer", ((Movie)mediaItem).Writer);
                    movieCmd.Parameters.AddWithValue("@duration", ((Movie)mediaItem).Duration);
                    movieCmd.ExecuteNonQuery();
                }
                else if (mediaItem is Serie)
                {
                    string updateSerieSql = "UPDATE Serie SET seasons = @seasons, episodes = @episodes WHERE id = @id";
                    SqlCommand serieCmd = new SqlCommand(updateSerieSql, conn);
                    serieCmd.Parameters.AddWithValue("@id", mediaItem.GetId());
                    serieCmd.Parameters.AddWithValue("@seasons", ((Serie)mediaItem).Seasons);
                    serieCmd.Parameters.AddWithValue("@episodes", ((Serie)mediaItem).Episodes);
                    serieCmd.ExecuteNonQuery();
                }
                return updateMediaItem = true;

            }
           catch (Exception ex)
            {
                throw new Exception("Error updating into the database", ex);
            }
            finally
            {
                conn.Close();
            }
        }


    }
}
