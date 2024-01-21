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
    public partial class HizliUrun : UserControl
    {
        public int id;

        public HizliUrun(string imagepath, string name, int id)
        {
            InitializeComponent();
            pb_resim.ImageLocation = imagepath;
            lbl_UrunAd.Text = name;
            this.id = id;
        }
    }
}
