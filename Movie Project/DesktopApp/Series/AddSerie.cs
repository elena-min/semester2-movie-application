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

            try{
                string title = textBoxSerieTitle.Text;
                string description = richTextBoxDescription.Text;
                double rating;
                if (!double.TryParse(textBoxSerieRating.Text, out rating))
                {
                    lblWarning.Text = "Please enter a rating using numbers.";
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


                newSerie = new Serie(title, description, pubslishDate, countryOfOrigin, rating, seasons, episodes);
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

            if (mediaController.AddMediaItem(newSerie, Filename, FilenameCompressed))
            {
                lblWarning.Text = "Serie has been added successfully!";
            }
            else
            {
                lblWarning.Text = "Operation failed.";
            }
        }
        byte[] Filename;
        byte[] FilenameCompressed;

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
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                DialogResult dialogResult = openFileDialog.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    SixLabors.ImageSharp.Image imageSharp;

                    pictureBoxSeriePic.BackgroundImage = Image.FromFile(openFileDialog.FileName);
                    pictureBoxSeriePic.BackgroundImageLayout = ImageLayout.Stretch;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pictureBoxSeriePic.BackgroundImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        // Load the original image into imageSharp
                        imageSharp = SixLabors.ImageSharp.Image.Load(ms.ToArray());
                    }

                    //Save the file as a 2mb file
                    Filename = ImageHelper.CompressImageToByteArray(imageSharp, 2 * 1024 * 1024);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        pictureBoxSeriePic.BackgroundImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        imageSharp = SixLabors.ImageSharp.Image.Load(ms.ToArray());
                    }
                    //Compress the photo again as 100kb and save it to FilenameCompressed
                    FilenameCompressed = ImageHelper.CompressImageToByteArray(imageSharp, 1000 * 1024);
                }
            }
            catch (Exception ex)
            {
                lblWarning.Text = $"{ex.Message}";
            }

        }
    }
}
