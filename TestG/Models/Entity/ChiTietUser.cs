namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietUser")]
    public partial class ChiTietUser
    {
        [Key]
        public int IDThongTinNguoiDung { get; set; }

        public int IDUser { get; set; }

        public string HoTen { get; set; }

        [StringLength(150)]
        public string DiaChi { get; set; }

        public string NgaySinh { get; set; }

        public string CMND { get; set; }

        [StringLength(20)]
        public string SoDienThoai { get; set; }

        public int? Luong { get; set; }

        public virtual User User { get; set; }
    }
}
