using OfficeOpenXml;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestG.Models;

namespace TestG.Controllers
{
    public class VatTusController : Controller
    {
        private DA_QLGarageEntities db = new DA_QLGarageEntities();

        // GET: VatTus
        public ActionResult Index(string timkiem, int? idloai, int? page)
        {
            ModelVattu map = new ModelVattu();
            var data = map.DanhSach(timkiem, idloai);
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var pagedData = data.ToPagedList(pageNumber, pageSize);
            return View(pagedData);
        }

        // GET: VatTus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VatTu vatTu = db.VatTus.Find(id);
            if (vatTu == null)
            {
                return HttpNotFound();
            }
            return View(vatTu);
        }

        // GET: VatTus/Create
        public ActionResult Create()
        {
            ViewBag.IDLoai = new SelectList(db.LoaiVatTus, "IDLoaiVatTu", "Ten");
            ViewBag.IDHangXe = new SelectList(db.ThuongHieuXes, "IDThuongHieuXe", "TenThuongHieu");
            return View();
        }

        // POST: VatTus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDVatTu,Ten,Gia,SoLuong,Anh,IDHangXe,IDLoai,GiaNhap")] VatTu vatTu, HttpPostedFileBase fFileUpload)
        {
            if (fFileUpload == null)
            {
                ViewBag.ThongBao = "Hãy chọn ảnh vật tư.";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var sFileName = Path.GetFileName(fFileUpload.FileName);

                    var path = Path.Combine(Server.MapPath("~/Images"), sFileName);

                    if (!System.IO.File.Exists(path))
                    {
                        fFileUpload.SaveAs(path);
                    }
                    vatTu.Anh = sFileName;

                    db.VatTus.Add(vatTu);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.IDLoai = new SelectList(db.LoaiVatTus, "IDLoaiVatTu", "Ten", vatTu.IDLoai);
            ViewBag.IDHangXe = new SelectList(db.ThuongHieuXes, "IDThuongHieuXe", "TenThuongHieu", vatTu.IDHangXe);
            return View(vatTu);
        }

        // GET: VatTus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VatTu vatTu = db.VatTus.Find(id);
            if (vatTu == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDLoai = new SelectList(db.LoaiVatTus, "IDLoaiVatTu", "Ten", vatTu.IDLoai);
            ViewBag.IDHangXe = new SelectList(db.ThuongHieuXes, "IDThuongHieuXe", "TenThuongHieu", vatTu.IDHangXe);
            return View(vatTu);
        }

        // POST: VatTus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDVatTu,Ten,Gia,SoLuong,Anh,IDHangXe,IDLoai,GiaNhap")] VatTu vatTu, HttpPostedFileBase fFileUpload)
        {
            if (ModelState.IsValid)
            {
                if (fFileUpload != null)
                {
                    var sFileName = Path.GetFileName(fFileUpload.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images"), sFileName);

                    if (!System.IO.File.Exists(path))
                    {
                        fFileUpload.SaveAs(path);
                    }
                    vatTu.Anh = sFileName;
                }
                db.Entry(vatTu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDLoai = new SelectList(db.LoaiVatTus, "IDLoaiVatTu", "Ten", vatTu.IDLoai);
            ViewBag.IDHangXe = new SelectList(db.ThuongHieuXes, "IDThuongHieuXe", "TenThuongHieu", vatTu.IDHangXe);
            return View(vatTu);
        }

        // GET: VatTus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VatTu vatTu = db.VatTus.Find(id);
            if (vatTu == null)
            {
                return HttpNotFound();
            }
            return View(vatTu);
        }

        // POST: VatTus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VatTu vatTu = db.VatTus.Find(id);
            db.VatTus.Remove(vatTu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public void XuatExcel()
        {
            var list = db.VatTus.ToList();

            using (var ep = new ExcelPackage())
            {
                ExcelWorksheet sheet = ep.Workbook.Worksheets.Add("Report");
                sheet.Cells["A1"].Value = "Mã vật tư";
                sheet.Cells["B1"].Value = "Tên vật tư";
                sheet.Cells["C1"].Value = "Số lượng";
                sheet.Cells["D1"].Value = "Giá";
                sheet.Cells["E1"].Value = "Hãng xe";
                sheet.Cells["F1"].Value = "Giá nhập";
                sheet.Cells["G1"].Value = "Phân loại";

                int row = 2;
                int tongSoLuong = 0;
                decimal tongTienBan = 0;
                decimal tongTienNhap = 0;

                foreach (var item in list)
                {
                    sheet.Cells[row, 1].Value = item.IDVatTu;
                    sheet.Cells[row, 2].Value = item.Ten;
                    sheet.Cells[row, 3].Value = item.SoLuong;
                    sheet.Cells[row, 4].Value = item.Gia;
                    sheet.Cells[row, 5].Value = item.ThuongHieuXe.TenThuongHieu;
                    sheet.Cells[row, 6].Value = item.GiaNhap;
                    sheet.Cells[row, 7].Value = item.LoaiVatTu.Ten;

                    tongTienBan += Math.Abs(item.SoLuong.GetValueOrDefault() * item.Gia.GetValueOrDefault());
                    tongSoLuong += item.SoLuong.GetValueOrDefault();   
                    tongTienNhap += item.SoLuong.GetValueOrDefault() * item.GiaNhap.GetValueOrDefault();

                    row++;
                }

                sheet.Cells[row, 3].Value = "Tổng số lượng:";
                sheet.Cells[row, 4].Value = tongSoLuong;
                sheet.Cells[row, 6].Value = "Tổng giá bán:";
                sheet.Cells[row, 7].Value = tongTienBan;
                sheet.Cells[row, 9].Value = "Tổng giá nhập:";
                sheet.Cells[row, 10].Value = tongTienNhap;

                sheet.Cells["A:AZ"].AutoFitColumns();

                var ms = new MemoryStream();
                ep.SaveAs(ms);
                ms.Position = 0;

                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment; filename=Report.xlsx");
                Response.BinaryWrite(ms.ToArray());
                Response.End();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
