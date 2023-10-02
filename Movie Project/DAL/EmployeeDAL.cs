using LogicLayer.Classes;
using LogicLayer.Interfaces;

namespace DAL
{
    public class EmployeeDAL : IEmployeeDAL
    {
        public void InsertEmployee(Employee newEmployee)
        {
        }
        public Employee GetEmployeeByID(int id)
        {
            return new Employee();
        }
        public Employee GetEmployeeByUsername(string username)
        {
            return new Employee();
        }
        public Employee GetEmployeeByEmail(string email)
        {
            return new Employee();
        }
        public Employee[] GetAll()
        {
            return new Employee[0];
        }
        public void UpdateEmployee(Employee employee)
        {
        }
        public void DeleteEmployee(int id)
        {
        }
    }
}