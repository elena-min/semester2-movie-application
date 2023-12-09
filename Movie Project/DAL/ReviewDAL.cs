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
    public class ReviewDAL : IReviewDAL
    {
        private readonly UserDAL userDAL;
        private readonly MediaItemDAL mediaDAL;
        public ReviewDAL()
        {
            userDAL = new UserDAL();
            mediaDAL = new MediaItemDAL();
        }
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
        public bool AddReview(Review newReview)
        {
            SqlConnection conn = CreateConnection();
            try
            {
                string commandSql = "INSERT INTO Review (title, reviewConten, rating, mediaItemID, personID, dateOfPublication, isItDeleted) VALUES (@title, @reviewConten, @rating, @mediaItemID, @personID, @dateOfPublication, @isItDeleted);";
                conn.Open();
                SqlCommand cmd = new SqlCommand(commandSql, conn);
                cmd.Parameters.AddWithValue("@title", newReview.Title);
                cmd.Parameters.AddWithValue("@reviewConten", newReview.ReviewContent);
                cmd.Parameters.AddWithValue("@rating", newReview.Rating);
                cmd.Parameters.AddWithValue("@mediaItemID", newReview.PointedTowards.GetId());
                cmd.Parameters.AddWithValue("@personID", newReview.ReviewWriter.GetId());
                DateTime today = DateTime.Today;
                cmd.Parameters.AddWithValue("@dateOfPublication", today);
                cmd.Parameters.AddWithValue("@isItDeleted", 0);
                cmd.ExecuteNonQuery();
                return true;
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
        public Review[] GetAll()
        {
            SqlConnection conn = CreateConnection();
            string query = "select * from Review where isItDeleted = 0";
            List<Review> productReviews = new List<Review>();
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
                        string title = reader.GetString(1);
                        string reviewContent = reader.GetString(2);
                        int rating = reader.GetInt32(3);
                        int pointedTowardsID = reader.GetInt32(4);
                        MediaItem pointedTowards = mediaDAL.GetMediaItemById(pointedTowardsID);
                        pointedTowards.AddRating(rating);
                        int reviewWriterID = reader.GetInt32(5);
                        User reviewWriter = userDAL.GetUserByID(reviewWriterID);
                        DateTime dateOfPublication = reader.GetDateTime(6);
                        Review review = new Review(title, reviewContent, rating, pointedTowards, reviewWriter, dateOfPublication);
                        review.SetId(id);
                        productReviews.Add(review);
                    }
                }

                reader.Close();
                return productReviews.ToArray();
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
        public Review GetReviewByID(int id)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            string query = "select * from Review where id = @id";
            try
            {
                Review review = null;
                CreateConnection().Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int r_id = reader.GetInt32(0);
                        string title = reader.GetString(1);
                        string reviewContent = reader.GetString(2);
                        int rating = reader.GetInt32(3);
                        int pointedTowardsID = reader.GetInt32(4);
                        MediaItem pointedTowards = mediaDAL.GetMediaItemById(pointedTowardsID);
                        pointedTowards.AddRating(rating);
                        int reviewWriterID = reader.GetInt32(5);
                        User reviewWriter = userDAL.GetUserByID(reviewWriterID);
                        DateTime dateOfPublication = reader.GetDateTime(6);
                        review = new Review(title, reviewContent, rating, pointedTowards, reviewWriter, dateOfPublication);
                        review.SetId(id);
                    }
                }

                reader.Close();
                return review;
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
        
        public Review[] GetReviewsByUser(User user)
        {
            SqlConnection conn = CreateConnection();
            string query = "select * from Review where isItDeleted = 0 AND personID = @personID";
            List<Review> productReviews = new List<Review>();
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@personID", user.GetId());
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string title = reader.GetString(1);
                        string reviewContent = reader.GetString(2);
                        int rating = reader.GetInt32(3);
                        int pointedTowardsID = reader.GetInt32(4);
                        MediaItem pointedTowards = mediaDAL.GetMediaItemById(pointedTowardsID);
                        pointedTowards.AddRating(rating);

                        int reviewWriterID = reader.GetInt32(5);
                        User reviewWriter = userDAL.GetUserByID(reviewWriterID);
                        DateTime dateOfPublication = reader.GetDateTime(6);
                        Review review = new Review(title, reviewContent, rating, pointedTowards, reviewWriter, dateOfPublication);
                        review.SetId(id);
                        productReviews.Add(review);
                    }
                }

                reader.Close();
                return productReviews.ToArray();
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

        public Review[] GetReviewsByMediaItem(MediaItem mediaItem)
        {            
            SqlConnection conn = CreateConnection();
            string query = "select * from Review where isItDeleted = 0 AND mediaItemID = @mediaItemID";
            List<Review> productReviews = new List<Review>();
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@mediaItemID", mediaItem.GetId());
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string title = reader.GetString(1);
                        string reviewContent = reader.GetString(2);
                        int rating = reader.GetInt32(3);
                        int pointedTowardsID = reader.GetInt32(4);
                        MediaItem pointedTowards = mediaDAL.GetMediaItemById(mediaItem.GetId());
                        pointedTowards.AddRating(rating);
                        int reviewWriterID = reader.GetInt32(5);
                        User reviewWriter = userDAL.GetUserByID(reviewWriterID);
                        DateTime dateOfPublication = reader.GetDateTime(6);
                        Review review = new Review(title, reviewContent, rating, pointedTowards, reviewWriter, dateOfPublication);
                        review.SetId(id);
                        productReviews.Add(review);
                    }
                }

                reader.Close();
                return productReviews.ToArray();
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
        public Review[] GetReviewsByDate(DateTime date)
        {
            SqlConnection conn = CreateConnection();
            string query = "select * from Review where isItDeleted = 0 AND dateOfPublication = @dateOfPublication";
            List<Review> productReviews = new List<Review>();
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@dateOfPublication", date.ToString("yyyy-MM-dd"));
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string title = reader.GetString(1);
                        string reviewContent = reader.GetString(2);
                        int rating = reader.GetInt32(3);
                        int pointedTowardsID = reader.GetInt32(4);
                        MediaItem pointedTowards = mediaDAL.GetMediaItemById(pointedTowardsID);
                        pointedTowards.AddRating(rating);
                        int reviewWriterID = reader.GetInt32(5);
                        User reviewWriter = userDAL.GetUserByID(reviewWriterID);
                        DateTime dateOfPublication = reader.GetDateTime(6);
                        Review review = new Review(title, reviewContent, rating, pointedTowards, reviewWriter, dateOfPublication);
                        review.SetId(id);
                        productReviews.Add(review);
                    }
                }

                reader.Close();
                return productReviews.ToArray();
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

        public Review[] GetDeletedReviewsByUser(User user)
        {
            SqlConnection conn = CreateConnection();
            string query = "select * from Review where isItDeleted = 1 AND personID = @personID";
            List<Review> productReviews = new List<Review>();
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@personID", user.GetId());
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string title = reader.GetString(1);
                        string reviewContent = reader.GetString(2);
                        int rating = reader.GetInt32(3);
                        int pointedTowardsID = reader.GetInt32(4);
                        MediaItem pointedTowards = mediaDAL.GetMediaItemById(pointedTowardsID);
                        pointedTowards.AddRating(rating);
                        int reviewWriterID = reader.GetInt32(5);
                        User reviewWriter = userDAL.GetUserByID(reviewWriterID);
                        DateTime dateOfPublication = reader.GetDateTime(6);
                        string deletingReason = reader.GetString(8);
                        Review review = new Review(title, reviewContent, rating, pointedTowards, reviewWriter, dateOfPublication);
                        review.SetId(id);
                        review.SetReviewAsDeleted(deletingReason);
                        productReviews.Add(review);
                    }
                }

                reader.Close();
                return productReviews.ToArray();
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
        public string Delete(Review review)
        {
            SqlConnection conn = CreateConnection();
            try
            {
                string commandSql = "UPDATE Review SET isItDeleted = @isItDeleted, reasonForDeleting = @reasonForDeleting WHERE id = @r_id;";
                conn.Open();
                SqlCommand cmd = new SqlCommand(commandSql, conn);
                cmd.Parameters.AddWithValue("@r_id", review.GetId());
                int isItDeletedInt = 0;
                if (review.IsDeleted == true)
                {
                    isItDeletedInt = 1;
                }
                cmd.Parameters.AddWithValue("@isItDeleted", isItDeletedInt);
                cmd.Parameters.AddWithValue("@reasonForDeleting", review.ReasonForDeleting);
                cmd.ExecuteNonQuery();
                return "Review has been deleteted.";
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting review in database", ex);
            }
            finally
            {
                conn.Close();
            }
        }

        public string DeletebyUser(Review review)
        {
            SqlConnection conn = CreateConnection();
            try
            {
                string commandSql = "DELETE Review WHERE id = @r_id;";
                conn.Open();
                SqlCommand cmd = new SqlCommand(commandSql, conn);
                cmd.Parameters.AddWithValue("@r_id", review.GetId());
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return "Review deleted successfully";
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

        public bool DeletedMediaItem(MediaItem mediaItem)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    string query = "DELETE FROM Review WHERE mediaItemID = @mediaItemID";
                    SqlCommand commandSql = new SqlCommand(query, conn);
                    commandSql.Parameters.AddWithValue("@mediaItemID", mediaItem.GetId());
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
        public bool DeletedUser(User deletedUser)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    string query = "DELETE FROM Review WHERE personID = @personID";
                    SqlCommand commandSql = new SqlCommand(query, conn);
                    commandSql.Parameters.AddWithValue("@personID", deletedUser.GetId());
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
