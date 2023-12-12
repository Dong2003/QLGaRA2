namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThuongHieuXe")]
    public partial class ThuongHieuXe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThuongHieuXe()
        {
            ChiTietDoanhThus = new HashSet<ChiTietDoanhThu>();
            VatTus = new HashSet<VatTu>();
            TiepNhanXes = new HashSet<TiepNhanXe>();
        }

        [Key]
        public int IDThuongHieuXe { get; set; }

        [StringLength(50)]
        public string TenThuongHieu { get; set; }

        public string ANh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDoanhThu> ChiTietDoanhThus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VatTu> VatTus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TiepNhanXe> TiepNhanXes { get; set; }
    }
}
