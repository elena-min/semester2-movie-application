using DAL;
using LogicLayer;
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

namespace DesktopApp.Movies
{
    public partial class MoreInfoMovie : Form
    {
        private MediaItem selectedMovie;
        private IMediaItemDAL imediaItemDAL;
        private MediaItemController mediaItemController;
        private IUserDAL iuserDAL;
        private UserController userController;

        public MoreInfoMovie(MediaItem movie)
        {
            InitializeComponent();
            imediaItemDAL = new MediaItemDAL();
            mediaItemController = new MediaItemController(imediaItemDAL);
            iuserDAL = new UserDAL();
            userController = new UserController(iuserDAL);
            this.selectedMovie = movie;

            lblInsertTitle.Text = movie.Title;
            richTextBoxDescription.Text = movie.Description;
            lblInsertDirector.Text = ((Movie)movie).Director;
            lblInsertWriter.Text = ((Movie)movie).Writer;
            lblInsertCast.Text = movie.Cast.ToString();
            lblInsertDateOfPublishment.Text = movie.ReleaseDate.ToString("dd-MM-yyyy");
            lblInsertCountryOfOrigin.Text = movie.CountryOfOrigin;
            lblInsertDuration.Text = ((Movie)movie).Duration.ToString();
            lblInsertCurrentRating.Text = movie.Rating.ToString();
            foreach (Genre genre in movie.GetAllGenres())
            {
                listBoxInsertGenres.Items.Add(genre.ToString());
            }

            if (mediaItemController.GetMediaItemImageByID(movie).Length != 0)
            {
                byte[] pictureBytes = Convert.FromBase64String(mediaItemController.GetMediaItemImageByID(movie));
                MemoryStream memoryStream = new MemoryStream(pictureBytes);
                Image pictureImage = Image.FromStream(memoryStream);
                pictureBoxBookPic.BackgroundImageLayout = ImageLayout.Stretch;
                pictureBoxBookPic.BackgroundImage = pictureImage;
            }

            if (mediaItemController.GetAllGivenRatings(movie).Length != 0)
            {
                foreach (int rating in mediaItemController.GetAllGivenRatings(movie))
                {
                    movie.AddRating(rating);
                }
                lblGivenRating.Text = ((Movie)movie).CalculateAverageRating().ToString();
            }
            else
            {
                lblGivenRating.Text = "No reviews yet.";
            }
        }
    }
}
