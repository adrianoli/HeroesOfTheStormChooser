namespace HeroesOfTheStormChooser.Configuration
{
    partial class AddHeroesToList
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
            this.uiBtnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uiBtnOk
            // 
            this.uiBtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiBtnOk.Location = new System.Drawing.Point(1404, 815);
            this.uiBtnOk.Name = "uiBtnOk";
            this.uiBtnOk.Size = new System.Drawing.Size(75, 23);
            this.uiBtnOk.TabIndex = 0;
            this.uiBtnOk.Text = "OK";
            this.uiBtnOk.UseVisualStyleBackColor = true;
            this.uiBtnOk.Click += new System.EventHandler(this.uiBtnOk_Click);
            // 
            // AddHeroesToList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1491, 850);
            this.Controls.Add(this.uiBtnOk);
            this.MinimumSize = new System.Drawing.Size(1507, 889);
            this.Name = "AddHeroesToList";
            this.Text = "AddHeroesToList";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AddHeroesToList_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uiBtnOk;
    }
}