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
        public void EmployeeConstructorTest()
        {
            // Arrange
            string firstName = "Nick";
            string lastName = "Jonas";
            string username = "nickJ";
            string email = "nickJonas@example.com";
            string password = "nickJLove";
            Gender gender = Gender.Male;
            int age = 25;

            // Act
            var employee = new Employee(firstName, lastName, username, email, password, gender, age);

            // Assert
            Assert.AreEqual(firstName, employee.FirstName);
            Assert.AreEqual(lastName, employee.LastName);
            Assert.AreEqual(username, employee.Username);
            Assert.AreEqual(email, employee.Email);
            Assert.AreEqual(password, employee.Password);
            Assert.AreEqual(gender, employee.Gender);
            Assert.AreEqual(age, employee.Age);
            Assert.AreEqual("Employee", employee.Role);
        }

        [TestMethod]
        public void EmployeeConstructor_WithSaltTest()
        {
            // Arrange
            string firstName = "Nick";
            string lastName = "Jonas";
            string username = "nickJ";
            string email = "nickJonas@example.com";
            string password = "nickJLove";
            Gender gender = Gender.Male;
            int age = 25;
            string salt = "saltyNick";

            // Act
            var employee = new Employee(firstName, lastName, username, email, password, salt,  gender, age);

            // Assert
            Assert.AreEqual(firstName, employee.FirstName);
            Assert.AreEqual(lastName, employee.LastName);
            Assert.AreEqual(username, employee.Username);
            Assert.AreEqual(email, employee.Email);
            Assert.AreEqual(password, employee.Password);
            Assert.AreEqual(gender, employee.Gender);
            Assert.AreEqual(age, employee.Age);
            Assert.AreEqual("Employee", employee.Role);
            Assert.AreEqual(salt, employee.Salt);

        }

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
