namespace DesktopApp.Movies
{
    partial class AddMovie
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
            lblFormTitle = new Label();
            textBoxCast = new TextBox();
            lblMovieCast = new Label();
            textBoxMovieWriter = new TextBox();
            lblMovieWriter = new Label();
            textBoxMovieDirector = new TextBox();
            richTextBoxDescription = new RichTextBox();
            textBoxMovieTitle = new TextBox();
            labelDirector = new Label();
            labelMovie = new Label();
            labelMovieDescription = new Label();
            textBMovieCountryOfOrigin = new TextBox();
            lblMovieCountryOfOrigin = new Label();
            textBoxMovieRating = new TextBox();
            labelMovieRating = new Label();
            dateTimeMoviePublishment = new DateTimePicker();
            labelMoviePublishment = new Label();
            textBoxMovieDuration = new TextBox();
            labelMovieDuration = new Label();
            btnAddCast = new Button();
            checkedLBGenres = new CheckedListBox();
            labelMovieGenre = new Label();
            btnImageUpload = new Button();
            pictureBoxMoviePic = new PictureBox();
            buttonAddMovie = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMoviePic).BeginInit();
            SuspendLayout();
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Sans Serif Collection", 11.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblFormTitle.ForeColor = Color.FromArgb(138, 104, 86);
            lblFormTitle.Location = new Point(0, -1);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(203, 49);
            lblFormTitle.TabIndex = 9;
            lblFormTitle.Text = "Add a movie";
            // 
            // textBoxCast
            // 
            textBoxCast.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxCast.ForeColor = Color.FromArgb(60, 144, 137);
            textBoxCast.Location = new Point(12, 440);
            textBoxCast.Name = "textBoxCast";
            textBoxCast.Size = new Size(500, 31);
            textBoxCast.TabIndex = 85;
            // 
            // lblMovieCast
            // 
            lblMovieCast.AutoSize = true;
            lblMovieCast.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            lblMovieCast.Location = new Point(12, 416);
            lblMovieCast.Name = "lblMovieCast";
            lblMovieCast.Size = new Size(182, 25);
            lblMovieCast.TabIndex = 84;
            lblMovieCast.Text = "Cast (add separately):";
            // 
            // textBoxMovieWriter
            // 
            textBoxMovieWriter.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxMovieWriter.ForeColor = Color.FromArgb(60, 144, 137);
            textBoxMovieWriter.Location = new Point(12, 382);
            textBoxMovieWriter.Name = "textBoxMovieWriter";
            textBoxMovieWriter.Size = new Size(582, 31);
            textBoxMovieWriter.TabIndex = 83;
            // 
            // lblMovieWriter
            // 
            lblMovieWriter.AutoSize = true;
            lblMovieWriter.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            lblMovieWriter.Location = new Point(12, 353);
            lblMovieWriter.Name = "lblMovieWriter";
            lblMovieWriter.Size = new Size(82, 25);
            lblMovieWriter.TabIndex = 82;
            lblMovieWriter.Text = "Writer(s):";
            // 
            // textBoxMovieDirector
            // 
            textBoxMovieDirector.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxMovieDirector.ForeColor = Color.FromArgb(60, 144, 137);
            textBoxMovieDirector.Location = new Point(12, 322);
            textBoxMovieDirector.Name = "textBoxMovieDirector";
            textBoxMovieDirector.Size = new Size(582, 31);
            textBoxMovieDirector.TabIndex = 81;
            // 
            // richTextBoxDescription
            // 
            richTextBoxDescription.Location = new Point(12, 130);
            richTextBoxDescription.Name = "richTextBoxDescription";
            richTextBoxDescription.Size = new Size(582, 163);
            richTextBoxDescription.TabIndex = 80;
            richTextBoxDescription.Text = "";
            // 
            // textBoxMovieTitle
            // 
            textBoxMovieTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxMovieTitle.ForeColor = Color.FromArgb(60, 144, 137);
            textBoxMovieTitle.Location = new Point(12, 70);
            textBoxMovieTitle.Name = "textBoxMovieTitle";
            textBoxMovieTitle.Size = new Size(582, 31);
            textBoxMovieTitle.TabIndex = 77;
            // 
            // labelDirector
            // 
            labelDirector.AutoSize = true;
            labelDirector.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelDirector.Location = new Point(12, 293);
            labelDirector.Name = "labelDirector";
            labelDirector.Size = new Size(96, 25);
            labelDirector.TabIndex = 79;
            labelDirector.Text = "Director(s):";
            // 
            // labelMovie
            // 
            labelMovie.AutoSize = true;
            labelMovie.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelMovie.Location = new Point(12, 42);
            labelMovie.Name = "labelMovie";
            labelMovie.Size = new Size(50, 25);
            labelMovie.TabIndex = 78;
            labelMovie.Text = "Title:";
            // 
            // labelMovieDescription
            // 
            labelMovieDescription.AutoSize = true;
            labelMovieDescription.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelMovieDescription.Location = new Point(12, 102);
            labelMovieDescription.Name = "labelMovieDescription";
            labelMovieDescription.Size = new Size(105, 25);
            labelMovieDescription.TabIndex = 76;
            labelMovieDescription.Text = "Description:";
            // 
            // textBMovieCountryOfOrigin
            // 
            textBMovieCountryOfOrigin.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBMovieCountryOfOrigin.ForeColor = Color.FromArgb(60, 144, 137);
            textBMovieCountryOfOrigin.Location = new Point(12, 502);
            textBMovieCountryOfOrigin.Name = "textBMovieCountryOfOrigin";
            textBMovieCountryOfOrigin.Size = new Size(582, 31);
            textBMovieCountryOfOrigin.TabIndex = 92;
            // 
            // lblMovieCountryOfOrigin
            // 
            lblMovieCountryOfOrigin.AutoSize = true;
            lblMovieCountryOfOrigin.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            lblMovieCountryOfOrigin.ForeColor = Color.FromArgb(138, 104, 86);
            lblMovieCountryOfOrigin.Location = new Point(12, 474);
            lblMovieCountryOfOrigin.Name = "lblMovieCountryOfOrigin";
            lblMovieCountryOfOrigin.Size = new Size(150, 25);
            lblMovieCountryOfOrigin.TabIndex = 93;
            lblMovieCountryOfOrigin.Text = "Country of origin:";
            // 
            // textBoxMovieRating
            // 
            textBoxMovieRating.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxMovieRating.ForeColor = Color.FromArgb(60, 144, 137);
            textBoxMovieRating.Location = new Point(619, 96);
            textBoxMovieRating.Name = "textBoxMovieRating";
            textBoxMovieRating.Size = new Size(203, 31);
            textBoxMovieRating.TabIndex = 90;
            // 
            // labelMovieRating
            // 
            labelMovieRating.AutoSize = true;
            labelMovieRating.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelMovieRating.ForeColor = Color.FromArgb(138, 104, 86);
            labelMovieRating.Location = new Point(619, 68);
            labelMovieRating.Name = "labelMovieRating";
            labelMovieRating.Size = new Size(127, 25);
            labelMovieRating.TabIndex = 91;
            labelMovieRating.Text = "Current rating:";
            // 
            // dateTimeMoviePublishment
            // 
            dateTimeMoviePublishment.CalendarFont = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimeMoviePublishment.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimeMoviePublishment.Location = new Point(619, 34);
            dateTimeMoviePublishment.Name = "dateTimeMoviePublishment";
            dateTimeMoviePublishment.Size = new Size(203, 31);
            dateTimeMoviePublishment.TabIndex = 89;
            // 
            // labelMoviePublishment
            // 
            labelMoviePublishment.AutoSize = true;
            labelMoviePublishment.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelMoviePublishment.ForeColor = Color.FromArgb(138, 104, 86);
            labelMoviePublishment.Location = new Point(619, 6);
            labelMoviePublishment.Name = "labelMoviePublishment";
            labelMoviePublishment.Size = new Size(115, 25);
            labelMoviePublishment.TabIndex = 88;
            labelMoviePublishment.Text = "Release date:";
            // 
            // textBoxMovieDuration
            // 
            textBoxMovieDuration.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxMovieDuration.ForeColor = Color.FromArgb(60, 144, 137);
            textBoxMovieDuration.Location = new Point(190, 540);
            textBoxMovieDuration.Name = "textBoxMovieDuration";
            textBoxMovieDuration.Size = new Size(203, 31);
            textBoxMovieDuration.TabIndex = 86;
            // 
            // labelMovieDuration
            // 
            labelMovieDuration.AutoSize = true;
            labelMovieDuration.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelMovieDuration.ForeColor = Color.FromArgb(138, 104, 86);
            labelMovieDuration.Location = new Point(12, 540);
            labelMovieDuration.Name = "labelMovieDuration";
            labelMovieDuration.Size = new Size(163, 25);
            labelMovieDuration.TabIndex = 87;
            labelMovieDuration.Text = "Duration (minutes):";
            // 
            // btnAddCast
            // 
            btnAddCast.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btnAddCast.Location = new Point(518, 440);
            btnAddCast.Name = "btnAddCast";
            btnAddCast.Size = new Size(76, 31);
            btnAddCast.TabIndex = 94;
            btnAddCast.Text = "Add";
            btnAddCast.UseVisualStyleBackColor = true;
            // 
            // checkedLBGenres
            // 
            checkedLBGenres.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            checkedLBGenres.FormattingEnabled = true;
            checkedLBGenres.Location = new Point(619, 158);
            checkedLBGenres.Name = "checkedLBGenres";
            checkedLBGenres.Size = new Size(203, 160);
            checkedLBGenres.TabIndex = 96;
            // 
            // labelMovieGenre
            // 
            labelMovieGenre.AutoSize = true;
            labelMovieGenre.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelMovieGenre.ForeColor = Color.FromArgb(138, 104, 86);
            labelMovieGenre.Location = new Point(619, 130);
            labelMovieGenre.Name = "labelMovieGenre";
            labelMovieGenre.Size = new Size(62, 25);
            labelMovieGenre.TabIndex = 95;
            labelMovieGenre.Text = "Genre:";
            // 
            // btnImageUpload
            // 
            btnImageUpload.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btnImageUpload.ForeColor = Color.FromArgb(138, 104, 86);
            btnImageUpload.Location = new Point(619, 324);
            btnImageUpload.Name = "btnImageUpload";
            btnImageUpload.Size = new Size(203, 31);
            btnImageUpload.TabIndex = 98;
            btnImageUpload.Text = "Upload Image";
            btnImageUpload.UseVisualStyleBackColor = true;
            // 
            // pictureBoxMoviePic
            // 
            pictureBoxMoviePic.Location = new Point(662, 361);
            pictureBoxMoviePic.Name = "pictureBoxMoviePic";
            pictureBoxMoviePic.Size = new Size(117, 157);
            pictureBoxMoviePic.TabIndex = 97;
            pictureBoxMoviePic.TabStop = false;
            // 
            // buttonAddMovie
            // 
            buttonAddMovie.BackColor = Color.White;
            buttonAddMovie.FlatAppearance.BorderColor = Color.FromArgb(138, 104, 86);
            buttonAddMovie.FlatAppearance.BorderSize = 2;
            buttonAddMovie.FlatStyle = FlatStyle.Flat;
            buttonAddMovie.Font = new Font("MV Boli", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonAddMovie.ForeColor = Color.FromArgb(138, 104, 86);
            buttonAddMovie.Location = new Point(619, 529);
            buttonAddMovie.Name = "buttonAddMovie";
            buttonAddMovie.Size = new Size(203, 44);
            buttonAddMovie.TabIndex = 99;
            buttonAddMovie.Text = "Add";
            buttonAddMovie.UseVisualStyleBackColor = false;
            // 
            // AddMovie
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(231, 223, 198);
            ClientSize = new Size(834, 583);
            Controls.Add(buttonAddMovie);
            Controls.Add(btnImageUpload);
            Controls.Add(pictureBoxMoviePic);
            Controls.Add(checkedLBGenres);
            Controls.Add(labelMovieGenre);
            Controls.Add(btnAddCast);
            Controls.Add(textBMovieCountryOfOrigin);
            Controls.Add(lblMovieCountryOfOrigin);
            Controls.Add(textBoxMovieRating);
            Controls.Add(labelMovieRating);
            Controls.Add(dateTimeMoviePublishment);
            Controls.Add(labelMoviePublishment);
            Controls.Add(textBoxMovieDuration);
            Controls.Add(labelMovieDuration);
            Controls.Add(textBoxCast);
            Controls.Add(lblMovieCast);
            Controls.Add(textBoxMovieWriter);
            Controls.Add(lblMovieWriter);
            Controls.Add(textBoxMovieDirector);
            Controls.Add(richTextBoxDescription);
            Controls.Add(textBoxMovieTitle);
            Controls.Add(labelDirector);
            Controls.Add(labelMovie);
            Controls.Add(labelMovieDescription);
            Controls.Add(lblFormTitle);
            ForeColor = Color.FromArgb(138, 104, 86);
            Name = "AddMovie";
            Text = "AddMovie";
            Load += AddMovie_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxMoviePic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFormTitle;
        private TextBox textBoxCast;
        private Label lblMovieCast;
        private TextBox textBoxMovieWriter;
        private Label lblMovieWriter;
        private TextBox textBoxMovieDirector;
        private RichTextBox richTextBoxDescription;
        private TextBox textBoxMovieTitle;
        private Label labelDirector;
        private Label labelMovie;
        private Label labelMovieDescription;
        private TextBox textBMovieCountryOfOrigin;
        private Label lblMovieCountryOfOrigin;
        private TextBox textBoxMovieRating;
        private Label labelMovieRating;
        private DateTimePicker dateTimeMoviePublishment;
        private Label labelMoviePublishment;
        private TextBox textBoxMovieDuration;
        private Label labelMovieDuration;
        private Button btnAddCast;
        private CheckedListBox checkedLBGenres;
        private Label labelMovieGenre;
        private Button btnImageUpload;
        private PictureBox pictureBoxMoviePic;
        private Button buttonAddMovie;
    }
}