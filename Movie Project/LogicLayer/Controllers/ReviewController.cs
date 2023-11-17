using LogicLayer.Classes;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Controllers
{
    public class ReviewController
    {
        private IReviewDAL ireviewDAL;
        public ReviewController(IReviewDAL reviewDAL)
        {
            this.ireviewDAL = reviewDAL;
        }
        public bool AddReview(Review newReview)
        {
            return ireviewDAL.AddReview(newReview);
        }
        public Review[] GetAll()
        {
            return ireviewDAL.GetAll().ToArray();
        }
        public Review GetReviewByID(int id)
        {
            return ireviewDAL.GetReviewByID(id);
        }
        public Review[] GetReviewsByUser(int userID)
        {
            return ireviewDAL.GetReviewsByUser(userID).ToArray();

        }
        public Review[] GetReviewsByMediaItem(int mediaItemID)
        {
            return ireviewDAL.GetReviewsByMediaItem(mediaItemID).ToArray();
        }
        public Review[] GetReviewsByDate(DateTime date)
        {
            return ireviewDAL.GetReviewsByDate(date).ToArray();
        }
        public Review[] GetDeletedReviewsByUser(int userID)
        {
            return ireviewDAL.GetDeletedReviewsByUser(userID).ToArray();
        }
        public string Delete(Review review)
        {
            return ireviewDAL.Delete(review);
        }
        public string DeletebyUser(Review review)
        {
            return ireviewDAL.DeletebyUser(review);
        }

        public bool DeletedMediaItem(int mediaID)
        {
            return ireviewDAL.DeletedMediaItem(mediaID);
        }
    }
}
