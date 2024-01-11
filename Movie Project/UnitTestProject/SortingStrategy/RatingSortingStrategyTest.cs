using LogicLayer.Classes;
using LogicLayer.SortingStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.SortingStrategy
{
    [TestClass]

    public class RatingSortingStrategyTest
    {
        [TestMethod]
        public void GetSortedMediaItemsTest()
        {
            //Arrange
            var mediaItems = new List<MediaItem>();
            MediaItem movie1 = new Movie("Movie1", "Description1", DateTime.Now.AddYears(-5), "USA", 8.0, "Director1", "Writer1", 123);
            movie1.AddRating(2);
            movie1.AddRating(3);
            movie1.AddRating(3);
            MediaItem movie2 = new Movie("Movie2", "Description2", DateTime.Now.AddYears(-11), "UK", 7.5, "Director2", "Writer2", 67);
            movie2.AddRating(5);
            movie2.AddRating(4);
            movie2.AddRating(5);
            MediaItem movie3 = new Movie("Movie3", "Description3", DateTime.Now.AddYears(-1), "France", 6.3, "Director3", "Writer3", 94);
            movie3.AddRating(1);
            movie3.AddRating(4);
            movie3.AddRating(5);
            MediaItem movie4 = new Movie("Movie4", "Description4", DateTime.Now.AddYears(-1), "Germany", 2.9, "Director4", "Writer4", 107);
            movie4.AddRating(2);
            movie4.AddRating(1);
            movie4.AddRating(2);
            mediaItems.Add(movie1);
            mediaItems.Add(movie2);
            mediaItems.Add(movie3);
            mediaItems.Add(movie4);

            var strategy = new RatingSortingStrategy();

            //Act
            var result = strategy.GetSortedMediaItems(mediaItems);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(mediaItems.Count, result.Length);
            CollectionAssert.AreEqual(new MediaItem[] {movie2, movie3, movie1, movie4 }, result);

        }

        [TestMethod]
        public void GetSortedMediaItems_ReturnEmptyArrayTest()
        {
            //Arrange
            var mediaItems = new List<MediaItem>();
            var strategy = new RatingSortingStrategy();

            //Act
            var result = strategy.GetSortedMediaItems(mediaItems);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Length);
            CollectionAssert.AreEqual(Array.Empty<MediaItem>(), result);

        }
    }
}
