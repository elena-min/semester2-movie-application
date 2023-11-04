using DAL;
using DesktopApp.Reviews;
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

namespace DesktopApp.Users
{
    public partial class MoreInfoUser : Form
    {
        private UserController userController;
        private IUserDAL iUserDAL;
        private ReviewController reviewController;
        private IReviewDAL iReviewDAL;
        private User selectedUser;
        public MoreInfoUser(User user)
        {
            InitializeComponent();
            iUserDAL = new UserDAL();
            userController = new UserController(iUserDAL);
            iReviewDAL = new ReviewDAL();
            reviewController = new ReviewController(iReviewDAL);
            this.selectedUser = user;
            lblWarning.Text = "";
            labelFName.Text = selectedUser.FirstName;
            labelLName.Text = selectedUser.LastName;
            labelUsername.Text = selectedUser.Username;
            labelEmail.Text = selectedUser.Email;
            richTextBoxDescription.Text = selectedUser.ProfileDescription;
            labelGender.Text = selectedUser.Gender.ToString();

            if (userController.GetProfilePicByID(selectedUser.GetId()) == null || userController.GetProfilePicByID(selectedUser.GetId()).Length == 0 )
            {
                pictureBoxBookPic.Image = null;
                btnRemoveImage.Visible = false;

            }
            else
            {
                byte[] pictureBytes = Convert.FromBase64String(userController.GetProfilePicByID(selectedUser.GetId()));
                MemoryStream memoryStream = new MemoryStream(pictureBytes);
                Image pictureImage = Image.FromStream(memoryStream);
                pictureBoxBookPic.BackgroundImageLayout = ImageLayout.Stretch;
                pictureBoxBookPic.BackgroundImage = pictureImage;
            }

            foreach (Review review in reviewController.GetReviewsByUser(selectedUser.GetId()))
            {
                listBoxViewReviews.Items.Add(review.GetInfo());
            }
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            pictureBoxBookPic.Dispose();
            pictureBoxBookPic.Image = null;
            pictureBoxBookPic.BackgroundImage = null;
            if (userController.SetProfilePicture(selectedUser.GetId(), ImageToBytes(pictureBoxBookPic.BackgroundImage, pictureBoxBookPic)))
            {
                lblWarning.Text = "Picture removed successfully!";
            }
            else
            {
                lblWarning.Text = "Operation failed.";
            }
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

        private void btnSeeReview_Click(object sender, EventArgs e)
        {
            lblWarning.Text = "";
            if (listBoxViewReviews.SelectedItem != null)
            {
                string selectedReview = listBoxViewReviews.SelectedItem.ToString();
                foreach (Review review in reviewController.GetAll())
                {
                    if (selectedReview == review.GetInfo())
                    {
                        MoreInfoReview reviewMoreInfo = new MoreInfoReview(review);
                        reviewMoreInfo.Show();
                    }
                }
            }
            else
            {
                lblWarning.Text = "There is no review selected.";
            }
        }
    }
}
