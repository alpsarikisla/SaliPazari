namespace SaliPazariWinformsApp
{
    partial class HizliKategoriEkle
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
            this.tb_kategori = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ekle = new System.Windows.Forms.Button();
            this.btn_iptal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_kategori
            // 
            this.tb_kategori.Location = new System.Drawing.Point(15, 40);
            this.tb_kategori.Name = "tb_kategori";
            this.tb_kategori.Size = new System.Drawing.Size(268, 20);
            this.tb_kategori.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kategori Adı";
            // 
            // btn_ekle
            // 
            this.btn_ekle.Location = new System.Drawing.Point(127, 66);
            this.btn_ekle.Name = "btn_ekle";
            this.btn_ekle.Size = new System.Drawing.Size(75, 23);
            this.btn_ekle.TabIndex = 2;
            this.btn_ekle.Text = "Ekle";
            this.btn_ekle.UseVisualStyleBackColor = true;
            this.btn_ekle.Click += new System.EventHandler(this.btn_ekle_Click);
            // 
            // btn_iptal
            // 
            this.btn_iptal.Location = new System.Drawing.Point(208, 66);
            this.btn_iptal.Name = "btn_iptal";
            this.btn_iptal.Size = new System.Drawing.Size(75, 23);
            this.btn_iptal.TabIndex = 3;
            this.btn_iptal.Text = "İptal";
            this.btn_iptal.UseVisualStyleBackColor = true;
            this.btn_iptal.Click += new System.EventHandler(this.btn_iptal_Click);
            // 
            // HizliKategoriEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 105);
            this.Controls.Add(this.btn_iptal);
            this.Controls.Add(this.btn_ekle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_kategori);
            this.Name = "HizliKategoriEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hızlı Kategori Ekle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_kategori;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ekle;
        private System.Windows.Forms.Button btn_iptal;
    }
}