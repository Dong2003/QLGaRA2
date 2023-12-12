using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using TestG.Models;

namespace TestG.Controllers
{
    public class HomeController : Controller
    {
        DA_QLGarageEntities db = new DA_QLGarageEntities();

        public ActionResult Index()
        {
            Thongke();
            ThongkeKH();
            ThongkeDV();
            return View();
        }

        public ActionResult NavPartial()
        {
            return PartialView();
        }
        public ActionResult MenuPartial()
        {
            return PartialView();
        }
        public ActionResult FooterPartial()
        {
            return PartialView();
        }

        public void Thongke()
        {
            var bd = db.BaoDuong1.ToList();

            decimal tong = 0;
            foreach (var item in bd)
            {
                tong += item.SoLuong.GetValueOrDefault() * item.VatTu.Gia.GetValueOrDefault();
            }
            ViewBag.Tong = tong;
        }

        public void ThongkeKH()
        {
            var kh = db.KhachHangs.ToList();
            int tongkh = kh.Count();
            ViewBag.TongKH = tongkh;
        }

        public void ThongkeDV()
        {
            var dv = db.DichVus.ToList();
            int tongdv = dv.Count();
            ViewBag.TongDV = tongdv;
        }
    }
}