using LogicLayer;
using LogicLayer.Classes;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MediaItemViewsDAL : IMediaItemViewsDAL
    {
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection("server=mssqlstud.fhict.local;Database=dbi500809_movieapp;User Id=dbi500809_movieapp;Password=movieapp;");
        }

        public Dictionary<DateTime, int> GetAllViewsByMediaItem(MediaItem mediaItem)
        {
            Dictionary<DateTime, int> viewsNumberByDate = new Dictionary<DateTime, int>();

            SqlConnection conn = CreateConnection();
            conn.Open();

            string commandSql = "select date, viewsCount from MediaItemViews where mediaItemID = @mediaItemID";
            SqlCommand cmd = new SqlCommand(commandSql, conn);
            cmd.Parameters.AddWithValue("@mediaItemID", mediaItem.GetId());

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    DateTime date = reader.GetDateTime(0);
                    int viewsCount = reader.GetInt32(1);

                    viewsNumberByDate.Add(date, viewsCount);
                }
            }

            conn.Close();

            return viewsNumberByDate;
        }

        public void UpdateViewsCount(MediaItem mediaItem, DateTime currentDate)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            currentDate = currentDate.Date; 

            // Check if a record for the current date already exists
            string selectCommandSql = "SELECT TOP 1 viewsCount FROM MediaItemViews WHERE mediaItemID = @mediaItemID AND date = @date ORDER BY date DESC";
            SqlCommand selectCmd = new SqlCommand(selectCommandSql, conn);
            selectCmd.Parameters.AddWithValue("@mediaItemID", mediaItem.GetId()); 
            selectCmd.Parameters.AddWithValue("@date", currentDate);

            SqlDataReader reader = selectCmd.ExecuteReader();


            if (reader.Read())
            {
                // If a record exists for the current date, update the viewsCount by 1
                int existingViewsCount = Convert.ToInt32(reader["viewsCount"]);
                reader.Close();

                string updateCommandSql = "UPDATE MediaItemViews SET viewsCount = @viewsCount WHERE mediaItemID = @mediaItemID AND date = @date";
                SqlCommand updateCmd = new SqlCommand(updateCommandSql, conn);
                updateCmd.Parameters.AddWithValue("@mediaItemID", mediaItem.GetId());
                updateCmd.Parameters.AddWithValue("@date", currentDate);
                updateCmd.Parameters.AddWithValue("@viewsCount", existingViewsCount + 1);

                updateCmd.ExecuteNonQuery();
            }
            else
            {
                reader.Close();

                // If no record exists for the current date, insert a new record with viewsCount = 1
                string insertCommandSql = "INSERT INTO MediaItemViews (mediaItemID, date, viewsCount) VALUES (@mediaItemID, @date, @viewsCount)";
                SqlCommand insertCmd = new SqlCommand(insertCommandSql, conn);
                insertCmd.Parameters.AddWithValue("@mediaItemID", mediaItem.GetId()); 
                insertCmd.Parameters.AddWithValue("@date", currentDate);
                insertCmd.Parameters.AddWithValue("@viewsCount", 1);

                insertCmd.ExecuteNonQuery();
            }

            conn.Close();
        }
        public string RemoveMediaItemViews(MediaItem mediaItem)
        {
            SqlConnection conn = CreateConnection();
            using (conn)
            {
                // try
                //{
                string query = "delete from MediaItemViews where mediaItemID = @mediaID";
                SqlCommand commandSql = new SqlCommand(query, conn);
                commandSql.Parameters.AddWithValue("@mediaID", mediaItem.GetId());
                conn.Open();
                int rowsAffected = commandSql.ExecuteNonQuery();


                conn.Close();

                if (rowsAffected > 0)
                {
                    return "Records deleted successfully";
                }

                else
                {
                    return "No data found.";
                }
                //}
                //catch (Exception ex)
                //{
                //    return "Operation failed.";
                //}        }
            }
        }
    }
}
