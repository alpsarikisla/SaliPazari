using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Marka
    {
        public int ID { get; set; }
        public string Isim { get; set; }
        public bool IsActive { get; set; }
        public string IsActiveStr { get; set; }
        public bool IsDeleted { get; set; }
        public string IsDeletedStr { get; set; }

    }
}
