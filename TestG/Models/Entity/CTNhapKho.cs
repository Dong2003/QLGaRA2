namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTNhapKho")]
    public partial class CTNhapKho
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDVatTu { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDNhapKho { get; set; }

        public int? SoLuong { get; set; }

        public int? Gia { get; set; }

        public int? TongTien { get; set; }

        public virtual NhapKho NhapKho { get; set; }

        public virtual VatTu VatTu { get; set; }
    }
}
