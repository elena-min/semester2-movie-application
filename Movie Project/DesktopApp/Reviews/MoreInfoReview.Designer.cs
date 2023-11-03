namespace DesktopApp.Reviews
{
    partial class MoreInfoReview
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
            paneldeleteReview = new Panel();
            buttonDelete = new Button();
            textBoxReason = new TextBox();
            lblReasonForDeleting = new Label();
            lblInsertDateOfPublishment = new Label();
            lblInsertGivenRating = new Label();
            lblInsertUser = new Label();
            lblInsertTitle = new Label();
            labelGivenRating = new Label();
            richTextBoxContent = new RichTextBox();
            labelReviewPublishment = new Label();
            labelWrittenBy = new Label();
            labelReviewTitle = new Label();
            labelReview = new Label();
            lblWarning = new Label();
            paneldeleteReview.SuspendLayout();
            SuspendLayout();
            // 
            // paneldeleteReview
            // 
            paneldeleteReview.BackColor = Color.FromArgb(138, 104, 86);
            paneldeleteReview.Controls.Add(lblWarning);
            paneldeleteReview.Controls.Add(buttonDelete);
            paneldeleteReview.Controls.Add(textBoxReason);
            paneldeleteReview.Controls.Add(lblReasonForDeleting);
            paneldeleteReview.Dock = DockStyle.Bottom;
            paneldeleteReview.Location = new Point(0, 385);
            paneldeleteReview.Name = "paneldeleteReview";
            paneldeleteReview.Size = new Size(806, 101);
            paneldeleteReview.TabIndex = 129;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.White;
            buttonDelete.FlatAppearance.BorderColor = Color.FromArgb(138, 104, 86);
            buttonDelete.FlatAppearance.BorderSize = 2;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Font = new Font("MV Boli", 11.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonDelete.ForeColor = Color.FromArgb(138, 104, 86);
            buttonDelete.Location = new Point(626, 45);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(177, 44);
            buttonDelete.TabIndex = 126;
            buttonDelete.Text = "Delete review";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // textBoxReason
            // 
            textBoxReason.Location = new Point(17, 62);
            textBoxReason.Name = "textBoxReason";
            textBoxReason.Size = new Size(591, 27);
            textBoxReason.TabIndex = 120;
            // 
            // lblReasonForDeleting
            // 
            lblReasonForDeleting.AutoSize = true;
            lblReasonForDeleting.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            lblReasonForDeleting.ForeColor = Color.FromArgb(255, 245, 235);
            lblReasonForDeleting.Location = new Point(17, 34);
            lblReasonForDeleting.Name = "lblReasonForDeleting";
            lblReasonForDeleting.Size = new Size(167, 25);
            lblReasonForDeleting.TabIndex = 119;
            lblReasonForDeleting.Text = "Reason for deleting:";
            // 
            // lblInsertDateOfPublishment
            // 
            lblInsertDateOfPublishment.AutoSize = true;
            lblInsertDateOfPublishment.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblInsertDateOfPublishment.ForeColor = Color.FromArgb(138, 104, 86);
            lblInsertDateOfPublishment.Location = new Point(194, 343);
            lblInsertDateOfPublishment.Name = "lblInsertDateOfPublishment";
            lblInsertDateOfPublishment.Size = new Size(188, 25);
            lblInsertDateOfPublishment.TabIndex = 128;
            lblInsertDateOfPublishment.Text = "DateOfPublishment...";
            // 
            // lblInsertGivenRating
            // 
            lblInsertGivenRating.AutoSize = true;
            lblInsertGivenRating.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblInsertGivenRating.ForeColor = Color.FromArgb(138, 104, 86);
            lblInsertGivenRating.Location = new Point(595, 343);
            lblInsertGivenRating.Name = "lblInsertGivenRating";
            lblInsertGivenRating.Size = new Size(78, 25);
            lblInsertGivenRating.TabIndex = 127;
            lblInsertGivenRating.Text = "Rating...";
            // 
            // lblInsertUser
            // 
            lblInsertUser.AutoSize = true;
            lblInsertUser.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblInsertUser.ForeColor = Color.FromArgb(138, 104, 86);
            lblInsertUser.Location = new Point(12, 300);
            lblInsertUser.Name = "lblInsertUser";
            lblInsertUser.Size = new Size(57, 25);
            lblInsertUser.TabIndex = 126;
            lblInsertUser.Text = "User..";
            // 
            // lblInsertTitle
            // 
            lblInsertTitle.AutoSize = true;
            lblInsertTitle.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblInsertTitle.ForeColor = Color.FromArgb(138, 104, 86);
            lblInsertTitle.Location = new Point(12, 31);
            lblInsertTitle.Name = "lblInsertTitle";
            lblInsertTitle.Size = new Size(61, 25);
            lblInsertTitle.TabIndex = 125;
            lblInsertTitle.Text = "Title...";
            // 
            // labelGivenRating
            // 
            labelGivenRating.AutoSize = true;
            labelGivenRating.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelGivenRating.ForeColor = Color.FromArgb(138, 104, 86);
            labelGivenRating.Location = new Point(490, 343);
            labelGivenRating.Name = "labelGivenRating";
            labelGivenRating.Size = new Size(113, 25);
            labelGivenRating.TabIndex = 124;
            labelGivenRating.Text = "Given rating:";
            // 
            // richTextBoxContent
            // 
            richTextBoxContent.Location = new Point(9, 94);
            richTextBoxContent.Name = "richTextBoxContent";
            richTextBoxContent.Size = new Size(664, 163);
            richTextBoxContent.TabIndex = 123;
            richTextBoxContent.Text = "";
            // 
            // labelReviewPublishment
            // 
            labelReviewPublishment.AutoSize = true;
            labelReviewPublishment.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelReviewPublishment.ForeColor = Color.FromArgb(138, 104, 86);
            labelReviewPublishment.Location = new Point(12, 343);
            labelReviewPublishment.Name = "labelReviewPublishment";
            labelReviewPublishment.Size = new Size(176, 25);
            labelReviewPublishment.TabIndex = 122;
            labelReviewPublishment.Text = "Date of publishment:";
            // 
            // labelWrittenBy
            // 
            labelWrittenBy.AutoSize = true;
            labelWrittenBy.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelWrittenBy.ForeColor = Color.FromArgb(138, 104, 86);
            labelWrittenBy.Location = new Point(12, 275);
            labelWrittenBy.Name = "labelWrittenBy";
            labelWrittenBy.Size = new Size(72, 25);
            labelWrittenBy.TabIndex = 121;
            labelWrittenBy.Text = "By user:";
            // 
            // labelReviewTitle
            // 
            labelReviewTitle.AutoSize = true;
            labelReviewTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelReviewTitle.ForeColor = Color.FromArgb(138, 104, 86);
            labelReviewTitle.Location = new Point(9, 6);
            labelReviewTitle.Name = "labelReviewTitle";
            labelReviewTitle.Size = new Size(110, 25);
            labelReviewTitle.TabIndex = 120;
            labelReviewTitle.Text = "Review Title:";
            // 
            // labelReview
            // 
            labelReview.AutoSize = true;
            labelReview.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelReview.ForeColor = Color.FromArgb(138, 104, 86);
            labelReview.Location = new Point(9, 66);
            labelReview.Name = "labelReview";
            labelReview.Size = new Size(105, 25);
            labelReview.TabIndex = 119;
            labelReview.Text = "Description:";
            // 
            // lblWarning
            // 
            lblWarning.AutoSize = true;
            lblWarning.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblWarning.ForeColor = Color.Maroon;
            lblWarning.Location = new Point(12, 9);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new Size(81, 25);
            lblWarning.TabIndex = 130;
            lblWarning.Text = "Warning";
            // 
            // MoreInfoReview
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(231, 223, 198);
            ClientSize = new Size(806, 486);
            Controls.Add(paneldeleteReview);
            Controls.Add(lblInsertDateOfPublishment);
            Controls.Add(lblInsertGivenRating);
            Controls.Add(lblInsertUser);
            Controls.Add(lblInsertTitle);
            Controls.Add(labelGivenRating);
            Controls.Add(richTextBoxContent);
            Controls.Add(labelReviewPublishment);
            Controls.Add(labelWrittenBy);
            Controls.Add(labelReviewTitle);
            Controls.Add(labelReview);
            ForeColor = Color.FromArgb(138, 104, 86);
            Name = "MoreInfoReview";
            Text = "MoreInfoReview";
            paneldeleteReview.ResumeLayout(false);
            paneldeleteReview.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel paneldeleteReview;
        private TextBox textBoxReason;
        private Label lblReasonForDeleting;
        private Label lblInsertDateOfPublishment;
        private Label lblInsertGivenRating;
        private Label lblInsertUser;
        private Label lblInsertTitle;
        private Label labelGivenRating;
        private RichTextBox richTextBoxContent;
        private Label labelReviewPublishment;
        private Label labelWrittenBy;
        private Label labelReviewTitle;
        private Label labelReview;
        private Button buttonDelete;
        private Label lblWarning;
    }
}