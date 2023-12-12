namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TonKho")]
    public partial class TonKho
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TonKho()
        {
            CTTonKhoes = new HashSet<CTTonKho>();
        }

        [Key]
        public int IDTonKho { get; set; }

        public int? IDUser { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayLap { get; set; }

        public string NguoiLap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTTonKho> CTTonKhoes { get; set; }

        public virtual User User { get; set; }
    }
}
