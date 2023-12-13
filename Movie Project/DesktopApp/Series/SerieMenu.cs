using DAL;
using DesktopApp.Movies;
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

namespace DesktopApp.Series
{
    public partial class SerieMenu : Form
    {
        private Button currentButton;
        private Form activeform;
        private readonly MediaItemController mediaItemController;
        private readonly FavoritesController favController;
        private readonly ReviewController reviewController;
        IMediaItemDAL iMediaItemDAL;
        IFavoritesDAL ifavoritesDAL;
        IReviewDAL iReviewDAL;
        List<MediaItem> allSeries;
        public SerieMenu()
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

            listBoxViewSeries.Items.Clear();
            allSeries = new List<MediaItem>();
            try
            {
                if (mediaItemController.GetAll() == null)
                {

                    lblWarning.Text = "No series in the system.";
                }
                else
                {
                    foreach (MediaItem serie in mediaItemController.GetAll())
                    {
                        if (serie is Serie)
                        {
                            allSeries.Add(serie);
                        }
                    }
                }

                if (allSeries.Count > 0)
                {
                    foreach (MediaItem serie in allSeries)
                    {
                        listBoxViewSeries.Items.Add(((Serie)serie).ToString());
                    }
                }
                else
                {
                    lblWarning.Text = "No series in the system.";
                }
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

        private void btnAddSerie_Click(object sender, EventArgs e)
        {
            AddSerie addSerie = new AddSerie();
            addSerie.Show();
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
            listBoxViewSeries.Items.Clear();
            List<MediaItem> allSeries = new List<MediaItem>();
            if (textBoxSeriesTitle.Text != null && textBoxSeriesID.Text != null)
            {
                foreach (MediaItem serie in mediaItemController.GetAll())
                {
                    if (serie is Serie)
                    {
                        if (serie.Title.Contains(textBoxSeriesTitle.Text))
                        {
                            string movieID = serie.GetId().ToString();
                            if (movieID.Contains(textBoxSeriesID.Text))
                            {
                                //listBoxViewMovies.Items.Add(movie.ToString());
                                allSeries.Add(serie);
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (MediaItem serie in mediaItemController.GetAll())
                {
                    if (serie is Serie)
                    {
                        allSeries.Add(serie);
                    }
                    //listBoxViewMovies.Items.Add(book.ToString());
                }
            }


            foreach (MediaItem serie in allSeries)
            {
                listBoxViewSeries.Items.Add(serie.ToString());
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this serie?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (listBoxViewSeries.SelectedIndex != -1)
                {
                    int selected_serie_id = Int32.Parse(listBoxViewSeries.SelectedItem.ToString().Split('-')[1]);
                    MediaItem mediaItem = mediaItemController.GetMediaItemById(selected_serie_id);
                    if(mediaItem != null)
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

                    listBoxViewSeries.Items.Clear();
                    foreach (MediaItem serie in mediaItemController.GetAll())
                    {
                        if (serie is Serie)
                        {
                            listBoxViewSeries.Items.Add(serie.ToString());
                        }
                    }
                }
                else
                {
                    lblWarning.Text = "There is no serie selected!";

                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            lblWarning.Text = "";
            if (listBoxViewSeries.SelectedItem != null)
            {
                string selectedSerie = listBoxViewSeries.SelectedItem.ToString();
                int serieID = Convert.ToInt32(selectedSerie.Split("-")[1]);
                foreach (MediaItem serie in mediaItemController.GetAll())
                {
                    if (serie is Serie)
                    {
                        if (selectedSerie == ((Serie)serie).ToString())
                        {
                            UpdateSerie serieUpdate = new UpdateSerie(serie, serieID);
                            serieUpdate.Show();
                        }
                    }
                }
            }
            else
            {
                lblWarning.Text = "There is no serie selected.";
            }
        }

        private void buttonMoreInfo_Click(object sender, EventArgs e)
        {
            lblWarning.Text = "";
            if (listBoxViewSeries.SelectedItem != null)
            {
                string selectedSerie = listBoxViewSeries.SelectedItem.ToString();
                foreach (MediaItem serie in mediaItemController.GetAll())
                {
                    if (serie is Serie)
                    {
                        if (selectedSerie == ((Serie)serie).ToString())
                        {
                            MoreInfoSerie serieMoreInfo = new MoreInfoSerie(serie);
                            serieMoreInfo.Show();
                        }
                    }
                }
            }
        }
    }
}
