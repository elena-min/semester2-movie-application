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
    public class PersonTest
    {
        [TestMethod]
        public void FirstName_WithValidInputTest()
        {
            // Arrange
            var person = new Person();

            // Act
            person.FirstName = "Lilly";

            // Assert
            Assert.AreEqual("Lilly", person.FirstName);
        }

        [TestMethod]
        public void FirstNameWithEmptyInput_ThrowsValidationException()
        {
            // Arrange
            var person = new Person();

            // Act + Assert
            Assert.ThrowsException<ValidationException>(() =>
            {
                person.FirstName = "";
            });
        }

        [TestMethod]
        public void LastNameWithValidInputTest()
        {
            // Arrange
            var person = new Person();

            // Act
            person.LastName = "Jones";

            // Assert
            Assert.AreEqual("Jones", person.LastName);
        }

        [TestMethod]
        public void LastNameWithEmptyInput_ThrowsValidationException()
        {
            // Arrange
            var person = new Person();

            // Act + Assert
            Assert.ThrowsException<ValidationException>(() =>
            {
                person.LastName = "";
            });
        }

        [TestMethod]
        public void UsernameWithValidInputTest()
        {
            // Arrange
            var person = new Person();

            // Act
            person.Username = "lilly.J";

            // Assert
            Assert.AreEqual("lilly.J", person.Username);
        }

        [TestMethod]
        public void UsernameWithEmptyInput_ThrowsValidationException()
        {
            // Arrange
            var person = new Person();

            // Act + Assert
            Assert.ThrowsException<ValidationException>(() =>
            {
                person.Username = "";
            });
        }

        [TestMethod]
        public void PasswordWithValidInputTesy()
        {
            // Arrange
            var person = new Person();

            // Act
            person.Password = "lilliet23";

            // Assert
            Assert.AreEqual("lilliet23", person.Password);
        }

        [TestMethod]
        public void PasswordWithEmptyInput_ThrowsArgumentException()
        {
            // Arrange
            var person = new Person();

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                person.Password = "";
            });
        }

        [TestMethod]
        public void EmailWithValidInputTest()
        {
            // Arrange
            var person = new Person();

            // Act
            person.Email = "lilly@gmail.com";

            // Assert
            Assert.AreEqual("lilly@gmail.com", person.Email);
        }

        [TestMethod]
        public void EmailWithInvalidInput_ThrowsArgumentException()
        {
            // Arrange
            var person = new Person();

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                person.Email = "invalidemail";
            });
        }

    }
}
