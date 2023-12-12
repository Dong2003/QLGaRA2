using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestG.Models
{
    public class ModelTiepnhanxe
    {
        public List<TiepNhanXe> DanhSach()
        {
            var db = new DA_QLGarageEntities();
            var data = db.TiepNhanXes.ToList();
            return data;
        }

        public List<TiepNhanXe> DanhSach(string dtimkiem, int? idloai)
        {
            var db = new DA_QLGarageEntities();

            var data = db.TiepNhanXes.Where(n => (n.BanGiaoXe == true || n.BanGiaoXe == false) && (string.IsNullOrEmpty(dtimkiem) || (n.BanGiaoXe == true && dtimkiem.ToLower() == "Đã tiếp nhận") || (n.BanGiaoXe == false && dtimkiem.ToLower() == "Chưa tiếp nhận"))).ToList();
            return data;

        }
    }
}