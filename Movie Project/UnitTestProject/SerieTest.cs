using LogicLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class SerieTest
    {
        [TestMethod]
        public void SerieConstructorTest()
        {
            // Arrange
            string title = "Titanic";
            string description = "Love story";
            DateTime releaseDate = DateTime.Now;
            string countryOfOrigin = "USA";
            double rating = 7.8;
            int seasons = 5;
            int episodes = 45;

            // Act
            var serie = new Serie(title, description, releaseDate, countryOfOrigin, rating, seasons, episodes);

            // Assert
            Assert.AreEqual(title, serie.Title);
            Assert.AreEqual(description, serie.Description);
            Assert.AreEqual(releaseDate, serie.ReleaseDate);
            Assert.AreEqual(countryOfOrigin, serie.CountryOfOrigin);
            Assert.AreEqual(rating, serie.Rating);
            Assert.AreEqual(seasons, serie.Seasons);
            Assert.AreEqual(episodes, serie.Episodes);
        }

        [TestMethod]
        public void SeaonsWithInvalidInput_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                // Arrange
                var mediaItem = new Serie("Home alone", "Description", DateTime.Now, "USA", 5.0, 0, 12);
            });

        }

        [TestMethod]
        public void EpisodesWithInvalidInput_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                // Arrange
                var mediaItem = new Serie("Home alone", "Description", DateTime.Now, "USA", 5.0, 3, 0);
            });
        }

    }
}
