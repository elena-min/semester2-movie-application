using DAL;
using DesktopApp.Employees;
using LogicLayer.Classes;
using LogicLayer.Controllers;
using LogicLayer.Interfaces;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.Users
{
    public partial class UserMenu : Form
    {
        private Button currentButton;
        private Form activeform;
        private readonly ReviewController reviewController;
        IReviewDAL iReviewDAL;
        private readonly UserController userController;
        IUserDAL iUserDAL;
        private readonly FavoritesController favController;
        IFavoritesDAL ifavDAL;
        List<LogicLayer.Classes.User> allUsers;
        public UserMenu()
        {
            InitializeComponent();
            iUserDAL = new UserDAL();
            userController = new UserController(iUserDAL);
            ifavDAL = new FavoritesDAL();
            favController = new FavoritesController(ifavDAL);
            iReviewDAL = new ReviewDAL();
            reviewController = new ReviewController(iReviewDAL);

            lblWarning.Text = "";
            listBoxViewUsers.Items.Clear();
            allUsers = new List<LogicLayer.Classes.User>();

            try
            {
                if (userController.GetAll() == null)
                {

                    lblWarning.Text = "No users in the system.";
                }
                else
                {
                    foreach (LogicLayer.Classes.User user in userController.GetAll())
                    {
                        allUsers.Add(user);
                    }
                }

                if (allUsers.Count > 0)
                {
                    foreach (LogicLayer.Classes.User user in allUsers)
                    {
                        listBoxViewUsers.Items.Add(user.ToString());
                    }
                }
                else
                {
                    lblWarning.Text = "No users in the system.";
                }
            }
            catch (Exception ex)
            {
                lblWarning.Text = $"An unexpected error occurred: {ex.Message}";
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

        private void btnView_Click(object sender, EventArgs e)
        {
            if (activeform != null)
            {
                activeform.Close();
            }
            ActivateButton(sender);
        }

        private void buttonMoreInfo_Click(object sender, EventArgs e)
        {
            lblWarning.Text = "";
            try
            {
                if (listBoxViewUsers.SelectedItem != null)
                {
                    string selectedUser = listBoxViewUsers.SelectedItem.ToString();
                    foreach (LogicLayer.Classes.User user in userController.GetAll())
                    {
                        if (selectedUser == user.ToString())
                        {
                            MoreInfoUser userMoreInfo = new MoreInfoUser(user);
                            userMoreInfo.Show();
                        }
                    }
                }
                else
                {
                    lblWarning.Text = "There is no user selected.";
                }
            }
            catch (Exception ex)
            {
                lblWarning.Text = $"An unexpected error occurred: {ex.Message}";
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (listBoxViewUsers.SelectedIndex != -1)
                    {
                        int selected_user_id = Int32.Parse(listBoxViewUsers.SelectedItem.ToString().Split('-')[0]);
                        LogicLayer.Classes.User selectedUser = userController.GetUserByID(selected_user_id);
                        if (selectedUser != null)
                        {
                            lblWarning.Text = userController.DeleteUser(selectedUser);
                            reviewController.DeletedUser(selectedUser);
                            favController.DeletedUser(selectedUser);
                        }
                        else
                        {
                            lblWarning.Text = "No data found.";
                        }
                        listBoxViewUsers.Items.Clear();
                        foreach (LogicLayer.Classes.User user in userController.GetAll())
                        {
                            listBoxViewUsers.Items.Add(user.ToString());
                        }
                    }
                    else
                    {
                        lblWarning.Text = "There is no user selected!";

                    }
                }
            }
            catch (Exception ex)
            {
                lblWarning.Text = $"An unexpected error occurred: {ex.Message}";
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            lblWarning.Text = "";
            try
            {
                listBoxViewUsers.Items.Clear();
                List<LogicLayer.Classes.User> allUsers = new List<LogicLayer.Classes.User>();
                if (textBoxUserName.Text != null || textBoxUserName.Text == "")
                {
                    foreach (LogicLayer.Classes.User user in userController.GetAll())
                    {

                        if (user.FirstName.Contains(textBoxUserName.Text) || user.LastName.Contains(textBoxUserName.Text))
                        {
                            allUsers.Add(user);
                        }

                    }
                }
                else
                {
                    foreach (LogicLayer.Classes.User user in userController.GetAll())
                    {
                        allUsers.Add(user);
                    }
                }


                foreach (LogicLayer.Classes.User user in allUsers)
                {
                    listBoxViewUsers.Items.Add(user.ToString());
                }
            }
            catch (Exception ex)
            {
                lblWarning.Text = $"An unexpected error occurred: {ex.Message}";
            }
        }
    }
}
