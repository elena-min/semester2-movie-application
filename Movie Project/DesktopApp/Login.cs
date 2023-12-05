using DAL;
using LogicLayer;
using LogicLayer.Classes;
using LogicLayer.Controllers;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class Login : Form
    {
        EmployeeController employeeController;
        IEmployeeDAL iemployyeDAL = new EmployeeDAL();
        public Login()
        {
            InitializeComponent();
            employeeController = new EmployeeController(iemployyeDAL);
            lblWarning.Text = "";
            textBoxPassword.PasswordChar = '*';
            btnHidePass.Text = "Show";
        }
        MainPage mainform;

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string email = textBoxEmail.Text;
                Employee employee = employeeController.GetEmployeeByEmail(email);
                bool isLoggedIn = false;

                if (employee == null)
                {
                    lblWarning.Text = $"No employee with the email {email} exists.";
                    return;
                }
                else if (employee.Username != textBoxUsername.Text)
                {
                    lblWarning.Text = "Incorrect username.";
                    return;
                }
                else if (!HashPassword.VerifyPassword(textBoxPassword.Text, employee.Password, employee.Salt))
                {
                    lblWarning.Text = "Incorrect password.";
                    return;
                }
                else
                {
                    isLoggedIn = true;
                }

                if (isLoggedIn)
                {
                    mainform = new MainPage(employee);
                    mainform.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                lblWarning.Text = $"An error occurred: {ex.Message}";
            }
        }

        private void btnHidePass_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.PasswordChar == '\0')
            {
                textBoxPassword.PasswordChar = '*';
                btnHidePass.Text = "Show";
            }
            else
            {
                textBoxPassword.PasswordChar = '\0';
                btnHidePass.Text = "Hide";
            }
        }
    }
}
