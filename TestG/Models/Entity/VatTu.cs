namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VatTu")]
    public partial class VatTu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VatTu()
        {
            ChiTietSuaChuas = new HashSet<ChiTietSuaChua>();
            CTNhapKhoes = new HashSet<CTNhapKho>();
            CTTonKhoes = new HashSet<CTTonKho>();
        }

        [Key]
        public int IDVatTu { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        public int? Gia { get; set; }

        public int? SoLuong { get; set; }

        public string Anh { get; set; }

        public int? IDHangXe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietSuaChua> ChiTietSuaChuas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTNhapKho> CTNhapKhoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTTonKho> CTTonKhoes { get; set; }

        public virtual ThuongHieuXe ThuongHieuXe { get; set; }
    }
}
