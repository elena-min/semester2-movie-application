using LogicLayer.Classes;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Controllers
{
    public class EmployeeController
    {
        private IEmployeeDAL iemployeeDAL;
        private IBannedUserDAL ibannedUserDAL;

        public EmployeeController(IEmployeeDAL employeeDAL)
        {
            this.iemployeeDAL = employeeDAL;
        }
        public EmployeeController(IEmployeeDAL employeeDAL, IBannedUserDAL bannedUserDAL)
        {
            this.iemployeeDAL = employeeDAL;
            this.ibannedUserDAL = bannedUserDAL;
        }

        public bool AddEmployee(Employee newEmployee)
        {
            return iemployeeDAL.InsertEmployee(newEmployee);
        }
        public Employee GetEmployeeByID(int id)
        {
            return iemployeeDAL.GetEmployeeByID(id);

        }

        public Employee GetEmployeeByUsername(string username)
        {
            return iemployeeDAL.GetEmployeeByUsername(username);

        }
        public Employee GetEmployeeByEmail(string email)
        {
            return iemployeeDAL.GetEmployeeByEmail(email);

        }
        public Employee[] GetAll()
        {
            return iemployeeDAL.GetAll();
        }
        public bool UpdateEmployee(Employee employee, byte[] pictureBytes)
        {
            return iemployeeDAL.UpdateEmployee(employee, pictureBytes);
        }
        public string DeleteEmployee(Employee emp)
        {
            return iemployeeDAL.DeleteEmployee(emp);    
        }
        public string GetProfilePicByID(Employee emp)
        {
            return iemployeeDAL.GetProfilePicByID(emp);  
        }
        public bool BanUserAccount(User user, string reasonForDeleting)
        {
            return ibannedUserDAL.BanUserAccount(user, reasonForDeleting);
        }
        public string UnBanUserAccount(User user)
        {
            return ibannedUserDAL.UnBanUserAccount(user);
        }
    }
}
