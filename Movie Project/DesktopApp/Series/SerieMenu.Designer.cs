﻿namespace DesktopApp.Series
{
    partial class SerieMenu
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
            buttonSearch = new Button();
            buttonMoreInfo = new Button();
            buttonUpdate = new Button();
            buttonDelete = new Button();
            labelOrder = new Label();
            comboBoxOrder = new ComboBox();
            lblWarning = new Label();
            lblSearchMovies = new Label();
            textBoxSeriesTitle = new TextBox();
            labelSeriesTitle = new Label();
            listBoxViewSeries = new ListBox();
            panel1 = new Panel();
            btnView = new Button();
            btnAddSerie = new Button();
            panelDesktop = new Panel();
            panel1.SuspendLayout();
            panelDesktop.SuspendLayout();
            SuspendLayout();
            // 
            // buttonSearch
            // 
            buttonSearch.BackColor = Color.White;
            buttonSearch.FlatAppearance.BorderColor = Color.FromArgb(138, 104, 86);
            buttonSearch.FlatAppearance.BorderSize = 2;
            buttonSearch.FlatStyle = FlatStyle.Flat;
            buttonSearch.Font = new Font("MV Boli", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonSearch.ForeColor = Color.FromArgb(138, 104, 86);
            buttonSearch.Location = new Point(546, 215);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(263, 44);
            buttonSearch.TabIndex = 142;
            buttonSearch.Text = "Search";
            buttonSearch.UseVisualStyleBackColor = false;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // buttonMoreInfo
            // 
            buttonMoreInfo.BackColor = Color.White;
            buttonMoreInfo.FlatAppearance.BorderColor = Color.FromArgb(138, 104, 86);
            buttonMoreInfo.FlatAppearance.BorderSize = 2;
            buttonMoreInfo.FlatStyle = FlatStyle.Flat;
            buttonMoreInfo.Font = new Font("MV Boli", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonMoreInfo.ForeColor = Color.FromArgb(138, 104, 86);
            buttonMoreInfo.Location = new Point(12, 533);
            buttonMoreInfo.Name = "buttonMoreInfo";
            buttonMoreInfo.Size = new Size(203, 44);
            buttonMoreInfo.TabIndex = 141;
            buttonMoreInfo.Text = "More Info";
            buttonMoreInfo.UseVisualStyleBackColor = false;
            buttonMoreInfo.Click += buttonMoreInfo_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.BackColor = Color.White;
            buttonUpdate.FlatAppearance.BorderColor = Color.FromArgb(138, 104, 86);
            buttonUpdate.FlatAppearance.BorderSize = 2;
            buttonUpdate.FlatStyle = FlatStyle.Flat;
            buttonUpdate.Font = new Font("MV Boli", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonUpdate.ForeColor = Color.FromArgb(138, 104, 86);
            buttonUpdate.Location = new Point(306, 533);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(203, 44);
            buttonUpdate.TabIndex = 140;
            buttonUpdate.Text = "Update";
            buttonUpdate.UseVisualStyleBackColor = false;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.White;
            buttonDelete.FlatAppearance.BorderColor = Color.FromArgb(138, 104, 86);
            buttonDelete.FlatAppearance.BorderSize = 2;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Font = new Font("MV Boli", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonDelete.ForeColor = Color.FromArgb(138, 104, 86);
            buttonDelete.Location = new Point(606, 533);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(203, 44);
            buttonDelete.TabIndex = 139;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // labelOrder
            // 
            labelOrder.AutoSize = true;
            labelOrder.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelOrder.ForeColor = Color.FromArgb(138, 104, 86);
            labelOrder.Location = new Point(546, 117);
            labelOrder.Name = "labelOrder";
            labelOrder.Size = new Size(61, 25);
            labelOrder.TabIndex = 138;
            labelOrder.Text = "Order:";
            // 
            // comboBoxOrder
            // 
            comboBoxOrder.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxOrder.FormattingEnabled = true;
            comboBoxOrder.Location = new Point(546, 159);
            comboBoxOrder.Name = "comboBoxOrder";
            comboBoxOrder.Size = new Size(263, 33);
            comboBoxOrder.TabIndex = 137;
            // 
            // lblWarning
            // 
            lblWarning.AutoSize = true;
            lblWarning.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblWarning.ForeColor = Color.Maroon;
            lblWarning.Location = new Point(12, 92);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new Size(81, 25);
            lblWarning.TabIndex = 136;
            lblWarning.Text = "Warning";
            // 
            // lblSearchMovies
            // 
            lblSearchMovies.AutoSize = true;
            lblSearchMovies.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblSearchMovies.ForeColor = Color.FromArgb(138, 104, 86);
            lblSearchMovies.Location = new Point(546, 92);
            lblSearchMovies.Name = "lblSearchMovies";
            lblSearchMovies.Size = new Size(93, 25);
            lblSearchMovies.TabIndex = 135;
            lblSearchMovies.Text = "Search by:";
            // 
            // textBoxSeriesTitle
            // 
            textBoxSeriesTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxSeriesTitle.ForeColor = Color.FromArgb(60, 144, 137);
            textBoxSeriesTitle.Location = new Point(546, 145);
            textBoxSeriesTitle.Name = "textBoxSeriesTitle";
            textBoxSeriesTitle.Size = new Size(263, 31);
            textBoxSeriesTitle.TabIndex = 133;
            // 
            // labelSeriesTitle
            // 
            labelSeriesTitle.AutoSize = true;
            labelSeriesTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point);
            labelSeriesTitle.ForeColor = Color.FromArgb(138, 104, 86);
            labelSeriesTitle.Location = new Point(546, 117);
            labelSeriesTitle.Name = "labelSeriesTitle";
            labelSeriesTitle.Size = new Size(50, 25);
            labelSeriesTitle.TabIndex = 134;
            labelSeriesTitle.Text = "Title:";
            // 
            // listBoxViewSeries
            // 
            listBoxViewSeries.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            listBoxViewSeries.FormattingEnabled = true;
            listBoxViewSeries.ItemHeight = 23;
            listBoxViewSeries.Location = new Point(12, 120);
            listBoxViewSeries.Name = "listBoxViewSeries";
            listBoxViewSeries.Size = new Size(497, 395);
            listBoxViewSeries.TabIndex = 130;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(145, 190, 222);
            panel1.Controls.Add(btnView);
            panel1.Controls.Add(btnAddSerie);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(834, 67);
            panel1.TabIndex = 129;
            // 
            // btnView
            // 
            btnView.FlatAppearance.BorderSize = 0;
            btnView.FlatStyle = FlatStyle.Flat;
            btnView.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnView.ForeColor = Color.White;
            btnView.Location = new Point(409, 0);
            btnView.Name = "btnView";
            btnView.Size = new Size(425, 75);
            btnView.TabIndex = 10;
            btnView.Text = "View Series";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
            // 
            // btnAddSerie
            // 
            btnAddSerie.FlatAppearance.BorderSize = 0;
            btnAddSerie.FlatStyle = FlatStyle.Flat;
            btnAddSerie.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddSerie.ForeColor = Color.White;
            btnAddSerie.Location = new Point(3, 0);
            btnAddSerie.Name = "btnAddSerie";
            btnAddSerie.Size = new Size(424, 75);
            btnAddSerie.TabIndex = 9;
            btnAddSerie.Text = "Add Serie";
            btnAddSerie.UseVisualStyleBackColor = true;
            btnAddSerie.Click += btnAddSerie_Click;
            // 
            // panelDesktop
            // 
            panelDesktop.BackColor = Color.FromArgb(231, 223, 198);
            panelDesktop.Controls.Add(buttonSearch);
            panelDesktop.Controls.Add(labelOrder);
            panelDesktop.Controls.Add(comboBoxOrder);
            panelDesktop.Dock = DockStyle.Bottom;
            panelDesktop.Location = new Point(0, 62);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new Size(834, 521);
            panelDesktop.TabIndex = 143;
            // 
            // SerieMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(231, 223, 198);
            ClientSize = new Size(834, 583);
            Controls.Add(buttonMoreInfo);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonDelete);
            Controls.Add(lblWarning);
            Controls.Add(lblSearchMovies);
            Controls.Add(textBoxSeriesTitle);
            Controls.Add(labelSeriesTitle);
            Controls.Add(listBoxViewSeries);
            Controls.Add(panel1);
            Controls.Add(panelDesktop);
            ForeColor = Color.FromArgb(138, 104, 86);
            Name = "SerieMenu";
            Text = "SerieMenu";
            panel1.ResumeLayout(false);
            panelDesktop.ResumeLayout(false);
            panelDesktop.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonSearch;
        private Button buttonMoreInfo;
        private Button buttonUpdate;
        private Button buttonDelete;
        private Label labelOrder;
        private ComboBox comboBoxOrder;
        private Label lblWarning;
        private Label lblSearchMovies;
        private TextBox textBoxSeriesTitle;
        private Label labelSeriesTitle;
        private ListBox listBoxViewSeries;
        private Panel panel1;
        private Button btnView;
        private Button btnAddSerie;
        private Panel panelDesktop;
    }
}