namespace DesktopApp.Users
{
    partial class MoreInfoUser
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
            pictureBoxBookPic = new PictureBox();
            btnRemoveImage = new Button();
            lblWarning = new Label();
            listBoxViewReviews = new ListBox();
            groupBox2 = new GroupBox();
            richTextBoxDescription = new RichTextBox();
            lblProfileDescr = new Label();
            labelGender = new Label();
            labelLName = new Label();
            labelEmail = new Label();
            labelUsername = new Label();
            labelFName = new Label();
            lblGender = new Label();
            lblLName = new Label();
            lblEmail = new Label();
            lblUsername = new Label();
            lblFName = new Label();
            labelReviews = new Label();
            btnSeeReview = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBookPic).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxBookPic
            // 
            pictureBoxBookPic.Location = new Point(422, 12);
            pictureBoxBookPic.Name = "pictureBoxBookPic";
            pictureBoxBookPic.Size = new Size(135, 175);
            pictureBoxBookPic.TabIndex = 166;
            pictureBoxBookPic.TabStop = false;
            // 
            // btnRemoveImage
            // 
            btnRemoveImage.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btnRemoveImage.ForeColor = Color.FromArgb(138, 104, 86);
            btnRemoveImage.Location = new Point(585, 12);
            btnRemoveImage.Name = "btnRemoveImage";
            btnRemoveImage.Size = new Size(165, 70);
            btnRemoveImage.TabIndex = 167;
            btnRemoveImage.Text = "Remove current image";
            btnRemoveImage.UseVisualStyleBackColor = true;
            btnRemoveImage.Click += btnRemoveImage_Click;
            // 
            // lblWarning
            // 
            lblWarning.AutoSize = true;
            lblWarning.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblWarning.ForeColor = Color.Maroon;
            lblWarning.Location = new Point(22, 9);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new Size(81, 25);
            lblWarning.TabIndex = 168;
            lblWarning.Text = "Warning";
            // 
            // listBoxViewReviews
            // 
            listBoxViewReviews.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            listBoxViewReviews.FormattingEnabled = true;
            listBoxViewReviews.ItemHeight = 23;
            listBoxViewReviews.Location = new Point(422, 226);
            listBoxViewReviews.Name = "listBoxViewReviews";
            listBoxViewReviews.Size = new Size(351, 257);
            listBoxViewReviews.TabIndex = 169;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.White;
            groupBox2.Controls.Add(richTextBoxDescription);
            groupBox2.Controls.Add(lblProfileDescr);
            groupBox2.Controls.Add(labelGender);
            groupBox2.Controls.Add(labelLName);
            groupBox2.Controls.Add(labelEmail);
            groupBox2.Controls.Add(labelUsername);
            groupBox2.Controls.Add(labelFName);
            groupBox2.Controls.Add(lblGender);
            groupBox2.Controls.Add(lblLName);
            groupBox2.Controls.Add(lblEmail);
            groupBox2.Controls.Add(lblUsername);
            groupBox2.Controls.Add(lblFName);
            groupBox2.FlatStyle = FlatStyle.Flat;
            groupBox2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.Location = new Point(12, 37);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(395, 451);
            groupBox2.TabIndex = 170;
            groupBox2.TabStop = false;
            groupBox2.Text = "Selected info";
            // 
            // richTextBoxDescription
            // 
            richTextBoxDescription.Location = new Point(10, 240);
            richTextBoxDescription.Name = "richTextBoxDescription";
            richTextBoxDescription.Size = new Size(365, 185);
            richTextBoxDescription.TabIndex = 176;
            richTextBoxDescription.Text = "";
            // 
            // lblProfileDescr
            // 
            lblProfileDescr.AutoSize = true;
            lblProfileDescr.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            lblProfileDescr.Location = new Point(10, 212);
            lblProfileDescr.Name = "lblProfileDescr";
            lblProfileDescr.Size = new Size(160, 25);
            lblProfileDescr.TabIndex = 175;
            lblProfileDescr.Text = "Profile Description:";
            // 
            // labelGender
            // 
            labelGender.AutoSize = true;
            labelGender.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            labelGender.Location = new Point(110, 96);
            labelGender.Name = "labelGender";
            labelGender.Size = new Size(80, 25);
            labelGender.TabIndex = 174;
            labelGender.Text = "Gender:";
            // 
            // labelLName
            // 
            labelLName.AutoSize = true;
            labelLName.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            labelLName.Location = new Point(112, 62);
            labelLName.Name = "labelLName";
            labelLName.Size = new Size(103, 25);
            labelLName.TabIndex = 173;
            labelLName.Text = "Last name:";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            labelEmail.Location = new Point(112, 173);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(63, 25);
            labelEmail.TabIndex = 172;
            labelEmail.Text = "Email:";
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            labelUsername.Location = new Point(110, 136);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(102, 25);
            labelUsername.TabIndex = 171;
            labelUsername.Text = "Username:";
            // 
            // labelFName
            // 
            labelFName.AutoSize = true;
            labelFName.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            labelFName.Location = new Point(110, 28);
            labelFName.Name = "labelFName";
            labelFName.Size = new Size(105, 25);
            labelFName.TabIndex = 170;
            labelFName.Text = "First name:";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            lblGender.Location = new Point(28, 96);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(72, 25);
            lblGender.TabIndex = 169;
            lblGender.Text = "Gender:";
            // 
            // lblLName
            // 
            lblLName.AutoSize = true;
            lblLName.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            lblLName.Location = new Point(6, 62);
            lblLName.Name = "lblLName";
            lblLName.Size = new Size(96, 25);
            lblLName.TabIndex = 168;
            lblLName.Text = "Last name:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            lblEmail.Location = new Point(40, 173);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(60, 25);
            lblEmail.TabIndex = 167;
            lblEmail.Text = "Email:";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            lblUsername.Location = new Point(6, 136);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(94, 25);
            lblUsername.TabIndex = 166;
            lblUsername.Text = "Username:";
            // 
            // lblFName
            // 
            lblFName.AutoSize = true;
            lblFName.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            lblFName.Location = new Point(6, 28);
            lblFName.Name = "lblFName";
            lblFName.Size = new Size(98, 25);
            lblFName.TabIndex = 165;
            lblFName.Text = "First name:";
            // 
            // labelReviews
            // 
            labelReviews.AutoSize = true;
            labelReviews.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelReviews.Location = new Point(422, 198);
            labelReviews.Name = "labelReviews";
            labelReviews.Size = new Size(142, 25);
            labelReviews.TabIndex = 177;
            labelReviews.Text = "Written Reviews:";
            // 
            // btnSeeReview
            // 
            btnSeeReview.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btnSeeReview.ForeColor = Color.FromArgb(138, 104, 86);
            btnSeeReview.Location = new Point(649, 190);
            btnSeeReview.Name = "btnSeeReview";
            btnSeeReview.Size = new Size(124, 30);
            btnSeeReview.TabIndex = 178;
            btnSeeReview.Text = "See Review";
            btnSeeReview.UseVisualStyleBackColor = true;
            btnSeeReview.Click += btnSeeReview_Click;
            // 
            // MoreInfoUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(231, 223, 198);
            ClientSize = new Size(785, 499);
            Controls.Add(btnSeeReview);
            Controls.Add(labelReviews);
            Controls.Add(groupBox2);
            Controls.Add(listBoxViewReviews);
            Controls.Add(lblWarning);
            Controls.Add(btnRemoveImage);
            Controls.Add(pictureBoxBookPic);
            ForeColor = Color.FromArgb(138, 104, 86);
            Name = "MoreInfoUser";
            Text = "MoreInfoUser";
            ((System.ComponentModel.ISupportInitialize)pictureBoxBookPic).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBoxBookPic;
        private Button btnRemoveImage;
        private Label lblWarning;
        private ListBox listBoxViewReviews;
        private GroupBox groupBox2;
        private RichTextBox richTextBoxDescription;
        private Label lblProfileDescr;
        private Label labelGender;
        private Label labelLName;
        private Label labelEmail;
        private Label labelUsername;
        private Label labelFName;
        private Label lblGender;
        private Label lblLName;
        private Label lblEmail;
        private Label lblUsername;
        private Label lblFName;
        private Label labelReviews;
        private Button btnSeeReview;
    }
}