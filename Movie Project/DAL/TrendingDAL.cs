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
    public class TrendingDAL : ITrendingDAL
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

        public void SaveTrendingMonthly(List<MediaItem> monthlyTrendingMedias, DateTime monthYear)
        {
            SqlConnection conn = CreateConnection();
            try
            {
                conn.Open();

                string formattedMonthYear = monthYear.ToString("yyyy-MM");

                // Delete existing records for the specified month
                string deleteCommandSql = "DELETE FROM MonthlyTrendingMediaItems WHERE MonthYear = @MonthYear";

                using (SqlCommand deleteCommand = new SqlCommand(deleteCommandSql, conn))
                {
                    deleteCommand.Parameters.AddWithValue("@MonthYear", formattedMonthYear);
                    deleteCommand.ExecuteNonQuery();
                }

                string selectCommandSql = "INSERT INTO MonthlyTrendingMediaItems (MonthYear, mediaItemID, TrendingScore) VALUES (@MonthYear, @mediaItemID, @TrendingScore)";

                foreach (MediaItem mediaItem in monthlyTrendingMedias)
                {

                    using (SqlCommand command = new SqlCommand(selectCommandSql, conn))
                    {
                        double trendingScore = mediaItem.CalculatePopularityScore(DateTime.Today, LogicLayer.TimePeriod.Month);

                        command.Parameters.AddWithValue("@MonthYear", formattedMonthYear);
                        command.Parameters.AddWithValue("@mediaItemID", mediaItem.GetId());
                        command.Parameters.AddWithValue("@TrendingScore", trendingScore);

                        command.ExecuteNonQuery();
                    }
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

        public void SaveTrendingWeekly(List<MediaItem> mediaItems, DateTime currentDate)
        {
            SqlConnection conn = CreateConnection();
            try
            {
                conn.Open();
                int dayOfWeek = (int)currentDate.DayOfWeek;
                DateTime startDate = currentDate.AddDays(-(dayOfWeek == 0 ? 6 : dayOfWeek - 1));
                DateTime endDate = startDate.AddDays(6);
                // Delete existing records for the specified week
                string deleteCommandSql = "DELETE FROM WeeklyTrendingMediaItems WHERE WeekStartDate = @WeekStartDate AND WeekEndDate = @WeekEndDate";

                using (SqlCommand deleteCommand = new SqlCommand(deleteCommandSql, conn))
                {
                    deleteCommand.Parameters.AddWithValue("@WeekStartDate", startDate);
                    deleteCommand.Parameters.AddWithValue("@WeekEndDate", endDate);
                    deleteCommand.ExecuteNonQuery();
                }

                string selectCommandSql = "INSERT INTO WeeklyTrendingMediaItems (WeekStartDate, WeekEndDate, mediaItemID, TrendingScore) VALUES (@WeekStartDate, @WeekEndDate, @mediaItemID, @TrendingScore)";

                foreach (MediaItem mediaItem in mediaItems)
                {
                    using (SqlCommand command = new SqlCommand(selectCommandSql, conn))
                    {
                        // Assume you have a method to calculate the trending score for each media item
                        double trendingScore = mediaItem.CalculatePopularityScore(DateTime.Today, LogicLayer.TimePeriod.Week);
                        ;
                        // Set parameters
                        command.Parameters.AddWithValue("@WeekStartDate", startDate);
                        command.Parameters.AddWithValue("@WeekEndDate", endDate);
                        command.Parameters.AddWithValue("@mediaItemID", mediaItem.GetId());
                        command.Parameters.AddWithValue("@TrendingScore", trendingScore);

                        // Execute the query
                        command.ExecuteNonQuery();
                    }
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
            

        public void SaveTrendingDaily(List<MediaItem> dailyTrendingMedias, DateTime dayPicked)
        {
            SqlConnection conn = CreateConnection();
            try
            {
                conn.Open();

                // Delete existing records for the specified day
                string deleteCommandSql = "DELETE FROM DailyTrendingMediaItems WHERE CONVERT(DATE, Day) = @Day";

                using (SqlCommand deleteCommand = new SqlCommand(deleteCommandSql, conn))
                {
                    deleteCommand.Parameters.AddWithValue("@Day", dayPicked.Date);
                    deleteCommand.ExecuteNonQuery();
                }

                // Insert new records for the specified day
                string insertCommandSql = "INSERT INTO DailyTrendingMediaItems (Day, mediaItemID, TrendingScore) VALUES (@Day, @mediaItemID, @TrendingScore)";

                foreach (MediaItem mediaItem in dailyTrendingMedias)
                {
                    double trendingScore = mediaItem.CalculatePopularityScore(DateTime.Today, LogicLayer.TimePeriod.Month);

                    using (SqlCommand insertCommand = new SqlCommand(insertCommandSql, conn))
                    {
                        insertCommand.Parameters.AddWithValue("@Day", dayPicked);
                        insertCommand.Parameters.AddWithValue("@mediaItemID", mediaItem.GetId());
                        insertCommand.Parameters.AddWithValue("@TrendingScore", trendingScore);

                        insertCommand.ExecuteNonQuery();
                    }
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

        public MediaItem[] GetTrendingDaily(DateTime dayPicked)
        {
            List<MediaItem> mediaItems = new List<MediaItem>();

            SqlConnection conn = CreateConnection();
            try
            {
                conn.Open();

                string commandSql = "select DTM.Day, MI.id, MI.title, MI.description, MI.rating, MI.countryOfOrigin, MI.genres, MI.cast, MI.releaseDate, M.director, M.writer, M.duration, S.seasons, S.episodes " +
                    "from DailyTrendingMediaItems as DTM " +
                    "inner join MediaItem as MI " +
                    "on DTM.mediaItemID = MI.id " +
                    "LEFT JOIN Movie as M ON MI.id = M.id " +
                    "LEFT JOIN Serie as S ON MI.id = S.id " +
                    "WHERE DTM.Day = @day;";
                SqlCommand cmd = new SqlCommand(commandSql, conn);
                cmd.Parameters.AddWithValue("@day", dayPicked);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int mediaItemId = reader.GetInt32(1);
                        string title = reader.GetString(2);
                        string description = reader.GetString(3);
                        double rating = (double)reader.GetDecimal(4);
                        string countryOfOrigin = reader.GetString(5);
                        string string_cast = reader.GetString(7);
                        string genres_string = reader.GetString(6);
                        DateTime releaseDate = reader.GetDateTime(8);
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
                            // If it's neither a Movie nor Serie, create a generic MediaItem
                            mediaItem = new MediaItem(title, description, releaseDate, countryOfOrigin, rating);
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
                }
                return mediaItems.ToArray();
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
        public DateTime GetLastTrendingCalculationTime(DateTime givenDate)
        {
            SqlConnection conn = CreateConnection();
            try
            {
                conn.Open();
                DateTime lastCalculationTime = DateTime.MinValue;

                string commandSql = "SELECT TOP 1 Day AS LastCalculationTime " +
                    "FROM DailyTrendingMediaItems " +
                    "WHERE CONVERT(DATE, [Day]) = CONVERT(DATE, @GivenDate);";
                SqlCommand cmd = new SqlCommand(commandSql, conn);
                cmd.Parameters.AddWithValue("@GivenDate", givenDate);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read() && !reader.IsDBNull(reader.GetOrdinal("LastCalculationTime")))
                    {
                        lastCalculationTime = reader.GetDateTime(reader.GetOrdinal("LastCalculationTime"));
                    }
                }
                return lastCalculationTime;
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

        public MediaItem[] GetTrendingWeekly(DateTime dayPicked)
        {
            List<MediaItem> mediaItems = new List<MediaItem>();

            SqlConnection conn = CreateConnection();
            try
            {
                conn.Open();

                string commandSql = "select DTM.WeekStartDate,  MI.id, MI.title, MI.description, MI.rating, MI.countryOfOrigin, MI.genres, MI.cast, MI.releaseDate, M.director, M.writer, M.duration, S.seasons, S.episodes " +
                    "from WeeklyTrendingMediaItems as DTM " +
                    "inner join MediaItem as MI " +
                    "on DTM.mediaItemID = MI.id " +
                    "LEFT JOIN Movie as M ON MI.id = M.id " +
                    "LEFT JOIN Serie as S ON MI.id = S.id " +
                    "WHERE DTM.WeekStartDate = @startDate AND DTM.WeekEndDate = @endDate;";
                SqlCommand cmd = new SqlCommand(commandSql, conn);
                int dayOfWeek = (int)dayPicked.DayOfWeek;
                DateTime startDate = dayPicked.AddDays(-(dayOfWeek == 0 ? 6 : dayOfWeek - 1));
                DateTime endDate = startDate.AddDays(6);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int mediaItemId = reader.GetInt32(1);
                        string title = reader.GetString(2);
                        string description = reader.GetString(3);
                        double rating = (double)reader.GetDecimal(4);
                        string countryOfOrigin = reader.GetString(5);
                        string string_cast = reader.GetString(7);
                        string genres_string = reader.GetString(6);
                        DateTime releaseDate = reader.GetDateTime(8);
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
                            // If it's neither a Movie nor Serie, create a generic MediaItem
                            mediaItem = new MediaItem(title, description, releaseDate, countryOfOrigin, rating);
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
                }
                return mediaItems.ToArray();
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

        public MediaItem[] GetTrendingMonthly(DateTime dayPicked)
        {
            List<MediaItem> mediaItems = new List<MediaItem>();

            SqlConnection conn = CreateConnection();
            try
            {
                conn.Open();

                string commandSql = "select DTM.MonthYear, MI.id, MI.title, MI.description, MI.rating, MI.countryOfOrigin, MI.genres, MI.cast, MI.releaseDate, M.director, M.writer, M.duration, S.seasons, S.episodes " +
                    "from MonthlyTrendingMediaItems as DTM " +
                    "inner join MediaItem as MI " +
                    "on DTM.mediaItemID = MI.id " +
                    "LEFT JOIN Movie as M ON MI.id = M.id " +
                    "LEFT JOIN Serie as S ON MI.id = S.id " +
                    "WHERE DTM.MonthYear = @MonthYear;";
                SqlCommand cmd = new SqlCommand(commandSql, conn);
                string formattedMonthYear = dayPicked.ToString("yyyy-MM");
                cmd.Parameters.AddWithValue("@MonthYear", formattedMonthYear);


                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int mediaItemId = reader.GetInt32(1);
                        string title = reader.GetString(2);
                        string description = reader.GetString(3);
                        double rating = (double)reader.GetDecimal(4);
                        string countryOfOrigin = reader.GetString(5);
                        string string_cast = reader.GetString(7);
                        string genres_string = reader.GetString(6);
                        DateTime releaseDate = reader.GetDateTime(8);
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
                            // If it's neither a Movie nor Serie, create a generic MediaItem
                            mediaItem = new MediaItem(title, description, releaseDate, countryOfOrigin, rating);
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
                }
                return mediaItems.ToArray();
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
