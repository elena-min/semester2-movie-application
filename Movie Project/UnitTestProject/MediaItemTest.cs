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
            double expectedresult = 0.7 * avrgRating + 0.3 * 15;

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
            double expectedresult = 0.7 * avrgRating + 0.3 * 27;

            // Assert
            Assert.AreEqual(expectedresult, mediaItem.PopularityScore);
        }
    }
}
