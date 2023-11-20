using LogicLayer.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TrendingDAL
    {
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection("server=mssqlstud.fhict.local;Database=dbi500809_movieapp;User Id=dbi500809_movieapp;Password=movieapp;");
        }

        public void SaveTrendingMonthly(List<MediaItem> monthlyTrendingMedias, DateTime monthYear)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            string selectCommandSql = "INSERT INTO MonthlyTrendingMovies (MonthYear, mediaItemID, TrendingScore) VALUES (@MonthYear, @mediaItemID, @TrendingScore)";

            foreach (MediaItem mediaItem in monthlyTrendingMedias)
            {

                using (SqlCommand command = new SqlCommand(selectCommandSql, conn))
                {
                    double trendingScore = mediaItem.CalculatePopularityScoreTwo(DateTime.Today, LogicLayer.TimePeriod.Month);
                    string formattedMonthYear = monthYear.ToString("yyyy-MM");

                    command.Parameters.AddWithValue("@MonthYear", formattedMonthYear);
                    command.Parameters.AddWithValue("@mediaItemID", mediaItem.GetId());
                    command.Parameters.AddWithValue("@TrendingScore", trendingScore);

                    command.ExecuteNonQuery();
                }
            }
            conn.Close();
        }
    }
}
