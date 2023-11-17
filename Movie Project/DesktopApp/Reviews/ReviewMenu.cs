using DAL;
using DesktopApp.Movies;
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

namespace DesktopApp.Reviews
{
    public partial class ReviewMenu : Form
    {
        private Button currentButton;
        private Form activeform;
        private readonly ReviewController reviewController;
        IReviewDAL iReviewDAL;
        List<Review> allReviews;
        public ReviewMenu()
        {
            InitializeComponent();
            iReviewDAL = new ReviewDAL();
            reviewController = new ReviewController(iReviewDAL);

            lblWarning.Text = "";

            listBoxViewReviews.Items.Clear();
            allReviews = new List<Review>();

            if (reviewController.GetAll() == null)
            {

                lblWarning.Text = "No reviews in the system.";
            }
            else
            {
                foreach (Review movie in reviewController.GetAll())
                {

                    allReviews.Add(movie);

                }
            }

            if (allReviews.Count > 0)
            {
                foreach (Review review in allReviews)
                {
                    listBoxViewReviews.Items.Add(review.ToString());
                }
            }
            else
            {
                lblWarning.Text = "No reviews in the system.";
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
            foreach (Control previousButton in panelDesktop.Controls)
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

        private void buttonDelete_Click(object sender, EventArgs e) { }

        private void buttonMoreInfo_Click(object sender, EventArgs e)
        {
            lblWarning.Text = "";
            if (listBoxViewReviews.SelectedItem != null)
            {
                string selectedReview = listBoxViewReviews.SelectedItem.ToString();
                foreach (Review review in reviewController.GetAll())
                {
                    if (selectedReview == review.ToString())
                    {
                        MoreInfoReview movieMoreReview = new MoreInfoReview(review);
                        movieMoreReview.Show();
                    }
                }
            }
            else
            {
                lblWarning.Text = "There is no review selected.";
            }
        }

        private void btnDailyReviews_Click(object sender, EventArgs e)
        {
            lblWarning.Text = "";
            listBoxViewReviews.Items.Clear();
            List<Review> matchingReviews = new List<Review>();
            DateTime chosenDate = dateTimePicker1.Value;

            foreach (Review review in reviewController.GetReviewsByDate(chosenDate))
            {
                if (review.ReviewWriter.Username.Contains(textBoxUsername.Text))
                {
                    string productTitle = review.PointedTowards.Title;
                    if (productTitle.Contains(textBoxTitle.Text))
                    {
                        matchingReviews.Add(review);
                        listBoxViewReviews.Items.Add(review.ToString());
                    }
                }
            }

        }

        private void labelName_Click(object sender, EventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            lblWarning.Text = "";

            listBoxViewReviews.Items.Clear();
            allReviews = new List<Review>();

            if (reviewController.GetAll() == null)
            {

                lblWarning.Text = "No reviews in the system.";
            }
            else
            {
                foreach (Review movie in reviewController.GetAll())
                {

                    allReviews.Add(movie);

                }
            }

            if (allReviews.Count > 0)
            {
                foreach (Review review in allReviews)
                {
                    listBoxViewReviews.Items.Add(review.ToString());
                }
            }
            else
            {
                lblWarning.Text = "No reviews in the system.";
            }
        }
    }
}
