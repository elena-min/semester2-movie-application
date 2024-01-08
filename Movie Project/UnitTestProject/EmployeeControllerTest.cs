using DAL.FakeDAL;
using LogicLayer.Classes;
using LogicLayer.Controllers;
using LogicLayer.Interfaces;

namespace UnitTestProject
{
    [TestClass]
    public class EmployeeControllerTest
    {

        [TestMethod]
        public void AddEmployeeTest()
        {
            // Arrange
            EmployeeController empController = new EmployeeController(createTestRepo());
            Employee emp1 = new Employee("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male, 29);
            Employee emp2 = new Employee("Lilly", "JThomas", "lillyT", "lilly@gmail.com", "12345", LogicLayer.Gender.Female, 18);

            //Act
            bool resultS1 = empController.AddEmployee(emp1);
            bool resultS2 = empController.AddEmployee(emp2);

            //Assert
            Assert.IsTrue(resultS1);
            Assert.IsTrue(resultS2);
        }

        [TestMethod]
        public void AddEmployee_SameUsernameTest()
        {
            // Arrange
            EmployeeController empController = new EmployeeController(createTestRepo());
            Employee emp1 = new Employee("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male, 29);
            Employee emp2 = new Employee("Lilly", "JThomas", "nickJ", "lilly@gmail.com", "12345", LogicLayer.Gender.Female, 18);

            //Act
            bool resultS1 = empController.AddEmployee(emp1);
            bool resultS2 = empController.AddEmployee(emp2);

            //Assert
            Assert.IsTrue(resultS1);
            Assert.IsFalse(resultS2);
        }


        [TestMethod]
        public void GetEmployeeByIDTest()
        {
            // Arrange
            EmployeeController empController = new EmployeeController(createTestRepo());
            Employee emp1 = new Employee("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male, 29);
            emp1.SetId(5);

            //Act
            empController.AddEmployee(emp1);
            Employee foundEmployee = empController.GetEmployeeByID(5);

            //Assert
            Assert.AreEqual(emp1, foundEmployee);
        }
        [TestMethod]
        public void GetEmployeeByID_ReturnNullTest()
        {
            // Arrange
            EmployeeController empController = new EmployeeController(createTestRepo());
            Employee emp1 = new Employee("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male, 29);
            emp1.SetId(1);

            //Act
            empController.AddEmployee(emp1);
            Employee foundEmployee = empController.GetEmployeeByID(18);

            //Assert
            Assert.AreEqual(null, foundEmployee);
        }

        [TestMethod]
        public void GetEmployeeByUsernameTest()
        {
            // Arrange
            EmployeeController empController = new EmployeeController(createTestRepo());
            Employee emp1 = new Employee("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male, 29);
            emp1.SetId(5);

            //Act
            empController.AddEmployee(emp1);
            Employee foundEmployee = empController.GetEmployeeByUsername("nickJ");

            //Assert
            Assert.AreEqual(emp1, foundEmployee);
        }
        [TestMethod]
        public void GetEmployeeByUsername_ReturnNullTest()
        {
            // Arrange
            EmployeeController empController = new EmployeeController(createTestRepo());
            Employee emp1 = new Employee("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male, 29);
            emp1.SetId(1);

            //Act
            empController.AddEmployee(emp1);
            Employee foundEmployee = empController.GetEmployeeByUsername("lillyT");

            //Assert
            Assert.AreEqual(null, foundEmployee);
        }

        [TestMethod]
        public void GetEmployeeByEmailTest()
        {
            // Arrange
            EmployeeController empController = new EmployeeController(createTestRepo());
            Employee emp1 = new Employee("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male, 29);
            emp1.SetId(5);

            //Act
            empController.AddEmployee(emp1);
            Employee foundEmployee = empController.GetEmployeeByEmail("nick@gmail.com");

            //Assert
            Assert.AreEqual(emp1, foundEmployee);
        }
        [TestMethod]
        public void GetEmployeeByEmail_ReturnNullTest()
        {
            // Arrange
            EmployeeController empController = new EmployeeController(createTestRepo());
            Employee emp1 = new Employee("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male, 29);
            emp1.SetId(1);

            //Act
            empController.AddEmployee(emp1);
            Employee foundEmployee = empController.GetEmployeeByEmail("lilly@gmail.com");

            //Assert
            Assert.AreEqual(null, foundEmployee);
        }

        [TestMethod]
        public void GetAllTest()
        {
            // Arrange
            EmployeeController empController = new EmployeeController(createTestRepo());
            Employee emp1 = new Employee("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male, 29);
            Employee emp2 = new Employee("Lilly", "JThomas", "lillyT", "lilly@gmail.com", "12345", LogicLayer.Gender.Female, 18);
            empController.AddEmployee(emp1);
            empController.AddEmployee(emp2);

            //Act
            Employee[] employees = empController.GetAll();

            //Assert
            CollectionAssert.AreEquivalent(new Employee[] { emp1, emp2 }, employees);
        }
        [TestMethod]
        public void GetAll_ReturnEmptyArrayTest()
        {
            // Arrange
            EmployeeController empController = new EmployeeController(createTestRepo());

            // Act
            Employee[] employees = empController.GetAll();

            // Assert
            CollectionAssert.AreEqual(Array.Empty<Employee>(), employees);
        }

        [TestMethod]
        public void UpdateEmployeeTest()
        {
            // Arrange
            EmployeeController empController = new EmployeeController(createTestRepo());
            Employee emp1 = new Employee("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male, 29);
            emp1.SetId(1);  
            Employee emp2 = new Employee("Lilly", "JThomas", "lillyT", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male, 29);
            emp2.SetId(1);
            empController.AddEmployee(emp1);
            byte[] emptyByteArray = new byte[0];

            //Act
            bool result = empController.UpdateEmployee(emp2, emptyByteArray);

            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void UpdateEmployee_UnsuccessfulTest()
        {
            // Arrange
            EmployeeController empController = new EmployeeController(createTestRepo());
            Employee emp1 = new Employee("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male, 29);
            byte[] emptyByteArray = new byte[0];

            //Act
            bool result = empController.UpdateEmployee(emp1, emptyByteArray);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DeleteEmployeeTest()
        {
            // Arrange
            EmployeeController empController = new EmployeeController(createTestRepo());
            Employee emp1 = new Employee("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male, 29);
            Employee emp2 = new Employee("Lilly", "JThomas", "lillyT", "lilly@gmail.com", "12345", LogicLayer.Gender.Female, 18);
            emp1.SetId(1);
            emp2.SetId(2);
            empController.AddEmployee(emp1);
            empController.AddEmployee(emp2);

            //Act
            string result = empController.DeleteEmployee(emp2);

            //Assert
            Assert.AreEqual("Employee deleted successfully", result);
        }

        [TestMethod]
        public void DeleteEmployee_NoEmployeeFoundTest()
        {
            // Arrange
            EmployeeController empController = new EmployeeController(createTestRepo());
            Employee emp1 = new Employee("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male, 29);
            Employee emp2 = new Employee("Lilly", "JThomas", "lillyT", "lilly@gmail.com", "12345", LogicLayer.Gender.Female, 18);
            emp1.SetId(1);
            emp2.SetId(2);
            empController.AddEmployee(emp1);

            //Act
            string result = empController.DeleteEmployee(emp2);

            //Assert
            Assert.AreEqual("No data found.", result);
        }

        [TestMethod]
        public void GetProfilePicByIDTest()
        {
            // Arrange
            EmployeeController empController = new EmployeeController(createTestRepo());

            Employee emp1 = new Employee("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male, 29);
            emp1.SetId(1);
            emp1.ProfilePicture = new byte[] { 1, 2, 3 };
            empController.AddEmployee(emp1);

            // Act
            string result = empController.GetProfilePicByID(emp1);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetProfilePicByID_NonExistingEmployeeTest()
        {
            // Arrange
            EmployeeController empController = new EmployeeController(createTestRepo());
            Employee emp1 = new Employee();
            emp1.SetId(6);
            // Act
            string result = empController.GetProfilePicByID(emp1);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProfilePicByID_NullProfilePictureTest()
        {
            // Arrange
            EmployeeController empController = new EmployeeController(createTestRepo());
            Employee emp1 = new Employee("Nick", "Jonas", "nickJ", "nick@gmail.com", "nickJonas", LogicLayer.Gender.Male, 29);
            emp1.SetId(1);
            emp1.ProfilePicture = null;
            empController.AddEmployee(emp1);

            // Act
            string result = empController.GetProfilePicByID(emp1);

            // Assert
            Assert.IsNull(result);
        }

        private IEmployeeDAL createTestRepo()
        {
            return new FakeEmployeeDAL(); 
        }
    }
}