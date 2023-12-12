namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SuaChua")]
    public partial class SuaChua
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SuaChua()
        {
            ChiTietSuaChuas = new HashSet<ChiTietSuaChua>();
        }

        [Key]
        public int IDMaSuaChua { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayLap { get; set; }

        public int? TongTien { get; set; }

        public int? IDTiepNhan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietSuaChua> ChiTietSuaChuas { get; set; }

        public virtual TiepNhanXe TiepNhanXe { get; set; }
    }
}
