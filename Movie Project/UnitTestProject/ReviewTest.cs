using LogicLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class ReviewTest
    {
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
        public void RatingWithInvalidInput_ThrowsArgumentException()
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
    }
}
