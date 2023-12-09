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
    public partial class KullaniciGiris : Form
    {
        bool girisyapildi = false;
        DataModel dm = new DataModel();
        public KullaniciGiris()
        {
            InitializeComponent();
        }

        private void btn_giris_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_kullaniciAdi.Text) && !string.IsNullOrEmpty(tb_sifre.Text))
            {
                Yonetici y = dm.YoneticiGiris(tb_kullaniciAdi.Text, tb_sifre.Text);
                if (y!= null)
                {
                    if (y.IsActive == true)
                    {
                        girisyapildi = true;
                        Helpers.GirisYapanYonetici = y;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı hesabınız kapatıldı", "Dikkat.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Bilgilerinizi kontrol ediniz", "Kullanıcı bulunamadı.",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş bırakılamaz", "Giriş yapılamadı.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_kapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void KullaniciGiris_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!girisyapildi)
            {
                Application.Exit();
            }
        }
    }
}
