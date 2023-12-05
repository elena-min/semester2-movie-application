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
        bool AddReview(Review newReview);
        Review[] GetAll();
        Review GetReviewByID(int id);
        Review[] GetReviewsByUser(User user);
        Review[] GetReviewsByMediaItem(MediaItem mediaItem);
        Review[] GetReviewsByDate(DateTime date);
        Review[] GetDeletedReviewsByUser(User user);
        string Delete(Review review);
        string DeletebyUser(Review review);
        bool DeletedMediaItem(MediaItem mediaItem);
        bool DeletedUser(User deletedUser);

    }
}
