using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace TestG.Models
{
    public class ModelDatlich
    {
        public List<DATLICH> DanhSach()
        {
            var db = new DA_QLGarageEntities();
            var data = db.DATLICHes.ToList();
            return data;
        }

        public List<DATLICH> DanhSach(string dtimkiem, int? idloai)
        {
            var db = new DA_QLGarageEntities();
            var data = db.DATLICHes.Where(n => (n.TinhTrang == true || n.TinhTrang == false) && (string.IsNullOrEmpty(dtimkiem) || (n.TinhTrang == true && dtimkiem.ToLower() == "Đã bảo dưỡng") || (n.TinhTrang == false && dtimkiem.ToLower() == "Chưa bảo dưỡng"))).ToList();
            return data;
        }

        public List<BaoDuong1> DanhSachBaoDuong(int id)
        {
            var db = new DA_QLGarageEntities();

            var data = (from item in db.BaoDuong1

                        where item.MaDL == id
                        select item).ToList();
            return data;
        }

        public List<ChiTietBD> DanhSachKM(int id)
        {
            var db = new DA_QLGarageEntities();

            var data = (from item in db.ChiTietBDs
                        where item.MaDL == id
                        select item).ToList();
            return data;
        }

        public List<SOKM> DanhSachsokm()
        {
            var db = new DA_QLGarageEntities();
            var data = db.SOKMs.ToList();
            return data;
        }

        public List<VatTu> DanhSachvt()
        {
            var db = new DA_QLGarageEntities();
            var data = db.VatTus.ToList();
            return data;
        }

        public bool CapNhatSoLuong(int? id, int soluong)
        {
            try
            {
                DA_QLGarageEntities db = new DA_QLGarageEntities();
                var baoduong = db.BaoDuong1.Find(id);
                baoduong.SoLuong = soluong;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}