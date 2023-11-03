namespace DesktopApp.Reviews
{
    partial class ReviewMenu
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
            labelTitle = new Label();
            textBoxTitle = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            btnDailyReviews = new Button();
            lblWarning = new Label();
            buttonMoreInfo = new Button();
            listBoxViewReviews = new ListBox();
            buttonSearch = new Button();
            lblSearchMovies = new Label();
            labelName = new Label();
            textBoxUsername = new TextBox();
            btnView = new Button();
            panel1 = new Panel();
            panelDesktop.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelDesktop
            // 
            panelDesktop.BackColor = Color.FromArgb(231, 223, 198);
            panelDesktop.Controls.Add(labelTitle);
            panelDesktop.Controls.Add(textBoxTitle);
            panelDesktop.Controls.Add(dateTimePicker1);
            panelDesktop.Controls.Add(btnDailyReviews);
            panelDesktop.Controls.Add(lblWarning);
            panelDesktop.Controls.Add(buttonMoreInfo);
            panelDesktop.Controls.Add(listBoxViewReviews);
            panelDesktop.Controls.Add(buttonSearch);
            panelDesktop.Controls.Add(lblSearchMovies);
            panelDesktop.Controls.Add(labelName);
            panelDesktop.Controls.Add(textBoxUsername);
            panelDesktop.Location = new Point(0, 62);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new Size(860, 541);
            panelDesktop.TabIndex = 148;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelTitle.ForeColor = Color.FromArgb(138, 104, 86);
            labelTitle.Location = new Point(565, 107);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(101, 25);
            labelTitle.TabIndex = 147;
            labelTitle.Text = "Media title:";
            // 
            // textBoxTitle
            // 
            textBoxTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxTitle.ForeColor = Color.FromArgb(60, 144, 137);
            textBoxTitle.Location = new Point(565, 135);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(263, 31);
            textBoxTitle.TabIndex = 146;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePicker1.Location = new Point(565, 267);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(263, 32);
            dateTimePicker1.TabIndex = 145;
            // 
            // btnDailyReviews
            // 
            btnDailyReviews.BackColor = Color.White;
            btnDailyReviews.FlatAppearance.BorderColor = Color.FromArgb(138, 104, 86);
            btnDailyReviews.FlatAppearance.BorderSize = 2;
            btnDailyReviews.FlatStyle = FlatStyle.Flat;
            btnDailyReviews.Font = new Font("MV Boli", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnDailyReviews.ForeColor = Color.FromArgb(138, 104, 86);
            btnDailyReviews.Location = new Point(565, 305);
            btnDailyReviews.Name = "btnDailyReviews";
            btnDailyReviews.Size = new Size(263, 44);
            btnDailyReviews.TabIndex = 144;
            btnDailyReviews.Text = "Show by date";
            btnDailyReviews.UseVisualStyleBackColor = false;
            btnDailyReviews.Click += btnDailyReviews_Click;
            // 
            // lblWarning
            // 
            lblWarning.AutoSize = true;
            lblWarning.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblWarning.ForeColor = Color.Maroon;
            lblWarning.Location = new Point(12, 19);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new Size(81, 25);
            lblWarning.TabIndex = 137;
            lblWarning.Text = "Warning";
            // 
            // buttonMoreInfo
            // 
            buttonMoreInfo.BackColor = Color.White;
            buttonMoreInfo.FlatAppearance.BorderColor = Color.FromArgb(138, 104, 86);
            buttonMoreInfo.FlatAppearance.BorderSize = 2;
            buttonMoreInfo.FlatStyle = FlatStyle.Flat;
            buttonMoreInfo.Font = new Font("MV Boli", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonMoreInfo.ForeColor = Color.FromArgb(138, 104, 86);
            buttonMoreInfo.Location = new Point(12, 483);
            buttonMoreInfo.Name = "buttonMoreInfo";
            buttonMoreInfo.Size = new Size(226, 44);
            buttonMoreInfo.TabIndex = 142;
            buttonMoreInfo.Text = "More Info";
            buttonMoreInfo.UseVisualStyleBackColor = false;
            buttonMoreInfo.Click += buttonMoreInfo_Click;
            // 
            // listBoxViewReviews
            // 
            listBoxViewReviews.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            listBoxViewReviews.FormattingEnabled = true;
            listBoxViewReviews.ItemHeight = 23;
            listBoxViewReviews.Location = new Point(12, 47);
            listBoxViewReviews.Name = "listBoxViewReviews";
            listBoxViewReviews.Size = new Size(513, 418);
            listBoxViewReviews.TabIndex = 131;
            // 
            // buttonSearch
            // 
            buttonSearch.BackColor = Color.White;
            buttonSearch.FlatAppearance.BorderColor = Color.FromArgb(138, 104, 86);
            buttonSearch.FlatAppearance.BorderSize = 2;
            buttonSearch.FlatStyle = FlatStyle.Flat;
            buttonSearch.Font = new Font("MV Boli", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonSearch.ForeColor = Color.FromArgb(138, 104, 86);
            buttonSearch.Location = new Point(565, 172);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(263, 44);
            buttonSearch.TabIndex = 143;
            buttonSearch.Text = "Search";
            buttonSearch.UseVisualStyleBackColor = false;
            // 
            // lblSearchMovies
            // 
            lblSearchMovies.AutoSize = true;
            lblSearchMovies.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblSearchMovies.ForeColor = Color.FromArgb(138, 104, 86);
            lblSearchMovies.Location = new Point(565, 19);
            lblSearchMovies.Name = "lblSearchMovies";
            lblSearchMovies.Size = new Size(93, 25);
            lblSearchMovies.TabIndex = 136;
            lblSearchMovies.Text = "Search by:";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelName.ForeColor = Color.FromArgb(138, 104, 86);
            labelName.Location = new Point(565, 44);
            labelName.Name = "labelName";
            labelName.Size = new Size(185, 25);
            labelName.TabIndex = 135;
            labelName.Text = "Written by:(username)";
            labelName.Click += labelName_Click;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxUsername.ForeColor = Color.FromArgb(60, 144, 137);
            textBoxUsername.Location = new Point(565, 72);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(263, 31);
            textBoxUsername.TabIndex = 134;
            // 
            // btnView
            // 
            btnView.FlatAppearance.BorderSize = 0;
            btnView.FlatStyle = FlatStyle.Flat;
            btnView.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnView.ForeColor = Color.White;
            btnView.Location = new Point(0, -8);
            btnView.Name = "btnView";
            btnView.Size = new Size(870, 75);
            btnView.TabIndex = 10;
            btnView.Text = "View Reviews";
            btnView.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(145, 190, 222);
            panel1.Controls.Add(btnView);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(860, 67);
            panel1.TabIndex = 147;
            // 
            // ReviewMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(231, 223, 198);
            ClientSize = new Size(860, 602);
            Controls.Add(panelDesktop);
            Controls.Add(panel1);
            ForeColor = Color.FromArgb(138, 104, 86);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReviewMenu";
            Text = "ReviewMenu";
            panelDesktop.ResumeLayout(false);
            panelDesktop.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelDesktop;
        private Label lblWarning;
        private Button buttonMoreInfo;
        private ListBox listBoxViewReviews;
        private Button buttonSearch;
        private Label lblSearchMovies;
        private Label labelName;
        private TextBox textBoxUsername;
        private Button btnView;
        private Panel panel1;
        private Button btnDailyReviews;
        private DateTimePicker dateTimePicker1;
        private Label labelTitle;
        private TextBox textBoxTitle;
    }
}