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
            dateTimePicker1 = new DateTimePicker();
            btnDailyReviews = new Button();
            lblWarning = new Label();
            buttonMoreInfo = new Button();
            listBoxViewReviews = new ListBox();
            btnView = new Button();
            panel1 = new Panel();
            panelDesktop.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelDesktop
            // 
            panelDesktop.BackColor = Color.FromArgb(231, 223, 198);
            panelDesktop.Controls.Add(dateTimePicker1);
            panelDesktop.Controls.Add(btnDailyReviews);
            panelDesktop.Controls.Add(lblWarning);
            panelDesktop.Controls.Add(buttonMoreInfo);
            panelDesktop.Controls.Add(listBoxViewReviews);
            panelDesktop.Location = new Point(0, 62);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new Size(860, 541);
            panelDesktop.TabIndex = 148;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Segoe UI", 11F);
            dateTimePicker1.Location = new Point(565, 49);
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
            btnDailyReviews.Font = new Font("MV Boli", 13.8F, FontStyle.Bold);
            btnDailyReviews.ForeColor = Color.FromArgb(138, 104, 86);
            btnDailyReviews.Location = new Point(565, 87);
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
            lblWarning.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic);
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
            buttonMoreInfo.Font = new Font("MV Boli", 13.8F, FontStyle.Bold);
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
            listBoxViewReviews.Font = new Font("Segoe UI", 10.2F);
            listBoxViewReviews.FormattingEnabled = true;
            listBoxViewReviews.ItemHeight = 23;
            listBoxViewReviews.Location = new Point(12, 47);
            listBoxViewReviews.Name = "listBoxViewReviews";
            listBoxViewReviews.Size = new Size(513, 418);
            listBoxViewReviews.TabIndex = 131;
            // 
            // btnView
            // 
            btnView.FlatAppearance.BorderSize = 0;
            btnView.FlatStyle = FlatStyle.Flat;
            btnView.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnView.ForeColor = Color.White;
            btnView.Location = new Point(0, -8);
            btnView.Name = "btnView";
            btnView.Size = new Size(870, 75);
            btnView.TabIndex = 10;
            btnView.Text = "View Reviews";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
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
        private Button btnView;
        private Panel panel1;
        private Button btnDailyReviews;
        private DateTimePicker dateTimePicker1;
    }
}