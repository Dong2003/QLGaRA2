using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestG.Models
{
    public class ModelBaoDuong
    {
        public List<BaoDuong1> DanhSach()
        {
            var db = new DA_QLGarageEntities();
            var data = db.BaoDuong1.ToList();
            return data;
        }

        public List<BaoDuong1> DanhSach(string dtimkiem, int? idloai)
        {
            var db = new DA_QLGarageEntities();

            var data = db.BaoDuong1.Where(n => n.VatTu.LoaiVatTu.Ten.ToLower().Contains(dtimkiem.ToLower()) == true || string.IsNullOrEmpty(dtimkiem)).ToList();
            return data;
        }

        public List<TiepNhanXe> DanhSachKM(string dtimkiem, int? idkm)
        {
            var db = new DA_QLGarageEntities();

            var data = db.TiepNhanXes.Where(n => n.BienSoXe.ToLower().Contains(dtimkiem.ToLower()) == true || string.IsNullOrEmpty(dtimkiem)).ToList();
            return data;
        }
    }
}