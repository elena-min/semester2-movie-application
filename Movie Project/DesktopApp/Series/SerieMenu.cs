﻿using DAL;
using DesktopApp.Movies;
using LogicLayer;
using LogicLayer.Classes;
using LogicLayer.Controllers;
using LogicLayer.Interfaces;
using LogicLayer.SortingStrategy;
using LogicLayer.Strategy;
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
        private readonly MediaItemViewsController mediaItemViewsController;
        private readonly TrendingController trendingController;
        private FilterContext filterContext;
        private SortingContext sortingContext;
        List<MediaItem> allSeries;
        public SerieMenu()
        {
            InitializeComponent();
            mediaItemController = new MediaItemController(new MediaItemDAL());
            favController = new FavoritesController(new FavoritesDAL());
            reviewController = new ReviewController(new ReviewDAL());
            mediaItemViewsController = new MediaItemViewsController(new MediaItemViewsDAL());
            trendingController = new TrendingController(new TrendingDAL());
            filterContext = new FilterContext();
            sortingContext = new SortingContext();

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
            List<MediaItem> filteredSeries = new List<MediaItem>();
            string serieName = textBoxSeriesTitle.Text;

            filterContext.SetFilterStrategy(new SearchFilterStrategy(serieName, null));

            filteredSeries = filterContext.GetFilteredMediaItems(allSeries).ToList();

            string selectedOrder = comboBoxOrder.SelectedItem?.ToString();

            switch (selectedOrder)
            {
                case "Ascending by title":
                    sortingContext.SetSortingStrategy(new TitleSortingStrategy());
                    filteredSeries = sortingContext.GetSortedMediaItems(filteredSeries).ToList();
                    break;

                case "Descending by title":
                    sortingContext.SetSortingStrategy(new TitleSortingStrategy(descending: true));
                    filteredSeries = sortingContext.GetSortedMediaItems(filteredSeries).ToList();
                    break;

                case "Ascending by id":
                    sortingContext.SetSortingStrategy(new IDSortingStrategy());
                    filteredSeries = sortingContext.GetSortedMediaItems(filteredSeries).ToList();
                    break;
                case "Descending by id":
                    sortingContext.SetSortingStrategy(new IDSortingStrategy(descending: true));
                    filteredSeries = sortingContext.GetSortedMediaItems(filteredSeries).ToList();
                    break;


            }

            foreach (MediaItem serie in filteredSeries)
            {
                listBoxViewSeries.Items.Add(serie.ToString());
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this serie?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (listBoxViewSeries.SelectedIndex != -1)
                    {
                        int selected_serie_id = Int32.Parse(listBoxViewSeries.SelectedItem.ToString().Split('-')[1]);
                        MediaItem mediaItem = mediaItemController.GetMediaItemById(selected_serie_id);
                        if (mediaItem != null)
                        {
                            bool removalSuccess = mediaItemController.RemoveMediaItem(mediaItem);

                            if (removalSuccess)
                            {
                                lblWarning.Text = "Media item deleted successfully";
                                reviewController.DeletedMediaItem(mediaItem);
                                favController.DeletedMediaItem(mediaItem);
                                mediaItemViewsController.RemoveMediaItemViews(mediaItem);
                                trendingController.RemoveMediaItem(mediaItem);

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
            catch (Exception ex)
            {
                lblWarning.Text = ex.Message;
            }
            
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                lblWarning.Text = ex.Message;
            }         
        }

        private void buttonMoreInfo_Click(object sender, EventArgs e)
        {
            try
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
            catch(Exception ex)
            {
                lblWarning.Text = ex.Message;
            }
            
        }
    }
}
