using LogicLayer.Classes;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicLayer.Controllers;
using LogicLayer.Interfaces;
using DAL;
using System.Text.RegularExpressions;

namespace DesktopApp.Employees
{
    public partial class AddEmployee : Form
    {
        private readonly EmployeeController empController;
        IEmployeeDAL iEmployeeDAL;
        Employee newEmp;
        public AddEmployee()
        {
            InitializeComponent();
            iEmployeeDAL = new EmployeeDAL();
            empController = new EmployeeController(iEmployeeDAL);
            lblWarning.Text = "";
            comboBoxGender.DataSource = Enum.GetValues(typeof(Gender));

        }

        private void buttonAddEmp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxAge.Text))
            {
                lblWarning.Text = "No age is filled in!";
                return;
            }
            if (string.IsNullOrEmpty(comboBoxGender.Text))
            {
                lblWarning.Text = "No gender is filled in!";
                return;
            }

            try
            {
                string fName = textBoxFName.Text;
                string lName = textBoxLName.Text;
                string username = textBoxUsername.Text;
                string email = textBoxEmail.Text;
                string emailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
                if (!Regex.IsMatch(email, emailPattern))
                {
                    lblWarning.Text = "Please enter a valid email address.";
                    return;
                }
                string password = textBoxPassword.Text;
                Gender gender = (Gender)comboBoxGender.SelectedItem;

                int age;
                if (!int.TryParse(textBoxAge.Text, out age))
                {
                    lblWarning.Text = "Please enter age using numbers!";
                    return;
                }

                newEmp = new Employee(fName, lName, username, email, password, gender, age);
            }
            catch (InvalidAgeException ex)
            {
                lblWarning.Text = ex.Message;
                return;
            }
            catch (Exception ex)
            {
                lblWarning.Text = $"An unexpected error: {ex.Message}";
                return;
            }


            if (empController.AddEmployee(newEmp))
            {
                lblWarning.Text = "Employee has been added successfully!";
            }
            else
            {
                lblWarning.Text = "Operation failed.";
            }
        }
    }
}
