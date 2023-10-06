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
    public partial class UpdateMovie : Form
    {
        private IMediaItemDAL iMediaItemDAL;
        private MediaItemController mediaItemController;
        private MediaItem changedMovie;
        public UpdateMovie(MediaItem movie, int movieid)
        {
            InitializeComponent();
            iMediaItemDAL = new MediaItemDAL();
            mediaItemController = new MediaItemController(iMediaItemDAL);

            lblWarning.Text = "";
            textBoxMovieTitle.Text = movie.Title;
            labelMovieId.Text = movieid.ToString();
            richTextBoxDescription.Text = movie.Description;
            textBoxCast.Text = movie.Cast.ToString();
            textBoxMovieDirector.Text = ((Movie)movie).Director;
            textBoxMovieWriter.Text = ((Movie)movie).Writer;
            textBMovieCountryOfOrigin.Text = movie.CountryOfOrigin;
            dateTimeMoviePublishment.Value = movie.ReleaseDate;
            textBoxMovieDuration.Text = ((Movie)movie).Duration.ToString();
            textBoxMovieRating.Text = movie.Rating.ToString();

            var genres = Enum.GetValues(typeof(Genre));

            foreach (Genre g in genres)
            {
                checkedLBGenres.Items.Add(g);
            }
            foreach (Genre genre in movie.GetAllGenres())
            {
                if (checkedLBGenres.Items.Contains(genre))
                {
                    int index = checkedLBGenres.Items.IndexOf(genre);
                    checkedLBGenres.SetItemChecked(index, true);
                }
            }

            if (mediaItemController.GetMediaItemImageByID(movie.GetId()).Length != 0)
            {
                byte[] pictureBytes = Convert.FromBase64String(mediaItemController.GetMediaItemImageByID(movie.GetId()));
                MemoryStream memoryStream = new MemoryStream(pictureBytes);
                Image pictureImage = Image.FromStream(memoryStream);
                pictureBoxMoviePic.BackgroundImageLayout = ImageLayout.Stretch;
                pictureBoxMoviePic.BackgroundImage = pictureImage;
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

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            pictureBoxMoviePic.Dispose();
            pictureBoxMoviePic.Image = null;
            pictureBoxMoviePic.BackgroundImage = null;
        }

        private void buttonUpdateMovie_Click(object sender, EventArgs e)
        {
            string title = textBoxMovieTitle.Text;
            string description = richTextBoxDescription.Text;
            double rating;
            if (!double.TryParse(textBoxMovieRating.Text, out rating))
            {
                lblWarning.Text = "Please enter a valid rating.";
                return;
            }
            DateTime pubslishDate = dateTimeMoviePublishment.Value;
            string director = textBoxMovieDirector.Text;
            string writer = textBoxMovieWriter.Text;
            string cast = textBoxCast.Text;
            string countryOfOrigin = textBMovieCountryOfOrigin.Text;
            int duration;
            if (!int.TryParse(textBoxMovieDuration.Text, out duration))
            {
                lblWarning.Text = "Please enter a valid duartion in minutes.";
                return;
            }


            changedMovie = new Movie(title, description, pubslishDate, countryOfOrigin, rating, director, writer, duration);
            changedMovie.SetId(Int32.Parse(labelMovieId.Text));
            List<string> castList = cast.Split(',').ToList();
            foreach (string actor in castList)
            {
                changedMovie.Cast.AddToCast(actor);
            }
            foreach (object selectedGenre in checkedLBGenres.CheckedItems)
            {
                if (Enum.TryParse(selectedGenre.ToString(), out Genre enum_genre))
                {
                    changedMovie.AddGenre(enum_genre);
                }
            }

            if (mediaItemController.UpdateMediaItem(changedMovie, ImageToBytes(pictureBoxMoviePic.BackgroundImage, pictureBoxMoviePic)))
            {
                lblWarning.Text = "Movie updated successfully!";
            }
            else
            {
                lblWarning.Text = "Operation failed.";
            }
        }
    }
}
