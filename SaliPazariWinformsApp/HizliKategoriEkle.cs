using DataAccessLayer;
using System;
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
    public partial class HizliKategoriEkle : Form
    {
        SaliPazari_DBEntities db = new SaliPazari_DBEntities();
        public HizliKategoriEkle()
        {
            InitializeComponent();
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            Kategoriler k = new Kategoriler();
            if (!string.IsNullOrEmpty(tb_kategori.Text))
            {
                k.Isim = tb_kategori.Text;
                k.IsActive = true;
                k.IsDeleted = false;
                try
                {
                    db.Kategoriler.Add(k);
                    db.SaveChanges();
                    this.DialogResult = DialogResult.OK;
                }
                catch
                {
                    this.DialogResult = DialogResult.Abort;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("İsim Boş Bırakılamaz", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_iptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
