using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestG.Models
{
    public class ModelDichVu
    {
        public List<DichVu> DanhSach()
        {
            var db = new DA_QLGarageEntities();
            var data = db.DichVus.ToList();
            return data;
        }
       
        public List<DichVu> DanhSach(string dtimkiem, int? idloai)
        {
            var db = new DA_QLGarageEntities();

            var data = db.DichVus.Where(n => n.Ten.ToLower().Contains(dtimkiem.ToLower()) == true || string.IsNullOrEmpty(dtimkiem)).ToList();
            return data;

        }
      
        
    }
}