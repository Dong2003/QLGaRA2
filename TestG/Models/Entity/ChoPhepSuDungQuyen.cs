namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChoPhepSuDungQuyen")]
    public partial class ChoPhepSuDungQuyen
    {
        [Key]
        public int IDPhanQyen { get; set; }

        public int? IDChucVu { get; set; }

        public int? IDQuyen { get; set; }

        [Column("ChoPhepSuDungQuyen")]
        public bool? ChoPhepSuDungQuyen1 { get; set; }

        public virtual ChucVu ChucVu { get; set; }

        public virtual Quyen Quyen { get; set; }
    }
}
