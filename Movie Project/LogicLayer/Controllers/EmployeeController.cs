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
        public EmployeeController(IEmployeeDAL employeeDAL)
        {
            this.iemployeeDAL = employeeDAL;
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
        public void UpdateEmployee(Employee employee)
        {
            iemployeeDAL.UpdateEmployee(employee);
        }
        public string DeleteEmployee(int id)
        {
            return iemployeeDAL.DeleteEmployee(id);    
        }

    }
}
