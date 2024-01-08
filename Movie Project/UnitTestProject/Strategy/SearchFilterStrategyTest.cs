using LogicLayer;
using LogicLayer.Classes;
using LogicLayer.Controllers;
using LogicLayer.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Strategy
{
    [TestClass]
    public class SearchFilterStrategyTest
    {
        [TestMethod]
        public void GetFilteredMediaItems_GenreSearchTest()
        {
            // Arrange
            var searchLine = "";
            var searchGenre = Genre.Action; 
            var strategy = new SearchFilterStrategy(searchLine, searchGenre);
            Movie movie1 = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            movie1.AddGenre(Genre.Action);
            movie1.AddGenre(Genre.Adventure);
            movie1.AddGenre(Genre.HistoricalDrama);
            Movie movie2 = new Movie("Interstellar", "Sci-fi masterpiece", DateTime.Now, "USA", 9.7, "Christopher Nolan", "Jonathan Nolan", 169);
            movie2.AddGenre(Genre.Adventure);
            movie2.AddGenre(Genre.Action);
            movie2.AddGenre(Genre.Crime);
            Movie movie3 = new Movie("Titanic", "All time romance", DateTime.Now, "USA", 8.7, "Christopher Nolan", "Jonathan Nolan", 104);
            movie3.AddGenre(Genre.Romance);
            movie3.AddGenre(Genre.Documentary);
            movie3.AddGenre(Genre.Animation);
            var mediaItems = new List<MediaItem>();
            mediaItems.Add(movie1);
            mediaItems.Add(movie2);
            mediaItems.Add(movie3);


            // Act
            var result = strategy.GetFilteredMediaItems(mediaItems);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Length);
            CollectionAssert.AreEquivalent(new MediaItem[] { movie1, movie2 }, result);

        }

        [TestMethod]
        public void GetFilteredMediaItems_SearchLineTest()
        {
            // Arrange
            var searchLine = "Tita";
            var searchGenre = (Genre?)null; 
            var strategy = new SearchFilterStrategy(searchLine, searchGenre);
            Movie movie1 = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            movie1.AddGenre(Genre.Action);
            movie1.AddGenre(Genre.Adventure);
            movie1.AddGenre(Genre.HistoricalDrama);
            Movie movie2 = new Movie("Interstellar", "Sci-fi masterpiece", DateTime.Now, "USA", 9.7, "Christopher Nolan", "Jonathan Nolan", 169);
            movie2.AddGenre(Genre.Adventure);
            movie2.AddGenre(Genre.Action);
            movie2.AddGenre(Genre.Crime);
            Movie movie3 = new Movie("Titanic", "All time romance", DateTime.Now, "USA", 8.7, "Christopher Nolan", "Jonathan Nolan", 104);
            movie3.AddGenre(Genre.Romance);
            movie3.AddGenre(Genre.Documentary);
            movie3.AddGenre(Genre.Animation);
            var mediaItems = new List<MediaItem>();
            mediaItems.Add(movie1);
            mediaItems.Add(movie2);
            mediaItems.Add(movie3);


            // Act
            var result = strategy.GetFilteredMediaItems(mediaItems);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Length);
            CollectionAssert.AreEquivalent(new MediaItem[] { movie3 }, result);

        }

        [TestMethod]
        public void GetFilteredMediaItem_Test()
        {
            // Arrange
            var searchLine = "In";
            var searchGenre = Genre.HistoricalDrama;
            var strategy = new SearchFilterStrategy(searchLine, searchGenre);
            Movie movie1 = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            movie1.AddGenre(Genre.Action);
            movie1.AddGenre(Genre.Adventure);
            movie1.AddGenre(Genre.HistoricalDrama);
            Movie movie2 = new Movie("Interstellar", "Sci-fi masterpiece", DateTime.Now, "USA", 9.7, "Christopher Nolan", "Jonathan Nolan", 169);
            movie2.AddGenre(Genre.Adventure);
            movie2.AddGenre(Genre.Action);
            movie2.AddGenre(Genre.Crime);
            Movie movie3 = new Movie("Titanic", "All time romance", DateTime.Now, "USA", 8.7, "Christopher Nolan", "Jonathan Nolan", 104);
            movie3.AddGenre(Genre.Romance);
            movie3.AddGenre(Genre.Documentary);
            movie3.AddGenre(Genre.Animation);
            var mediaItems = new List<MediaItem>();
            mediaItems.Add(movie1);
            mediaItems.Add(movie2);
            mediaItems.Add(movie3);


            // Act
            var result = strategy.GetFilteredMediaItems(mediaItems);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Length);
            CollectionAssert.AreEquivalent(new MediaItem[] { movie1 }, result);

        }

        [TestMethod]
        public void GetFilteredMediaItem_NoResultsTest()
        {
            // Arrange
            var searchLine = "In";
            var searchGenre = Genre.Romance;
            var strategy = new SearchFilterStrategy(searchLine, searchGenre);
            Movie movie1 = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            movie1.AddGenre(Genre.Action);
            movie1.AddGenre(Genre.Adventure);
            movie1.AddGenre(Genre.HistoricalDrama);
            Movie movie2 = new Movie("Interstellar", "Sci-fi masterpiece", DateTime.Now, "USA", 9.7, "Christopher Nolan", "Jonathan Nolan", 169);
            movie2.AddGenre(Genre.Adventure);
            movie2.AddGenre(Genre.Action);
            movie2.AddGenre(Genre.Crime);
            Movie movie3 = new Movie("Titanic", "All time romance", DateTime.Now, "USA", 8.7, "Christopher Nolan", "Jonathan Nolan", 104);
            movie3.AddGenre(Genre.Romance);
            movie3.AddGenre(Genre.Documentary);
            movie3.AddGenre(Genre.Animation);
            var mediaItems = new List<MediaItem>();
            mediaItems.Add(movie1);
            mediaItems.Add(movie2);
            mediaItems.Add(movie3);


            // Act
            var result = strategy.GetFilteredMediaItems(mediaItems);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Length);
            CollectionAssert.AreEqual(Array.Empty<MediaItem>(), result);

        }

    }
}
