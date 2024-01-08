using LogicLayer.Classes;
using LogicLayer.Strategy;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Strategy
{
    [TestClass]
    public class TrendingFilterStrategyTest
    {
        [TestMethod]
        public void GetFilteredMediaItems_MonthlyTrenidngTest()
        {
            // Arrange
            var dateTime = DateTime.Now;
            var timePeriod = TimePeriod.Month; 
            var strategy = new TrendingFilterStrategy(dateTime, timePeriod);
            var mediaItems = new List<MediaItem>();

            MediaItem movie1 = new Movie("Movie1", "Description1", DateTime.Now.AddMonths(-1), "USA", 8.0, "Director1", "Writer1", 123);
            movie1.RecordView(DateTime.Now);
            movie1.RecordView(DateTime.Now);
            movie1.RecordView(DateTime.Now.AddDays(-3));
            movie1.AddRating(3);
            MediaItem movie2 = new Movie("Movie2", "Description2", DateTime.Now.AddMonths(-2), "UK", 7.5, "Director2", "Writer2", 67);
            movie2.RecordView(DateTime.Now.AddDays(-3));
            movie2.RecordView(DateTime.Now.AddDays(-4));
            movie2.RecordView(DateTime.Now);
            movie1.AddRating(5);
            movie1.AddRating(2);
            MediaItem movie3 = new Movie("Movie3", "Description3", DateTime.Now.AddMonths(-3), "France", 6.3, "Director3", "Writer3", 94);
            movie2.RecordView(DateTime.Now.AddDays(-36));
            movie2.RecordView(DateTime.Now.AddDays(-9));
            movie1.AddRating(2);
            MediaItem movie4 = new Movie("Movie4", "Description4", DateTime.Now.AddMonths(-4), "Germany", 2.9, "Director4", "Writer4", 107);
            movie2.RecordView(DateTime.Now.AddDays(-1));
            movie2.RecordView(DateTime.Now);
            movie1.AddRating(5);
            movie1.AddRating(4);

            mediaItems.Add(movie1);
            mediaItems.Add(movie2);
            mediaItems.Add(movie3);
            mediaItems.Add(movie4);

            // Act
            var result = strategy.GetFilteredMediaItems(mediaItems);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Length);
            Assert.IsTrue(result.All(item => item.PopularityScore > 55));
            // Add more assertions based on your specific criteria
        }
        [TestMethod]
        public void GetFilteredMediaItems_WeeklyTrenidngTest()
        {
            // Arrange
            var dateTime = DateTime.Now;
            var timePeriod = TimePeriod.Week;
            var strategy = new TrendingFilterStrategy(dateTime, timePeriod);
            var mediaItems = new List<MediaItem>();

            MediaItem movie1 = new Movie("Movie1", "Description1", DateTime.Now.AddMonths(-1), "USA", 8.0, "Director1", "Writer1", 123);
            movie1.RecordView(DateTime.Now);
            movie1.RecordView(DateTime.Now);
            movie1.RecordView(DateTime.Now.AddDays(-3));
            movie1.AddRating(3);
            MediaItem movie2 = new Movie("Movie2", "Description2", DateTime.Now.AddMonths(-2), "UK", 7.5, "Director2", "Writer2", 67);
            movie2.RecordView(DateTime.Now.AddDays(-3));
            movie2.RecordView(DateTime.Now.AddDays(-4));
            movie2.RecordView(DateTime.Now);
            movie1.AddRating(5);
            movie1.AddRating(2);
            MediaItem movie3 = new Movie("Movie3", "Description3", DateTime.Now.AddMonths(-3), "France", 6.3, "Director3", "Writer3", 94);
            movie2.RecordView(DateTime.Now.AddDays(-36));
            movie2.RecordView(DateTime.Now.AddDays(-9));
            movie1.AddRating(2);
            MediaItem movie4 = new Movie("Movie4", "Description4", DateTime.Now.AddMonths(-4), "Germany", 2.9, "Director4", "Writer4", 107);
            movie2.RecordView(DateTime.Now.AddDays(-1));
            movie2.RecordView(DateTime.Now);
            movie1.AddRating(5);
            movie1.AddRating(4);

            mediaItems.Add(movie1);
            mediaItems.Add(movie2);
            mediaItems.Add(movie3);
            mediaItems.Add(movie4);

            // Act
            var result = strategy.GetFilteredMediaItems(mediaItems);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Length);
            Assert.IsTrue(result.All(item => item.PopularityScore > 55));
            // Add more assertions based on your specific criteria
        }

        [TestMethod]
        public void GetFilteredMediaItems_DailyTrenidngTest()
        {
            // Arrange
            var dateTime = DateTime.Now;
            var timePeriod = TimePeriod.Day;
            var strategy = new TrendingFilterStrategy(dateTime, timePeriod);
            var mediaItems = new List<MediaItem>();

            MediaItem movie1 = new Movie("Movie1", "Description1", DateTime.Now.AddMonths(-1), "USA", 8.0, "Director1", "Writer1", 123);
            movie1.RecordView(DateTime.Now);
            movie1.RecordView(DateTime.Now);
            movie1.RecordView(DateTime.Now.AddDays(-3));
            movie1.AddRating(5);
            MediaItem movie2 = new Movie("Movie2", "Description2", DateTime.Now.AddMonths(-2), "UK", 7.5, "Director2", "Writer2", 67);
            movie2.RecordView(DateTime.Now.AddDays(-3));
            movie2.RecordView(DateTime.Now.AddDays(-4));
            movie2.RecordView(DateTime.Now);
            movie1.AddRating(5);
            movie1.AddRating(2);
            MediaItem movie3 = new Movie("Movie3", "Description3", DateTime.Now.AddMonths(-3), "France", 6.3, "Director3", "Writer3", 94);
            movie2.RecordView(DateTime.Now.AddDays(-36));
            movie2.RecordView(DateTime.Now.AddDays(-9));
            movie1.AddRating(2);
            MediaItem movie4 = new Movie("Movie4", "Description4", DateTime.Now.AddMonths(-4), "Germany", 2.9, "Director4", "Writer4", 107);
            movie2.RecordView(DateTime.Now.AddDays(-1));
            movie2.RecordView(DateTime.Now);
            movie1.AddRating(5);
            movie1.AddRating(4);

            mediaItems.Add(movie1);
            mediaItems.Add(movie2);
            mediaItems.Add(movie3);
            mediaItems.Add(movie4);

            // Act
            var result = strategy.GetFilteredMediaItems(mediaItems);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Length);
            Assert.IsTrue(result.All(item => item.PopularityScore > 55));
            // Add more assertions based on your specific criteria
        }
        [TestMethod]
        public void GetFilteredMediaItems_EmptyList_ShouldReturnEmptyArray()
        {
            // Arrange
            var dateTime = DateTime.Now;
            var timePeriod = TimePeriod.Month; // Adjust as needed
            var strategy = new TrendingFilterStrategy(dateTime, timePeriod);

            var mediaItems = new List<MediaItem>();

            // Act
            var result = strategy.GetFilteredMediaItems(mediaItems);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Length); // Expecting an empty array for an empty input list
        }

    }
}
