using DAL.FakeDAL;
using LogicLayer.Classes;
using LogicLayer.Controllers;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class FavoriteControllerTest
    {

        [TestMethod]
        public void AddProductToFavoriteTest()
        {
            // Arrange
            User user = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user.SetId(2);
            FavoritesController favController = new FavoritesController(createTestRepo());
            Movie favMovie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            favMovie.SetId(1);

            // Act
            favController.AddProductToFavorite(favMovie, user);

            // Assert        
            CollectionAssert.Contains(favController.GetAllFavorites(user), favMovie);
        }

        [TestMethod]
        public void AddProductToFavorite_AddDuplicateTest()
        {
            // Arrange
            User user = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user.SetId(2);
            FavoritesController favController = new FavoritesController(createTestRepo());
            Movie favMovie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            favMovie.SetId(1);

            // Act
            favController.AddProductToFavorite(favMovie, user);
            favController.AddProductToFavorite(favMovie, user);


            // Assert        
            CollectionAssert.Contains(favController.GetAllFavorites(user), favMovie);
        }

        [TestMethod]
        public void AddProductToFavorite_ProductIsNullTest()
        {
            // Arrange
            User user = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user.SetId(2);
            FavoritesController favController = new FavoritesController(createTestRepo());
            Movie favMovie = null;

            //Act
            //Assert
            var exception = Assert.ThrowsException<Exception>(() =>
            {
                favController.AddProductToFavorite(favMovie, user);
            });
        }


        [TestMethod]
        public void CheckIfProductIsInFavorites()
        {
            // Arrange
            User user = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user.SetId(2);
            FavoritesController favController = new FavoritesController(createTestRepo());
            Movie favMovie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            favMovie.SetId(1);
            favController.AddProductToFavorite(favMovie, user);

            // Act
            var result = favController.CheckIfProductIsInFavorites(favMovie, user);

            // Assert        
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckIfProductIsInFavorites_ReturnFalseTest()
        {
            // Arrange
            User user = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user.SetId(2);
            FavoritesController favController = new FavoritesController(createTestRepo());
            Movie favMovie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            favMovie.SetId(1);

            // Act
            var result = favController.CheckIfProductIsInFavorites(favMovie, user);

            // Assert        
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckIfProductIsInFavorites_ProductIsNullTest()
        {
            // Arrange
            User user = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user.SetId(2);
            FavoritesController favController = new FavoritesController(createTestRepo());
            Movie favMovie = null;

            //Act
            //Assert
            var exception = Assert.ThrowsException<Exception>(() =>
            {
                favController.CheckIfProductIsInFavorites(favMovie, user);
            });
        }

        [TestMethod]
        public void GetAllFavorites()
        {
            // Arrange
            User user = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user.SetId(2);
            FavoritesController favController = new FavoritesController(createTestRepo());
            Movie favMovie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            Movie favMovie2 = new Movie("Titanic", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            favMovie.SetId(1);
            favMovie2.SetId(2);
            favController.AddProductToFavorite(favMovie, user);
            favController.AddProductToFavorite(favMovie2, user);

            // Act
            var result = favController.GetAllFavorites(user);
            // Assert        
            Assert.AreEqual(2, favController.GetAllFavorites(user).Length);
            CollectionAssert.AreEquivalent(new Movie[] { favMovie, favMovie2 }, result);
        }

        [TestMethod]
        public void GetAllFavorites_EmptyListTest()
        {
            // Arrange
            User user = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user.SetId(2);
            FavoritesController favController = new FavoritesController(createTestRepo());

            // Act
            var result = favController.GetAllFavorites(user);

            // Assert        
            Assert.AreEqual(0, favController.GetAllFavorites(user).Length);
            CollectionAssert.AreEquivalent(new Movie[] { }, result);
        }

        [TestMethod]

        public void RemoveFromFavoritesTest()
        {
            // Arrange
            User user = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user.SetId(2);
            FavoritesController favController = new FavoritesController(createTestRepo());
            Movie favMovie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            favMovie.SetId(1);
            favController.AddProductToFavorite(favMovie, user);

            // Act
            favController.RemoveFromFavorites(favMovie, user);

            // Assert        
            CollectionAssert.DoesNotContain(favController.GetAllFavorites(user), favMovie);
        }

        [TestMethod]
        public void RemoveFromFavorites_NoSuchMovieInListTest()
        {
            // Arrange
            User user = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user.SetId(2);
            FavoritesController favController = new FavoritesController(createTestRepo());
            Movie favMovie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            Movie favMovie2 = new Movie("Titanic", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            favMovie.SetId(1);
            favMovie2.SetId(2);
            favController.AddProductToFavorite(favMovie, user);

            // Act
            favController.RemoveFromFavorites(favMovie2, user);

            // Assert        
            CollectionAssert.Contains(favController.GetAllFavorites(user), favMovie);
            CollectionAssert.DoesNotContain(favController.GetAllFavorites(user), favMovie2);
            Assert.AreEqual(1, favController.GetAllFavorites(user).Length);
        }

        [TestMethod]
        public void RemoveFromFavorites_MovieIsNullTest()
        {
            // Arrange
            User user = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user.SetId(2);
            FavoritesController favController = new FavoritesController(createTestRepo());
            Movie favMovie = null;

            //Act
            //Assert
            var exception = Assert.ThrowsException<Exception>(() =>
            {
                favController.RemoveFromFavorites(favMovie, user);
            });
        }

        [TestMethod]
        public void DeletedMediaItemTest()
        {
            //Arrange
            User user = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user.SetId(2);
            FavoritesController favController = new FavoritesController(createTestRepo());
            Movie favMovie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            Movie favMovie2 = new Movie("Titanic", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            favMovie.SetId(1);
            favMovie2.SetId(2);
            favController.AddProductToFavorite(favMovie, user);
            favController.AddProductToFavorite(favMovie2, user);

            // Act
            var result = favController.DeletedMediaItem(favMovie);
            // Assert        
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeletedMediaItem_ReturnFalseTest()
        {
            //Arrange
            User user = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user.SetId(2);
            FavoritesController favController = new FavoritesController(createTestRepo());
            Movie favMovie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            Movie favMovie2 = new Movie("Titanic", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            favMovie.SetId(1);
            favMovie2.SetId(2);
            favController.AddProductToFavorite(favMovie, user);

            // Act
            var result = favController.DeletedMediaItem(favMovie2);
            // Assert        
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DeletedMediaItem_ProductIsNullTest()
        {
            // Arrange
            User user = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user.SetId(2);
            FavoritesController favController = new FavoritesController(createTestRepo());
            Movie favMovie = null;

            //Act
            //Assert
            var exception = Assert.ThrowsException<Exception>(() =>
            {
                favController.DeletedMediaItem(favMovie);
            });
        }

        private IFavoritesDAL createTestRepo()
        {
            return new FakeFavoritesDAL();
        }
    }
}
