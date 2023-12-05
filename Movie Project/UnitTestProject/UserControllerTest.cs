using DAL;
using DAL.FakeDAL;
using LogicLayer.Classes;
using LogicLayer.Controllers;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void InsertUserTest()
        {
            // Arrange
            UserController userController = new UserController(createTestRepo());
            User emp1 = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            User emp2 = new User("Lilly", "JThomas", "lillyT", "lilly@gmail.com", "12345", LogicLayer.Gender.Female);

            //Act
            bool resultS1 = userController.InsertUser(emp1);
            bool resultS2 = userController.InsertUser(emp2);

            //Assert
            Assert.IsTrue(resultS1);
            Assert.IsTrue(resultS2);
        }

        [TestMethod]
        public void InsertUser_SameUsernameTest()
        {
            // Arrange
            UserController userController = new UserController(createTestRepo());
            User user1 = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            User user2 = new User("Lilly", "JThomas", "nickJ", "lilly@gmail.com", "12345", LogicLayer.Gender.Female);

            //Act
            bool resultS1 = userController.InsertUser(user1);
            bool resultS2 = userController.InsertUser(user2);

            //Assert
            Assert.IsTrue(resultS1);
            Assert.IsFalse(resultS2);
        }
        [TestMethod]
        public void GetUserByIDTest()
        {
            // Arrange
            UserController userController = new UserController(createTestRepo());
            User user1 = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user1.SetId(5);

            //Act
            userController.InsertUser(user1);
            User foundUser = userController.GetUserByID(5);

            //Assert
            Assert.AreEqual(user1, foundUser);
        }
        [TestMethod]
        public void GetUserByID_ReturnNullTest()
        {
            // Arrange
            UserController userController = new UserController(createTestRepo());
            User user1 = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user1.SetId(5);

            //Act
            userController.InsertUser(user1);
            User foundUser = userController.GetUserByID(56);

            //Assert
            Assert.AreEqual(null, foundUser);
        }

        [TestMethod]
        public void GetUserByUsernameTest()
        {
            // Arrange
            UserController userController = new UserController(createTestRepo());
            User user1 = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user1.SetId(5);

            //Act
            userController.InsertUser(user1);
            User foundUser = userController.GetUserByUsername("nickJ");

            //Assert
            Assert.AreEqual(user1, foundUser);
        }

        [TestMethod]
        public void GetUserByUsername_NotFoundTest()
        {
            // Arrange
            UserController userController = new UserController(createTestRepo());
            User user1 = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user1.SetId(5);

            //Act
            userController.InsertUser(user1);
            User foundUser = userController.GetUserByUsername("lilly");

            //Assert
            Assert.AreEqual(null, foundUser);
        }

        [TestMethod]
        public void GetUserByEmailTest()
        {
            // Arrange
            UserController userController = new UserController(createTestRepo());
            User user1 = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user1.SetId(5);

            //Act
            userController.InsertUser(user1);
            User foundUser = userController.GetUserByEmail("nick@gmail.com");

            //Assert
            Assert.AreEqual(user1, foundUser);
        }

        [TestMethod]
        public void GetUserByEmail_NotFoundTest()
        {
            // Arrange
            UserController userController = new UserController(createTestRepo());
            User user1 = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user1.SetId(5);

            //Act
            userController.InsertUser(user1);
            User foundUser = userController.GetUserByEmail("lilly@gmail.com");

            //Assert
            Assert.AreEqual(null, foundUser);
        }

        [TestMethod]
        public void GetAllTest()
        {
            // Arrange
            UserController userController = new UserController(createTestRepo());
            User user1 = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            User user2 = new User("Lilly", "JThomas", "lillyT", "lilly@gmail.com", "12345", LogicLayer.Gender.Female);
            userController.InsertUser(user1);
            userController.InsertUser(user2);

            //Act
            User[] users = userController.GetAll();

            //Assert
            CollectionAssert.AreEquivalent(new User[] { user1, user2 }, users);
        }

        [TestMethod]
        public void GetAll_ReturnNullTest()
        {
            // Arrange
            UserController userController = new UserController(createTestRepo());


            //Act
            User[] users = userController.GetAll();

            //Assert
            CollectionAssert.AreEqual(Array.Empty<User>(), users);
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            // Arrange
            UserController userController = new UserController(createTestRepo());
            User user1 = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user1.SetId(2);
            userController.InsertUser(user1);

            User updatedUser = new User("Lilly", "JThomas", "lillyJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            updatedUser.SetId(2);

            //Act
            bool result = userController.UpdateUser(updatedUser);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UpdateUser_UnsuccessfulTest()
        {
            // Arrange
            UserController userController = new UserController(createTestRepo());
            User user1 = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user1.SetId(2);
            //Act
            bool result = userController.UpdateUser(user1);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            // Arrange
            UserController userController = new UserController(createTestRepo());
            User user1 = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user1.SetId(2);
            User user2 = new User("Lilly", "JThomas", "nickJ", "lilly@gmail.com", "12345", LogicLayer.Gender.Female);
            user2.SetId(3);
            userController.InsertUser(user2);
            userController.InsertUser(user2);

            //Act
            string result = userController.DeleteUser(user1);

            //Assert
            Assert.AreEqual("User deleted successfully", result);
        }

        [TestMethod]
        public void DeleteUser_NoUserFoundTest()
        {
            // Arrange
            UserController userController = new UserController(createTestRepo());
            User user1 = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user1.SetId(2);
            User user2 = new User("Lilly", "JThomas", "nickJ", "lilly@gmail.com", "12345", LogicLayer.Gender.Female);
            user2.SetId(3);
            userController.InsertUser(user1);
            userController.InsertUser(user2);

            //Act
            string result = userController.DeleteUser(user2);

            //Assert
            Assert.AreEqual("No data found.", result);
        }

        [TestMethod]
        public void SetProfilePictureTest()
        {
            // Arrange
            UserController userController = new UserController(createTestRepo());
            User user1 = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user1.SetId(2);
            userController.InsertUser(user1);
            byte[] picture = new byte[] { 1, 2, 3 };

            // Act
            bool result = userController.SetProfilePicture(user1, picture);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void SetProfilePictureTest_NoPictureSuppliedTest()
        {
            // Arrange
            UserController userController = new UserController(createTestRepo());
            User user1 = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user1.SetId(1);
            userController.InsertUser(user1);
            byte[] picture = null;

            // Act
            bool result = userController.SetProfilePicture(user1, picture); 

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetProfilePicByIDTest()
        {
            // Arrange
            UserController userController = new UserController(createTestRepo());
            User user1 = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user1.SetId(2);
            user1.ProfilePicture = new byte[] { 1, 2, 3 };
            userController.InsertUser(user1);

            // Act
            string result = userController.GetProfilePicByID(user1);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetProfilePicByID_NonExistingUserTest()
        {
            // Arrange
            UserController userController = new UserController(createTestRepo());
            User user = null;
            // Act
            string result = userController.GetProfilePicByID(user);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProfilePicByID_NullProfilePictureTest()
        {
            // Arrange
            UserController userController = new UserController(createTestRepo());
            User user1 = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user1.SetId(2);
            user1.ProfilePicture = null;
            userController.InsertUser(user1);

            // Act
            string result = userController.GetProfilePicByID(user1);

            // Assert
            Assert.IsNull(result);
        }
        private IUserDAL createTestRepo()
        {
            return new FakeUserDAL();
        }
    }
}
