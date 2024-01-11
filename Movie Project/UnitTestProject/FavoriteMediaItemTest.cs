using LogicLayer;
using LogicLayer.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class FavoriteMediaItemTest
    {
        [TestMethod]
        public void ConstructorFavoriteMediaItemTest()
        {
            // Arrange
            User user = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);

            // Act
            var favoriteMediaItem = new FavoriteMediaItem(user);

            // Assert
            Assert.IsNotNull(favoriteMediaItem);
            Assert.AreEqual(user, favoriteMediaItem.User);
        }

        [TestMethod]
        public void AddToFavoritesTest()
        {
            // Arrange
            User user = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            var favoriteMediaItem = new FavoriteMediaItem(user);
            Movie favMovie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);

            // Act
            favoriteMediaItem.AddToFavorites(favMovie);

            // Assert        
            CollectionAssert.Contains(favoriteMediaItem.FavoriteMediaItems, favMovie);
        }

        [TestMethod]
        public void AddToFavorites_AddDuplicateTest()
        {
            // Arrange
            User user = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            var favoriteMediaItem = new FavoriteMediaItem(user);
            Movie favMovie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);

            // Act
            favoriteMediaItem.AddToFavorites(favMovie);
            favoriteMediaItem.AddToFavorites(favMovie);


            // Assert        
            CollectionAssert.Contains(favoriteMediaItem.FavoriteMediaItems, favMovie);
            Assert.AreEqual(1, favoriteMediaItem.FavoriteMediaItems.Count);
        }

        [TestMethod]
        public void RemoveFromFavoritesTest()
        {
            // Arrange
            User user = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            var favoriteMediaItem = new FavoriteMediaItem(user);
            Movie favMovie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            favoriteMediaItem.AddToFavorites(favMovie);

            // Act
            favoriteMediaItem.RemoveFromFavorites(favMovie);

            // Assert        
            CollectionAssert.DoesNotContain(favoriteMediaItem.FavoriteMediaItems, favMovie);
        }

        [TestMethod]
        public void RemoveFromFavorites_NoSuchMovieInListTest()
        {
            // Arrange
            User user = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            var favoriteMediaItem = new FavoriteMediaItem(user);
            Movie favMovie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            Movie favMovie2 = new Movie("Titanic", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            favoriteMediaItem.AddToFavorites(favMovie);

            // Act
            favoriteMediaItem.RemoveFromFavorites(favMovie2);

            // Assert        
            CollectionAssert.Contains(favoriteMediaItem.FavoriteMediaItems, favMovie);
            CollectionAssert.DoesNotContain(favoriteMediaItem.FavoriteMediaItems, favMovie2);
            Assert.AreEqual(1, favoriteMediaItem.FavoriteMediaItems.Count);
        }

        [TestMethod]
        public void GetAllFavoriteTest()
        {
            // Arrange
            User user = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            var favoriteMediaItem = new FavoriteMediaItem(user);
            Movie favMovie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            Movie favMovie2 = new Movie("Titanic", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            favoriteMediaItem.AddToFavorites(favMovie);
            favoriteMediaItem.AddToFavorites(favMovie2);

            // Act
            var result = favoriteMediaItem.GetAllFavorite();

            // Assert        
            Assert.AreEqual(2, favoriteMediaItem.FavoriteMediaItems.Count);
            CollectionAssert.AreEquivalent(new Movie[] { favMovie, favMovie2 }, result);

        }

        [TestMethod]
        public void GetAllFavorite_EmptyListTest()
        {
            // Arrange
            User user = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            var favoriteMediaItem = new FavoriteMediaItem(user);

            // Act
            var result = favoriteMediaItem.GetAllFavorite();

            // Assert        
            Assert.AreEqual(0, favoriteMediaItem.FavoriteMediaItems.Count);
            CollectionAssert.AreEquivalent(new Movie[] { }, result);
        }

        [TestMethod]
        public void GetFavoriteGenresTest()
        {
            // Arrange
            User user = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            var favoriteMediaItem = new FavoriteMediaItem(user);
            MediaItem movie1 = new Movie("Movie1", "Description1", DateTime.Now.AddYears(-5), "USA", 8.0, "Director1", "Writer1", 123);
            movie1.AddGenre(LogicLayer.Genre.Romance);
            movie1.AddGenre(LogicLayer.Genre.TeenDrama);
            movie1.AddGenre(LogicLayer.Genre.Comedy);
            MediaItem movie2 = new Movie("Movie2", "Description2", DateTime.Now.AddYears(-11), "UK", 7.5, "Director2", "Writer2", 67);
            movie2.AddGenre(LogicLayer.Genre.Comedy);
            movie2.AddGenre(LogicLayer.Genre.Action);
            favoriteMediaItem.AddToFavorites(movie1);
            favoriteMediaItem.AddToFavorites(movie2);

            // Act
            var result = favoriteMediaItem.GetFavoriteGenres();

            // Assert        
            Debug.WriteLine($"Actual Genres: {string.Join(", ", result)}");
            CollectionAssert.AreEquivalent(new Genre[] { Genre.Comedy, Genre.Romance, Genre.TeenDrama, Genre.Action}, result);
        }

        [TestMethod]
        public void GetFavoriteGenres_EmptyListTest()
        {
            // Arrange
            User user = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            var favoriteMediaItem = new FavoriteMediaItem(user);

            // Act
            var result = favoriteMediaItem.GetFavoriteGenres();

            // Assert        
            Assert.AreEqual(0, result.Length);
        }
    }
}
