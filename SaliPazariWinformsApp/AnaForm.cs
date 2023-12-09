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
    }
}
