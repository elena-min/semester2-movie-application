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
    public partial class MovieMenu : Form
    {
        private Button currentButton;
        private Form activeform;
        private readonly MediaItemController mediaItemController;
        private readonly FavoritesController favController;
        private readonly ReviewController reviewController;

        IMediaItemDAL iMediaItemDAL;
        IFavoritesDAL ifavoritesDAL;
        IReviewDAL iReviewDAL;
        List<MediaItem> allMovies;
        public MovieMenu()
        {
            InitializeComponent();
            iMediaItemDAL = new MediaItemDAL();
            ifavoritesDAL = new FavoritesDAL();
            iReviewDAL = new ReviewDAL();
            mediaItemController = new MediaItemController(iMediaItemDAL);
            favController = new FavoritesController(ifavoritesDAL);
            reviewController = new ReviewController(iReviewDAL);

            lblWarning.Text = "";
            string[] orderOptions = new string[]
            {
                "Ascending by id",
                "Descending by id",
                "Ascending by title",
                "Descending by title"
            };
            foreach (string option in orderOptions)
            {
                comboBoxOrder.Items.Add(option);
            }

            listBoxViewMovies.Items.Clear();
            allMovies = new List<MediaItem>();
            try
            {
                MediaItem[] allMediaItems = mediaItemController.GetAll();

                if (allMediaItems == null || allMediaItems.Length == 0)
                {
                    lblWarning.Text = "No movies in the system.";
                }
                else
                {
                    foreach (MediaItem mediaItem in allMediaItems)
                    {
                        if (mediaItem is Movie)
                        {
                            allMovies.Add(mediaItem);
                        }
                    }

                    if (allMovies.Count > 0)
                    {
                        foreach (MediaItem movie in allMovies)
                        {
                            listBoxViewMovies.Items.Add(((Movie)movie).ToString());
                        }
                    }
                    else
                    {
                        lblWarning.Text = "No movies in the system.";
                    }
                }
            }
            catch (InvalidObjectException ex)
            {
                lblWarning.Text = $"{ex.Message}";
            }
            catch (Exception ex)
            {
                lblWarning.Text = $"An unexpected error: {ex.Message}";
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
        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            AddMovie addMovies = new AddMovie();
            addMovies.Show();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (activeform != null)
            {
                activeform.Close();
            }
            ActivateButton(sender);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            lblWarning.Text = "";
            listBoxViewMovies.Items.Clear();
            List<MediaItem> allMovies = new List<MediaItem>();
            if (textBoxMovieName.Text != null && textBoxMoviesID.Text != null)
            {
                foreach (MediaItem movie in mediaItemController.GetAll())
                {
                    if (movie is Movie)
                    {
                        if (movie.Title.Contains(textBoxMovieName.Text))
                        {
                            string movieID = movie.GetId().ToString();
                            if (movieID == textBoxMoviesID.Text)
                            {
                                //listBoxViewMovies.Items.Add(movie.ToString());
                                allMovies.Add(movie);
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (MediaItem movie in mediaItemController.GetAll())
                {
                    if (movie is Movie)
                    {
                        allMovies.Add(movie);
                    }
                    //listBoxViewMovies.Items.Add(book.ToString());
                }
            }


            foreach (MediaItem movie in allMovies)
            {
                listBoxViewMovies.Items.Add(movie.ToString());
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this movie?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (listBoxViewMovies.SelectedIndex != -1)
                {
                    int selected_movie_id = Int32.Parse(listBoxViewMovies.SelectedItem.ToString().Split('-')[1]);
                    MediaItem mediaItem = mediaItemController.GetMediaItemById(selected_movie_id);
                    if (mediaItem != null)
                    {
                        bool removalSuccess = mediaItemController.RemoveMediaItem(mediaItem);

                        if (removalSuccess)
                        {
                            lblWarning.Text = "Media item deleted successfully";
                            reviewController.DeletedMediaItem(mediaItem);
                            favController.DeletedMediaItem(mediaItem);

                        }
                        else
                        {
                            lblWarning.Text = "Failed to delete media item";
                        }
                    }
                    else
                    {
                        lblWarning.Text = "No data found.";
                    }

                    listBoxViewMovies.Items.Clear();
                    foreach (MediaItem movie in mediaItemController.GetAll())
                    {
                        if (movie is Movie)
                        {
                            listBoxViewMovies.Items.Add(movie.ToString());
                        }
                    }
                }
                else
                {
                    lblWarning.Text = "There is no movie selected!";

                }
            }
        }

        private void buttonMoreInfo_Click(object sender, EventArgs e)
        {
            lblWarning.Text = "";
            if (listBoxViewMovies.SelectedItem != null)
            {
                string selectedMovie = listBoxViewMovies.SelectedItem.ToString();
                foreach (MediaItem movie in mediaItemController.GetAll())
                {
                    if (movie is Movie)
                    {
                        if (selectedMovie == ((Movie)movie).ToString())
                        {
                            MoreInfoMovie movieMoreInfo = new MoreInfoMovie(movie);
                            movieMoreInfo.Show();
                        }
                    }
                }
            }
            else
            {
                lblWarning.Text = "There is no movie selected.";
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            lblWarning.Text = "";
            if (listBoxViewMovies.SelectedItem != null)
            {
                string selectedMovie = listBoxViewMovies.SelectedItem.ToString();
                int movieID = Convert.ToInt32(selectedMovie.Split("-")[1]);
                foreach (MediaItem movie in mediaItemController.GetAll())
                {
                    if (movie is Movie)
                    {
                        if (selectedMovie == ((Movie)movie).ToString())
                        {
                            UpdateMovie movieUpdate = new UpdateMovie(movie, movieID);
                            movieUpdate.Show();
                        }
                    }
                }
            }
            else
            {
                lblWarning.Text = "There is no movie selected.";
            }
        }
    }
}
