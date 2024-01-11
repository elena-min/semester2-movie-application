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
    public class TitleSortingStrategyTest
    {
        [TestMethod]
        public void GetSortedMediaItems_DescendingTest()
        {
            //Arrange
            var mediaItems = new List<MediaItem>();
            MediaItem movie1 = new Movie("One", "Description1", DateTime.Now.AddYears(-5), "USA", 8.0, "Director1", "Writer1", 123);
            MediaItem movie2 = new Movie("Two", "Description2", DateTime.Now.AddYears(-11), "UK", 7.5, "Director2", "Writer2", 67);
            MediaItem movie3 = new Movie("Three", "Description3", DateTime.Now.AddYears(-1), "France", 6.3, "Director3", "Writer3", 94);
            MediaItem movie4 = new Movie("Six", "Description4", DateTime.Now.AddYears(-1), "Germany", 2.9, "Director4", "Writer4", 107);
            mediaItems.Add(movie1);
            mediaItems.Add(movie2);
            mediaItems.Add(movie3);
            mediaItems.Add(movie4);

            var strategy = new TitleSortingStrategy(descending: true);

            //Act
            var result = strategy.GetSortedMediaItems(mediaItems);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(mediaItems.Count, result.Length);
            CollectionAssert.AreEqual(new MediaItem[] { movie2, movie3, movie4, movie1 }, result);

        }

        [TestMethod]
        public void GetSortedMediaItems_AscendningTest()
        {
            //Arrange
            var mediaItems = new List<MediaItem>();
            MediaItem movie1 = new Movie("One", "Description1", DateTime.Now.AddYears(-5), "USA", 8.0, "Director1", "Writer1", 123);
            MediaItem movie2 = new Movie("Two", "Description2", DateTime.Now.AddYears(-11), "UK", 7.5, "Director2", "Writer2", 67);
            MediaItem movie3 = new Movie("Three", "Description3", DateTime.Now.AddYears(-1), "France", 6.3, "Director3", "Writer3", 94);
            MediaItem movie4 = new Movie("Six", "Description4", DateTime.Now.AddYears(-1), "Germany", 2.9, "Director4", "Writer4", 107);
            mediaItems.Add(movie1);
            mediaItems.Add(movie2);
            mediaItems.Add(movie3);
            mediaItems.Add(movie4);

            var strategy = new TitleSortingStrategy();

            //Act
            var result = strategy.GetSortedMediaItems(mediaItems);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(mediaItems.Count, result.Length);
            CollectionAssert.AreEqual(new MediaItem[] { movie1, movie4, movie3, movie2 }, result);


        }

        [TestMethod]
        public void GetSortedMediaItems_ReturnEmptyArrayTest()
        {
            //Arrange
            var mediaItems = new List<MediaItem>();
            var strategy = new TitleSortingStrategy();

            //Act
            var result = strategy.GetSortedMediaItems(mediaItems);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Length);
            CollectionAssert.AreEqual(Array.Empty<MediaItem>(), result);

        }
    }
}
