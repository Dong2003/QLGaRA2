//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestG.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TonKho
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TonKho()
        {
            this.CTTonKhoes = new HashSet<CTTonKho>();
        }
    
        public int IDTonKho { get; set; }
        public Nullable<int> IDUser { get; set; }
        public Nullable<System.DateTime> NgayLap { get; set; }
    
        public virtual ChiTietUser ChiTietUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTTonKho> CTTonKhoes { get; set; }
    }
}
