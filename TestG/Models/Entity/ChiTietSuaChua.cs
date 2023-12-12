namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietSuaChua")]
    public partial class ChiTietSuaChua
    {
        [Key]
        public int IDSuaChu { get; set; }

        public int? IDMaVatTu { get; set; }

        public int? IDMaSuaChu { get; set; }

        public string NoiDung { get; set; }

        public int? DonGia { get; set; }

        public int? SoLuongVatTu { get; set; }

        public int? TongTien { get; set; }

        public int? IDUser { get; set; }

        public int? IDTienCong { get; set; }

        public virtual SuaChua SuaChua { get; set; }

        public virtual TienCong TienCong { get; set; }

        public virtual User User { get; set; }

        public virtual VatTu VatTu { get; set; }
    }
}
