//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SaliPazariWinformsApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Satislar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Satislar()
        {
            this.SatisDetaylar = new HashSet<SatisDetaylar>();
        }
    
        public int ID { get; set; }
        public Nullable<int> Kasiyer_ID { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public string FaturaNo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SatisDetaylar> SatisDetaylar { get; set; }
        public virtual Yoneticiler Yoneticiler { get; set; }
    }
}
