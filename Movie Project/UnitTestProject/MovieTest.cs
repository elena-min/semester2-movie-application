using LogicLayer;
using LogicLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class MovieTest
    {
        [TestMethod]
        public void MovieConstructorTest()
        {
            // Arrange
            string title = "Titanic";
            string description = "Love story";
            DateTime releaseDate = DateTime.Now;
            string countryOfOrigin = "USA";
            double rating = 7.8;
            string director = "Anotni Tonev";
            string writer = "Nick Jonas";
            int duration = 125;

            // Act
            var movie = new Movie(title, description, releaseDate, countryOfOrigin, rating, director, writer, duration);

            // Assert
            Assert.AreEqual(title, movie.Title);
            Assert.AreEqual(description, movie.Description);
            Assert.AreEqual(releaseDate, movie.ReleaseDate);
            Assert.AreEqual(countryOfOrigin, movie.CountryOfOrigin);
            Assert.AreEqual(rating, movie.Rating);
            Assert.AreEqual(director, movie.Director);
            Assert.AreEqual(writer, movie.Writer);
            Assert.AreEqual(duration, movie.Duration);
        }
        [TestMethod]
        public void DirectorWithInvalidInput_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                // Arrange
                var mediaItem = new Movie("Home alone", "Description", DateTime.Now, "USA", 5.0, "", "Amy Sing", 123);
            });

        }

        [TestMethod]
        public void WriterWithInvalidInput_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                // Arrange
                var mediaItem = new Movie("Home alone", "Description", DateTime.Now, "USA", 5.0, "John John", "", 123);
            });
        }

        [TestMethod]
        public void DurationWithInvalidInput_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                // Arrange
                var mediaItem = new Movie("Home alone", "Description", DateTime.Now, "USA", 5.0, "John John", "Amy Sing", 0);
            });
        }
    }
}
