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
    public class RecommendationsFilterStrategyTests
    {
        [TestMethod]
        public void GetFilteredMediaItems_ReturnsFilteredResults()
        {
            // Arrange
            var currentUser = new User("Lilly", "Jones", "liliJ", "lilly@gmail.com", "lilito", LogicLayer.Gender.Female);
            var mediaItems = new List<MediaItem>();
            MediaItem movie1 = new Movie("Movie1", "Description1", DateTime.Now.AddYears(-5), "USA", 8.0, "Director1", "Writer1", 123);
            movie1.AddGenre(LogicLayer.Genre.Romance);
            movie1.AddGenre(LogicLayer.Genre.TeenDrama);
            movie1.AddGenre(LogicLayer.Genre.Comedy);
            MediaItem movie2 = new Movie("Movie2", "Description2", DateTime.Now.AddYears(-11), "UK", 7.5, "Director2", "Writer2", 67);
            movie2.AddGenre(LogicLayer.Genre.Comedy);
            movie2.AddGenre(LogicLayer.Genre.Action);
            movie2.AddGenre(LogicLayer.Genre.Animation);
            MediaItem movie3 = new Movie("Movie3", "Description3", DateTime.Now.AddYears(-1), "France", 6.3, "Director3", "Writer3", 94);
            movie3.AddGenre(LogicLayer.Genre.Comedy);
            movie3.AddGenre(LogicLayer.Genre.Romance);
            movie3.AddGenre(LogicLayer.Genre.Drama);
            MediaItem movie4 = new Movie("Movie4", "Description4", DateTime.Now.AddYears(-1), "Germany", 2.9, "Director4", "Writer4", 107);
            movie4.AddGenre(LogicLayer.Genre.War);
            movie4.AddGenre(LogicLayer.Genre.Western);
            movie4.AddGenre(LogicLayer.Genre.Documentary);
            mediaItems.Add(movie2);
            mediaItems.Add(movie3);
            mediaItems.Add(movie4);

            var favMovies = new FavoriteMediaItem(currentUser);
            favMovies.AddToFavorites(movie1);
            var strategy = new RecommendationsFilterStrategy(currentUser);
            // Act
            var filteredMediaItems = strategy.GetFilteredMediaItems(mediaItems);

            // Assert
            Assert.IsNotNull(filteredMediaItems);
            // Add more specific assertions based on your expectations for the filtering logic
        }
    }
}
