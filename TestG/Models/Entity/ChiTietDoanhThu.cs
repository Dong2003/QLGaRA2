namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDoanhThu")]
    public partial class ChiTietDoanhThu
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDDoanhThu { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDHangXe { get; set; }

        public int? SoLuotSua { get; set; }

        public int? TongTien { get; set; }

        public double? Rate { get; set; }

        public virtual ThuongHieuXe ThuongHieuXe { get; set; }
    }
}
