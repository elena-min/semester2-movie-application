namespace DesktopApp
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelDesktop = new Panel();
            panelButtons = new Panel();
            btnReviews = new Button();
            btnUsers = new Button();
            btnEmployees = new Button();
            btnProfile = new Button();
            btnLogout = new Button();
            btnSeries = new Button();
            btnMovies = new Button();
            panelTitle = new Panel();
            buttonClose = new Button();
            lblFormTitle = new Label();
            panelButtons.SuspendLayout();
            panelTitle.SuspendLayout();
            SuspendLayout();
            // 
            // panelDesktop
            // 
            panelDesktop.BackColor = Color.FromArgb(231, 223, 198);
            panelDesktop.Location = new Point(209, 81);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new Size(852, 630);
            panelDesktop.TabIndex = 5;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.FromArgb(145, 190, 222);
            panelButtons.Controls.Add(btnReviews);
            panelButtons.Controls.Add(btnUsers);
            panelButtons.Controls.Add(btnEmployees);
            panelButtons.Controls.Add(btnProfile);
            panelButtons.Controls.Add(btnLogout);
            panelButtons.Controls.Add(btnSeries);
            panelButtons.Controls.Add(btnMovies);
            panelButtons.Dock = DockStyle.Left;
            panelButtons.Location = new Point(0, 81);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(212, 630);
            panelButtons.TabIndex = 4;
            // 
            // btnReviews
            // 
            btnReviews.FlatAppearance.BorderSize = 0;
            btnReviews.FlatStyle = FlatStyle.Flat;
            btnReviews.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnReviews.ForeColor = Color.White;
            btnReviews.Location = new Point(0, 178);
            btnReviews.Name = "btnReviews";
            btnReviews.Size = new Size(221, 96);
            btnReviews.TabIndex = 16;
            btnReviews.Text = "Reviews";
            btnReviews.UseVisualStyleBackColor = true;
            btnReviews.Click += btnReviews_Click;
            // 
            // btnUsers
            // 
            btnUsers.FlatAppearance.BorderSize = 0;
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnUsers.ForeColor = Color.White;
            btnUsers.Location = new Point(0, 264);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(221, 96);
            btnUsers.TabIndex = 15;
            btnUsers.Text = "Users";
            btnUsers.UseVisualStyleBackColor = true;
            btnUsers.Click += btnUsers_Click;
            // 
            // btnEmployees
            // 
            btnEmployees.FlatAppearance.BorderSize = 0;
            btnEmployees.FlatStyle = FlatStyle.Flat;
            btnEmployees.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnEmployees.ForeColor = Color.White;
            btnEmployees.Location = new Point(0, 352);
            btnEmployees.Name = "btnEmployees";
            btnEmployees.Size = new Size(221, 96);
            btnEmployees.TabIndex = 14;
            btnEmployees.Text = "Employees";
            btnEmployees.UseVisualStyleBackColor = true;
            btnEmployees.Click += btnEmployees_Click;
            // 
            // btnProfile
            // 
            btnProfile.FlatAppearance.BorderSize = 0;
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnProfile.ForeColor = Color.White;
            btnProfile.Location = new Point(0, 444);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(221, 99);
            btnProfile.TabIndex = 13;
            btnProfile.Text = "Profile";
            btnProfile.UseVisualStyleBackColor = true;
            btnProfile.Click += btnProfile_Click;
            // 
            // btnLogout
            // 
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(0, 534);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(221, 96);
            btnLogout.TabIndex = 9;
            btnLogout.Text = "Log out";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnSeries
            // 
            btnSeries.FlatAppearance.BorderSize = 0;
            btnSeries.FlatStyle = FlatStyle.Flat;
            btnSeries.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSeries.ForeColor = Color.White;
            btnSeries.Location = new Point(0, 87);
            btnSeries.Name = "btnSeries";
            btnSeries.Size = new Size(221, 96);
            btnSeries.TabIndex = 12;
            btnSeries.Text = "Series";
            btnSeries.UseVisualStyleBackColor = true;
            btnSeries.Click += btnSeries_Click;
            // 
            // btnMovies
            // 
            btnMovies.FlatAppearance.BorderSize = 0;
            btnMovies.FlatStyle = FlatStyle.Flat;
            btnMovies.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnMovies.ForeColor = Color.White;
            btnMovies.Location = new Point(0, 0);
            btnMovies.Name = "btnMovies";
            btnMovies.Size = new Size(221, 96);
            btnMovies.TabIndex = 8;
            btnMovies.Text = "Movies";
            btnMovies.UseVisualStyleBackColor = true;
            btnMovies.Click += btnMovies_Click;
            // 
            // panelTitle
            // 
            panelTitle.BackColor = Color.FromArgb(138, 104, 86);
            panelTitle.Controls.Add(buttonClose);
            panelTitle.Controls.Add(lblFormTitle);
            panelTitle.Dock = DockStyle.Top;
            panelTitle.Location = new Point(0, 0);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(1061, 81);
            panelTitle.TabIndex = 3;
            // 
            // buttonClose
            // 
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point);
            buttonClose.ForeColor = Color.FromArgb(231, 223, 198);
            buttonClose.Location = new Point(979, 8);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(79, 70);
            buttonClose.TabIndex = 10;
            buttonClose.Text = "X";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblFormTitle.ForeColor = Color.FromArgb(231, 223, 198);
            lblFormTitle.Location = new Point(536, 17);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(127, 56);
            lblFormTitle.TabIndex = 8;
            lblFormTitle.Text = "Home";
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1061, 711);
            Controls.Add(panelDesktop);
            Controls.Add(panelButtons);
            Controls.Add(panelTitle);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainPage";
            Text = "MainPage";
            panelButtons.ResumeLayout(false);
            panelTitle.ResumeLayout(false);
            panelTitle.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelDesktop;
        private Panel panelButtons;
        private Button btnReviews;
        private Button btnUsers;
        private Button btnEmployees;
        private Button btnProfile;
        private Button btnLogout;
        private Button btnSeries;
        private Button btnMovies;
        private Panel panelTitle;
        private Button buttonClose;
        private Label lblFormTitle;
    }
}