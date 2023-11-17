using DAL;
using LogicLayer.Classes;
using LogicLayer.Controllers;
using LogicLayer.Interfaces;
using Microsoft.VisualBasic.Devices;
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
    public partial class ProfilePage : Form
    {
        private EmployeeController empController;
        private IEmployeeDAL iEmployeeDAL;
        private Employee employee;
        private Button currentButton;
        private Form activeform;
        public ProfilePage(Employee selectedEmp)
        {
            InitializeComponent();
            iEmployeeDAL = new EmployeeDAL();
            empController = new EmployeeController(iEmployeeDAL);
            this.employee = empController.GetEmployeeByID(selectedEmp.GetId());

            labelFName.Text = employee.FirstName;
            labelLName.Text = employee.LastName;
            labelUsername.Text = employee.Username;
            labelEmail.Text = employee.Email;
            labelAge.Text = employee.Age.ToString() + " years";
            labelGender.Text = employee.Gender.ToString();
            if (empController.GetProfilePicByID(employee.GetId()).Length != 0 || empController.GetProfilePicByID(employee.GetId()) == null)
            {
                byte[] pictureBytes = Convert.FromBase64String(empController.GetProfilePicByID(employee.GetId()));
                MemoryStream memoryStream = new MemoryStream(pictureBytes);
                Image pictureImage = Image.FromStream(memoryStream);
                pictureBoxProfilePic.BackgroundImageLayout = ImageLayout.Stretch;
                pictureBoxProfilePic.BackgroundImage = pictureImage;
            }
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.FromArgb(0, 71, 102);
                    currentButton.ForeColor = Color.FromArgb(145, 190, 222);
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousButton in panel1.Controls)
            {
                if (previousButton.GetType() == typeof(Button))
                {
                    previousButton.BackColor = Color.FromArgb(145, 190, 222);
                    previousButton.ForeColor = Color.White;
                }
            }
        }

        private void OpenChildForm(Form childform, object btnSender)
        {
            if (activeform != null)
            {
                activeform.Close();
            }
            ActivateButton(btnSender);
            activeform = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childform);
            this.panelDesktop.Tag = childform;
            childform.BringToFront();
            childform.Show();
        }
        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ProfilePageEdit(employee), sender);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (activeform != null)
            {
                activeform.Close();
            }
            ActivateButton(sender);
        }
    }
}
