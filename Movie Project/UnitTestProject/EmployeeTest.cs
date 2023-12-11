using LogicLayer.Classes;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void AgeWithValidInputTest()
        {
            // Arrange
            var person = new Employee();

            // Act
            person.Age = 30;

            // Assert
            Assert.AreEqual(30, person.Age);
        }

        [TestMethod]
        public void AgeWithInvalidInputBelow16_ThrowsInvalidAgeException()
        {
            // Arrange
            var person = new Employee();

            // Act + Assert
            Assert.ThrowsException<InvalidAgeException>(() =>
            {
                person.Age = 15;
            });
        }

        [TestMethod]
        public void AgeWithInvalidInputAbove65_ThrowsInvalidAgeException()
        {
            // Arrange
            var person = new Employee();

            // Act + Assert
            Assert.ThrowsException<InvalidAgeException>(() =>
            {
                person.Age = 70;
            });
        }
    }

}
