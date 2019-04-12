namespace HeroesOfTheStormChooser.Configuration
{
    partial class HeroConfiguration
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
            this.uiPbPhoto = new System.Windows.Forms.PictureBox();
            this.uiLblName = new System.Windows.Forms.Label();
            this.uiLblRole = new System.Windows.Forms.Label();
            this.uiTxtName = new System.Windows.Forms.TextBox();
            this.uiCmbRole = new System.Windows.Forms.ComboBox();
            this.uiBtnStrong = new System.Windows.Forms.Button();
            this.uiBtnCrowdControl = new System.Windows.Forms.Button();
            this.uiBtnCounters = new System.Windows.Forms.Button();
            this.uiBtnSynergizes = new System.Windows.Forms.Button();
            this.uiBtnGoodMaps = new System.Windows.Forms.Button();
            this.uiBtnWeakMaps = new System.Windows.Forms.Button();
            this.uiBtnSave = new System.Windows.Forms.Button();
            this.uiBtnAdd = new System.Windows.Forms.Button();
            this.uiLblPathPicture = new System.Windows.Forms.Label();
            this.uiTxtPathToPicture = new System.Windows.Forms.TextBox();
            this.uiBtnBrowse = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uiPbPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // uiPbPhoto
            // 
            this.uiPbPhoto.Location = new System.Drawing.Point(12, 12);
            this.uiPbPhoto.Name = "uiPbPhoto";
            this.uiPbPhoto.Size = new System.Drawing.Size(182, 191);
            this.uiPbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.uiPbPhoto.TabIndex = 0;
            this.uiPbPhoto.TabStop = false;
            // 
            // uiLblName
            // 
            this.uiLblName.AutoSize = true;
            this.uiLblName.Location = new System.Drawing.Point(200, 12);
            this.uiLblName.Name = "uiLblName";
            this.uiLblName.Size = new System.Drawing.Size(43, 13);
            this.uiLblName.TabIndex = 1;
            this.uiLblName.Text = "Nazwa:";
            // 
            // uiLblRole
            // 
            this.uiLblRole.AutoSize = true;
            this.uiLblRole.Location = new System.Drawing.Point(200, 45);
            this.uiLblRole.Name = "uiLblRole";
            this.uiLblRole.Size = new System.Drawing.Size(35, 13);
            this.uiLblRole.TabIndex = 2;
            this.uiLblRole.Text = "Rola: ";
            // 
            // uiTxtName
            // 
            this.uiTxtName.Location = new System.Drawing.Point(314, 9);
            this.uiTxtName.Name = "uiTxtName";
            this.uiTxtName.Size = new System.Drawing.Size(201, 20);
            this.uiTxtName.TabIndex = 4;
            // 
            // uiCmbRole
            // 
            this.uiCmbRole.FormattingEnabled = true;
            this.uiCmbRole.Location = new System.Drawing.Point(314, 45);
            this.uiCmbRole.Name = "uiCmbRole";
            this.uiCmbRole.Size = new System.Drawing.Size(201, 21);
            this.uiCmbRole.TabIndex = 5;
            // 
            // uiBtnStrong
            // 
            this.uiBtnStrong.Location = new System.Drawing.Point(241, 224);
            this.uiBtnStrong.Name = "uiBtnStrong";
            this.uiBtnStrong.Size = new System.Drawing.Size(108, 23);
            this.uiBtnStrong.TabIndex = 7;
            this.uiBtnStrong.Text = "Silny przeciwko";
            this.uiBtnStrong.UseVisualStyleBackColor = true;
            this.uiBtnStrong.Click += new System.EventHandler(this.uiBtnStrong_Click);
            // 
            // uiBtnCrowdControl
            // 
            this.uiBtnCrowdControl.Location = new System.Drawing.Point(13, 224);
            this.uiBtnCrowdControl.Name = "uiBtnCrowdControl";
            this.uiBtnCrowdControl.Size = new System.Drawing.Size(107, 23);
            this.uiBtnCrowdControl.TabIndex = 8;
            this.uiBtnCrowdControl.Text = "Kontrola tłumu";
            this.uiBtnCrowdControl.UseVisualStyleBackColor = true;
            this.uiBtnCrowdControl.Click += new System.EventHandler(this.uiBtnCrowdControl_Click);
            // 
            // uiBtnCounters
            // 
            this.uiBtnCounters.Location = new System.Drawing.Point(355, 224);
            this.uiBtnCounters.Name = "uiBtnCounters";
            this.uiBtnCounters.Size = new System.Drawing.Size(107, 23);
            this.uiBtnCounters.TabIndex = 9;
            this.uiBtnCounters.Text = "Kontrowany przez";
            this.uiBtnCounters.UseVisualStyleBackColor = true;
            this.uiBtnCounters.Click += new System.EventHandler(this.uiBtnCounters_Click);
            // 
            // uiBtnSynergizes
            // 
            this.uiBtnSynergizes.Location = new System.Drawing.Point(126, 224);
            this.uiBtnSynergizes.Name = "uiBtnSynergizes";
            this.uiBtnSynergizes.Size = new System.Drawing.Size(109, 23);
            this.uiBtnSynergizes.TabIndex = 10;
            this.uiBtnSynergizes.Text = "Współpracujący z";
            this.uiBtnSynergizes.UseVisualStyleBackColor = true;
            this.uiBtnSynergizes.Click += new System.EventHandler(this.uiBtnSynergizes_Click);
            // 
            // uiBtnGoodMaps
            // 
            this.uiBtnGoodMaps.Location = new System.Drawing.Point(13, 253);
            this.uiBtnGoodMaps.Name = "uiBtnGoodMaps";
            this.uiBtnGoodMaps.Size = new System.Drawing.Size(107, 23);
            this.uiBtnGoodMaps.TabIndex = 11;
            this.uiBtnGoodMaps.Text = "Dobry na mapach";
            this.uiBtnGoodMaps.UseVisualStyleBackColor = true;
            this.uiBtnGoodMaps.Click += new System.EventHandler(this.uiBtnGoodMaps_Click);
            // 
            // uiBtnWeakMaps
            // 
            this.uiBtnWeakMaps.Location = new System.Drawing.Point(126, 253);
            this.uiBtnWeakMaps.Name = "uiBtnWeakMaps";
            this.uiBtnWeakMaps.Size = new System.Drawing.Size(109, 23);
            this.uiBtnWeakMaps.TabIndex = 12;
            this.uiBtnWeakMaps.Text = "Słaby na mapach";
            this.uiBtnWeakMaps.UseVisualStyleBackColor = true;
            this.uiBtnWeakMaps.Click += new System.EventHandler(this.uiBtnWeakMaps_Click);
            // 
            // uiBtnSave
            // 
            this.uiBtnSave.Location = new System.Drawing.Point(487, 326);
            this.uiBtnSave.Name = "uiBtnSave";
            this.uiBtnSave.Size = new System.Drawing.Size(75, 23);
            this.uiBtnSave.TabIndex = 13;
            this.uiBtnSave.Text = "Zapisz";
            this.uiBtnSave.UseVisualStyleBackColor = true;
            this.uiBtnSave.Click += new System.EventHandler(this.uiBtnSave_Click);
            // 
            // uiBtnAdd
            // 
            this.uiBtnAdd.Location = new System.Drawing.Point(487, 326);
            this.uiBtnAdd.Name = "uiBtnAdd";
            this.uiBtnAdd.Size = new System.Drawing.Size(75, 23);
            this.uiBtnAdd.TabIndex = 14;
            this.uiBtnAdd.Text = "Dodaj";
            this.uiBtnAdd.UseVisualStyleBackColor = true;
            this.uiBtnAdd.Click += new System.EventHandler(this.uiBtnAdd_Click);
            // 
            // uiLblPathPicture
            // 
            this.uiLblPathPicture.AutoSize = true;
            this.uiLblPathPicture.Location = new System.Drawing.Point(200, 85);
            this.uiLblPathPicture.Name = "uiLblPathPicture";
            this.uiLblPathPicture.Size = new System.Drawing.Size(88, 13);
            this.uiLblPathPicture.TabIndex = 15;
            this.uiLblPathPicture.Text = "Ścieżka do pliku:";
            // 
            // uiTxtPathToPicture
            // 
            this.uiTxtPathToPicture.Enabled = false;
            this.uiTxtPathToPicture.Location = new System.Drawing.Point(314, 82);
            this.uiTxtPathToPicture.Name = "uiTxtPathToPicture";
            this.uiTxtPathToPicture.Size = new System.Drawing.Size(201, 20);
            this.uiTxtPathToPicture.TabIndex = 16;
            // 
            // uiBtnBrowse
            // 
            this.uiBtnBrowse.Image = global::HeroesOfTheStormChooser.Properties.Resources.BrowseImage_16;
            this.uiBtnBrowse.Location = new System.Drawing.Point(521, 77);
            this.uiBtnBrowse.Name = "uiBtnBrowse";
            this.uiBtnBrowse.Size = new System.Drawing.Size(41, 28);
            this.uiBtnBrowse.TabIndex = 17;
            this.uiBtnBrowse.UseVisualStyleBackColor = true;
            this.uiBtnBrowse.Click += new System.EventHandler(this.uiBtnBrowse_Click);
            // 
            // HeroConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 361);
            this.Controls.Add(this.uiBtnBrowse);
            this.Controls.Add(this.uiTxtPathToPicture);
            this.Controls.Add(this.uiLblPathPicture);
            this.Controls.Add(this.uiBtnAdd);
            this.Controls.Add(this.uiBtnSave);
            this.Controls.Add(this.uiBtnWeakMaps);
            this.Controls.Add(this.uiBtnGoodMaps);
            this.Controls.Add(this.uiBtnSynergizes);
            this.Controls.Add(this.uiBtnCounters);
            this.Controls.Add(this.uiBtnCrowdControl);
            this.Controls.Add(this.uiBtnStrong);
            this.Controls.Add(this.uiCmbRole);
            this.Controls.Add(this.uiTxtName);
            this.Controls.Add(this.uiLblRole);
            this.Controls.Add(this.uiLblName);
            this.Controls.Add(this.uiPbPhoto);
            this.MaximumSize = new System.Drawing.Size(590, 400);
            this.MinimumSize = new System.Drawing.Size(590, 400);
            this.Name = "HeroConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Konfiguracja bohatera";
            ((System.ComponentModel.ISupportInitialize)(this.uiPbPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox uiPbPhoto;
        private System.Windows.Forms.Label uiLblName;
        private System.Windows.Forms.Label uiLblRole;
        private System.Windows.Forms.TextBox uiTxtName;
        private System.Windows.Forms.ComboBox uiCmbRole;
        private System.Windows.Forms.Button uiBtnStrong;
        private System.Windows.Forms.Button uiBtnCrowdControl;
        private System.Windows.Forms.Button uiBtnCounters;
        private System.Windows.Forms.Button uiBtnSynergizes;
        private System.Windows.Forms.Button uiBtnGoodMaps;
        private System.Windows.Forms.Button uiBtnWeakMaps;
        private System.Windows.Forms.Button uiBtnSave;
        private System.Windows.Forms.Button uiBtnAdd;
        private System.Windows.Forms.Label uiLblPathPicture;
        private System.Windows.Forms.TextBox uiTxtPathToPicture;
        private System.Windows.Forms.Button uiBtnBrowse;
    }
}