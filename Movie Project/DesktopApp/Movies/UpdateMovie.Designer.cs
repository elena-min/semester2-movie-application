namespace DesktopApp.Movies
{
    partial class UpdateMovie
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
            lblWarning = new Label();
            buttonUpdateMovie = new Button();
            btnImageUpload = new Button();
            pictureBoxMoviePic = new PictureBox();
            checkedLBGenres = new CheckedListBox();
            labelMovieGenre = new Label();
            textBMovieCountryOfOrigin = new TextBox();
            lblMovieCountryOfOrigin = new Label();
            textBoxMovieRating = new TextBox();
            labelMovieRating = new Label();
            dateTimeMoviePublishment = new DateTimePicker();
            labelMoviePublishment = new Label();
            textBoxMovieDuration = new TextBox();
            labelMovieDuration = new Label();
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
            btnRemoveImage = new Button();
            labelMovieId = new Label();
            lblMovieID = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMoviePic).BeginInit();
            SuspendLayout();
            // 
            // lblWarning
            // 
            lblWarning.AutoSize = true;
            lblWarning.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblWarning.ForeColor = Color.Maroon;
            lblWarning.Location = new Point(12, 7);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new Size(81, 25);
            lblWarning.TabIndex = 125;
            lblWarning.Text = "Warning";
            // 
            // buttonUpdateMovie
            // 
            buttonUpdateMovie.BackColor = Color.White;
            buttonUpdateMovie.FlatAppearance.BorderColor = Color.FromArgb(138, 104, 86);
            buttonUpdateMovie.FlatAppearance.BorderSize = 2;
            buttonUpdateMovie.FlatStyle = FlatStyle.Flat;
            buttonUpdateMovie.Font = new Font("MV Boli", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonUpdateMovie.ForeColor = Color.FromArgb(138, 104, 86);
            buttonUpdateMovie.Location = new Point(621, 574);
            buttonUpdateMovie.Name = "buttonUpdateMovie";
            buttonUpdateMovie.Size = new Size(203, 44);
            buttonUpdateMovie.TabIndex = 124;
            buttonUpdateMovie.Text = "Update";
            buttonUpdateMovie.UseVisualStyleBackColor = false;
            buttonUpdateMovie.Click += buttonUpdateMovie_Click;
            // 
            // btnImageUpload
            // 
            btnImageUpload.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btnImageUpload.ForeColor = Color.FromArgb(138, 104, 86);
            btnImageUpload.Location = new Point(621, 289);
            btnImageUpload.Name = "btnImageUpload";
            btnImageUpload.Size = new Size(203, 31);
            btnImageUpload.TabIndex = 123;
            btnImageUpload.Text = "Upload Image";
            btnImageUpload.UseVisualStyleBackColor = true;
            btnImageUpload.Click += btnImageUpload_Click;
            // 
            // pictureBoxMoviePic
            // 
            pictureBoxMoviePic.Location = new Point(651, 366);
            pictureBoxMoviePic.Name = "pictureBoxMoviePic";
            pictureBoxMoviePic.Size = new Size(148, 191);
            pictureBoxMoviePic.TabIndex = 122;
            pictureBoxMoviePic.TabStop = false;
            // 
            // checkedLBGenres
            // 
            checkedLBGenres.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            checkedLBGenres.FormattingEnabled = true;
            checkedLBGenres.Location = new Point(621, 123);
            checkedLBGenres.Name = "checkedLBGenres";
            checkedLBGenres.Size = new Size(203, 160);
            checkedLBGenres.TabIndex = 121;
            // 
            // labelMovieGenre
            // 
            labelMovieGenre.AutoSize = true;
            labelMovieGenre.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelMovieGenre.ForeColor = Color.FromArgb(138, 104, 86);
            labelMovieGenre.Location = new Point(621, 95);
            labelMovieGenre.Name = "labelMovieGenre";
            labelMovieGenre.Size = new Size(62, 25);
            labelMovieGenre.TabIndex = 120;
            labelMovieGenre.Text = "Genre:";
            // 
            // textBMovieCountryOfOrigin
            // 
            textBMovieCountryOfOrigin.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBMovieCountryOfOrigin.ForeColor = Color.Black;
            textBMovieCountryOfOrigin.Location = new Point(12, 492);
            textBMovieCountryOfOrigin.Name = "textBMovieCountryOfOrigin";
            textBMovieCountryOfOrigin.Size = new Size(582, 31);
            textBMovieCountryOfOrigin.TabIndex = 118;
            // 
            // lblMovieCountryOfOrigin
            // 
            lblMovieCountryOfOrigin.AutoSize = true;
            lblMovieCountryOfOrigin.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            lblMovieCountryOfOrigin.ForeColor = Color.FromArgb(138, 104, 86);
            lblMovieCountryOfOrigin.Location = new Point(12, 464);
            lblMovieCountryOfOrigin.Name = "lblMovieCountryOfOrigin";
            lblMovieCountryOfOrigin.Size = new Size(150, 25);
            lblMovieCountryOfOrigin.TabIndex = 119;
            lblMovieCountryOfOrigin.Text = "Country of origin:";
            // 
            // textBoxMovieRating
            // 
            textBoxMovieRating.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxMovieRating.ForeColor = Color.Black;
            textBoxMovieRating.Location = new Point(621, 61);
            textBoxMovieRating.Name = "textBoxMovieRating";
            textBoxMovieRating.Size = new Size(203, 31);
            textBoxMovieRating.TabIndex = 116;
            // 
            // labelMovieRating
            // 
            labelMovieRating.AutoSize = true;
            labelMovieRating.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelMovieRating.ForeColor = Color.FromArgb(138, 104, 86);
            labelMovieRating.Location = new Point(621, 33);
            labelMovieRating.Name = "labelMovieRating";
            labelMovieRating.Size = new Size(127, 25);
            labelMovieRating.TabIndex = 117;
            labelMovieRating.Text = "Current rating:";
            // 
            // dateTimeMoviePublishment
            // 
            dateTimeMoviePublishment.CalendarFont = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimeMoviePublishment.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimeMoviePublishment.Location = new Point(190, 573);
            dateTimeMoviePublishment.Name = "dateTimeMoviePublishment";
            dateTimeMoviePublishment.Size = new Size(203, 31);
            dateTimeMoviePublishment.TabIndex = 115;
            // 
            // labelMoviePublishment
            // 
            labelMoviePublishment.AutoSize = true;
            labelMoviePublishment.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelMoviePublishment.ForeColor = Color.FromArgb(138, 104, 86);
            labelMoviePublishment.Location = new Point(12, 573);
            labelMoviePublishment.Name = "labelMoviePublishment";
            labelMoviePublishment.Size = new Size(115, 25);
            labelMoviePublishment.TabIndex = 114;
            labelMoviePublishment.Text = "Release date:";
            // 
            // textBoxMovieDuration
            // 
            textBoxMovieDuration.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxMovieDuration.ForeColor = Color.Black;
            textBoxMovieDuration.Location = new Point(190, 530);
            textBoxMovieDuration.Name = "textBoxMovieDuration";
            textBoxMovieDuration.Size = new Size(203, 31);
            textBoxMovieDuration.TabIndex = 112;
            // 
            // labelMovieDuration
            // 
            labelMovieDuration.AutoSize = true;
            labelMovieDuration.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelMovieDuration.ForeColor = Color.FromArgb(138, 104, 86);
            labelMovieDuration.Location = new Point(12, 530);
            labelMovieDuration.Name = "labelMovieDuration";
            labelMovieDuration.Size = new Size(163, 25);
            labelMovieDuration.TabIndex = 113;
            labelMovieDuration.Text = "Duration (minutes):";
            // 
            // textBoxCast
            // 
            textBoxCast.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxCast.ForeColor = Color.Black;
            textBoxCast.Location = new Point(12, 430);
            textBoxCast.Name = "textBoxCast";
            textBoxCast.Size = new Size(582, 31);
            textBoxCast.TabIndex = 111;
            // 
            // lblMovieCast
            // 
            lblMovieCast.AutoSize = true;
            lblMovieCast.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            lblMovieCast.Location = new Point(12, 406);
            lblMovieCast.Name = "lblMovieCast";
            lblMovieCast.Size = new Size(241, 25);
            lblMovieCast.TabIndex = 110;
            lblMovieCast.Text = "Cast (seperate with commas):";
            // 
            // textBoxMovieWriter
            // 
            textBoxMovieWriter.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxMovieWriter.ForeColor = Color.Black;
            textBoxMovieWriter.Location = new Point(12, 372);
            textBoxMovieWriter.Name = "textBoxMovieWriter";
            textBoxMovieWriter.Size = new Size(582, 31);
            textBoxMovieWriter.TabIndex = 109;
            // 
            // lblMovieWriter
            // 
            lblMovieWriter.AutoSize = true;
            lblMovieWriter.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            lblMovieWriter.Location = new Point(12, 343);
            lblMovieWriter.Name = "lblMovieWriter";
            lblMovieWriter.Size = new Size(82, 25);
            lblMovieWriter.TabIndex = 108;
            lblMovieWriter.Text = "Writer(s):";
            // 
            // textBoxMovieDirector
            // 
            textBoxMovieDirector.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxMovieDirector.ForeColor = Color.Black;
            textBoxMovieDirector.Location = new Point(12, 312);
            textBoxMovieDirector.Name = "textBoxMovieDirector";
            textBoxMovieDirector.Size = new Size(582, 31);
            textBoxMovieDirector.TabIndex = 107;
            // 
            // richTextBoxDescription
            // 
            richTextBoxDescription.ForeColor = Color.Black;
            richTextBoxDescription.Location = new Point(12, 120);
            richTextBoxDescription.Name = "richTextBoxDescription";
            richTextBoxDescription.Size = new Size(582, 163);
            richTextBoxDescription.TabIndex = 106;
            richTextBoxDescription.Text = "";
            // 
            // textBoxMovieTitle
            // 
            textBoxMovieTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxMovieTitle.ForeColor = Color.Black;
            textBoxMovieTitle.Location = new Point(12, 60);
            textBoxMovieTitle.Name = "textBoxMovieTitle";
            textBoxMovieTitle.Size = new Size(582, 31);
            textBoxMovieTitle.TabIndex = 103;
            // 
            // labelDirector
            // 
            labelDirector.AutoSize = true;
            labelDirector.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelDirector.Location = new Point(12, 283);
            labelDirector.Name = "labelDirector";
            labelDirector.Size = new Size(96, 25);
            labelDirector.TabIndex = 105;
            labelDirector.Text = "Director(s):";
            // 
            // labelMovie
            // 
            labelMovie.AutoSize = true;
            labelMovie.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelMovie.Location = new Point(12, 32);
            labelMovie.Name = "labelMovie";
            labelMovie.Size = new Size(50, 25);
            labelMovie.TabIndex = 104;
            labelMovie.Text = "Title:";
            // 
            // labelMovieDescription
            // 
            labelMovieDescription.AutoSize = true;
            labelMovieDescription.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelMovieDescription.Location = new Point(12, 92);
            labelMovieDescription.Name = "labelMovieDescription";
            labelMovieDescription.Size = new Size(105, 25);
            labelMovieDescription.TabIndex = 102;
            labelMovieDescription.Text = "Description:";
            // 
            // btnRemoveImage
            // 
            btnRemoveImage.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btnRemoveImage.ForeColor = Color.FromArgb(138, 104, 86);
            btnRemoveImage.Location = new Point(621, 324);
            btnRemoveImage.Name = "btnRemoveImage";
            btnRemoveImage.Size = new Size(203, 36);
            btnRemoveImage.TabIndex = 126;
            btnRemoveImage.Text = "Remove current image";
            btnRemoveImage.UseVisualStyleBackColor = true;
            btnRemoveImage.Click += btnRemoveImage_Click;
            // 
            // labelMovieId
            // 
            labelMovieId.AutoSize = true;
            labelMovieId.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            labelMovieId.ForeColor = Color.FromArgb(138, 104, 86);
            labelMovieId.Location = new Point(564, 536);
            labelMovieId.Name = "labelMovieId";
            labelMovieId.Size = new Size(30, 25);
            labelMovieId.TabIndex = 128;
            labelMovieId.Text = "ID";
            // 
            // lblMovieID
            // 
            lblMovieID.AutoSize = true;
            lblMovieID.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            lblMovieID.ForeColor = Color.FromArgb(138, 104, 86);
            lblMovieID.Location = new Point(524, 536);
            lblMovieID.Name = "lblMovieID";
            lblMovieID.Size = new Size(34, 25);
            lblMovieID.TabIndex = 127;
            lblMovieID.Text = "ID:";
            // 
            // UpdateMovie
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(231, 223, 198);
            ClientSize = new Size(834, 622);
            Controls.Add(labelMovieId);
            Controls.Add(lblMovieID);
            Controls.Add(btnRemoveImage);
            Controls.Add(lblWarning);
            Controls.Add(buttonUpdateMovie);
            Controls.Add(btnImageUpload);
            Controls.Add(pictureBoxMoviePic);
            Controls.Add(checkedLBGenres);
            Controls.Add(labelMovieGenre);
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
            ForeColor = Color.FromArgb(138, 104, 86);
            Name = "UpdateMovie";
            Text = "UpdateMovie";
            ((System.ComponentModel.ISupportInitialize)pictureBoxMoviePic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWarning;
        private Button buttonUpdateMovie;
        private Button btnImageUpload;
        private PictureBox pictureBoxMoviePic;
        private CheckedListBox checkedLBGenres;
        private Label labelMovieGenre;
        private TextBox textBMovieCountryOfOrigin;
        private Label lblMovieCountryOfOrigin;
        private TextBox textBoxMovieRating;
        private Label labelMovieRating;
        private DateTimePicker dateTimeMoviePublishment;
        private Label labelMoviePublishment;
        private TextBox textBoxMovieDuration;
        private Label labelMovieDuration;
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
        private Button btnRemoveImage;
        private Label labelMovieId;
        private Label lblMovieID;
    }
}