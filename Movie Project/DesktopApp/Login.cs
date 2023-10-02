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

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            MainPage mainform = new MainPage();
            mainform.Show();
            this.Hide();
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
