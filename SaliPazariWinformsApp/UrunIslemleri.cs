using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaliPazariWinformsApp
{
    public partial class UrunIslemleri : Form
    {
        SaliPazari_DBEntities db = new SaliPazari_DBEntities();
        string imagePath;
        public UrunIslemleri()
        {
            InitializeComponent();
            openFileDialog1.Filter = "jpeg Resmi|*.jpg|png Resmi|*.png";
        }

        private void UrunIslemleri_Load(object sender, EventArgs e)
        {
            cb_kategori.ValueMember = "ID";
            cb_kategori.DisplayMember = "Isim";
            cb_kategori.DataSource = db.Kategoriler.ToList();
            cb_kategori.Text = "Seçiniz...";

            cb_marka.ValueMember = "ID";
            cb_marka.DisplayMember = "Isim";
            cb_marka.DataSource = db.Markalar.ToList();
            cb_marka.Text = "Seçiniz...";

            cb_Tedarikci.ValueMember = "ID";
            cb_Tedarikci.DisplayMember = "FirmaIsim";
            cb_Tedarikci.DataSource = db.Tedarikciler.ToList();
            cb_Tedarikci.Text = "Seçiniz...";
          
        }

        private void btn_resimSec_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog1.FileName;
                pictureBox1.ImageLocation = imagePath;
            }
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            Urunler u = new Urunler();
            u.BarkodNo = tb_barkod.Text;
            u.BirimFiyat = nu_fiyat.Value;
            u.GuvenlikStogu = Convert.ToInt32(nu_GuvenlikStok.Value);
            u.IsActive = cb_aktif.Checked;
            u.IsDeleted = false;
            u.IsFastProduct = cb_hizli.Checked;
            u.Kategori_ID = Convert.ToInt32(cb_kategori.SelectedValue);
            u.Marka_ID = Convert.ToInt32(cb_marka.SelectedValue);
            if (!string.IsNullOrEmpty(imagePath))
            {
                FileInfo fi = new FileInfo(imagePath);
                string isim = Guid.NewGuid().ToString() + fi.Extension;
                fi.CopyTo("../../UrunResim/" + isim);
                u.Resim = isim;
            }
            else
            {
                u.Resim = "none.gif";
            }
            u.StokMiktari = 0;
            u.Tedarikci_ID = Convert.ToInt32(cb_Tedarikci.SelectedValue);
            u.UrunAdi = tb_urunAdi.Text;
            try
            {
                db.Urunler.Add(u);
                db.SaveChanges();
                MessageBox.Show($"Ürün {u.ID} id ile eklenmiştir");
            }
            catch
            {
                MessageBox.Show("Hata Oluştu");
            }
        }
    }
}
