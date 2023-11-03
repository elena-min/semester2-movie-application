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
            labelOrder = new Label();
            comboBoxOrder = new ComboBox();
            textBoxUserName = new TextBox();
            labelName = new Label();
            buttonDelete = new Button();
            lblSearchMovies = new Label();
            buttonSearch = new Button();
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
            btnView.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
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
            // labelOrder
            // 
            labelOrder.AutoSize = true;
            labelOrder.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelOrder.ForeColor = Color.FromArgb(138, 104, 86);
            labelOrder.Location = new Point(565, 121);
            labelOrder.Name = "labelOrder";
            labelOrder.Size = new Size(61, 25);
            labelOrder.TabIndex = 139;
            labelOrder.Text = "Order:";
            // 
            // comboBoxOrder
            // 
            comboBoxOrder.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxOrder.FormattingEnabled = true;
            comboBoxOrder.Location = new Point(565, 149);
            comboBoxOrder.Name = "comboBoxOrder";
            comboBoxOrder.Size = new Size(263, 33);
            comboBoxOrder.TabIndex = 138;
            // 
            // textBoxUserName
            // 
            textBoxUserName.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxUserName.ForeColor = Color.FromArgb(60, 144, 137);
            textBoxUserName.Location = new Point(565, 72);
            textBoxUserName.Name = "textBoxUserName";
            textBoxUserName.Size = new Size(263, 31);
            textBoxUserName.TabIndex = 134;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelName.ForeColor = Color.FromArgb(138, 104, 86);
            labelName.Location = new Point(565, 44);
            labelName.Name = "labelName";
            labelName.Size = new Size(64, 25);
            labelName.TabIndex = 135;
            labelName.Text = "Name:";
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.White;
            buttonDelete.FlatAppearance.BorderColor = Color.FromArgb(138, 104, 86);
            buttonDelete.FlatAppearance.BorderSize = 2;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Font = new Font("MV Boli", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonDelete.ForeColor = Color.FromArgb(138, 104, 86);
            buttonDelete.Location = new Point(299, 483);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(226, 44);
            buttonDelete.TabIndex = 140;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
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
            // buttonSearch
            // 
            buttonSearch.BackColor = Color.White;
            buttonSearch.FlatAppearance.BorderColor = Color.FromArgb(138, 104, 86);
            buttonSearch.FlatAppearance.BorderSize = 2;
            buttonSearch.FlatStyle = FlatStyle.Flat;
            buttonSearch.Font = new Font("MV Boli", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonSearch.ForeColor = Color.FromArgb(138, 104, 86);
            buttonSearch.Location = new Point(565, 197);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(263, 44);
            buttonSearch.TabIndex = 143;
            buttonSearch.Text = "Search";
            buttonSearch.UseVisualStyleBackColor = false;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // listBoxViewUsers
            // 
            listBoxViewUsers.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
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
            // panelDesktop
            // 
            panelDesktop.BackColor = Color.FromArgb(231, 223, 198);
            panelDesktop.Controls.Add(lblWarning);
            panelDesktop.Controls.Add(buttonMoreInfo);
            panelDesktop.Controls.Add(listBoxViewUsers);
            panelDesktop.Controls.Add(buttonSearch);
            panelDesktop.Controls.Add(lblSearchMovies);
            panelDesktop.Controls.Add(buttonDelete);
            panelDesktop.Controls.Add(labelName);
            panelDesktop.Controls.Add(textBoxUserName);
            panelDesktop.Controls.Add(comboBoxOrder);
            panelDesktop.Controls.Add(labelOrder);
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
        private Label labelOrder;
        private ComboBox comboBoxOrder;
        private TextBox textBoxUserName;
        private Label labelName;
        private Button buttonDelete;
        private Label lblSearchMovies;
        private Button buttonSearch;
        private ListBox listBoxViewUsers;
        private Button buttonMoreInfo;
        private Label lblWarning;
        private Panel panelDesktop;
    }
}