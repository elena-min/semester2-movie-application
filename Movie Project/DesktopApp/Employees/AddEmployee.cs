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
            if (string.IsNullOrEmpty(textBoxFName.Text))
            {
                lblWarning.Text = "No first name is filled in!";
                return;
            }
            if (string.IsNullOrEmpty(textBoxLName.Text))
            {
                lblWarning.Text = "No last name is filled in!";
                return;
            }
            if (string.IsNullOrEmpty(textBoxUsername.Text))
            {
                lblWarning.Text = "No username is filled in!";
                return;
            }
            if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                lblWarning.Text = "No password is filled in!";
                return;
            }
            if (string.IsNullOrEmpty(textBoxEmail.Text))
            {
                lblWarning.Text = "No email is filled in!";
                return;
            }
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
            string salt;
            string hashedPassword = HashPassword.GenerateHash(password, out salt); Gender gender = (Gender)comboBoxGender.SelectedItem;
           
            int age;
            if (int.TryParse(textBoxAge.Text, out  age))
            {
                if (age < 16 && age > 80)
                {
                    lblWarning.Text = "e is not valid. You must be at least 16 years old and under 80.";
                }
            }
            else
            {
                lblWarning.Text = "Please enter a valid age in years.";
                return;
            }


            newEmp = new Employee(fName, lName, username, email,hashedPassword, salt, gender, age);
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
