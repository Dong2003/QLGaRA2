namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DoanhThu")]
    public partial class DoanhThu
    {
        [Key]
        public int IDBaoCaoDoanhThu { get; set; }

        public int? IDNguoiDung { get; set; }

        [Column("DoanhThu")]
        [StringLength(10)]
        public string DoanhThu1 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayLap { get; set; }

        public string NguoiLap { get; set; }

        public virtual User User { get; set; }
    }
}
