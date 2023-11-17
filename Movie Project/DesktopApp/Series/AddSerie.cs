using LogicLayer.Classes;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicLayer.Controllers;
using LogicLayer.Interfaces;
using DAL;

namespace DesktopApp.Series
{
    public partial class AddSerie : Form
    {
        MediaItem newSerie;
        IMediaItemDAL imediaDAL;
        MediaItemController mediaController;
        public AddSerie()
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

        private void buttonAddSerie_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxSerieTitle.Text))
            {
                lblWarning.Text = "No title is filled in!";
                return;
            }
            if (string.IsNullOrEmpty(richTextBoxDescription.Text))
            {
                lblWarning.Text = "No description is filled in!";
                return;
            }
            if (string.IsNullOrEmpty(textBoxSerieRating.Text))
            {
                lblWarning.Text = "No rating is filled in!";
                return;
            }
            if (string.IsNullOrEmpty(textBoxCast.Text))
            {
                lblWarning.Text = "No cast is filled in!";
                return;
            }
            if (string.IsNullOrEmpty(textBSerieCountryOfOrigin.Text))
            {
                lblWarning.Text = "No counrry of origin is filled in!";
                return;
            }
            if (string.IsNullOrEmpty(textBoxSerieSeasons.Text))
            {
                lblWarning.Text = "No number of seasons is filled in!";
                return;
            }
            if (string.IsNullOrEmpty(textBoxSerieEpisodes.Text))
            {
                lblWarning.Text = "No number of episodes is filled in!";
                return;
            }
            if (checkedLBGenres.CheckedIndices.Count == 0)
            {
                lblWarning.Text = "No genres are filled in!";
                return;
            }


            string title = textBoxSerieTitle.Text;
            string description = richTextBoxDescription.Text;
            double rating;
            if (!double.TryParse(textBoxSerieRating.Text, out rating))
            {
                lblWarning.Text = "Please enter a valid rating.";
                return;
            }

            DateTime pubslishDate = dateTimeSeriePublishment.Value;
            string cast = textBoxCast.Text;
            string countryOfOrigin = textBSerieCountryOfOrigin.Text;
            int seasons;
            if (!int.TryParse(textBoxSerieSeasons.Text, out seasons))
            {
                lblWarning.Text = "Please enter a valid number of seasons.";
                return;
            }
            int episodes;
            if (!int.TryParse(textBoxSerieEpisodes.Text, out episodes))
            {
                lblWarning.Text = "Please enter a valid number of episodes.";
                return;
            }
            int checkedItemCount = 0;


            newSerie = new Serie(title, description, pubslishDate, countryOfOrigin, rating, 0,seasons, episodes);
            List<string> castList = cast.Split(',').ToList();
            foreach (string actor in castList)
            {
                ((Serie)newSerie).Cast.AddToCast(actor);
            }
            foreach (object selectedGenre in checkedLBGenres.CheckedItems)
            {
                if (Enum.TryParse(selectedGenre.ToString(), out Genre enum_genre))
                {
                    newSerie.AddGenre(enum_genre);
                }
            }

            if (mediaController.AddMediaItem(newSerie, ImageToBytes(pictureBoxSeriePic.BackgroundImage, pictureBoxSeriePic)))
            {
                lblWarning.Text = "Serie has been added successfully!";
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
                pictureBoxSeriePic.BackgroundImage = Image.FromFile(openFileDialog.FileName);
                pictureBoxSeriePic.BackgroundImageLayout = ImageLayout.Stretch;
                Filename = ImageToBytes(pictureBoxSeriePic.BackgroundImage, pictureBoxSeriePic);
            }
        }
    }
}
