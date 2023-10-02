using LogicLayer.Classes;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReviewDAL : IReviewDAL
    {
        public void AddReview(Review newReview)
        {
        }

        public void Delete(int id)
        {
        }

        public void DeletebyUser(Review review)
        {
        }

        public Review[] GetAll()
        {
            return new Review[0];
        }

        public Review[] GetDeletedReviewsByUser(int userID)
        {
            return new Review[0];
        }

        public Review GetReviewByID(int id)
        {
            return new Review();
        }

        public Review[] GetReviewsByDate(DateTime date)
        {
            return new Review[0];
        }

        public Review[] GetReviewsByMediaItem(int mediaItemID)
        {
            return new Review[0];
        }

        public Review[] GetReviewsByUser(int userID)
        {
            return new Review[0];
        }
    }
}
