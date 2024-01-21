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
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            KullaniciGiris frm = new KullaniciGiris();
            frm.ShowDialog();
            InitializeComponent();
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            TSSL_kullanici.Text = Helpers.GirisYapanYonetici.KullaniciAdi + "(" + Helpers.GirisYapanYonetici.YetkiIsim + ")";
        }

        private void TSMI_KategoriForm_Click(object sender, EventArgs e)
        {
            Form[] acikformlar = this.MdiChildren;

            bool acikmi = false;

            foreach (Form item in acikformlar)
            {
                if (item.GetType() == typeof(KategoriIslemleri))
                {
                    item.Activate();
                    acikmi = true;
                }
            }
            if (acikmi == false)
            {
                KategoriIslemleri frm = new KategoriIslemleri();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void TSMI_UrunForm_Click(object sender, EventArgs e)
        {
            Form[] acikformlar = this.MdiChildren;

            bool acikmi = false;

            foreach (Form item in acikformlar)
            {
                if (item.GetType() == typeof(UrunIslemleri))
                {
                    item.Activate();
                    acikmi = true;
                }
            }
            if (acikmi == false)
            {
                UrunIslemleri frm = new UrunIslemleri();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void TSMI_Markalar_Click(object sender, EventArgs e)
        {
            Form[] acikformlar = this.MdiChildren;

            bool acikmi = false;

            foreach (Form item in acikformlar)
            {
                if (item.GetType() == typeof(MarkaIslemleri))
                {
                    item.Activate();
                    acikmi = true;
                }
            }
            if (acikmi == false)
            {
                MarkaIslemleri frm = new MarkaIslemleri();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void TSMI_satisYap_Click(object sender, EventArgs e)
        {
            Form[] acikformlar = this.MdiChildren;

            bool acikmi = false;

            foreach (Form item in acikformlar)
            {
                if (item.GetType() == typeof(SatisModulu))
                {
                    item.Activate();
                    acikmi = true;
                }
            }
            if (acikmi == false)
            {
                SatisModulu frm = new SatisModulu();
                frm.MdiParent = this;
                frm.Show();
            }
        }
    }
}
