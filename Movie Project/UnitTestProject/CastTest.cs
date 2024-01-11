using LogicLayer;
using LogicLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class CastTest
    {
        [TestMethod]
        public void ConstructorCastTest()
        {
            // Arrange
            Movie movie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);

            // Act
            var cast = new Cast(movie.Title);

            // Assert
            Assert.IsNotNull(cast);
            Assert.AreEqual(movie.Title, cast.MediaItemTitle);
        }

        [TestMethod]
        public void AddToCastTest()
        {
            // Arrange
            Movie movie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            var cast = new Cast(movie.Title);

            // Act
            cast.AddToCast("Nick Jonas");

            // Assert        
            Assert.IsTrue(cast.ToString().Contains("Nick Jonas"));
        }

        [TestMethod]
        public void RemoveFromCastTest()
        {
            // Arrange
            Movie movie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            var cast = new Cast(movie.Title);
            cast.AddToCast("Nick Jonas");
            cast.AddToCast("Selena Gomez");

            // Act
            cast.RemoveFromCast("Selena Gomez");


            // Assert        
            Assert.IsTrue(cast.ToString().Contains("Nick Jonas"));
            Assert.IsFalse(cast.ToString().Contains("Selena Gomez"));
        }

        [TestMethod]
        public void RemoveFromCast_NonExistenActorTest()
        {
            // Arrange
            Movie movie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            var cast = new Cast(movie.Title);
            cast.AddToCast("Nick Jonas");
            cast.AddToCast("Selena Gomez");

            // Act
            cast.RemoveFromCast("Brad Pitt");


            // Assert        
            Assert.IsTrue(cast.ToString().Contains("Nick Jonas"));
            Assert.IsTrue(cast.ToString().Contains("Selena Gomez"));
            Assert.IsFalse(cast.ToString().Contains("Brad Pitt"));
        }

        [TestMethod]
        public void RemoveFromCast_EmptyCastListTest()
        {
            // Arrange
            Movie movie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            var cast = new Cast(movie.Title);

            // Act
            cast.RemoveFromCast("Brad Pitt");

            // Assert        
            Assert.IsFalse(cast.ToString().Contains("Brad Pitt"));
        }

    }
}
