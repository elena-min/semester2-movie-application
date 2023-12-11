using LogicLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class MovieTest
    {
        [TestMethod]
        public void DirectorWithInvalidInput_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                // Arrange
                var mediaItem = new Movie("Home alone", "Description", DateTime.Now, "USA", 5.0, "", "Amy Sing", 123);
            });

        }

        [TestMethod]
        public void WriterWithInvalidInput_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                // Arrange
                var mediaItem = new Movie("Home alone", "Description", DateTime.Now, "USA", 5.0, "John John", "", 123);
            });
        }

        [TestMethod]
        public void DurationWithInvalidInput_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                // Arrange
                var mediaItem = new Movie("Home alone", "Description", DateTime.Now, "USA", 5.0, "John John", "Amy Sing", 0);
            });
        }
    }
}
