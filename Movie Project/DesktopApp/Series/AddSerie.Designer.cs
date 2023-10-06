namespace DesktopApp.Series
{
    partial class AddSerie
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
            buttonAddSerie = new Button();
            btnImageUpload = new Button();
            pictureBoxSeriePic = new PictureBox();
            checkedLBGenres = new CheckedListBox();
            labelSerieGenre = new Label();
            textBSerieCountryOfOrigin = new TextBox();
            lblSerieCountryOfOrigin = new Label();
            textBoxSerieRating = new TextBox();
            labelSerieRating = new Label();
            dateTimeSeriePublishment = new DateTimePicker();
            labelSeriePublishment = new Label();
            textBoxSerieSeasons = new TextBox();
            labelSerieSeasons = new Label();
            textBoxCast = new TextBox();
            lblSerieCast = new Label();
            richTextBoxDescription = new RichTextBox();
            textBoxSerieTitle = new TextBox();
            labelSerie = new Label();
            labelSerieDescription = new Label();
            lblFormTitle = new Label();
            textBoxSerieEpisodes = new TextBox();
            lblEpisodes = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSeriePic).BeginInit();
            SuspendLayout();
            // 
            // lblWarning
            // 
            lblWarning.AutoSize = true;
            lblWarning.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblWarning.ForeColor = Color.Maroon;
            lblWarning.Location = new Point(12, 45);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new Size(81, 25);
            lblWarning.TabIndex = 125;
            lblWarning.Text = "Warning";
            // 
            // buttonAddSerie
            // 
            buttonAddSerie.BackColor = Color.White;
            buttonAddSerie.FlatAppearance.BorderColor = Color.FromArgb(138, 104, 86);
            buttonAddSerie.FlatAppearance.BorderSize = 2;
            buttonAddSerie.FlatStyle = FlatStyle.Flat;
            buttonAddSerie.Font = new Font("MV Boli", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonAddSerie.ForeColor = Color.FromArgb(138, 104, 86);
            buttonAddSerie.Location = new Point(625, 534);
            buttonAddSerie.Name = "buttonAddSerie";
            buttonAddSerie.Size = new Size(203, 44);
            buttonAddSerie.TabIndex = 124;
            buttonAddSerie.Text = "Add";
            buttonAddSerie.UseVisualStyleBackColor = false;
            buttonAddSerie.Click += buttonAddSerie_Click;
            // 
            // btnImageUpload
            // 
            btnImageUpload.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btnImageUpload.ForeColor = Color.FromArgb(138, 104, 86);
            btnImageUpload.Location = new Point(625, 329);
            btnImageUpload.Name = "btnImageUpload";
            btnImageUpload.Size = new Size(203, 31);
            btnImageUpload.TabIndex = 123;
            btnImageUpload.Text = "Upload Image";
            btnImageUpload.UseVisualStyleBackColor = true;
            btnImageUpload.Click += btnImageUpload_Click;
            // 
            // pictureBoxSeriePic
            // 
            pictureBoxSeriePic.Location = new Point(668, 366);
            pictureBoxSeriePic.Name = "pictureBoxSeriePic";
            pictureBoxSeriePic.Size = new Size(117, 157);
            pictureBoxSeriePic.TabIndex = 122;
            pictureBoxSeriePic.TabStop = false;
            // 
            // checkedLBGenres
            // 
            checkedLBGenres.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            checkedLBGenres.FormattingEnabled = true;
            checkedLBGenres.Location = new Point(625, 163);
            checkedLBGenres.Name = "checkedLBGenres";
            checkedLBGenres.Size = new Size(203, 160);
            checkedLBGenres.TabIndex = 121;
            // 
            // labelSerieGenre
            // 
            labelSerieGenre.AutoSize = true;
            labelSerieGenre.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelSerieGenre.ForeColor = Color.FromArgb(138, 104, 86);
            labelSerieGenre.Location = new Point(625, 135);
            labelSerieGenre.Name = "labelSerieGenre";
            labelSerieGenre.Size = new Size(62, 25);
            labelSerieGenre.TabIndex = 120;
            labelSerieGenre.Text = "Genre:";
            // 
            // textBSerieCountryOfOrigin
            // 
            textBSerieCountryOfOrigin.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBSerieCountryOfOrigin.ForeColor = Color.Black;
            textBSerieCountryOfOrigin.Location = new Point(12, 416);
            textBSerieCountryOfOrigin.Name = "textBSerieCountryOfOrigin";
            textBSerieCountryOfOrigin.Size = new Size(582, 31);
            textBSerieCountryOfOrigin.TabIndex = 118;
            // 
            // lblSerieCountryOfOrigin
            // 
            lblSerieCountryOfOrigin.AutoSize = true;
            lblSerieCountryOfOrigin.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            lblSerieCountryOfOrigin.ForeColor = Color.FromArgb(138, 104, 86);
            lblSerieCountryOfOrigin.Location = new Point(12, 388);
            lblSerieCountryOfOrigin.Name = "lblSerieCountryOfOrigin";
            lblSerieCountryOfOrigin.Size = new Size(150, 25);
            lblSerieCountryOfOrigin.TabIndex = 119;
            lblSerieCountryOfOrigin.Text = "Country of origin:";
            // 
            // textBoxSerieRating
            // 
            textBoxSerieRating.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxSerieRating.ForeColor = Color.Black;
            textBoxSerieRating.Location = new Point(625, 101);
            textBoxSerieRating.Name = "textBoxSerieRating";
            textBoxSerieRating.Size = new Size(203, 31);
            textBoxSerieRating.TabIndex = 116;
            // 
            // labelSerieRating
            // 
            labelSerieRating.AutoSize = true;
            labelSerieRating.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelSerieRating.ForeColor = Color.FromArgb(138, 104, 86);
            labelSerieRating.Location = new Point(625, 73);
            labelSerieRating.Name = "labelSerieRating";
            labelSerieRating.Size = new Size(127, 25);
            labelSerieRating.TabIndex = 117;
            labelSerieRating.Text = "Current rating:";
            // 
            // dateTimeSeriePublishment
            // 
            dateTimeSeriePublishment.CalendarFont = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimeSeriePublishment.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimeSeriePublishment.Location = new Point(625, 39);
            dateTimeSeriePublishment.Name = "dateTimeSeriePublishment";
            dateTimeSeriePublishment.Size = new Size(203, 31);
            dateTimeSeriePublishment.TabIndex = 115;
            // 
            // labelSeriePublishment
            // 
            labelSeriePublishment.AutoSize = true;
            labelSeriePublishment.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelSeriePublishment.ForeColor = Color.FromArgb(138, 104, 86);
            labelSeriePublishment.Location = new Point(625, 11);
            labelSeriePublishment.Name = "labelSeriePublishment";
            labelSeriePublishment.Size = new Size(115, 25);
            labelSeriePublishment.TabIndex = 114;
            labelSeriePublishment.Text = "Release date:";
            // 
            // textBoxSerieSeasons
            // 
            textBoxSerieSeasons.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxSerieSeasons.ForeColor = Color.Black;
            textBoxSerieSeasons.Location = new Point(12, 478);
            textBoxSerieSeasons.Name = "textBoxSerieSeasons";
            textBoxSerieSeasons.Size = new Size(278, 31);
            textBoxSerieSeasons.TabIndex = 112;
            // 
            // labelSerieSeasons
            // 
            labelSerieSeasons.AutoSize = true;
            labelSerieSeasons.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelSerieSeasons.ForeColor = Color.FromArgb(138, 104, 86);
            labelSerieSeasons.Location = new Point(12, 450);
            labelSerieSeasons.Name = "labelSerieSeasons";
            labelSerieSeasons.Size = new Size(172, 25);
            labelSerieSeasons.TabIndex = 113;
            labelSerieSeasons.Text = "Numbers of seasons:";
            // 
            // textBoxCast
            // 
            textBoxCast.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxCast.ForeColor = Color.Black;
            textBoxCast.Location = new Point(12, 354);
            textBoxCast.Name = "textBoxCast";
            textBoxCast.Size = new Size(582, 31);
            textBoxCast.TabIndex = 111;
            // 
            // lblSerieCast
            // 
            lblSerieCast.AutoSize = true;
            lblSerieCast.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            lblSerieCast.Location = new Point(12, 330);
            lblSerieCast.Name = "lblSerieCast";
            lblSerieCast.Size = new Size(241, 25);
            lblSerieCast.TabIndex = 110;
            lblSerieCast.Text = "Cast (seperate with commas):";
            // 
            // richTextBoxDescription
            // 
            richTextBoxDescription.ForeColor = Color.Black;
            richTextBoxDescription.Location = new Point(12, 161);
            richTextBoxDescription.Name = "richTextBoxDescription";
            richTextBoxDescription.Size = new Size(582, 163);
            richTextBoxDescription.TabIndex = 106;
            richTextBoxDescription.Text = "";
            // 
            // textBoxSerieTitle
            // 
            textBoxSerieTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxSerieTitle.ForeColor = Color.Black;
            textBoxSerieTitle.Location = new Point(12, 101);
            textBoxSerieTitle.Name = "textBoxSerieTitle";
            textBoxSerieTitle.Size = new Size(582, 31);
            textBoxSerieTitle.TabIndex = 103;
            // 
            // labelSerie
            // 
            labelSerie.AutoSize = true;
            labelSerie.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelSerie.Location = new Point(12, 73);
            labelSerie.Name = "labelSerie";
            labelSerie.Size = new Size(50, 25);
            labelSerie.TabIndex = 104;
            labelSerie.Text = "Title:";
            // 
            // labelSerieDescription
            // 
            labelSerieDescription.AutoSize = true;
            labelSerieDescription.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelSerieDescription.Location = new Point(12, 133);
            labelSerieDescription.Name = "labelSerieDescription";
            labelSerieDescription.Size = new Size(105, 25);
            labelSerieDescription.TabIndex = 102;
            labelSerieDescription.Text = "Description:";
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Sans Serif Collection", 11.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblFormTitle.ForeColor = Color.FromArgb(138, 104, 86);
            lblFormTitle.Location = new Point(6, 4);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(187, 49);
            lblFormTitle.TabIndex = 101;
            lblFormTitle.Text = "Add a serie";
            // 
            // textBoxSerieEpisodes
            // 
            textBoxSerieEpisodes.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxSerieEpisodes.ForeColor = Color.Black;
            textBoxSerieEpisodes.Location = new Point(12, 541);
            textBoxSerieEpisodes.Name = "textBoxSerieEpisodes";
            textBoxSerieEpisodes.Size = new Size(278, 31);
            textBoxSerieEpisodes.TabIndex = 126;
            // 
            // lblEpisodes
            // 
            lblEpisodes.AutoSize = true;
            lblEpisodes.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            lblEpisodes.ForeColor = Color.FromArgb(138, 104, 86);
            lblEpisodes.Location = new Point(12, 513);
            lblEpisodes.Name = "lblEpisodes";
            lblEpisodes.Size = new Size(168, 25);
            lblEpisodes.TabIndex = 127;
            lblEpisodes.Text = "Number of episodes";
            // 
            // AddSerie
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(231, 223, 198);
            ClientSize = new Size(834, 583);
            Controls.Add(textBoxSerieEpisodes);
            Controls.Add(lblEpisodes);
            Controls.Add(lblWarning);
            Controls.Add(buttonAddSerie);
            Controls.Add(btnImageUpload);
            Controls.Add(pictureBoxSeriePic);
            Controls.Add(checkedLBGenres);
            Controls.Add(labelSerieGenre);
            Controls.Add(textBSerieCountryOfOrigin);
            Controls.Add(lblSerieCountryOfOrigin);
            Controls.Add(textBoxSerieRating);
            Controls.Add(labelSerieRating);
            Controls.Add(dateTimeSeriePublishment);
            Controls.Add(labelSeriePublishment);
            Controls.Add(textBoxSerieSeasons);
            Controls.Add(labelSerieSeasons);
            Controls.Add(textBoxCast);
            Controls.Add(lblSerieCast);
            Controls.Add(richTextBoxDescription);
            Controls.Add(textBoxSerieTitle);
            Controls.Add(labelSerie);
            Controls.Add(labelSerieDescription);
            Controls.Add(lblFormTitle);
            ForeColor = Color.FromArgb(138, 104, 86);
            Name = "AddSerie";
            Text = "AddSerie";
            ((System.ComponentModel.ISupportInitialize)pictureBoxSeriePic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWarning;
        private Button buttonAddSerie;
        private Button btnImageUpload;
        private PictureBox pictureBoxSeriePic;
        private CheckedListBox checkedLBGenres;
        private Label labelSerieGenre;
        private TextBox textBSerieCountryOfOrigin;
        private Label lblSerieCountryOfOrigin;
        private TextBox textBoxSerieRating;
        private Label labelSerieRating;
        private DateTimePicker dateTimeSeriePublishment;
        private Label labelSeriePublishment;
        private TextBox textBoxSerieSeasons;
        private Label labelSerieSeasons;
        private TextBox textBoxCast;
        private Label lblSerieCast;
        private RichTextBox richTextBoxDescription;
        private TextBox textBoxSerieTitle;
        private Label labelSerie;
        private Label labelSerieDescription;
        private Label lblFormTitle;
        private TextBox textBoxSerieEpisodes;
        private Label lblEpisodes;
    }
}