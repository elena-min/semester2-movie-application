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
        public void CalculatePopularityScore_DayPeriodTest()
        {
            // Arrange
            MediaItem mediaItem = new MediaItem("Test", "Description", DateTime.Now, "USA", 4.5);
            mediaItem.RecordView(DateTime.Now);
            mediaItem.AddRating(4);
            mediaItem.AddRating(5);

            // Act
            mediaItem.CalculatePopularityScore(DateTime.Now, TimePeriod.Day);
            double avrgRating = mediaItem.CalculateAverageRating();
            double expectedresult = 0.7 * avrgRating + 0.3 * 1;

            // Assert
            Assert.AreEqual(expectedresult, mediaItem.PopularityScore);
        }

        [TestMethod]
        public void CalculatePopularityScore_WeekPeriodTest()
        {
            // Arrange
            MediaItem mediaItem = new MediaItem("Test", "Description", DateTime.Now, "USA", 4.5);
            mediaItem.RecordView(DateTime.Now);
            mediaItem.AddRating(4);
            mediaItem.AddRating(5);

            // Act
            mediaItem.CalculatePopularityScore(DateTime.Now, TimePeriod.Week);
            double avrgRating = mediaItem.CalculateAverageRating();
            double expectedresult = 0.7 * avrgRating + 0.3 * 1;

            // Assert
            Assert.AreEqual(expectedresult, mediaItem.PopularityScore); 
        }

        [TestMethod]
        public void CalculatePopularityScore_MonthPeriodTest()
        {
            // Arrange
            MediaItem mediaItem = new MediaItem("Test", "Description", DateTime.Now, "USA", 4.5);
            mediaItem.RecordView(DateTime.Now);
            mediaItem.AddRating(4);
            mediaItem.AddRating(5);

            // Act
            mediaItem.CalculatePopularityScore(DateTime.Now, TimePeriod.Month);
            double avrgRating = mediaItem.CalculateAverageRating();
            double expectedresult = 0.7 * avrgRating + 0.3 * 1;

            // Assert
            Assert.AreEqual(expectedresult, mediaItem.PopularityScore);
        }
    }
}
