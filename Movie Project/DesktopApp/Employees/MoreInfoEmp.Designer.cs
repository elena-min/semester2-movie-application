namespace DesktopApp.Employees
{
    partial class MoreInfoEmp
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
            labelGender = new Label();
            labelAge = new Label();
            labelLName = new Label();
            labelEmail = new Label();
            labelUsername = new Label();
            labelFName = new Label();
            lblGender = new Label();
            lblLName = new Label();
            lblEmail = new Label();
            lblUsername = new Label();
            lblFName = new Label();
            lblAge = new Label();
            SuspendLayout();
            // 
            // labelGender
            // 
            labelGender.AutoSize = true;
            labelGender.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            labelGender.Location = new Point(613, 95);
            labelGender.Name = "labelGender";
            labelGender.Size = new Size(80, 25);
            labelGender.TabIndex = 152;
            labelGender.Text = "Gender:";
            // 
            // labelAge
            // 
            labelAge.AutoSize = true;
            labelAge.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            labelAge.Location = new Point(613, 23);
            labelAge.Name = "labelAge";
            labelAge.Size = new Size(51, 25);
            labelAge.TabIndex = 151;
            labelAge.Text = "Age:";
            // 
            // labelLName
            // 
            labelLName.AutoSize = true;
            labelLName.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            labelLName.Location = new Point(120, 95);
            labelLName.Name = "labelLName";
            labelLName.Size = new Size(103, 25);
            labelLName.TabIndex = 150;
            labelLName.Text = "Last name:";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            labelEmail.Location = new Point(120, 240);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(63, 25);
            labelEmail.TabIndex = 149;
            labelEmail.Text = "Email:";
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            labelUsername.Location = new Point(120, 167);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(102, 25);
            labelUsername.TabIndex = 148;
            labelUsername.Text = "Username:";
            // 
            // labelFName
            // 
            labelFName.AutoSize = true;
            labelFName.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            labelFName.Location = new Point(118, 23);
            labelFName.Name = "labelFName";
            labelFName.Size = new Size(105, 25);
            labelFName.TabIndex = 147;
            labelFName.Text = "First name:";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            lblGender.Location = new Point(535, 95);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(72, 25);
            lblGender.TabIndex = 146;
            lblGender.Text = "Gender:";
            // 
            // lblLName
            // 
            lblLName.AutoSize = true;
            lblLName.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            lblLName.Location = new Point(14, 95);
            lblLName.Name = "lblLName";
            lblLName.Size = new Size(96, 25);
            lblLName.TabIndex = 145;
            lblLName.Text = "Last name:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            lblEmail.Location = new Point(50, 240);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(60, 25);
            lblEmail.TabIndex = 144;
            lblEmail.Text = "Email:";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            lblUsername.Location = new Point(16, 167);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(94, 25);
            lblUsername.TabIndex = 143;
            lblUsername.Text = "Username:";
            // 
            // lblFName
            // 
            lblFName.AutoSize = true;
            lblFName.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            lblFName.Location = new Point(14, 23);
            lblFName.Name = "lblFName";
            lblFName.Size = new Size(98, 25);
            lblFName.TabIndex = 142;
            lblFName.Text = "First name:";
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            lblAge.Location = new Point(561, 23);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(46, 25);
            lblAge.TabIndex = 141;
            lblAge.Text = "Age:";
            // 
            // MoreInfoEmp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(231, 223, 198);
            ClientSize = new Size(734, 286);
            Controls.Add(labelGender);
            Controls.Add(labelAge);
            Controls.Add(labelLName);
            Controls.Add(labelEmail);
            Controls.Add(labelUsername);
            Controls.Add(labelFName);
            Controls.Add(lblGender);
            Controls.Add(lblLName);
            Controls.Add(lblEmail);
            Controls.Add(lblUsername);
            Controls.Add(lblFName);
            Controls.Add(lblAge);
            ForeColor = Color.FromArgb(138, 104, 86);
            Name = "MoreInfoEmp";
            Text = "MoreInfoEmp";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelGender;
        private Label labelAge;
        private Label labelLName;
        private Label labelEmail;
        private Label labelUsername;
        private Label labelFName;
        private Label lblGender;
        private Label lblLName;
        private Label lblEmail;
        private Label lblUsername;
        private Label lblFName;
        private Label lblAge;
    }
}