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
            if (string.IsNullOrEmpty(textBoxMovieTitle.Text))
            {
                lblWarning.Text = "No title is filled in!";
                return;
            }
            if (string.IsNullOrEmpty(richTextBoxDescription.Text))
            {
                lblWarning.Text = "No description is filled in!";
                return;
            }
            if (string.IsNullOrEmpty(textBoxMovieDirector.Text))
            {
                lblWarning.Text = "No director is filled in!";
                return;
            }
            if (string.IsNullOrEmpty(textBoxMovieWriter.Text))
            {
                lblWarning.Text = "No writer is filled in!";
                return;
            }
            if (string.IsNullOrEmpty(textBoxMovieRating.Text))
            {
                lblWarning.Text = "No rating is filled in!";
                return;
            }
            if (string.IsNullOrEmpty(textBoxCast.Text))
            {
                lblWarning.Text = "No cast is filled in!";
                return;
            }
            if (string.IsNullOrEmpty(textBMovieCountryOfOrigin.Text))
            {
                lblWarning.Text = "No counrry of origin is filled in!";
                return;
            }
            if (string.IsNullOrEmpty(textBoxMovieDuration.Text))
            {
                lblWarning.Text = "No duration is filled in!";
                return;
            }
            if (checkedLBGenres.CheckedIndices.Count == 0)
            {
                lblWarning.Text = "No genres are filled in!";
                return;
            }


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


            newMovie = new Movie(title, description, pubslishDate, countryOfOrigin, rating, director, writer, duration);
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
