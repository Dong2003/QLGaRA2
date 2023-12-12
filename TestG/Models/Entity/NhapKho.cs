namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhapKho")]
    public partial class NhapKho
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhapKho()
        {
            CTNhapKhoes = new HashSet<CTNhapKho>();
        }

        [Key]
        public int IDNhapKho { get; set; }

        public int? IDNhaCungCap { get; set; }

        public int? IDUser { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayNhap { get; set; }

        public int? TongTien { get; set; }

        public string TenNguoiNhap { get; set; }

        public string TenNhaCC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTNhapKho> CTNhapKhoes { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }

        public virtual User User { get; set; }
    }
}
