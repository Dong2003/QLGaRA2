namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TienCong")]
    public partial class TienCong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TienCong()
        {
            ChiTietSuaChuas = new HashSet<ChiTietSuaChua>();
        }

        [Key]
        public int IDTienCong { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        public int? GiaTri { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietSuaChua> ChiTietSuaChuas { get; set; }
    }
}
