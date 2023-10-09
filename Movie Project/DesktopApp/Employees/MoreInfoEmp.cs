using DAL;
using LogicLayer.Classes;
using LogicLayer.Controllers;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.Employees
{
    public partial class MoreInfoEmp : Form
    {
        private EmployeeController empController;
        private IEmployeeDAL iEmployeeDAL;
        private Employee selectedEmp;
        public MoreInfoEmp(Employee employee)
        {
            InitializeComponent();
            iEmployeeDAL = new EmployeeDAL();
            empController = new EmployeeController(iEmployeeDAL);
            this.selectedEmp = employee;

            labelFName.Text = employee.FirstName;
            labelLName.Text = employee.LastName;
            labelUsername.Text = employee.Username;
            labelEmail.Text = employee.Email;
            labelAge.Text = employee.Age.ToString() + " years";
            labelGender.Text = employee.Gender.ToString();
        }
    }
}
