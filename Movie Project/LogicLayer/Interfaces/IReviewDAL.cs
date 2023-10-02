using LogicLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface IReviewDAL
    {
        void AddReview(Review newReview);
        Review[] GetAll();
        Review GetReviewByID(int id);
        Review[] GetReviewsByUser(int userID);
        Review[] GetReviewsByMediaItem(int mediaItemID);
        Review[] GetReviewsByDate(DateTime date);
        Review[] GetDeletedReviewsByUser(int userID);
        void Delete(int id);
        void DeletebyUser(Review review);

    }
}
