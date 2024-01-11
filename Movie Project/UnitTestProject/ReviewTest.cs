using LogicLayer.Classes;
using Org.BouncyCastle.Asn1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class ReviewTest
    {
        [TestMethod]
        public void ReviewConstructorTest()
        {
            // Arrange
            string title = "Titanic";
            string content = "Love story";
            int rating = 4;
            Movie pointedTowards = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            User reviewWriter = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);

            // Act
            var review = new Review(title, content, rating, pointedTowards, reviewWriter);

            // Assert
            Assert.AreEqual(title, review.Title);
            Assert.AreEqual(content, review.ReviewContent);
            Assert.AreEqual(pointedTowards, review.PointedTowards);
            Assert.AreEqual(reviewWriter, review.ReviewWriter);
            Assert.AreEqual(rating, review.Rating);
            Assert.IsFalse(review.IsDeleted);
        }

        [TestMethod]
        public void ReviewConstructor_WithDateOfPublicationTest()
        {
            // Arrange
            string title = "Titanic";
            string content = "Love story";
            DateTime dateOfPublication = DateTime.Now;
            int rating = 4;
            Movie pointedTowards = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            User reviewWriter = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);

            // Act
            var review = new Review(title, content, rating, pointedTowards, reviewWriter, dateOfPublication);

            // Assert
            Assert.AreEqual(title, review.Title);
            Assert.AreEqual(content, review.ReviewContent);
            Assert.AreEqual(pointedTowards, review.PointedTowards);
            Assert.AreEqual(reviewWriter, review.ReviewWriter);
            Assert.AreEqual(rating, review.Rating);
            Assert.AreEqual(dateOfPublication, review.DateOfPublication);
            Assert.IsFalse(review.IsDeleted);
        }

        [TestMethod]
        public void TitleWithValidInputTest()
        {
            // Arrange
            var review = new Review();

            // Act
            review.Title = "Great Movie";

            // Assert
            Assert.AreEqual("Great Movie", review.Title);
        }

        [TestMethod]
        public void TitleWithEmptyInput_ThrowsArgumentException()
        {
            // Arrange
            var review = new Review();

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                review.Title = "";
            });
        }

        [TestMethod]
        public void TitleWithNoLetters_ThrowsArgumentException()
        {
            // Arrange
            var instance = new Review();

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                instance.Title = "12345";
            });
        }

        [TestMethod]
        public void ReviewContentWithValidInputTest()
        {
            // Arrange
            var review = new Review();

            // Act
            review.ReviewContent = "This movie is awesome!";

            // Assert
            Assert.AreEqual("This movie is awesome!", review.ReviewContent);
        }

        [TestMethod]
        public void ReviewContentWithEmptyInput_ThrowsArgumentException()
        {
            // Arrange
            var review = new Review();

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                review.ReviewContent = "";
            });
        }
        [TestMethod]
        public void ReviewContentWithNoLetters_ThrowsArgumentException()
        {
            // Arrange
            var review = new Review();

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                review.ReviewContent = "12345";
            });
        }

        [TestMethod]
        public void Rating_WithValidInputTest()
        {
            // Arrange
            var review = new Review();

            // Act
            review.Rating = 4;

            // Assert
            Assert.AreEqual(4, review.Rating);
        }

        [TestMethod]
        public void Rating_WithInvalidInput_ThrowsArgumentExceptionTest()
        {
            // Arrange
            var review = new Review();

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                review.Rating = 0;
            });

            Assert.ThrowsException<ArgumentException>(() =>
            {
                review.Rating = 6;
            });
        }

        [TestMethod]
        public void DateOfPublicationWithFutureDate_ThrowsArgumentException()
        {
            // Arrange
            var review = new Review();

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                review.DateOfPublication = DateTime.Now.AddDays(1);
            });
        }

        [TestMethod]
        public void ReasonForDeletingWithValidInputTest()
        {
            // Arrange
            var review = new Review();

            // Act
            review.ReasonForDeleting = "Duplicate Review";

            // Assert
            Assert.AreEqual("Duplicate Review", review.ReasonForDeleting);
        }

        [TestMethod]
        public void ReasonForDeletingWithEmptyInput_ThrowsArgumentException()
        {
            // Arrange
            var review = new Review();

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                review.ReasonForDeleting = "";
            });
        }

        [TestMethod]
        public void ReasonForDeletingWithNoLettersInput_ThrowsArgumentException()
        {
            // Arrange
            var review = new Review();

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                review.ReasonForDeleting = "12345";
            });
        }

        [TestMethod]
        public void SetReviewAsDeletedTest()
        {
            // Arrange
            string title = "Titanic";
            string content = "Love story";
            DateTime dateOfPublication = DateTime.Now;
            int rating = 4;
            Movie pointedTowards = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            User reviewWriter = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            var review = new Review(title, content, rating, pointedTowards, reviewWriter, dateOfPublication);
            string reasonForDeleting = "Bad language";

            // Act
            review.SetReviewAsDeleted(reasonForDeleting);

            // Assert
            Assert.AreEqual(reasonForDeleting, review.ReasonForDeleting);
            Assert.IsTrue(review.IsDeleted);
        }
    }
}
