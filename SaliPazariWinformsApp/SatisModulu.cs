using DataAccessLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaliPazariWinformsApp
{
    public partial class SatisModulu : Form
    {
        SaliPazari_DBEntities db = new SaliPazari_DBEntities();

        List<SatisDetaylar> satilacaklar = new List<SatisDetaylar>();
        public SatisModulu()
        {
            InitializeComponent();
        }

        private void SatisModulu_Load(object sender, EventArgs e)
        {
            List<Urunler> HizliUrunler = db.Urunler.Where(x => x.IsFastProduct == true).ToList();
            foreach (Urunler item in HizliUrunler)
            {
                HizliUrun hu = new HizliUrun("../../UrunResim/" + item.Resim, item.UrunAdi, item.ID);
                flowLayoutPanel1.Controls.Add(hu);
                hu.Click += Hu_Click;
                hu.pb_resim.Click += Pb_resim_Click; ;
                hu.lbl_UrunAd.Click += Lbl_UrunAd_Click;
            }
        }

        private void Lbl_UrunAd_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            HizliUrun hu = lbl.Parent as HizliUrun;
            HizliEkle(hu.id);
        }

        private void Pb_resim_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            HizliUrun hu = pb.Parent as HizliUrun;
            HizliEkle(hu.id);
        }

        private void Hu_Click(object sender, EventArgs e)
        {
            HizliUrun hu = sender as HizliUrun;
            HizliEkle(hu.id);
        }
        private void HizliEkle(int id)
        {
            Urunler u = db.Urunler.Find(id);
            tb_urunFiyat.Text = u.BirimFiyat.ToString();
            bool varmi = false;
            foreach (SatisDetaylar item in satilacaklar)
            {
                if (item.Urun_ID == u.ID)
                {
                    item.Adet += Convert.ToInt32(tb_Adet.Text);
                    varmi = true;
                    tb_Adet.Text = "1";
                }
            }
            if (varmi == false)
            {
                SatisDetaylar sd = new SatisDetaylar();
                sd.Adet = 0;
                sd.Urunler = u;
                sd.Adet += Convert.ToInt32(tb_Adet.Text);
                sd.Urun_ID = u.ID;
                sd.Fiyat = u.BirimFiyat;
                satilacaklar.Add(sd);
            }
            GridDoldur();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Urunler u = db.Urunler.FirstOrDefault(x => x.BarkodNo == tb_barkod.Text);
                if (u != null)
                {
                    tb_urunFiyat.Text = u.BirimFiyat.ToString();
                    bool varmi = false;
                    foreach (SatisDetaylar item in satilacaklar)
                    {
                        if (item.Urun_ID == u.ID)
                        {
                            item.Adet += item.Adet += Convert.ToInt32(tb_Adet.Text); ;
                            varmi = true;
                        }
                    }
                    if (varmi == false)
                    {
                        SatisDetaylar sd = new SatisDetaylar();
                        sd.Adet = 0;
                        sd.Urunler = u;
                        sd.Adet += 1;
                        sd.Urun_ID = u.ID;
                        sd.Fiyat = u.BirimFiyat;
                        satilacaklar.Add(sd);
                    }
                    GridDoldur();
                    tb_Adet.Text = "1";
                }
                else
                {
                    MessageBox.Show("Urun Bulunamadı. Barkod Tanımsız", "Tanımsız Ürün", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                tb_barkod.Clear();
            }
        }
        private void GridDoldur()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Barkod";
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].Name = "Ürün Adı";
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Name = "Fiyat";
            dataGridView1.Columns[2].Width = 60;
            dataGridView1.Columns[3].Name = "Adet";
            dataGridView1.Columns[3].Width = 60;

            foreach (SatisDetaylar item in satilacaklar)
            {
                ArrayList row = new ArrayList();
                row.Add(item.Urunler.BarkodNo);
                row.Add(item.Urunler.UrunAdi);
                row.Add(item.Urunler.BirimFiyat);
                row.Add(item.Adet);
                dataGridView1.Rows.Add(row.ToArray());
            }

            tb_satisToplam.Text = satilacaklar.Sum(x => x.Adet * x.Urunler.BirimFiyat).ToString();
        }

        private void btn_nakit_Click(object sender, EventArgs e)
        {
            Satislar satis = new Satislar();
            satis.Kasiyer_ID = Helpers.GirisYapanYonetici.ID;
            satis.Tarih = DateTime.Now;
            satis.FaturaNo = Guid.NewGuid().ToString().Substring(0, 10);
            db.Satislar.Add(satis);
            db.SaveChanges();

            foreach (SatisDetaylar item in satilacaklar)
            {
                item.Satis_ID = satis.ID;
                db.SatisDetaylar.Add(item);
            }
            db.SaveChanges();
            MessageBox.Show("Satış Tamamalandı", "Satış Kapatıldı");

            dataGridView1.Rows.Clear();
            tb_satisToplam.Text = "0,00";
            tb_urunFiyat.Text = "0,00";
            satilacaklar.Clear();

        }
    }
}
