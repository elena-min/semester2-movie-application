using LogicLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class SerieTest
    {
        [TestMethod]
        public void SeaonsWithInvalidInput_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                // Arrange
                var mediaItem = new Serie("Home alone", "Description", DateTime.Now, "USA", 5.0, 0, 12);
            });

        }

        [TestMethod]
        public void EpisodesWithInvalidInput_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                // Arrange
                var mediaItem = new Serie("Home alone", "Description", DateTime.Now, "USA", 5.0, 3, 0);
            });
        }

    }
}
