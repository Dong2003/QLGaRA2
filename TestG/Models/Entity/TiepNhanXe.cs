namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TiepNhanXe")]
    public partial class TiepNhanXe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TiepNhanXe()
        {
            SuaChuas = new HashSet<SuaChua>();
        }

        [Key]
        public int IDTiepNhanXe { get; set; }

        [StringLength(50)]
        public string BienSoXe { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTiepNhan { get; set; }

        public int? No { get; set; }

        public int? IDKhachHang { get; set; }

        public int? IDThuongHieuXe { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuaChua> SuaChuas { get; set; }

        public virtual ThuongHieuXe ThuongHieuXe { get; set; }
    }
}
