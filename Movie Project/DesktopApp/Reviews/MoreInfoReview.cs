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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DesktopApp.Reviews
{
    public partial class MoreInfoReview : Form
    {
        private Review review;
        private ReviewController reviewController;
        private IReviewDAL iReviewDAL;

        public MoreInfoReview(Review _review)
        {
            InitializeComponent();
            iReviewDAL = new ReviewDAL();
            reviewController = new ReviewController(iReviewDAL);
            this.review = _review;
            lblWarning.Text = "";

            lblInsertTitle.Text = review.Title;
            richTextBoxContent.Text = review.ReviewContent.ToString();
            lblInsertUser.Text = review.ReviewWriter.Username.ToString();
            lblInsertDateOfPublishment.Text = review.DateOfPublication.ToString("dd-MM-yyyy");
            lblInsertGivenRating.Text = $"{review.Rating.ToString()}/5";

        }

        private void buttonDelete_Click(object sender, EventArgs e)
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
