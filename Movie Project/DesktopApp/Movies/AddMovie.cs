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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.Movies
{
    public partial class AddMovie : Form
    {
        MediaItem newMovie;
        IMediaItemDAL imediaDAL;
        MediaItemController mediaController;
        public AddMovie()
        {
            InitializeComponent();
            imediaDAL = new MediaItemDAL();
            mediaController = new MediaItemController(imediaDAL);
            var genres = Enum.GetValues(typeof(Genre));
            foreach (Genre g in genres)
            {
                checkedLBGenres.Items.Add(g);
            }
            lblWarning.Text = "";
        }
        private void AddMovie_Load(object sender, EventArgs e)
        {

        }

        private void buttonAddMovie_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBoxCast.Text))
            {
                lblWarning.Text = "No cast is filled in!";
                return;
            }
            if (checkedLBGenres.CheckedIndices.Count == 0)
            {
                lblWarning.Text = "No genres are filled in!";
                return;
            }

            try
            {
                string title = textBoxMovieTitle.Text;
                string description = richTextBoxDescription.Text;

                double rating;
                if (!double.TryParse(textBoxMovieRating.Text, out rating))
                {
                    lblWarning.Text = "Please enter a valid rating.";
                    return;
                }

                DateTime publishDate = dateTimeMoviePublishment.Value;
                string director = textBoxMovieDirector.Text;
                string writer = textBoxMovieWriter.Text;
                string cast = textBoxCast.Text;
                string countryOfOrigin = textBMovieCountryOfOrigin.Text;
                int duration;
                if (!int.TryParse(textBoxMovieDuration.Text, out duration))
                {
                    lblWarning.Text = "Please enter a valid duration in minutes.";
                    return;
                }

                newMovie = new Movie(title, description, publishDate, countryOfOrigin, rating, director, writer, duration);
                List<string> castList = cast.Split(',').ToList();
                foreach (string actor in castList)
                {
                    ((Movie)newMovie).Cast.AddToCast(actor);
                }
                foreach (object selectedGenre in checkedLBGenres.CheckedItems)
                {
                    if (Enum.TryParse(selectedGenre.ToString(), out Genre enum_genre))
                    {
                        newMovie.AddGenre(enum_genre);
                    }
                }

                if (mediaController.AddMediaItem(newMovie, ImageToBytes(pictureBoxMoviePic.BackgroundImage, pictureBoxMoviePic)))
                {
                    lblWarning.Text = "Movie has been added successfully!";
                }
                else
                {
                    lblWarning.Text = "Operation failed.";
                }
            }
            catch (InvalidRatingException ex)
            {
                lblWarning.Text = ex.Message;
                return;
            }
            catch (Exception ex)
            {
                lblWarning.Text = $"An unexpected error: {ex.Message}";
                return;
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

        private void btnImageUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                pictureBoxMoviePic.BackgroundImage = Image.FromFile(openFileDialog.FileName);
                pictureBoxMoviePic.BackgroundImageLayout = ImageLayout.Stretch;
                Filename = ImageToBytes(pictureBoxMoviePic.BackgroundImage, pictureBoxMoviePic);
            }
        }

        private void btnAddCast_Click(object sender, EventArgs e)
        {

        }
    }
}
