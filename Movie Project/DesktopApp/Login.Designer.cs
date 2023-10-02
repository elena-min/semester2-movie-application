namespace DesktopApp
{
    partial class Login
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
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            lblWarning = new Label();
            btnHidePass = new Button();
            buttonLogin = new Button();
            textBoxPassword = new TextBox();
            textBoxUsername = new TextBox();
            textBoxEmail = new TextBox();
            lblEMail = new Label();
            lblPassword = new Label();
            lblUsername = new Label();
            lblLogin = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = Properties.Resources.mainPoster;
            pictureBox1.InitialImage = Properties.Resources.mainPoster;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(816, 491);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblWarning);
            panel1.Controls.Add(btnHidePass);
            panel1.Controls.Add(buttonLogin);
            panel1.Controls.Add(textBoxPassword);
            panel1.Controls.Add(textBoxUsername);
            panel1.Controls.Add(textBoxEmail);
            panel1.Controls.Add(lblEMail);
            panel1.Controls.Add(lblPassword);
            panel1.Controls.Add(lblUsername);
            panel1.Controls.Add(lblLogin);
            panel1.Location = new Point(384, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(454, 491);
            panel1.TabIndex = 1;
            // 
            // lblWarning
            // 
            lblWarning.AutoSize = true;
            lblWarning.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblWarning.ForeColor = Color.Maroon;
            lblWarning.Location = new Point(55, 334);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new Size(81, 25);
            lblWarning.TabIndex = 38;
            lblWarning.Text = "Warning";
            // 
            // btnHidePass
            // 
            btnHidePass.Location = new Point(324, 297);
            btnHidePass.Name = "btnHidePass";
            btnHidePass.Size = new Size(61, 34);
            btnHidePass.TabIndex = 37;
            btnHidePass.Text = "Show";
            btnHidePass.UseVisualStyleBackColor = true;
            btnHidePass.Click += btnHidePass_Click;
            // 
            // buttonLogin
            // 
            buttonLogin.BackColor = Color.FromArgb(138, 104, 86);
            buttonLogin.FlatStyle = FlatStyle.Flat;
            buttonLogin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonLogin.ForeColor = Color.White;
            buttonLogin.Location = new Point(55, 379);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(308, 48);
            buttonLogin.TabIndex = 36;
            buttonLogin.Text = "Login";
            buttonLogin.UseVisualStyleBackColor = false;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxPassword.Location = new Point(55, 297);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(263, 34);
            textBoxPassword.TabIndex = 35;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxUsername.Location = new Point(55, 215);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(308, 34);
            textBoxUsername.TabIndex = 34;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxEmail.Location = new Point(55, 136);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(308, 34);
            textBoxEmail.TabIndex = 33;
            // 
            // lblEMail
            // 
            lblEMail.AutoSize = true;
            lblEMail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblEMail.ForeColor = Color.FromArgb(138, 104, 86);
            lblEMail.Location = new Point(51, 105);
            lblEMail.Name = "lblEMail";
            lblEMail.Size = new Size(63, 28);
            lblEMail.TabIndex = 32;
            lblEMail.Text = "Email:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblPassword.ForeColor = Color.FromArgb(138, 104, 86);
            lblPassword.Location = new Point(51, 266);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(97, 28);
            lblPassword.TabIndex = 31;
            lblPassword.Text = "Password:";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsername.ForeColor = Color.FromArgb(138, 104, 86);
            lblUsername.Location = new Point(51, 184);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(103, 28);
            lblUsername.TabIndex = 30;
            lblUsername.Text = "Username:";
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            lblLogin.ForeColor = Color.FromArgb(138, 104, 86);
            lblLogin.Location = new Point(51, 56);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(88, 38);
            lblLogin.TabIndex = 29;
            lblLogin.Text = "Login";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(231, 223, 198);
            ClientSize = new Size(814, 491);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            ShowInTaskbar = false;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel1;
        private Label lblWarning;
        private Button btnHidePass;
        private Button buttonLogin;
        private TextBox textBoxPassword;
        private TextBox textBoxUsername;
        private TextBox textBoxEmail;
        private Label lblEMail;
        private Label lblPassword;
        private Label lblUsername;
        private Label lblLogin;
    }
}