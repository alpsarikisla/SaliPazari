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
    
    public partial class SatisDetaylar
    {
        public int ID { get; set; }
        public Nullable<int> Satis_ID { get; set; }
        public Nullable<int> Urun_ID { get; set; }
        public Nullable<int> Adet { get; set; }
        public Nullable<decimal> Fiyat { get; set; }
    
        public virtual Satislar Satislar { get; set; }
        public virtual Urunler Urunler { get; set; }
    }
}
