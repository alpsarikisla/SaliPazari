using DataAccessLayer;
using System;
using System.Collections;
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
            Cb_Doldur();
            Dgv_Doldur3();
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

        private void btn_KategoriEkle_Click(object sender, EventArgs e)
        {
            HizliKategoriEkle hke = new HizliKategoriEkle();
            DialogResult gelen =  hke.ShowDialog();
            //Enum ve switch kardeşliği

            switch (gelen)
            {
                case DialogResult.OK:
                    MessageBox.Show("Kategori eklendi", "Başarılı");
                    break;
                case DialogResult.Cancel:
                    MessageBox.Show("Kategori ekleme işlemi iptal edildi.", "İptal");
                    break;
                case DialogResult.Abort:
                    MessageBox.Show("Kategori eklenirken bir hata oluştu", "Hata");
                    break;
                default:
                    break;
            }

            Cb_Doldur();
        }
        private void Cb_Doldur()
        {
            cb_kategori.ValueMember = "ID";
            cb_kategori.DisplayMember = "Isim";
            cb_kategori.DataSource = db.Kategoriler.Where(x=> x.IsDeleted== false).ToList();
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
        private void Dgv_Doldur()
        {
            dgv_Urunler.Rows.Clear();
            dgv_Urunler.ColumnCount = 12;
            dgv_Urunler.Columns[0].Name = "No";
            dgv_Urunler.Columns[1].Name = "Barkod No";
            dgv_Urunler.Columns[2].Name = "Kategori Adı";
            dgv_Urunler.Columns[3].Name = "Marka Adı";
            dgv_Urunler.Columns[4].Name = "Firma Adı";
            dgv_Urunler.Columns[5].Name = "Ürün Adı";
            dgv_Urunler.Columns[6].Name = "Fiyat";
            dgv_Urunler.Columns[7].Name = "Stok";
            dgv_Urunler.Columns[8].Name = "Güvenlik Stoğu";
            dgv_Urunler.Columns[8].Width = 100;
            dgv_Urunler.Columns[9].Name = "Aktif";
            dgv_Urunler.Columns[10].Name = "Silinmiş";
            dgv_Urunler.Columns[11].Name = "Hızlı Satış";

            List<UrunlerView> urunlers = db.UrunlerView.ToList();
            foreach (UrunlerView item in urunlers)
            {
                ArrayList row = new ArrayList();
                row.Add(item.ID);
                row.Add(item.Ürün_Barkod);
                row.Add(item.Kategori_Adı);
                row.Add(item.Marka_Adı);
                row.Add(item.Firma_Adı);
                row.Add(item.Ürün_Adı);
                row.Add(item.Birim_Fiyat);
                row.Add(item.Stok);
                row.Add(item.Güvenlik_Stoğu);
                row.Add(item.Aktif);
                row.Add(item.Silinmis);
                row.Add(item.Hızlı_Satış);
                dgv_Urunler.Rows.Add(row.ToArray());
            }
        }
        private void Dgv_Doldur2()
        {
            dgv_Urunler.DataSource = db.UrunlerView.Select(x => new
            {
                ÜrunNo = x.ID,
                Barkod = x.Ürün_Barkod,
                Isim = x.Ürün_Adı,
                Kategori = x.Kategori_Adı,
            }).ToList();
        }
        private void Dgv_Doldur3()
        {
            var liste = db.Urunler.Select(x => new
            {
                No = x.ID,
                Barkod = x.BarkodNo,
                Kategori = x.Kategoriler.Isim,
                Marka = x.Markalar.Isim,
                Tedarikci = x.Tedarikciler.FirmaIsim,
                UrunAdi = x.UrunAdi,
                Fiyat = x.BirimFiyat,
                Stok = x.StokMiktari,
                GStok = x.GuvenlikStogu,
                Aktif = x.IsActive,
                HizliSatis = x.IsFastProduct
            });
            dgv_Urunler.Rows.Clear();
            dgv_Urunler.ColumnCount = 11;
            dgv_Urunler.Columns[0].Name = "No";
            dgv_Urunler.Columns[1].Name = "Barkod No";
            dgv_Urunler.Columns[2].Name = "Kategori Adı";
            dgv_Urunler.Columns[3].Name = "Marka Adı";
            dgv_Urunler.Columns[4].Name = "Firma Adı";
            dgv_Urunler.Columns[5].Name = "Ürün Adı";
            dgv_Urunler.Columns[6].Name = "Fiyat";
            dgv_Urunler.Columns[7].Name = "Stok";
            dgv_Urunler.Columns[8].Name = "Güvenlik Stoğu";
            dgv_Urunler.Columns[8].Width = 120;
            dgv_Urunler.Columns[9].Name = "Aktif";
            dgv_Urunler.Columns[10].Name = "Hızlı Satış";
            foreach (var item in liste)
            {
                ArrayList row = new ArrayList();
                row.Add(item.No);
                row.Add(item.Barkod);
                row.Add(item.Kategori);
                row.Add(item.Marka);
                row.Add(item.Tedarikci);
                row.Add(item.UrunAdi);
                row.Add(item.Fiyat);
                row.Add(item.Stok);
                row.Add(item.GStok);
                row.Add(item.Aktif);
                row.Add(item.HizliSatis);
                dgv_Urunler.Rows.Add(row.ToArray());
            }
        }
    }
}
