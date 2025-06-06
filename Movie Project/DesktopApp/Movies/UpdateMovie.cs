﻿using DAL;
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

            try
            {
                if (mediaItemController.GetMediaItemImageByID(movie).Length != 0)
                {
                    byte[] pictureBytes = Convert.FromBase64String(mediaItemController.GetMediaItemImageByID(movie));
                    MemoryStream memoryStream = new MemoryStream(pictureBytes);
                    Image pictureImage = Image.FromStream(memoryStream);
                    pictureBoxMoviePic.BackgroundImageLayout = ImageLayout.Stretch;
                    pictureBoxMoviePic.BackgroundImage = pictureImage;
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

                    pictureBoxMoviePic.BackgroundImage = Image.FromFile(openFileDialog.FileName);
                    pictureBoxMoviePic.BackgroundImageLayout = ImageLayout.Stretch;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pictureBoxMoviePic.BackgroundImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        // ms.Seek(0, SeekOrigin.Begin);
                        // Load the original image into imageSharp
                        imageSharp = SixLabors.ImageSharp.Image.Load(ms.ToArray());
                    }

                    //Save the file as a 2mb file
                    Filename = ImageHelper.CompressImageToByteArray(imageSharp, 2 * 1024 * 1024);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        pictureBoxMoviePic.BackgroundImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        // ms.Seek(0, SeekOrigin.Begin);
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
            pictureBoxMoviePic.Dispose();
            pictureBoxMoviePic.Image = null;
            pictureBoxMoviePic.BackgroundImage = null;
        }

        private void buttonUpdateMovie_Click(object sender, EventArgs e)
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

                if (Filename == null || Filename.Length == 0 || FilenameCompressed == null || FilenameCompressed.Length == 0)
                {
                    Filename = Convert.FromBase64String(mediaItemController.GetMediaItemImageByID(changedMovie));
                FilenameCompressed = Convert.FromBase64String(mediaItemController.GetMediaItemCompressedImageByID(changedMovie));


            }


            if (mediaItemController.UpdateMediaItem(changedMovie, Filename, FilenameCompressed))
                {
                    lblWarning.Text = "Movie updated successfully!";
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
