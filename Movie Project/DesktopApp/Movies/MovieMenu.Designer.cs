namespace DesktopApp.Movies
{
    partial class MovieMenu
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
            panel1 = new Panel();
            btnView = new Button();
            btnAddMovie = new Button();
            labelOrder = new Label();
            comboBoxOrder = new ComboBox();
            lblWarning = new Label();
            lblSearchMovies = new Label();
            textBoxMovieName = new TextBox();
            labelName = new Label();
            listBoxViewMovies = new ListBox();
            buttonDelete = new Button();
            buttonUpdate = new Button();
            buttonMoreInfo = new Button();
            buttonSearch = new Button();
            panelDesktop = new Panel();
            panel1.SuspendLayout();
            panelDesktop.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(145, 190, 222);
            panel1.Controls.Add(btnView);
            panel1.Controls.Add(btnAddMovie);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(860, 67);
            panel1.TabIndex = 0;
            // 
            // btnView
            // 
            btnView.FlatAppearance.BorderSize = 0;
            btnView.FlatStyle = FlatStyle.Flat;
            btnView.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnView.ForeColor = Color.White;
            btnView.Location = new Point(433, 0);
            btnView.Name = "btnView";
            btnView.Size = new Size(427, 75);
            btnView.TabIndex = 10;
            btnView.Text = "View Movies";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
            // 
            // btnAddMovie
            // 
            btnAddMovie.FlatAppearance.BorderSize = 0;
            btnAddMovie.FlatStyle = FlatStyle.Flat;
            btnAddMovie.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddMovie.ForeColor = Color.White;
            btnAddMovie.Location = new Point(3, 0);
            btnAddMovie.Name = "btnAddMovie";
            btnAddMovie.Size = new Size(435, 75);
            btnAddMovie.TabIndex = 9;
            btnAddMovie.Text = "Add Movie";
            btnAddMovie.UseVisualStyleBackColor = true;
            btnAddMovie.Click += btnAddMovie_Click;
            // 
            // labelOrder
            // 
            labelOrder.AutoSize = true;
            labelOrder.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelOrder.ForeColor = Color.FromArgb(138, 104, 86);
            labelOrder.Location = new Point(546, 113);
            labelOrder.Name = "labelOrder";
            labelOrder.Size = new Size(85, 25);
            labelOrder.TabIndex = 69;
            labelOrder.Text = "Order by:";
            // 
            // comboBoxOrder
            // 
            comboBoxOrder.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxOrder.FormattingEnabled = true;
            comboBoxOrder.Location = new Point(546, 141);
            comboBoxOrder.Name = "comboBoxOrder";
            comboBoxOrder.Size = new Size(288, 33);
            comboBoxOrder.TabIndex = 68;
            // 
            // lblWarning
            // 
            lblWarning.AutoSize = true;
            lblWarning.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblWarning.ForeColor = Color.Maroon;
            lblWarning.Location = new Point(12, 86);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new Size(81, 25);
            lblWarning.TabIndex = 64;
            lblWarning.Text = "Warning";
            // 
            // lblSearchMovies
            // 
            lblSearchMovies.AutoSize = true;
            lblSearchMovies.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblSearchMovies.ForeColor = Color.FromArgb(138, 104, 86);
            lblSearchMovies.Location = new Point(546, 86);
            lblSearchMovies.Name = "lblSearchMovies";
            lblSearchMovies.Size = new Size(93, 25);
            lblSearchMovies.TabIndex = 63;
            lblSearchMovies.Text = "Search by:";
            // 
            // textBoxMovieName
            // 
            textBoxMovieName.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxMovieName.ForeColor = Color.FromArgb(60, 144, 137);
            textBoxMovieName.Location = new Point(546, 139);
            textBoxMovieName.Name = "textBoxMovieName";
            textBoxMovieName.Size = new Size(288, 31);
            textBoxMovieName.TabIndex = 61;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelName.ForeColor = Color.FromArgb(138, 104, 86);
            labelName.Location = new Point(546, 111);
            labelName.Name = "labelName";
            labelName.Size = new Size(50, 25);
            labelName.TabIndex = 62;
            labelName.Text = "Title:";
            // 
            // listBoxViewMovies
            // 
            listBoxViewMovies.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            listBoxViewMovies.FormattingEnabled = true;
            listBoxViewMovies.ItemHeight = 23;
            listBoxViewMovies.Location = new Point(12, 114);
            listBoxViewMovies.Name = "listBoxViewMovies";
            listBoxViewMovies.Size = new Size(508, 418);
            listBoxViewMovies.TabIndex = 58;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.White;
            buttonDelete.FlatAppearance.BorderColor = Color.FromArgb(138, 104, 86);
            buttonDelete.FlatAppearance.BorderSize = 2;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Font = new Font("MV Boli", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonDelete.ForeColor = Color.FromArgb(138, 104, 86);
            buttonDelete.Location = new Point(631, 481);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(203, 44);
            buttonDelete.TabIndex = 125;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.BackColor = Color.White;
            buttonUpdate.FlatAppearance.BorderColor = Color.FromArgb(138, 104, 86);
            buttonUpdate.FlatAppearance.BorderSize = 2;
            buttonUpdate.FlatStyle = FlatStyle.Flat;
            buttonUpdate.Font = new Font("MV Boli", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonUpdate.ForeColor = Color.FromArgb(138, 104, 86);
            buttonUpdate.Location = new Point(306, 481);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(203, 44);
            buttonUpdate.TabIndex = 126;
            buttonUpdate.Text = "Update";
            buttonUpdate.UseVisualStyleBackColor = false;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // buttonMoreInfo
            // 
            buttonMoreInfo.BackColor = Color.White;
            buttonMoreInfo.FlatAppearance.BorderColor = Color.FromArgb(138, 104, 86);
            buttonMoreInfo.FlatAppearance.BorderSize = 2;
            buttonMoreInfo.FlatStyle = FlatStyle.Flat;
            buttonMoreInfo.Font = new Font("MV Boli", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonMoreInfo.ForeColor = Color.FromArgb(138, 104, 86);
            buttonMoreInfo.Location = new Point(12, 481);
            buttonMoreInfo.Name = "buttonMoreInfo";
            buttonMoreInfo.Size = new Size(203, 44);
            buttonMoreInfo.TabIndex = 127;
            buttonMoreInfo.Text = "More Info";
            buttonMoreInfo.UseVisualStyleBackColor = false;
            buttonMoreInfo.Click += buttonMoreInfo_Click;
            // 
            // buttonSearch
            // 
            buttonSearch.BackColor = Color.White;
            buttonSearch.FlatAppearance.BorderColor = Color.FromArgb(138, 104, 86);
            buttonSearch.FlatAppearance.BorderSize = 2;
            buttonSearch.FlatStyle = FlatStyle.Flat;
            buttonSearch.Font = new Font("MV Boli", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonSearch.ForeColor = Color.FromArgb(138, 104, 86);
            buttonSearch.Location = new Point(546, 198);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(288, 44);
            buttonSearch.TabIndex = 128;
            buttonSearch.Text = "Search";
            buttonSearch.UseVisualStyleBackColor = false;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // panelDesktop
            // 
            panelDesktop.BackColor = Color.FromArgb(231, 223, 198);
            panelDesktop.Controls.Add(buttonSearch);
            panelDesktop.Controls.Add(buttonDelete);
            panelDesktop.Controls.Add(labelOrder);
            panelDesktop.Controls.Add(buttonMoreInfo);
            panelDesktop.Controls.Add(comboBoxOrder);
            panelDesktop.Controls.Add(buttonUpdate);
            panelDesktop.Dock = DockStyle.Bottom;
            panelDesktop.Location = new Point(0, 68);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new Size(860, 534);
            panelDesktop.TabIndex = 129;
            // 
            // MovieMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(231, 223, 198);
            ClientSize = new Size(860, 602);
            Controls.Add(lblWarning);
            Controls.Add(lblSearchMovies);
            Controls.Add(textBoxMovieName);
            Controls.Add(labelName);
            Controls.Add(listBoxViewMovies);
            Controls.Add(panel1);
            Controls.Add(panelDesktop);
            ForeColor = Color.FromArgb(138, 104, 86);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MovieMenu";
            Text = "MovieMenu";
            panel1.ResumeLayout(false);
            panelDesktop.ResumeLayout(false);
            panelDesktop.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btnAddMovie;
        private Button btnView;
        private Label labelOrder;
        private ComboBox comboBoxOrder;
        private Label lblWarning;
        private Label lblSearchMovies;
        private TextBox textBoxMovieName;
        private Label labelName;
        private ListBox listBoxViewMovies;
        private Button buttonDelete;
        private Button buttonUpdate;
        private Button buttonMoreInfo;
        private Button buttonSearch;
        private Panel panelDesktop;
    }
}