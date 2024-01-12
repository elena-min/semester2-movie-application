using DAL.FakeDAL;
using LogicLayer.Classes;
using LogicLayer.Controllers;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class ReviewControllerTest
    {
        [TestMethod]
        public void AddReviewTest()
        {
            //Arrange
            ReviewController reviewController = new ReviewController(createTestRepo());
            User user = new User("Lilly", "JThomas", "lillyT", "lilly@gmail.com", "12345", LogicLayer.Gender.Female);
            Movie movie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            Review review = new Review("best movie everr", "amazing!", 4, movie, user);

            // Act
            bool result = reviewController.AddReview(review);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetAllTest()
        {
            //Arrange
            ReviewController reviewController = new ReviewController(createTestRepo());
            User user = new User("Lilly", "JThomas", "lillyT", "lilly@gmail.com", "12345", LogicLayer.Gender.Female);
            Movie movie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            Review review = new Review("best movie everr", "amazing!", 4, movie, user);
            Review review2 = new Review("eww", "waste of money", 4, movie, user);
            reviewController.AddReview(review);
            reviewController.AddReview(review2);


            // Act
            var result = reviewController.GetAll();

            // Assert
            CollectionAssert.AreEquivalent(new Review[] { review, review2 }, result);
        }

        [TestMethod]
        public void GetAll_ReturnNullTest()
        {
            //Arrange
            ReviewController reviewController = new ReviewController(createTestRepo());


            // Act
            var result = reviewController.GetAll();

            // Assert
            CollectionAssert.AreEqual(Array.Empty<Review>(), result);
        }

        [TestMethod]
        public void GetReviewByIDTest()
        {
            //Arrange
            ReviewController reviewController = new ReviewController(createTestRepo());
            User user = new User("Lilly", "JThomas", "lillyT", "lilly@gmail.com", "12345", LogicLayer.Gender.Female);
            Movie movie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            Review review = new Review("best movie everr", "amazing!", 4, movie, user);
            Review review2 = new Review("eww", "waste of money", 4, movie, user);
            reviewController.AddReview(review);
            reviewController.AddReview(review2);

            // Act
            var result = reviewController.GetReviewByID(2);

            // Assert
            Assert.AreEqual(review2, result);
        }

        [TestMethod]
        public void GetReviewByID_NotFoundTest()
        {
            //Arrange
            ReviewController reviewController = new ReviewController(createTestRepo());
            User user = new User("Lilly", "JThomas", "lillyT", "lilly@gmail.com", "12345", LogicLayer.Gender.Female);
            Movie movie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            Review review = new Review("best movie everr", "amazing!", 4, movie, user);
            Review review2 = new Review("eww", "waste of money", 4, movie, user);
            reviewController.AddReview(review);
            reviewController.AddReview(review2);

            // Act
            var result = reviewController.GetReviewByID(4);

            // Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void GetReviewByUserNameTest()
        {
            //Arrange
            ReviewController reviewController = new ReviewController(createTestRepo());
            User user = new User("Lilly", "JThomas", "lillyT", "lilly@gmail.com", "12345", LogicLayer.Gender.Female);
            Movie movie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            Review review = new Review("best movie everr", "amazing!", 4, movie, user);
            Review review2 = new Review("eww", "waste of money", 4, movie, user);
            reviewController.AddReview(review);
            reviewController.AddReview(review2);

            // Act
            var result = reviewController.GetReviewsByUser(user);

            // Assert
            CollectionAssert.AreEquivalent(new Review[] { review, review2 }, result);
        }

        [TestMethod]
        public void GetReviewByUser_NotFoundTest()
        {
            //Arrange
            ReviewController reviewController = new ReviewController(createTestRepo());
            User user = new User("Lilly", "JThomas", "lillyT", "lilly@gmail.com", "12345", LogicLayer.Gender.Female);
            User user2 = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user.SetId(1);
            user.SetId(2);
            Movie movie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            Review review = new Review("best movie everr", "amazing!", 4, movie, user);
            Review review2 = new Review("eww", "waste of money", 4, movie, user);
            reviewController.AddReview(review);
            reviewController.AddReview(review2);

            // Act
            var result = reviewController.GetReviewsByUser(user2);

            // Assert
            CollectionAssert.AreEquivalent(new Review[] { }, result);
        }

        [TestMethod]
        public void GetReviewsByDateTest()
        {
            //Arrange
            ReviewController reviewController = new ReviewController(createTestRepo());
            User user = new User("Lilly", "JThomas", "lillyT", "lilly@gmail.com", "12345", LogicLayer.Gender.Female);
            Movie movie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            Review review = new Review("best movie everr", "amazing!", 4, movie, user, DateTime.Now.AddDays(-3));
            Review review2 = new Review("eww", "waste of money", 4, movie, user, DateTime.Now.AddDays(-5));
            reviewController.AddReview(review);
            reviewController.AddReview(review2);

            // Act
            var result = reviewController.GetReviewsByDate(DateTime.Now.AddDays(-5));

            // Assert
            CollectionAssert.AreEquivalent(new Review[] { review2 }, result);
        }

        [TestMethod]
        public void GetReviewsByDate_NotFoundTest()
        {
            //Arrange
            ReviewController reviewController = new ReviewController(createTestRepo());
            User user = new User("Lilly", "JThomas", "lillyT", "lilly@gmail.com", "12345", LogicLayer.Gender.Female);
            User user2 = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);

            Movie movie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            Review review = new Review("best movie everr", "amazing!", 4, movie, user);
            Review review2 = new Review("eww", "waste of money", 4, movie, user, DateTime.Now.AddDays(-5));
            reviewController.AddReview(review);
            reviewController.AddReview(review2);

            // Act
            var result = reviewController.GetReviewsByDate(DateTime.Now.AddMonths(-1));

            // Assert
            CollectionAssert.AreEquivalent(new Review[] { }, result);
        }

        [TestMethod]
        public void GetDeletedReviewsByUserTest()
        {
            //Arrange
            ReviewController reviewController = new ReviewController(createTestRepo());
            User user = new User("Lilly", "JThomas", "lillyT", "lilly@gmail.com", "12345", LogicLayer.Gender.Female);
            Movie movie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            Review review = new Review("best movie everr", "amazing!", 4, movie, user);
            Review review2 = new Review("eww", "waste of money", 4, movie, user, DateTime.Now.AddDays(-5));
            Review review3 = new Review("Stupid actors", "waste of money", 4, movie, user, DateTime.Now.AddDays(-10));

            reviewController.AddReview(review);
            reviewController.AddReview(review2);
            reviewController.AddReview(review3);

            review2.SetReviewAsDeleted("Harsh words.");
            review3.SetReviewAsDeleted("Bullying.");

            // Act
            var result = reviewController.GetDeletedReviewsByUser(user);

            // Assert
            CollectionAssert.AreEquivalent(new Review[] { review2, review3 }, result);
        }

        [TestMethod]
        public void GetDeletedReviewsByUser()
        {
            //Arrange
            ReviewController reviewController = new ReviewController(createTestRepo());
            User user = new User("Lilly", "JThomas", "lillyT", "lilly@gmail.com", "12345", LogicLayer.Gender.Female);
            Movie movie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            Review review = new Review("best movie everr", "amazing!", 4, movie, user);
            Review review2 = new Review("eww", "waste of money", 4, movie, user, DateTime.Now.AddDays(-5));
            Review review3 = new Review("Stupid actors", "waste of money", 4, movie, user, DateTime.Now.AddDays(-10));

            reviewController.AddReview(review);
            reviewController.AddReview(review2);
            reviewController.AddReview(review3);

            // Act
            var result = reviewController.GetDeletedReviewsByUser(user);

            // Assert
            CollectionAssert.AreEquivalent(new Review[] {  }, result);
        }

        [TestMethod]
        public void DeleteTest()
        {
            //Arrange
            ReviewController reviewController = new ReviewController(createTestRepo());
            User user = new User("Lilly", "JThomas", "lillyT", "lilly@gmail.com", "12345", LogicLayer.Gender.Female);
            Movie movie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            Review review = new Review("best movie everr", "amazing!", 4, movie, user);
            Review review2 = new Review("eww", "waste of money", 4, movie, user, DateTime.Now.AddDays(-5));
            reviewController.AddReview(review);
            reviewController.AddReview(review2);

            // Act
            var result = reviewController.Delete(review2);

            // Assert
            Assert.AreEqual("Review has been deleteted.", result);
            Assert.IsTrue(review2.IsDeleted);
        }

        [TestMethod]
        public void DeletebyUserTest()
        {
            //Arrange
            ReviewController reviewController = new ReviewController(createTestRepo());
            User user = new User("Lilly", "JThomas", "lillyT", "lilly@gmail.com", "12345", LogicLayer.Gender.Female);
            Movie movie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            Review review = new Review("best movie everr", "amazing!", 4, movie, user);
            Review review2 = new Review("eww", "waste of money", 4, movie, user, DateTime.Now.AddDays(-5));
            Review review3 = new Review("Stupid actors", "waste of money", 4, movie, user, DateTime.Now.AddDays(-10));

            reviewController.AddReview(review);
            reviewController.AddReview(review2);

            // Act
            var result = reviewController.DeletebyUser(review2);

            // Assert
            Assert.AreEqual("Review deleted successfully", result);
        }

        [TestMethod]
        public void DeletebyUser_NotFoundTest()
        {
            //Arrange
            ReviewController reviewController = new ReviewController(createTestRepo());
            User user = new User("Lilly", "JThomas", "lillyT", "lilly@gmail.com", "12345", LogicLayer.Gender.Female);
            Movie movie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            Review review = new Review("best movie everr", "amazing!", 4, movie, user);
            Review review2 = new Review("eww", "waste of money", 4, movie, user, DateTime.Now.AddDays(-5));
            Review review3 = new Review("Stupid actors", "waste of money", 4, movie, user, DateTime.Now.AddDays(-10));

            reviewController.AddReview(review);
            reviewController.AddReview(review2);

            // Act
            var result = reviewController.DeletebyUser(review3);

            // Assert
            Assert.AreEqual("No data found.", result);
        }


        [TestMethod]
        public void DeletedMediaItemTest()
        {
            //Arrange
            ReviewController reviewController = new ReviewController(createTestRepo());
            User user = new User("Lilly", "JThomas", "lillyT", "lilly@gmail.com", "12345", LogicLayer.Gender.Female);
            Movie movie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            movie.SetId(1);
            Movie movie2 = new Movie("Interstellar", "Sci-fi masterpiece", DateTime.Now, "USA", 9.7, "Christopher Nolan", "Jonathan Nolan", 169);
            movie2.SetId(2);
            Review review = new Review("best movie everr", "amazing!", 4, movie, user);
            Review review2 = new Review("eww", "waste of money", 4, movie, user, DateTime.Now.AddDays(-5));
            Review review3 = new Review("Stupid actors", "waste of money", 4, movie2, user, DateTime.Now.AddDays(-10));

            reviewController.AddReview(review);
            reviewController.AddReview(review2);
            reviewController.AddReview(review3);


            // Act
            var result = reviewController.DeletedMediaItem(movie);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, reviewController.GetReviewsByMediaItem(movie).Length);
            Assert.AreEqual(1, reviewController.GetAll().Length);

        }

        [TestMethod]
        public void DeletedMediaItem_NoReviewsForThisMediaTest()
        {
            //Arrange
            ReviewController reviewController = new ReviewController(createTestRepo());
            User user = new User("Lilly", "JThomas", "lillyT", "lilly@gmail.com", "12345", LogicLayer.Gender.Female);
            Movie movie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            Movie movie2 = new Movie("Interstellar", "Sci-fi masterpiece", DateTime.Now, "USA", 9.7, "Christopher Nolan", "Jonathan Nolan", 169);
            movie.SetId(1);
            movie2.SetId(2);

            Review review = new Review("best movie everr", "amazing!", 4, movie, user);
            Review review2 = new Review("eww", "waste of money", 4, movie, user, DateTime.Now.AddDays(-5));
            Review review3 = new Review("Stupid actors", "waste of money", 4, movie, user, DateTime.Now.AddDays(-10));

            reviewController.AddReview(review);
            reviewController.AddReview(review2);
            reviewController.AddReview(review3);

            // Act
            var result = reviewController.DeletedMediaItem(movie2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DeletedUserTest()
        {
            //Arrange
            ReviewController reviewController = new ReviewController(createTestRepo());
            User user = new User("Lilly", "JThomas", "lillyT", "lilly@gmail.com", "12345", LogicLayer.Gender.Female);
            User user2 = new User("Lilly", "JThomas", "lillyT", "lilly@gmail.com", "12345", LogicLayer.Gender.Female);
            user.SetId(1);
            user2.SetId(2);
            Movie movie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            Movie movie2 = new Movie("Interstellar", "Sci-fi masterpiece", DateTime.Now, "USA", 9.7, "Christopher Nolan", "Jonathan Nolan", 169);
            Review review = new Review("best movie everr", "amazing!", 4, movie, user2);
            Review review2 = new Review("eww", "waste of money", 4, movie, user, DateTime.Now.AddDays(-5));
            Review review3 = new Review("Stupid actors", "waste of money", 4, movie2, user, DateTime.Now.AddDays(-10));

            reviewController.AddReview(review);
            reviewController.AddReview(review2);
            reviewController.AddReview(review3);

            // Act
            var result = reviewController.DeletedUser(user2);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, reviewController.GetReviewsByUser(user2).Length);
            Assert.AreEqual(2, reviewController.GetAll().Length);

        }

        [TestMethod]
        public void DeletedUser_NoReviewsByThisUserTest()
        {
            //Arrange
            ReviewController reviewController = new ReviewController(createTestRepo());
            User user = new User("Lilly", "JThomas", "lillyT", "lilly@gmail.com", "12345", LogicLayer.Gender.Female);
            User user2 = new User("Lilly", "JThomas", "lillyT", "lilly@gmail.com", "12345", LogicLayer.Gender.Female);
            user.SetId(1);
            user2.SetId(2);
            Movie movie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            Movie movie2 = new Movie("Interstellar", "Sci-fi masterpiece", DateTime.Now, "USA", 9.7, "Christopher Nolan", "Jonathan Nolan", 169);
            Review review = new Review("best movie everr", "amazing!", 4, movie, user);
            Review review2 = new Review("eww", "waste of money", 4, movie, user, DateTime.Now.AddDays(-5));
            Review review3 = new Review("Stupid actors", "waste of money", 4, movie2, user, DateTime.Now.AddDays(-10));

            reviewController.AddReview(review);
            reviewController.AddReview(review2);

            // Act
            var result = reviewController.DeletedUser(user2);

            // Assert
            Assert.IsFalse(result);

        }

        private IReviewDAL createTestRepo()
        {
            return new FakeReviewDAL();
        }

    }
}
