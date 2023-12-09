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
            StringBuilder exceptionMessages = new StringBuilder();

            if (string.IsNullOrEmpty(textBoxAge.Text))
            {
                exceptionMessages.AppendLine("No age is filled in!");
            }
            if (string.IsNullOrEmpty(comboBoxGender.Text))
            {
                exceptionMessages.AppendLine("No gender is filled in!");
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
                    exceptionMessages.AppendLine("Please enter a valid email address.");
                }
                string password = textBoxPassword.Text;
                Gender gender = (Gender)comboBoxGender.SelectedItem;

                int age;
                if (!int.TryParse(textBoxAge.Text, out age))
                {
                    exceptionMessages.AppendLine("Please enter age using numbers!");
                }

                newEmp = new Employee(fName, lName, username, email, password, gender, age);
            }
            catch (InvalidAgeException ex)
            {
                exceptionMessages.AppendLine(ex.Message);
            }
            catch(ValidationException ex)
            {
                foreach (var error in ex.ValidationErrors)
                {
                    exceptionMessages.AppendLine(error);
                }
            }
            catch (Exception ex)
            {
                exceptionMessages.AppendLine($"An unexpected error: {ex.Message}");
            }

            // Display all exception messages at once
            lblWarning.Text = exceptionMessages.ToString();
            try
            {
                if (string.IsNullOrEmpty(lblWarning.Text))
                {
                    // No exceptions occurred, proceed with adding the employee
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
            catch (Exception ex)
            {
                lblWarning.Text = $"An unexpected error occurred: {ex.Message}";
            }
        }
    }
}
