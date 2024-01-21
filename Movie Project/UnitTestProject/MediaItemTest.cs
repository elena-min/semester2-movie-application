using LogicLayer.Classes;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class MediaItemTest
    {
        [TestMethod]
        public void TitleWithInvalidInput_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                // Arrange
                var mediaItem = new Movie("", "Description", DateTime.Now, "USA", 5.0, "John John", "Amy Sing", 123);
            });

        }

        [TestMethod]
        public void DescriptionWithInvalidInput_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                // Arrange
                var mediaItem = new Movie("Home alone", "", DateTime.Now, "USA", 5.0, "John John", "Amy Sing", 123);
            });
        }

        [TestMethod]
        public void CountryOfOriginWithInvalidInput_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                // Arrange
                var mediaItem = new Movie("Home alone", "Description", DateTime.Now, "", 5.0, "John John", "Amy Sing", 123);
            });
        }

        [TestMethod]
        public void RatingWithInvalidInput_ThrowsInvalidRatingException()
        {
            Assert.ThrowsException<InvalidRatingException>(() =>
            {
                // Arrange
                var mediaItem = new Movie("Home alone", "Description", DateTime.Now, "USA", 15.0, "John John", "Amy Sing", 123);
            });
        }

        [TestMethod]
        public void AddRatingTest()
        {
            // Arrange
            MediaItem mediaItem = new Movie("Test", "Description", DateTime.Now, "USA", 4.5, "director", "writer", 84);

            // Act
            mediaItem.AddRating(4);

            // Assert
            CollectionAssert.AreEqual(new List<int> { 4 }, mediaItem.GetAllRatings());
        }

        [TestMethod]
        public void AddRating_InvalidRatingTest()
        {
            // Arrange
            MediaItem mediaItem = new Movie("Test", "Description", DateTime.Now, "USA", 4.5, "director", "writer", 84);

            // Act
            Assert.ThrowsException<ArgumentException>(() =>
            {
                // Arrange
                mediaItem.AddRating(6);
            });
        }

        [TestMethod]
        public void GetAllRatingsTest()
        {
            // Arrange
            MediaItem mediaItem = new Movie("Test", "Description", DateTime.Now, "USA", 4.5, "director", "writer", 84);
            mediaItem.AddRating(4);
            mediaItem.AddRating(5);
            mediaItem.AddRating(1);

            // Act
            var result = mediaItem.GetAllRatings();

            // Assert        
            Assert.AreEqual(3, mediaItem.GetAllRatings().Length);
            CollectionAssert.AreEquivalent(new int[] { 4, 5, 1 }, result);

        }

        [TestMethod]
        public void GetAllRatings_EmptyListTest()
        {
            // Arrange
            MediaItem mediaItem = new Movie("Test", "Description", DateTime.Now, "USA", 4.5, "director", "writer", 84);

            // Act
            var result = mediaItem.GetAllRatings();

            // Assert        
            Assert.AreEqual(0, mediaItem.GetAllRatings().Length);
            CollectionAssert.AreEquivalent(new int[] {  }, result);
        }

        [TestMethod]
        public void AddGenreTest()
        {
            // Arrange
            MediaItem mediaItem = new Movie("Test", "Description", DateTime.Now, "USA", 4.5, "director", "writer", 84);

            // Act
            mediaItem.AddGenre(Genre.Family);
            mediaItem.AddGenre(Genre.Action);
            mediaItem.AddGenre(Genre.Documentary);

            // Assert
            Assert.AreEqual(3, mediaItem.GetAllGenres().Length);
            CollectionAssert.AreEquivalent(new Genre[] { Genre.Family, Genre.Action, Genre.Documentary }, mediaItem.GetAllGenres());
        }

        [TestMethod]
        public void AddGenre_DuplicateGenreTest()
        {
            // Arrange
            MediaItem mediaItem = new Movie("Test", "Description", DateTime.Now, "USA", 4.5, "director", "writer", 84);
            mediaItem.AddGenre(Genre.Family);
            mediaItem.AddGenre(Genre.Action);

            // Act
            mediaItem.AddGenre(Genre.Family);

            // Assert
            Assert.AreEqual(2, mediaItem.GetAllGenres().Length);
            CollectionAssert.AreEquivalent(new Genre[] { Genre.Family, Genre.Action }, mediaItem.GetAllGenres());
        }

        [TestMethod]
        public void GetAllGenresTest()
        {
            // Arrange
            MediaItem mediaItem = new Movie("Test", "Description", DateTime.Now, "USA", 4.5, "director", "writer", 84);
            mediaItem.AddGenre(Genre.Family);
            mediaItem.AddGenre(Genre.Action);
            mediaItem.AddGenre(Genre.Documentary);

            // Act
            var result = mediaItem.GetAllGenres();

            // Assert        
            Assert.AreEqual(3, mediaItem.GetAllGenres().Length);
            CollectionAssert.AreEquivalent(new Genre[] { Genre.Family, Genre.Action, Genre.Documentary }, result);

        }

        [TestMethod]
        public void GetAllGenres_EmptyListTes()
        {
            // Arrange
            MediaItem mediaItem = new Movie("Test", "Description", DateTime.Now, "USA", 4.5, "director", "writer", 84);

            // Act
            var result = mediaItem.GetAllGenres();

            // Assert        
            Assert.AreEqual(0, mediaItem.GetAllGenres().Length);
            CollectionAssert.AreEquivalent(new Genre[] { }, result);
        }


        [TestMethod]
        public void CalculateAverageRatingTest()
        {
            // Arrange
            MediaItem mediaItem = new Movie("Test", "Description", DateTime.Now, "USA", 4.5, "director", "writer", 84);
            mediaItem.AddRating(4);
            mediaItem.AddRating(5);
            mediaItem.AddRating(2);
            mediaItem.AddRating(2);

            // Act
            double avrgRating = mediaItem.CalculateAverageRating();
            // Assert
            Assert.AreEqual(3.25, avrgRating);
        }

        [TestMethod]
        public void CalculateAverageRating_NoRatingsTest()
        {
            // Arrange
            MediaItem mediaItem = new Movie("Test", "Description", DateTime.Now, "USA", 4.5, "director", "writer", 84);

            // Act
            double avrgRating = mediaItem.CalculateAverageRating();
            // Assert
            Assert.AreEqual(0.00, avrgRating);
        }

        [TestMethod]
        public void CalculatePopularityScore_DayPeriodTest()
        {
            // Arrange
            MediaItem mediaItem = new Movie("Test", "Description", DateTime.Now, "USA", 4.5, "director", "writer", 84);
            mediaItem.ViewsNumberByDate = new Dictionary<DateTime, int>
            {
                { DateTime.Now.Date, 10 },
                { DateTime.Now.AddDays(-1).Date, 10 },
            };
            mediaItem.AddRating(4);
            mediaItem.AddRating(5);
            // Act
            var popularityScore = mediaItem.CalculatePopularityScore(DateTime.Now, TimePeriod.Day);
            double avrgRating = mediaItem.CalculateAverageRating();
            double expectedresult = 0.7 * avrgRating + 0.3 * 10;

            // Assert
            Assert.AreEqual(expectedresult, popularityScore);
        }

        [TestMethod]
        public void CalculatePopularityScore_WeekPeriodTest()
        {
            // Arrange
            MediaItem mediaItem = new Movie("Test", "Description", DateTime.Now, "USA", 4.5, "director", "writer", 84);
            mediaItem.ViewsNumberByDate = new Dictionary<DateTime, int>
            {
                { DateTime.Now.Date, 5 },
                { DateTime.Now.AddDays(-1).Date, 10 },
            };
            mediaItem.AddRating(4);
            mediaItem.AddRating(5);

            // Act
            mediaItem.CalculatePopularityScore(DateTime.Now, TimePeriod.Week);
            double avrgRating = mediaItem.CalculateAverageRating();
            double expectedresult = 0.7 * avrgRating + 0.3 * 5;

            // Assert
            Assert.AreEqual(expectedresult, mediaItem.PopularityScore); 
        }

        [TestMethod]
        public void CalculatePopularityScore_MonthPeriodTest()
        {
            // Arrange
            MediaItem mediaItem = new Movie("Test", "Description", DateTime.Now, "USA", 4.5, "director", "writer", 84);
            mediaItem.ViewsNumberByDate = new Dictionary<DateTime, int>
            {
                { DateTime.Now.Date, 8 },
                { DateTime.Now.AddDays(-1).Date, 6 },
                { DateTime.Now.AddDays(-7).Date, 4 },
                { DateTime.Now.AddDays(-10).Date, 9 },
                { DateTime.Now.AddDays(-13).Date, 10 },

            // Add more date-views pairs as needed
            }; 
            mediaItem.AddRating(4);
            mediaItem.AddRating(5);

            // Act
            mediaItem.CalculatePopularityScore(DateTime.Now, TimePeriod.Month);
            double avrgRating = mediaItem.CalculateAverageRating();
            double expectedresult = 0.7 * avrgRating + 0.3 * 37;

            // Assert
            Assert.AreEqual(expectedresult, mediaItem.PopularityScore);
        }
    }
}
