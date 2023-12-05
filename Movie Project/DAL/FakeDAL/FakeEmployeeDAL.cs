using LogicLayer.Classes;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.FakeDAL
{
    public class FakeEmployeeDAL : IEmployeeDAL
    {
        private List<Employee> employees;
        public FakeEmployeeDAL()
        {
            employees = new List<Employee>();
        }

        public bool InsertEmployee(Employee newEmployee)
        {
            if (employees.FirstOrDefault(x => x.Username == newEmployee.Username) == null)
            {
                employees.Add(newEmployee);
                return true;
            }
            else
            { return false; }
         
        }

        public Employee[] GetAll()
        {
            return employees.ToArray();
        }

        public Employee GetEmployeeByEmail(string email)
        {
            return employees.FirstOrDefault(x => x.Email == email);
        }

        public Employee GetEmployeeByID(int id)
        {
            return employees.FirstOrDefault(x => x.GetId() == id);
        }

        public Employee GetEmployeeByUsername(string username)
        {
            return employees.FirstOrDefault(x => x.Username == username);

        }

        public string GetProfilePicByID(Employee employee)
        {
            var slectedemployee = employees.FirstOrDefault(e => e == employee);
            if (slectedemployee != null && slectedemployee.ProfilePicture != null)
            {
                return Convert.ToBase64String(slectedemployee.ProfilePicture);
            }
            else
            {
                return null;
            }
        }

        public bool UpdateEmployee(Employee employee, byte[] pictureBytes)
        {
            var existingEmployee = employees.FirstOrDefault(e => e.GetId() == employee.GetId());
            if (existingEmployee != null)
            {
                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.LastName = employee.LastName;
                existingEmployee.Username = employee.Username;
                existingEmployee.Password = employee.Password;
                existingEmployee.Email = employee.Email;
                existingEmployee.Gender = employee.Gender;
                existingEmployee.Age = employee.Age;
                existingEmployee.ProfilePicture = pictureBytes;

                return true;
            }
            else
            {
                return false;
            }
        }
        public string DeleteEmployee(Employee employee)
        {
            var employeeToDelete = employees.FirstOrDefault(e => e == employee);
            if (employeeToDelete != null)
            {
                employees.Remove(employeeToDelete);
                return "Employee deleted successfully";
            }
            else
            {
                return "No data found.";
            }
        }

        public bool DeleteUserAccount(User user, string reasonForDeleting)
        {
            throw new NotImplementedException();
        }
    }
}
