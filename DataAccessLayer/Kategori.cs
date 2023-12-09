using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Kategori
    {
        public int ID { get; set; }
        public string Isim { get; set; }
        public string Aciklama { get; set; }
        public bool IsActive { get; set; }
        public string IsActiveStr { get; set; }
        public bool IsDeleted { get; set; }
        public string IsDeletedStr { get; set; }

        public Kategori() { }
        public Kategori(int id, string isim, string aciklama,  bool isactive, bool isdelted)
        {
            this.ID = id;
            this.Isim = isim;
            this.Aciklama = aciklama;
            this.IsDeleted = isdelted;
            this.IsActive = isactive;
        }
    }
}
