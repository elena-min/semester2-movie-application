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
    public class BannedUserControllerTest
    {
        [TestMethod]
        public void BanUserAccountTest()
        {
            // Arrange
            BannedUserController banController = new BannedUserController(createTestRepo());
            User emp1 = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            User emp2 = new User("Lilly", "JThomas", "lillyT", "lilly@gmail.com", "12345", LogicLayer.Gender.Female);
            emp1.SetId(1);
            emp2.SetId(2);
            string reason1 = "Reason1";
            string reason2 = "reason2";
            //Act
            bool resultS1 = banController.BanUserAccount(emp1, reason1);
            bool resultS2 = banController.BanUserAccount(emp2, reason2);

            //Assert
            Assert.IsTrue(resultS1);
            Assert.IsTrue(resultS2);
            Assert.AreEqual(emp2.ReasonForDeleting, reason2);
            Assert.AreEqual(emp1.ReasonForDeleting, reason1);
        }

        [TestMethod]
        public void BanUserAccount_RepeatingUserTest()
        {
            // Arrange
            BannedUserController banController = new BannedUserController(createTestRepo());
            User emp1 = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            User emp2 = new User("Lilly", "JThomas", "lillyT", "lilly@gmail.com", "12345", LogicLayer.Gender.Female);
            emp1.SetId(1);
            emp2.SetId(2);
            string reason1 = null;
            string reason2 = "reason2";
            //Act
            bool resultS1 = banController.BanUserAccount(emp1, reason1);
            bool resultS2 = banController.BanUserAccount(emp1, reason2);

            //Assert
            Assert.IsTrue(resultS1);
            Assert.IsFalse(resultS2);
            Assert.AreEqual(emp1.ReasonForDeleting, reason1);

        }

        [TestMethod]
        public void BanUserAccount_UserIsNullTest()
        {
            // Arrange
            BannedUserController banController = new BannedUserController(createTestRepo());
            User user1 = null;

            //Act
            //Assert
            var exception = Assert.ThrowsException<Exception>(() =>
            {
                banController.BanUserAccount(user1, "Bullying");
            });

        }

        [TestMethod]
        public void CheckIfUserIsBannedTest()
        {
            // Arrange
            BannedUserController banController = new BannedUserController(createTestRepo());
            User user1 = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user1.SetId(5);
            banController.BanUserAccount(user1, user1.ReasonForDeleting);

            //Act
            bool result = banController.CheckIfUserIsBanned(user1);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckIfUserIsBanned_ReturnFalseTest()
        {
            // Arrange
            BannedUserController banController = new BannedUserController(createTestRepo());
            User user1 = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user1.SetId(5);

            //Act
            bool result = banController.CheckIfUserIsBanned(user1);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckIfUserIsBanned_UserIsNullTest()
        {
            // Arrange
            BannedUserController banController = new BannedUserController(createTestRepo());
            User user1 = null;

            //Act
            //Assert
            var exception = Assert.ThrowsException<Exception>(() =>
            {
                banController.CheckIfUserIsBanned(user1);
            });
        }

        [TestMethod]
        public void GetReasonForBanningTest()
        {
            // Arrange
            BannedUserController banController = new BannedUserController(createTestRepo());
            User user1 = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user1.SetId(5);
            string reason = "Harsh language.";
            banController.BanUserAccount(user1, reason);

            //Act
            string result = banController.GetReasonForBanning(user1);

            //Assert
            Assert.AreEqual(reason, result);
        }

        [TestMethod]
        public void GetReasonForBanning_UserIsNotBannedTest()
        {
            // Arrange
            BannedUserController banController = new BannedUserController(createTestRepo());
            User user1 = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            user1.SetId(5);

            //Act
            string result = banController.GetReasonForBanning(user1);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetReasonForBanning_UserIsNullTest()
        {
            // Arrange
            BannedUserController banController = new BannedUserController(createTestRepo());
            User user1 = null;

            //Act
            //Assert
            var exception = Assert.ThrowsException<Exception>(() =>
            {
                banController.GetReasonForBanning(user1);
            });
        }

        [TestMethod]
        public void UnBanUserAccountTest()
        {
            // Arrange
            BannedUserController banController = new BannedUserController(createTestRepo());
            User emp1 = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            emp1.SetId(1);
            string reason1 = "Reason1";
            banController.BanUserAccount(emp1, reason1);
            //Act
            string result = banController.UnBanUserAccount(emp1);

            //Assert
            Assert.IsFalse(emp1.IsBanned);
            Assert.IsNull(emp1.ReasonForDeleting);
            Assert.AreEqual("User unbanned successfully", result);

        }

        [TestMethod]
        public void UnBanUserAccount_UserIsNotBannedTest()
        {
            // Arrange
            BannedUserController banController = new BannedUserController(createTestRepo());
            User user1 = null;

            //Act
            //Assert
            var exception = Assert.ThrowsException<Exception>(() =>
            {
                banController.UnBanUserAccount(user1);
            });

        }

        [TestMethod]
        public void UnBanUserAccount_UserIsNullTest()
        {
            // Arrange
            BannedUserController banController = new BannedUserController(createTestRepo());
            User emp1 = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            emp1.SetId(1);
            //Act
            string result = banController.UnBanUserAccount(emp1);

            //Assert
            Assert.IsFalse(emp1.IsBanned);
            Assert.IsNull(emp1.ReasonForDeleting);
            Assert.AreEqual("No data found.", result);

        }

        [TestMethod]
        public void GetAllBannedUser()
        {
            // Arrange
            BannedUserController banController = new BannedUserController(createTestRepo());

            User user1 = new User("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male);
            User user2 = new User("Lilly", "JThomas", "lillyT", "lilly@gmail.com", "12345", LogicLayer.Gender.Female);
            user1.SetId(1);
            user2.SetId(2);
            user1.SetUserAsBanned("Harsh language.");
            banController.BanUserAccount(user1, user1.ReasonForDeleting);
            user2.SetUserAsBanned("Bullying.");
            banController.BanUserAccount(user2, user2.ReasonForDeleting);

            //Act
            User[] users = banController.GetAllBannedUser();

            //Assert
            CollectionAssert.AreEquivalent(new User[] { user1, user2 }, users);
        }

        [TestMethod]
        public void GetAllBannedUser_ReturnNullTest()
        {
            // Arrange
            BannedUserController banController = new BannedUserController(createTestRepo());


            //Act
            User[] users = banController.GetAllBannedUser();

            //Assert
            CollectionAssert.AreEqual(Array.Empty<User>(), users);
        }

        private IBannedUserDAL createTestRepo()
        {
            return new FakeBannedUserDAL();
        }
    }
}
