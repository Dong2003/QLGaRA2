namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTTonKho")]
    public partial class CTTonKho
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDVatTu { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDTonKho { get; set; }

        public int? TonDau { get; set; }

        public int? PhatSinh { get; set; }

        public int? TonCuoi { get; set; }

        public virtual TonKho TonKho { get; set; }

        public virtual VatTu VatTu { get; set; }
    }
}
