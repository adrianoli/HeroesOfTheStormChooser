namespace HeroesOfTheStormChooser
{
    partial class ResultShow
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
            this.uiLblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uiLblInfo
            // 
            this.uiLblInfo.AutoSize = true;
            this.uiLblInfo.Location = new System.Drawing.Point(13, 13);
            this.uiLblInfo.Name = "uiLblInfo";
            this.uiLblInfo.Size = new System.Drawing.Size(170, 13);
            this.uiLblInfo.TabIndex = 0;
            this.uiLblInfo.Text = "Najlepsi bohaterowie do rozgrywki:";
            // 
            // ResultShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1434, 682);
            this.Controls.Add(this.uiLblInfo);
            this.Name = "ResultShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Najlepsze postacie pod daną rozgrywkę";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uiLblInfo;
    }
}