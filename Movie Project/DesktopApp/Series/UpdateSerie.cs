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
    public partial class UpdateSerie : Form
    {
        private IMediaItemDAL iMediaItemDAL;
        private MediaItemController mediaItemController;
        private MediaItem changedSerie;
        public UpdateSerie(MediaItem serie, int serieid)
        {
            InitializeComponent();
            iMediaItemDAL = new MediaItemDAL();
            mediaItemController = new MediaItemController(iMediaItemDAL);

            lblWarning.Text = "";
            textBoxSerieTitle.Text = serie.Title;
            labelSerieId.Text = serieid.ToString();
            richTextBoxDescription.Text = serie.Description;
            textBoxCast.Text = serie.Cast.ToString();
            textBSerieCountryOfOrigin.Text = serie.CountryOfOrigin;
            dateTimeSeriePublishment.Value = serie.ReleaseDate;
            textBoxSerieRating.Text = serie.Rating.ToString();
            textBoxSerieEpisodes.Text = ((Serie)serie).Episodes.ToString();
            textBoxSerieSeasons.Text = ((Serie)serie).Seasons.ToString();

            var genres = Enum.GetValues(typeof(Genre));

            foreach (Genre g in genres)
            {
                checkedLBGenres.Items.Add(g);
            }
            foreach (Genre genre in serie.GetAllGenres())
            {
                if (checkedLBGenres.Items.Contains(genre))
                {
                    int index = checkedLBGenres.Items.IndexOf(genre);
                    checkedLBGenres.SetItemChecked(index, true);
                }
            }

            try
            {
                if (mediaItemController.GetMediaItemImageByID(serie).Length != 0)
                    {
                       byte[] pictureBytes = Convert.FromBase64String(mediaItemController.GetMediaItemImageByID(serie));
                       MemoryStream memoryStream = new MemoryStream(pictureBytes);
                       Image pictureImage = Image.FromStream(memoryStream);
                       pictureBoxSeriePic.BackgroundImageLayout = ImageLayout.Stretch;
                       pictureBoxSeriePic.BackgroundImage = pictureImage;
                    }
            }
            catch (Exception ex)
            {
                lblWarning.Text = ex.Message;
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

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            pictureBoxSeriePic.Dispose();
            pictureBoxSeriePic.Image = null;
            pictureBoxSeriePic.BackgroundImage = null;
        }

        private void buttonUpdateSerie_Click(object sender, EventArgs e)
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
                int episodes;
                if (!int.TryParse(textBoxSerieEpisodes.Text, out episodes))
                {
                    lblWarning.Text = "Please enter a valid number of episodes.";
                    return;
                }
                int seasons;
                if (!int.TryParse(textBoxSerieSeasons.Text, out seasons))
                {
                    lblWarning.Text = "Please enter a valid number of seasons.";
                    return;
                }

                changedSerie = new Serie(title, description, pubslishDate, countryOfOrigin, rating, seasons, episodes);
                changedSerie.SetId(Int32.Parse(labelSerieId.Text));
                List<string> castList = cast.Split(',').ToList();
                foreach (string actor in castList)
                {
                    changedSerie.Cast.AddToCast(actor);
                }
                foreach (object selectedGenre in checkedLBGenres.CheckedItems)
                {
                    if (Enum.TryParse(selectedGenre.ToString(), out Genre enum_genre))
                    {
                        changedSerie.AddGenre(enum_genre);
                    }
                }

                if (Filename == null || Filename.Length == 0 || FilenameCompressed == null || FilenameCompressed.Length == 0)
                {
                    Filename = Convert.FromBase64String(mediaItemController.GetMediaItemImageByID(changedSerie));
                    FilenameCompressed = Convert.FromBase64String(mediaItemController.GetMediaItemCompressedImageByID(changedSerie));
                }

                if (mediaItemController.UpdateMediaItem(changedSerie, Filename, FilenameCompressed))
                {
                    lblWarning.Text = "Serie updated successfully!";
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
    }
}
