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
    public class UserTest
    {
        [TestMethod]
        public void UserConstructorTest()
        {
            // Arrange
            string firstName = "Nick";
            string lastName = "Jonas";
            string username = "nickJ";
            string email = "nickJonas@example.com";
            string password = "nickJLove";
            Gender gender = Gender.Male;

            // Act
            var user = new User(firstName, lastName, username, email, password, gender);

            // Assert
            Assert.AreEqual(firstName, user.FirstName);
            Assert.AreEqual(lastName, user.LastName);
            Assert.AreEqual(username, user.Username);
            Assert.AreEqual(email, user.Email);
            Assert.AreEqual(password, user.Password);
            Assert.AreEqual(gender, user.Gender);
            Assert.AreEqual("User", user.Role);
            Assert.AreEqual(false, user.IsBanned);

        }

        [TestMethod]
        public void UserConstructor_WithSaltTest()
        {
            // Arrange
            string firstName = "Nick";
            string lastName = "Jonas";
            string username = "nickJ";
            string email = "nickJonas@example.com";
            string password = "nickJLove";
            Gender gender = Gender.Male;
            string salt = "saltyNick";

            // Act
            var user = new User(firstName, lastName, username, email, password, salt, gender);

            // Assert
            Assert.AreEqual(firstName, user.FirstName);
            Assert.AreEqual(lastName, user.LastName);
            Assert.AreEqual(username, user.Username);
            Assert.AreEqual(email, user.Email);
            Assert.AreEqual(password, user.Password);
            Assert.AreEqual(gender, user.Gender);
            Assert.AreEqual("User", user.Role);
            Assert.AreEqual(false, user.IsBanned);
            Assert.AreEqual(salt, user.Salt);

        }

        [TestMethod]
        public void UserConstructor_WithProfileDescriptionTest()
        {
            // Arrange
            string firstName = "Nick";
            string lastName = "Jonas";
            string username = "nickJ";
            string email = "nickJonas@example.com";
            string password = "nickJLove";
            Gender gender = Gender.Male;
            string salt = "saltyNick";
            string profileDescription = "Hello!";

            // Act
            var user = new User(firstName, lastName, username, email, password, salt, gender, profileDescription);

            // Assert
            Assert.AreEqual(firstName, user.FirstName);
            Assert.AreEqual(lastName, user.LastName);
            Assert.AreEqual(username, user.Username);
            Assert.AreEqual(email, user.Email);
            Assert.AreEqual(password, user.Password);
            Assert.AreEqual(gender, user.Gender);
            Assert.AreEqual("User", user.Role);
            Assert.AreEqual(false, user.IsBanned);
            Assert.AreEqual(salt, user.Salt);
            Assert.AreEqual(profileDescription, user.ProfileDescription);

        }

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
