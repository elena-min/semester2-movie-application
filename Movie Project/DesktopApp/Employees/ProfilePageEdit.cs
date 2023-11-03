using DAL;
using LogicLayer;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.Employees
{
    public partial class ProfilePageEdit : Form
    {
        private Employee employee;
        private IEmployeeDAL iemployeeDAL;
        private EmployeeController employeeController;
        private Employee _user;
        public ProfilePageEdit(Employee user)
        {
            InitializeComponent();
            _user = user;
            iemployeeDAL = new EmployeeDAL();
            employeeController = new EmployeeController(iemployeeDAL);
            //labelEmpId.Text = _user.GetId().ToString();
            textBoxFName.Text = _user.FirstName;
            textBoxLName.Text = _user.LastName;
            textBoxUsername.Text = _user.Username;
            textBoxEmail.Text = _user.Email;
            textBoxAge.Text = _user.Age.ToString();
            comboBoxGender.DataSource = Enum.GetValues(typeof(Gender));
            comboBoxGender.SelectedItem = _user.Gender;
            lblWarning.Text = "";
        }
        byte[] Filename;
        public byte[] ImageToBytes(Image img, PictureBox pictureBox)
        {
            MemoryStream ms = new MemoryStream();
            if (img != null)
            {
                if (pictureBox != null)
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            return ms.ToArray();
        }
        private void btnImageUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                pictureBoxProfilePic.BackgroundImage = Image.FromFile(openFileDialog.FileName);
                pictureBoxProfilePic.BackgroundImageLayout = ImageLayout.Stretch;
                Filename = ImageToBytes(pictureBoxProfilePic.BackgroundImage, pictureBoxProfilePic);
            }
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            pictureBoxProfilePic.Dispose();
            pictureBoxProfilePic.Image = null;
            pictureBoxProfilePic.BackgroundImage = null;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string firstName = textBoxFName.Text;
            string lastName = textBoxLName.Text;
            string email = textBoxEmail.Text;
            string emailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(email))
            {
                lblWarning.Text = "Please fill in all required fields.";
                return;
            }

            if (!Regex.IsMatch(email, emailPattern))
            {
                lblWarning.Text = "Please enter a valid email address.";
                return;
            }


            int age;
            if (!int.TryParse(textBoxAge.Text, out age))
            {
                lblWarning.Text = "Please enter a valid age.";
                return;
            }
            Gender gender = (Gender)comboBoxGender.SelectedItem;
            string e_gender = gender.ToString();
            string username = textBoxUsername.Text;

            employee = new Employee(firstName, lastName, username, email, _user.Password, gender, age);
            employee.SetId(_user.GetId());
            if(employeeController.UpdateEmployee(employee, ImageToBytes(pictureBoxProfilePic.BackgroundImage, pictureBoxProfilePic)))
            {
                lblWarning.Text = "Profile information changes successfully!";
            }
            else
            {
                lblWarning.Text = "Operation failed.";

            }
        }
    }
}
