using LogicLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface IEmployeeDAL
    {
        bool InsertEmployee(Employee newEmployee);
        Employee GetEmployeeByID(int id);
        Employee GetEmployeeByUsername(string username);
        Employee GetEmployeeByEmail(string email);
        Employee[] GetAll();
        bool UpdateEmployee(Employee employee);
        string DeleteEmployee(int id);

    }
}
