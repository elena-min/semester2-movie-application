using LogicLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void ProfileDescriptionWithValidInputTest()
        {
            // Arrange
            var person = new User();

            // Act
            person.ProfileDescription = "This is a valid profile description.";

            // Assert
            Assert.AreEqual("This is a valid profile description.", person.ProfileDescription);
        }

        [TestMethod]
        public void ProfileDescriptionWithEmptyInput_ThrowsArgumentException()
        {
            // Arrange
            var person = new User();

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                person.ProfileDescription = "";
            });
        }

        [TestMethod]
        public void ProfileDescriptionWithNoLetters_ThrowsArgumentException()
        {
            // Arrange
            var person = new User();

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                person.ProfileDescription = "123456";
            });
        }

    }
}
