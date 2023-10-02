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
            btnAddMovie = new Button();
            btnView = new Button();
            labelOrder = new Label();
            comboBoxOrder = new ComboBox();
            lblWarning = new Label();
            lblSearchMovies = new Label();
            textBoxMoviesTitle = new TextBox();
            labelMoviesTitle = new Label();
            textBoxMoviesID = new TextBox();
            labelBooksID = new Label();
            listBoxViewMovies = new ListBox();
            buttonDelete = new Button();
            buttonUpdate = new Button();
            buttonMoreInfo = new Button();
            buttonSearch = new Button();
            panel1.SuspendLayout();
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
            panel1.Size = new Size(834, 67);
            panel1.TabIndex = 0;
            // 
            // btnAddMovie
            // 
            btnAddMovie.FlatAppearance.BorderSize = 0;
            btnAddMovie.FlatStyle = FlatStyle.Flat;
            btnAddMovie.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddMovie.ForeColor = Color.White;
            btnAddMovie.Location = new Point(3, 0);
            btnAddMovie.Name = "btnAddMovie";
            btnAddMovie.Size = new Size(424, 75);
            btnAddMovie.TabIndex = 9;
            btnAddMovie.Text = "Add Movie";
            btnAddMovie.UseVisualStyleBackColor = true;
            // 
            // btnView
            // 
            btnView.FlatAppearance.BorderSize = 0;
            btnView.FlatStyle = FlatStyle.Flat;
            btnView.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnView.ForeColor = Color.White;
            btnView.Location = new Point(409, 0);
            btnView.Name = "btnView";
            btnView.Size = new Size(425, 75);
            btnView.TabIndex = 10;
            btnView.Text = "View Movies";
            btnView.UseVisualStyleBackColor = true;
            // 
            // labelOrder
            // 
            labelOrder.AutoSize = true;
            labelOrder.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelOrder.ForeColor = Color.FromArgb(138, 104, 86);
            labelOrder.Location = new Point(546, 240);
            labelOrder.Name = "labelOrder";
            labelOrder.Size = new Size(61, 25);
            labelOrder.TabIndex = 69;
            labelOrder.Text = "Order:";
            // 
            // comboBoxOrder
            // 
            comboBoxOrder.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxOrder.FormattingEnabled = true;
            comboBoxOrder.Location = new Point(546, 268);
            comboBoxOrder.Name = "comboBoxOrder";
            comboBoxOrder.Size = new Size(263, 33);
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
            // textBoxMoviesTitle
            // 
            textBoxMoviesTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxMoviesTitle.ForeColor = Color.FromArgb(60, 144, 137);
            textBoxMoviesTitle.Location = new Point(546, 139);
            textBoxMoviesTitle.Name = "textBoxMoviesTitle";
            textBoxMoviesTitle.Size = new Size(263, 31);
            textBoxMoviesTitle.TabIndex = 61;
            // 
            // labelMoviesTitle
            // 
            labelMoviesTitle.AutoSize = true;
            labelMoviesTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelMoviesTitle.ForeColor = Color.FromArgb(138, 104, 86);
            labelMoviesTitle.Location = new Point(546, 111);
            labelMoviesTitle.Name = "labelMoviesTitle";
            labelMoviesTitle.Size = new Size(50, 25);
            labelMoviesTitle.TabIndex = 62;
            labelMoviesTitle.Text = "Title:";
            // 
            // textBoxMoviesID
            // 
            textBoxMoviesID.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxMoviesID.ForeColor = Color.FromArgb(60, 144, 137);
            textBoxMoviesID.Location = new Point(546, 201);
            textBoxMoviesID.Name = "textBoxMoviesID";
            textBoxMoviesID.Size = new Size(263, 31);
            textBoxMoviesID.TabIndex = 59;
            // 
            // labelBooksID
            // 
            labelBooksID.AutoSize = true;
            labelBooksID.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelBooksID.ForeColor = Color.FromArgb(138, 104, 86);
            labelBooksID.Location = new Point(546, 173);
            labelBooksID.Name = "labelBooksID";
            labelBooksID.Size = new Size(34, 25);
            labelBooksID.TabIndex = 60;
            labelBooksID.Text = "ID:";
            // 
            // listBoxViewMovies
            // 
            listBoxViewMovies.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            listBoxViewMovies.FormattingEnabled = true;
            listBoxViewMovies.ItemHeight = 23;
            listBoxViewMovies.Location = new Point(12, 114);
            listBoxViewMovies.Name = "listBoxViewMovies";
            listBoxViewMovies.Size = new Size(497, 395);
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
            buttonDelete.Location = new Point(606, 527);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(203, 44);
            buttonDelete.TabIndex = 125;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = false;
            // 
            // buttonUpdate
            // 
            buttonUpdate.BackColor = Color.White;
            buttonUpdate.FlatAppearance.BorderColor = Color.FromArgb(138, 104, 86);
            buttonUpdate.FlatAppearance.BorderSize = 2;
            buttonUpdate.FlatStyle = FlatStyle.Flat;
            buttonUpdate.Font = new Font("MV Boli", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonUpdate.ForeColor = Color.FromArgb(138, 104, 86);
            buttonUpdate.Location = new Point(306, 527);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(203, 44);
            buttonUpdate.TabIndex = 126;
            buttonUpdate.Text = "Update";
            buttonUpdate.UseVisualStyleBackColor = false;
            // 
            // buttonMoreInfo
            // 
            buttonMoreInfo.BackColor = Color.White;
            buttonMoreInfo.FlatAppearance.BorderColor = Color.FromArgb(138, 104, 86);
            buttonMoreInfo.FlatAppearance.BorderSize = 2;
            buttonMoreInfo.FlatStyle = FlatStyle.Flat;
            buttonMoreInfo.Font = new Font("MV Boli", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonMoreInfo.ForeColor = Color.FromArgb(138, 104, 86);
            buttonMoreInfo.Location = new Point(12, 527);
            buttonMoreInfo.Name = "buttonMoreInfo";
            buttonMoreInfo.Size = new Size(203, 44);
            buttonMoreInfo.TabIndex = 127;
            buttonMoreInfo.Text = "More Info";
            buttonMoreInfo.UseVisualStyleBackColor = false;
            // 
            // buttonSearch
            // 
            buttonSearch.BackColor = Color.White;
            buttonSearch.FlatAppearance.BorderColor = Color.FromArgb(138, 104, 86);
            buttonSearch.FlatAppearance.BorderSize = 2;
            buttonSearch.FlatStyle = FlatStyle.Flat;
            buttonSearch.Font = new Font("MV Boli", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonSearch.ForeColor = Color.FromArgb(138, 104, 86);
            buttonSearch.Location = new Point(546, 325);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(263, 44);
            buttonSearch.TabIndex = 128;
            buttonSearch.Text = "Search";
            buttonSearch.UseVisualStyleBackColor = false;
            // 
            // MovieMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(231, 223, 198);
            ClientSize = new Size(834, 583);
            Controls.Add(buttonSearch);
            Controls.Add(buttonMoreInfo);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonDelete);
            Controls.Add(labelOrder);
            Controls.Add(comboBoxOrder);
            Controls.Add(lblWarning);
            Controls.Add(lblSearchMovies);
            Controls.Add(textBoxMoviesTitle);
            Controls.Add(labelMoviesTitle);
            Controls.Add(textBoxMoviesID);
            Controls.Add(labelBooksID);
            Controls.Add(listBoxViewMovies);
            Controls.Add(panel1);
            ForeColor = Color.FromArgb(138, 104, 86);
            Name = "MovieMenu";
            Text = "MovieMenu";
            panel1.ResumeLayout(false);
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
        private TextBox textBoxMoviesTitle;
        private Label labelMoviesTitle;
        private TextBox textBoxMoviesID;
        private Label labelBooksID;
        private ListBox listBoxViewMovies;
        private Button buttonDelete;
        private Button buttonUpdate;
        private Button buttonMoreInfo;
        private Button buttonSearch;
    }
}