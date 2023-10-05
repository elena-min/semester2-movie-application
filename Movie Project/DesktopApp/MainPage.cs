using LogicLayer;
using LogicLayer.Classes;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class MainPage : Form
    {
        private Button currentButton;
        private Form activeform;
        private Employee _user { get; }
        public MainPage(/*Employee user*/)
        {
            InitializeComponent();
            buttonClose.Visible = false;
            //_user = user;
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
                    buttonClose.Visible = true;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousButton in panelButtons.Controls)
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
        private void btnMovies_Click(object sender, EventArgs e)
        {
            lblFormTitle.Text = "Movies";
            OpenChildForm(new Movies.MovieMenu(), sender);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (activeform != null)
            {
                activeform.Close();
            }
            Reset();
        }
        private void Reset()
        {
            DisableButton();
            lblFormTitle.Text = "Home";
            currentButton = null;
            buttonClose.Visible = false;
        }

        private void btnSeries_Click(object sender, EventArgs e)
        {
            lblFormTitle.Text = "Series";
            //OpenChildForm(new Movies.MoviesMenu(), sender);
        }

        private void btnReviews_Click(object sender, EventArgs e)
        {
            lblFormTitle.Text = "Reviews";
            // OpenChildForm(new Movies.MoviesMenu(), sender);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            lblFormTitle.Text = "Users";
            //   OpenChildForm(new Movies.MoviesMenu(), sender);
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            lblFormTitle.Text = "Employees";
            //   OpenChildForm(new Movies.MoviesMenu(), sender);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            lblFormTitle.Text = "Profile";
            //OpenChildForm(new Movies.MoviesMenu(), sender);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.ShowDialog();
            this.Close();
        }
    }
}
