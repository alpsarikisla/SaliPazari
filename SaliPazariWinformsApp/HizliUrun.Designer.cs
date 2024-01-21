namespace SaliPazariWinformsApp
{
    partial class HizliUrun
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pb_resim = new System.Windows.Forms.PictureBox();
            this.lbl_UrunAd = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_resim)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_resim
            // 
            this.pb_resim.Location = new System.Drawing.Point(3, 3);
            this.pb_resim.Name = "pb_resim";
            this.pb_resim.Size = new System.Drawing.Size(125, 86);
            this.pb_resim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_resim.TabIndex = 0;
            this.pb_resim.TabStop = false;
            // 
            // lbl_UrunAd
            // 
            this.lbl_UrunAd.AutoSize = true;
            this.lbl_UrunAd.Location = new System.Drawing.Point(3, 92);
            this.lbl_UrunAd.Name = "lbl_UrunAd";
            this.lbl_UrunAd.Size = new System.Drawing.Size(35, 13);
            this.lbl_UrunAd.TabIndex = 1;
            this.lbl_UrunAd.Text = "label1";
            // 
            // HizliUrun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbl_UrunAd);
            this.Controls.Add(this.pb_resim);
            this.Name = "HizliUrun";
            this.Size = new System.Drawing.Size(129, 124);
            ((System.ComponentModel.ISupportInitialize)(this.pb_resim)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pb_resim;
        public System.Windows.Forms.Label lbl_UrunAd;
    }
}
