using LogicLayer.Classes;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.FakeDAL
{
    public class FakeReviewDAL : IReviewDAL
    {
        private List<Review> reviews;
        private int nextId = 1;

        public FakeReviewDAL()
        {
            reviews = new List<Review>();
        }
        public bool AddReview(Review newReview)
        {
            newReview.SetId(nextId++);
            reviews.Add(newReview);
            return true;
        }
       
        public Review[] GetAll()
        {
            return reviews.ToArray();
        }

        public Review GetReviewByID(int id)
        {
            return reviews.Find(item => item.GetId() == id);
        }

        public Review[] GetReviewsByDate(DateTime date)
        {
            List<Review> deletedReviews = new List<Review>();
            foreach (Review review in reviews)
            {
                if (review.DateOfPublication.Date == date.Date)
                {
                    deletedReviews.Add(review);
                }
                
            }
            return deletedReviews.ToArray();
        }

        public Review[] GetReviewsByMediaItem(MediaItem mediaItem)
        {
            List<Review> deletedReviews = new List<Review>();
            foreach (Review review in reviews)
            {
                if (review.PointedTowards.GetId() == mediaItem.GetId())
                {
                    deletedReviews.Add(review);
                }

            }
            return deletedReviews.ToArray();
        }

        public Review[] GetReviewsByUser(User user)
        {
            List<Review> deletedReviews = new List<Review>();
            foreach (Review review in reviews)
            {
                if (review.ReviewWriter.GetId() == user.GetId())
                {
                    deletedReviews.Add(review);
                }

            }
            return deletedReviews.ToArray();
        }

        public Review[] GetDeletedReviewsByUser(User user)
        {
            List<Review> deletedReviews = new List<Review>();
            foreach (Review review in reviews)
            {
                if (review.IsDeleted)
                {
                    if (review.ReviewWriter.GetId() == user.GetId())
                    {
                        deletedReviews.Add(review);
                    }
                }
            }
            return deletedReviews.ToArray();
        }

        public string Delete(Review review)
        {
            Review reviewToRemove = reviews.Find(item => item == review);
            if (reviewToRemove != null)
            {
                reviewToRemove.SetReviewAsDeleted("Bad language");
                return "Review has been deleteted.";
            }
            return null;
        }
        public string DeletebyUser(Review review)
        {
            var reviewToDelete = reviews.FirstOrDefault(r => r.GetId() == review.GetId());

            if (reviewToDelete != null)
            {
                reviews.Remove(reviewToDelete);
                return "Review deleted successfully";
            }
            else
            {
                return "No data found.";
            }
        }

        public bool DeletedMediaItem(MediaItem mediaItem)
        {
            var reviewToDelete = reviews.Where(r => r.PointedTowards.GetId() == mediaItem.GetId()).ToList();

            if (reviewToDelete.Any())
            {
                reviews.RemoveAll(r => r.PointedTowards.GetId() == mediaItem.GetId());
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeletedUser(User deletedUser)
        {
            var reviewToDelete = reviews.Where(r => r.ReviewWriter.GetId() == deletedUser.GetId()).ToList();

            if (reviewToDelete.Any())
            {
                reviews.RemoveAll(r => r.ReviewWriter.GetId() == deletedUser.GetId());
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
