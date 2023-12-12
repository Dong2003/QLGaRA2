using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestG.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;
using System.Web.UI;
using System.Reflection;
using System.Net;
using OfficeOpenXml;
using System.Xml.Linq;

namespace TestG.Controllers
{
    public class DatLichController : Controller
    {
        DA_QLGarageEntities db = new DA_QLGarageEntities();

        public ActionResult Index(string timkiem, int? idloai, int? page)
        {
            ModelDatlich map = new ModelDatlich();
            var data = map.DanhSach(timkiem, idloai);
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var pagedData = data.ToPagedList(pageNumber, pageSize);
            return View(pagedData);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.IDTienCong = new SelectList(db.DichVus.ToList().OrderBy(n => n.Ten), "IDTienCong", "Ten");
            ViewBag.IDTiepNhanXe = new SelectList(db.TiepNhanXes.ToList().OrderBy(n => n.IDTiepNhanXe), "IDTiepNhanXe", "BienSoXe");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(DATLICH dl, FormCollection f)
        {
            ViewBag.IDTienCong = new SelectList(db.DichVus.ToList().OrderBy(n => n.Ten), "IDTienCong", "Ten");
            ViewBag.IDTiepNhanXe = new SelectList(db.TiepNhanXes.ToList().OrderBy(n => n.IDTiepNhanXe), "IDTiepNhanXe", "BienSoXe");

            if (ModelState.IsValid)
            {
                dl.NgayBD = Convert.ToDateTime(f["dNgayBD"]);
                dl.IDTiepNhanXe = int.Parse(f["IDTiepNhanXe"]);
                dl.IDTienCong = int.Parse(f["IDTienCong"]);
                dl.GhiChu = f["sGhiChu"];
                dl.TinhTrang = Boolean.Parse(f["sTinhTrang"]);
                db.DATLICHes.Add(dl);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            var dl = db.DATLICHes.SingleOrDefault(n => n.MaDL == id);
            if (dl == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return PartialView("Details", dl);
        }
        
        [HttpGet]
        public ActionResult Delete(int id)
        {
            DATLICH dl = db.DATLICHes.Find(id);

            db.DATLICHes.Remove(dl);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dl = db.DATLICHes.SingleOrDefault(n => n.MaDL == id);
            if (dl == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            ViewBag.IDTienCong = new SelectList(db.DichVus.ToList().OrderBy(n => n.Ten), "IDTienCong", "Ten");
            ViewBag.IDTiepNhanXe = new SelectList(db.TiepNhanXes.ToList().OrderBy(n => n.IDTiepNhanXe), "IDTiepNhanXe", "IDTiepNhanXe");
            return View(dl);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(DATLICH dl, FormCollection f)
        {
            int madl = int.Parse(f["iMaDL"]);
            dl = db.DATLICHes.SingleOrDefault(n => n.MaDL == madl);

            ViewBag.IDTienCong = new SelectList(db.DichVus.ToList().OrderBy(n => n.Ten), "IDTienCong", "Ten");
            ViewBag.IDTiepNhanXe = new SelectList(db.TiepNhanXes.ToList().OrderBy(n => n.IDTiepNhanXe), "IDTiepNhanXe", "IDTiepNhanXe");

            if (ModelState.IsValid)
            {
                dl.NgayBD = Convert.ToDateTime(f["dNgayBD"]);
                dl.IDTiepNhanXe = int.Parse(f["IDTiepNhanXe"]);
                dl.IDTienCong = int.Parse(f["IDTienCong"]);
                dl.GhiChu = f["sGhiChu"];
                dl.TinhTrang = Boolean.Parse(f["sTinhTrang"]);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult BaoDuong(int id)
        {
            ViewBag.IDTienCong = new SelectList(db.DichVus, "IDTienCong", "Ten");
            return View(new BaoDuong1()
            {
                MaDL = id
            });
        }

        [HttpPost]
        public ActionResult BaoDuong(BaoDuong1 baoDuong)
        {
            
            var datLich = db.DATLICHes.Find(baoDuong.MaDL);

            if (datLich == null)
            {
                ModelState.AddModelError("", "Không tìm thấy bản ghi DATLICH tương ứng");
            }
            else
            {
                var check = db.BaoDuong1.Count(n => n.IDTienCong == baoDuong.IDTienCong && n.IDVatTu == baoDuong.IDVatTu);
                baoDuong.SoLuong = baoDuong.SoLuong ?? 1;
                
                if (baoDuong.SoLuong <= 0)
                {
                    ModelState.AddModelError("", "Số lượng phải lớn hơn 0");
                }

                if (check > 0)
                {
                    ModelState.AddModelError("", "Đã thay linh kiện này");
                }

                if (ModelState.IsValid)
                { 
                    datLich.BaoDuong1.Add(baoDuong);
                    db.SaveChanges();
                    return View();
                }
                

            }
            ViewBag.IDTienCong = new SelectList(db.DichVus, "IDTienCong", "Ten", baoDuong.IDTienCong);
            return View(baoDuong);
        }

        public ActionResult Xoa(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaoDuong1 baoDuong = db.BaoDuong1.Find(id);
            if (baoDuong == null)
            {
                return HttpNotFound();
            }
            db.BaoDuong1.Remove(baoDuong);
            db.SaveChanges();
            TempData["Message"] = "Record deleted successfully.";
            string returnUrl = Request.UrlReferrer?.ToString();
            return Redirect(returnUrl ?? Url.Action("Index", "HomeAdmin"));
        }

        public ActionResult CapNhatSoLuong(int id)
        {
            BaoDuong1 bd = db.BaoDuong1.Find(id);

            ViewBag.id = id;
            return View(bd);
        }

        [HttpPost]
        public ActionResult CapNhatSoLuong(int id, int soluong)
        {
            if (soluong < 0)
            {
                ViewBag.err = "Số lượng không hợp lệ";
                ViewBag.id = id;
                return View();
            }
            var baoduong = db.BaoDuong1.Find(id);
            if (baoduong == null)
            {
                ViewBag.err = "Vật tư không tồn tại";
                return View();
            }
            ModelDatlich update = new ModelDatlich();

            update.CapNhatSoLuong(id, soluong);
            db.SaveChanges();
            string redirectScript = "<script>window.location.href = '/DatLich/Details/" + baoduong.MaDL + "';</script>";
            return Content(redirectScript, "text/html");
        }

        public ActionResult ThemSoKM( int id )
        {
            return View( new ChiTietBD() { MaDL = id });  
        }

        [HttpPost]
        public ActionResult ThemSoKM(ChiTietBD chitiet)
        {
            var check = db.ChiTietBDs.Count(m => m.MaDL == chitiet.MaDL & m.IDChiTietBD == chitiet.IDChiTietBD);
            if (check > 0)
            {
                ModelState.AddModelError("", "Đã được chọn");
                return View();  
            }
            db.ChiTietBDs.Add(chitiet);
            db.SaveChanges();
            return RedirectToAction("Details", new
            {
                id = chitiet.MaDL
            });
        }

        public ActionResult Xoakm(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietBD chiTiet = db.ChiTietBDs.Find(id);
            if (chiTiet == null)
            {
                return HttpNotFound();
            }
            db.ChiTietBDs.Remove(chiTiet);
            db.SaveChanges();
            TempData["Message"] = "Record deleted successfully.";
            string returnUrl = Request.UrlReferrer?.ToString();
            return Redirect(returnUrl ?? Url.Action("Index", "HomeAdmin"));
        }

        public void XuatHoaDon(string bienSoXe)
        {
            var datLich = db.DATLICHes.FirstOrDefault(dl => dl.TiepNhanXe.BienSoXe == bienSoXe);

            if (datLich == null)
            {
                return;
            }

            var baoDuongList = datLich.BaoDuong1.ToList();

            using (var package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("HoaDon");
                worksheet.Cells["B1"].Value = "Tên Vật tư";
                worksheet.Cells["C1"].Value = "Số lượng";
                worksheet.Cells["D1"].Value = "Giá thay";
                worksheet.Cells["E1"].Value = "Tên dịch vụ";
                worksheet.Cells["F1"].Value = "Giá dịch vụ";
                worksheet.Cells["G1"].Value = "Biển số xe";
                worksheet.Cells["H1"].Value = "Ngày bảo dưỡng";

                int row = 2;
                decimal tongTienThay = 0;
                int tongSoLuong = 0;
                decimal tongTienDichVu = 0;

                foreach (var item in baoDuongList)
                {
                    worksheet.Cells[row, 2].Value = item.VatTu?.Ten;
                    worksheet.Cells[row, 3].Value = item.SoLuong;
                    worksheet.Cells[row, 4].Value = item.VatTu?.Gia;
                    worksheet.Cells[row, 5].Value = item.DichVu?.Ten;
                    worksheet.Cells[row, 6].Value = item.DichVu?.GiaTri;
                    worksheet.Cells[row, 7].Value = item.DATLICH?.TiepNhanXe?.BienSoXe;
                    worksheet.Cells[row, 8].Value = item.DATLICH?.NgayBD?.ToString("dd/MM/yyyy");

                    if (item.VatTu != null)
                    {
                        tongTienThay += item.SoLuong.GetValueOrDefault() * item.VatTu.Gia.GetValueOrDefault();
                        tongSoLuong += item.SoLuong.GetValueOrDefault();
                    }

                    if (item.DichVu != null)
                    {
                        tongTienDichVu += item.DichVu.GiaTri.GetValueOrDefault();
                    }

                    row++;
                }

                worksheet.Cells[row, 3].Value = "Tổng số lượng:";
                worksheet.Cells[row, 4].Value = tongSoLuong;
                worksheet.Cells[row, 6].Value = "Tổng tiền thay:";
                worksheet.Cells[row, 7].Value = tongTienThay;
                worksheet.Cells[row, 9].Value = "Tổng tiền dịch vụ:";
                worksheet.Cells[row, 10].Value = tongTienDichVu;

                worksheet.Cells["A:AZ"].AutoFitColumns();

                var ms = new MemoryStream();
                package.SaveAs(ms);
                ms.Position = 0;

                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment; filename=HoaDon.xlsx");
                Response.BinaryWrite(ms.ToArray());
            }
        }

        public ActionResult Chitiet(int? km)
        {       
            return View();
        }

    }
}