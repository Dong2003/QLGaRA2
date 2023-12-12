using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using TestG.Models;
using PagedList;
using PagedList.Mvc;

namespace TestG.Controllers
{
    public class TIEPNHANXEController : Controller
    {
        DA_QLGarageEntities db = new DA_QLGarageEntities();

        public ActionResult Index(string timkiem, int? idloai, int? page)
        {
            ModelTiepnhanxe map = new ModelTiepnhanxe();
            var data = map.DanhSach(timkiem, idloai);
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var pagedData = data.ToPagedList(pageNumber, pageSize);
            return View(pagedData);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.IDKhachHang = new SelectList(db.KhachHangs.ToList().OrderBy(n => n.TenKH), "IDKhachHang", "TenKH");
            ViewBag.IDThuongHieuXe = new SelectList(db.ThuongHieuXes.ToList().OrderBy(n => n.TenThuongHieu), "IDThuongHieuXe", "TenThuongHieu");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(DATLICH dl, FormCollection f)
        {
            /*ViewBag.IDKhachHang = new SelectList(db.KhachHangs.ToList().OrderBy(n => n.TenKH), "IDKhachHang", "TenKH");
            ViewBag.IDThuongHieuXe = new SelectList(db.ThuongHieuXes.ToList().OrderBy(n => n.TenThuongHieu), "IDThuongHieuXe", "TenThuongHieu");

            if (ModelState.IsValid)
            {
                dl.NgayBD = Convert.ToDateTime(f["dNgayBD"]);
                //dl.NgayBD = Convert.ToDateTime(f["dNgayBD"]);
                dl.IDKhachHang = int.Parse(f["IDKhachHang"]);
                dl.IDThuongHieuXe = int.Parse(f["IDThuongHieuXe"]);
                dl.IDTienCong = int.Parse(f["IDTienCong"]);
                dl.IDNguoiDung = int.Parse(f["IDNguoiDung"]);
                if (dl.ChiTietUser != null)
                {
                    if (dl.IDTiepNhanXe != null)
                    {
                        dl.ChiTietUser.User.IDChucVu = int.Parse(f["IDChucVu"]);
                    }
                }
                //dl.ChiTietUser.User.IDChucVu = int.Parse(f["IDChucVu"]);
                dl.GhiChu = f["sGhiChu"];
                dl.TinhTrang = Boolean.Parse(f["sTinhTrang"]);
                db.DATLICHes.Add(dl);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }*/
            return View();
        }
    }
}