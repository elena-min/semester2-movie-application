using LogicLayer;
using LogicLayer.Classes;
using LogicLayer.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Strategy
{
    [TestClass]
    public class ReleaseDateFilterStrategyTest
    {
        [TestMethod]
        public void GetFilteredMediaItems_ShouldReturnTop20RecentMediaItems()
        {
            // Arrange
            var strategy = new ReleaseDateFilterStrategy();
            Movie movie1 = new Movie("Inception", "Mind-bending movie", DateTime.Now.AddYears(-1), "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            Movie movie2 = new Movie("Interstellar", "Sci-fi masterpiece", DateTime.Now.AddDays(-37), "USA", 9.7, "Christopher Nolan", "Jonathan Nolan", 169);
            Movie movie3 = new Movie("Titanic", "All time romance", DateTime.Now.AddYears(-5), "USA", 8.7, "Christopher Nolan", "Jonathan Nolan", 104);
            var mediaItems = new List<MediaItem>();
            mediaItems.Add(movie1);
            mediaItems.Add(movie2);
            mediaItems.Add(movie3);

            // Act
            var result = strategy.GetFilteredMediaItems(mediaItems);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length < 20);
            List<MediaItem> mediaItemsResult = mediaItems.OrderByDescending(item => item.ReleaseDate).Take(20).ToList();

            CollectionAssert.AreEqual(mediaItemsResult, result);
        }

        [TestMethod]
        public void GetFilteredMediaItems_EmptyList_ShouldReturnEmptyArray()
        {
            // Arrange
            var strategy = new ReleaseDateFilterStrategy();
            var mediaItems = new List<MediaItem>();

            // Act
            var result = strategy.GetFilteredMediaItems(mediaItems);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Length); 
        }
    }
}
