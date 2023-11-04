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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DesktopApp.Reviews
{
    public partial class MoreInfoReview : Form
    {
        private Review review;
        private ReviewController reviewController;
        private IReviewDAL iReviewDAL;
        private MediaItemController mediaController;
        private IMediaItemDAL mediaItemDAL; 

        public MoreInfoReview(Review _review)
        {
            InitializeComponent();
            iReviewDAL = new ReviewDAL();
            reviewController = new ReviewController(iReviewDAL);
            mediaItemDAL = new MediaItemDAL();
            mediaController = new MediaItemController(mediaItemDAL);
            this.review = _review;
            lblWarning.Text = "";

            lblInsertTitle.Text = review.Title;
            richTextBoxContent.Text = review.ReviewContent.ToString();
            lblInsertUser.Text = review.ReviewWriter.Username.ToString();
            lblInsertDateOfPublishment.Text = review.DateOfPublication.ToString("dd-MM-yyyy");
            lblInsertGivenRating.Text = $"{review.Rating.ToString()}/5";
            labelTowardsTitle.Text = review.PointedTowards.Title;
            if (mediaController.GetMediaItemImageByID(review.PointedTowards.GetId()).Length != 0)
            {
                byte[] pictureBytes = Convert.FromBase64String(mediaController.GetMediaItemImageByID(review.PointedTowards.GetId()));
                MemoryStream memoryStream = new MemoryStream(pictureBytes);
                Image pictureImage = Image.FromStream(memoryStream);
                pictureBoxPic.BackgroundImageLayout = ImageLayout.Stretch;
                pictureBoxPic.BackgroundImage = pictureImage;
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this review?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (!string.IsNullOrWhiteSpace(textBoxReason.Text))
                {
                    Review reviewDelete = reviewController.GetReviewByID(review.GetId());
                    string reasonForDeleting = textBoxReason.Text;
                    reviewDelete.SetReviewAsDeleted(reasonForDeleting);
                    reviewController.Delete(reviewDelete);
                    this.Close();
                }
                else
                {
                    lblWarning.Text = "Please fill in a reason for deleting!";
                }
            }


        }
    }
}
