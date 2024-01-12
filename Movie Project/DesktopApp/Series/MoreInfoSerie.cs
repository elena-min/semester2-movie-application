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

namespace DesktopApp.Series
{
    public partial class MoreInfoSerie : Form
    {
        private MediaItem selectedSerie;
        private IMediaItemDAL imediaItemDAL;
        private MediaItemController mediaItemController;
        private IUserDAL iuserDAL;
        private UserController userController;
        public MoreInfoSerie(MediaItem serie)
        {
            InitializeComponent();
            imediaItemDAL = new MediaItemDAL();
            mediaItemController = new MediaItemController(imediaItemDAL);
            iuserDAL = new UserDAL();
            userController = new UserController(iuserDAL);
            this.selectedSerie = serie;

            lblInsertTitle.Text = serie.Title;
            richTextBoxDescription.Text = serie.Description;
            lblInsertCast.Text = serie.Cast.ToString();
            lblInsertDateOfPublishment.Text = serie.ReleaseDate.ToString("dd-MM-yyyy");
            lblInsertCountryOfOrigin.Text = serie.CountryOfOrigin;
            lblInsertCurrentRating.Text = serie.Rating.ToString();
            lblInsertEpisodes.Text = ((Serie)serie).Episodes.ToString();
            lblInsertSeasons.Text = ((Serie)serie).Seasons.ToString();
            foreach (Genre genre in serie.GetAllGenres())
            {
                listBoxInsertGenres.Items.Add(genre.ToString());
            }

            try
            {
                if (mediaItemController.GetMediaItemImageByID(serie).Length != 0)
                {
                    byte[] pictureBytes = Convert.FromBase64String(mediaItemController.GetMediaItemImageByID(serie));
                    MemoryStream memoryStream = new MemoryStream(pictureBytes);
                    Image pictureImage = Image.FromStream(memoryStream);
                    pictureBoxBookPic.BackgroundImageLayout = ImageLayout.Stretch;
                    pictureBoxBookPic.BackgroundImage = pictureImage;
                }

                if (mediaItemController.GetAllGivenRatings(serie).Length != 0)
                {
                    foreach (int rating in mediaItemController.GetAllGivenRatings(serie))
                    {
                        serie.AddRating(rating);
                    }
                    lblGivenRating.Text = ((Serie)serie).CalculateAverageRating().ToString();
                }
                else
                {
                    lblGivenRating.Text = "No reviews yet.";
                }
            }
            catch (Exception ex)
            {
                lblWarning.Text = ex.Message;
            }
            
        }
    }
}
