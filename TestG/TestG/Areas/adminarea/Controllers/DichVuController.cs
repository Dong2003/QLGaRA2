using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.IO;
using TestG.Models;

namespace TestG.Areas.adminarea.Controllers
{
    public class DichVuController : Controller
    {
        DA_QLGarageEntities db = new DA_QLGarageEntities();
        // GET: adminarea/DichVu
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult DsDichVu()
        {
            try
            {
                var dsdv = (from v in db.DichVus
                            select new
                            {
                                id = v.IDTienCong,
                                Ten = v.Ten,
                                Tien = v.GiaTri,
                            }).ToList();
                return Json(new
                {
                    code = 200,
                    dsdv = dsdv,
                    mgs = "Lấy danh sách thành công "
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, mgs = "Lấy danh sách thất bại :" + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ThemDsDichVu(string ten, int dongia)
        {
            try
            {
                var v = new DichVu();
                v.Ten = ten;
                v.GiaTri = dongia;
                db.DichVus.Add(v);
                db.SaveChanges();
                return Json(new { code = 200, mgs = "Thêm thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, mgs = "Thêm thất bại" + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult ChiTietDichVu(int id)
        {
            try
            {
                var v = db.DichVus.SingleOrDefault(n => n.IDTienCong == id);
                return Json(new { code = 200, v = v, mgs = "Xem thành công" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { code = 500, mgs = "Xem thất bại" + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult CapNhatDichVu(int id, string ten, int dongia)
        {
            try
            {
                var v = db.DichVus.SingleOrDefault(n => n.IDTienCong == id);
                v.Ten = ten;
                v.GiaTri = dongia;
                db.SaveChanges();
                return Json(new { code = 200, mgs = "Cập nhật thành công" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { code = 500, mgs = "Thất bại" + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult XoaDichVu(int id)
        {
            try
            {
                var v = db.DichVus.SingleOrDefault(n => n.IDTienCong == id);

                db.DichVus.Remove(v);
                db.SaveChanges();
                return Json(new { code = 200, mgs = "Xóa thành công" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { code = 500, mgs = "Thất bại" + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}