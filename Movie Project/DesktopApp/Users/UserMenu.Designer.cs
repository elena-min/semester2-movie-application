namespace DesktopApp.Users
{
    partial class UserMenu
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
            btnView = new Button();
            panel1 = new Panel();
            buttonDelete = new Button();
            listBoxViewUsers = new ListBox();
            buttonMoreInfo = new Button();
            lblWarning = new Label();
            panelDesktop = new Panel();
            panel1.SuspendLayout();
            panelDesktop.SuspendLayout();
            SuspendLayout();
            // 
            // btnView
            // 
            btnView.FlatAppearance.BorderSize = 0;
            btnView.FlatStyle = FlatStyle.Flat;
            btnView.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnView.ForeColor = Color.White;
            btnView.Location = new Point(12, 3);
            btnView.Name = "btnView";
            btnView.Size = new Size(870, 75);
            btnView.TabIndex = 10;
            btnView.Text = "View Users";
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
            panel1.TabIndex = 145;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.White;
            buttonDelete.FlatAppearance.BorderColor = Color.FromArgb(138, 104, 86);
            buttonDelete.FlatAppearance.BorderSize = 2;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Font = new Font("MV Boli", 13.8F, FontStyle.Bold);
            buttonDelete.ForeColor = Color.FromArgb(138, 104, 86);
            buttonDelete.Location = new Point(299, 483);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(226, 44);
            buttonDelete.TabIndex = 140;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // listBoxViewUsers
            // 
            listBoxViewUsers.Font = new Font("Segoe UI", 10.2F);
            listBoxViewUsers.FormattingEnabled = true;
            listBoxViewUsers.ItemHeight = 23;
            listBoxViewUsers.Location = new Point(12, 47);
            listBoxViewUsers.Name = "listBoxViewUsers";
            listBoxViewUsers.Size = new Size(513, 418);
            listBoxViewUsers.TabIndex = 131;
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
            // panelDesktop
            // 
            panelDesktop.BackColor = Color.FromArgb(231, 223, 198);
            panelDesktop.Controls.Add(lblWarning);
            panelDesktop.Controls.Add(buttonMoreInfo);
            panelDesktop.Controls.Add(listBoxViewUsers);
            panelDesktop.Controls.Add(buttonDelete);
            panelDesktop.Location = new Point(0, 62);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new Size(860, 541);
            panelDesktop.TabIndex = 146;
            // 
            // UserMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(231, 223, 198);
            ClientSize = new Size(860, 602);
            Controls.Add(panelDesktop);
            Controls.Add(panel1);
            ForeColor = Color.FromArgb(138, 104, 86);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserMenu";
            Text = "UserMenu";
            panel1.ResumeLayout(false);
            panelDesktop.ResumeLayout(false);
            panelDesktop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnView;
        private Panel panel1;
        private Button buttonDelete;
        private ListBox listBoxViewUsers;
        private Button buttonMoreInfo;
        private Label lblWarning;
        private Panel panelDesktop;
    }
}