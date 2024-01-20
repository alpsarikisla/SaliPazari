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
    public partial class KategoriIslemleri : Form
    {
        DataModel dm = new DataModel();
        int kategoriID;
        public KategoriIslemleri()
        {
            //this.WindowState = FormWindowState.Maximized;
           
            InitializeComponent();
            GridDoldur();
        }

        private void KategoriIslemleri_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = dm.KategoriListele();

        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                Kategori kat = new Kategori();
                kat.Isim = tb_isim.Text;
                kat.Aciklama = tb_aciklama.Text;
                kat.IsActive = cb_aktif.Checked;
                int id = dm.KategoriEkle(kat);
                if (id != -1)
                {
                    GridDoldur();
                    MessageBox.Show($"Kategori {id} id numarası ile başarıyla eklendi", "Başarılı");
                }
                else
                {
                    MessageBox.Show("Kategori eklenirken bir hata oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Kategori adı boş bırakılmamalıdır", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }
        private void GridDoldur()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "No";
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].Name = "İsim";
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Name = "Açıklama";
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Name = "Durum";
            dataGridView1.Columns[3].Width = 80;

            List<Kategori> kategoriler = dm.KategoriListele();
            foreach (Kategori item in kategoriler)
            {
                ArrayList row = new ArrayList();
                row.Add(item.ID);
                row.Add(item.Isim);
                row.Add(item.Aciklama);
                row.Add(item.IsActiveStr);
                dataGridView1.Rows.Add(row.ToArray());
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int tiklananSatir = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                if (tiklananSatir != -1)
                {
                    contextMenuStrip1.Show(dataGridView1, new Point(e.X, e.Y));
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[tiklananSatir].Selected = true;
                    kategoriID = Convert.ToInt32(dataGridView1.Rows[tiklananSatir].Cells[0].Value);
                }
            }
        }

        private void TSMI_guncelle_Click(object sender, EventArgs e)
        {
            if (kategoriID != 0)
            {
                Kategori kat = dm.KategoriGetir(kategoriID);
                tb_ID.Text = kat.ID.ToString();
                tb_isim.Text = kat.Isim;
                tb_aciklama.Text = kat.Aciklama;
                cb_aktif.Checked = kat.IsActive;
                btn_guncelle.Visible = true;
              
            }
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                Kategori kat = dm.KategoriGetir(kategoriID);
                kat.Isim = tb_isim.Text;
                kat.Aciklama = tb_aciklama.Text;
                kat.IsActive = cb_aktif.Checked;
                if (dm.KategoriGuncelle(kat))
                {
                    Temizle();
                    GridDoldur();
                    MessageBox.Show(kategoriID + " ID'li Kategori Güncellendi", "Başarılı");
                }
                else
                {
                    MessageBox.Show("Kategori düzenlenirken bir hata oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Kategori adı boş bırakılmamalıdır", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

           
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void Temizle()
        {
            tb_aciklama.Text = tb_isim.Text = tb_ID.Text = "";
            cb_aktif.Checked = false;
            btn_guncelle.Visible = false;
        }

        private void TSMI_sil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(kategoriID + " ID'li kategori Silinecektir. Devam etmek istiyor musunuz?", "Veri Silinecek", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (dm.Sil("Kategoriler", kategoriID))
                {
                    GridDoldur();
                }
            }
            else
            {
                MessageBox.Show("Silme işlemi iptal edildi", "Bilgi");
            }
        }
    }
}
