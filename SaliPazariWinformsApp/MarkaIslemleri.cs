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
    public partial class MarkaIslemleri : Form
    {
        SaliPazari_DBEntities db = new SaliPazari_DBEntities();
        public MarkaIslemleri()
        {
            InitializeComponent();
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {

            Markalar m = new Markalar();
            m.Isim = tb_isim.Text;
            m.IsActive = cb_aktif.Checked;
            m.IsDeleted = false;
            db.Markalar.Add(m);
            try
            {
                db.SaveChanges();
                GridDoldur();
                MessageBox.Show("Marka " + m.ID + " ile başarıyla eklenmiştir");
            }
            catch
            {
                MessageBox.Show("Hata Oluştu");
            }
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {

        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {

        }

        private void MarkaIslemleri_Load(object sender, EventArgs e)
        {
            GridDoldur();
        }

        private void TSMI_guncelle_Click(object sender, EventArgs e)
        {

        }

        private void TSMI_sil_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

        }
        public void GridDoldur()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "No";
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].Name = "İsim";
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Name = "Durum";
            dataGridView1.Columns[2].Width = 80;

            List<Markalar> markalars = db.Markalar.ToList();
            foreach (Markalar item in markalars)
            {
                ArrayList row = new ArrayList();
                row.Add(item.ID);
                row.Add(item.Isim);
                row.Add(item.IsActive == true ? "Aktif": "Pasif");
                dataGridView1.Rows.Add(row.ToArray());
            }
        }
    }
}
