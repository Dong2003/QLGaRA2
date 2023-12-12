using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestG.Models;

namespace TestG.Controllers
{
    public class BaoDuong11111Controller : Controller
    {
        private DA_QLGarageEntities db = new DA_QLGarageEntities();

        // GET: BaoDuong11111
        public ActionResult Index()
        {
            var baoDuong1 = db.BaoDuong1.Include(b => b.DATLICH).Include(b => b.VatTu).Include(b => b.DichVu);
            return View(baoDuong1.ToList());
        }

        // GET: BaoDuong11111/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaoDuong1 baoDuong1 = db.BaoDuong1.Find(id);
            if (baoDuong1 == null)
            {
                return HttpNotFound();
            }
            return View(baoDuong1);
        }

        // GET: BaoDuong11111/Create
        public ActionResult Create()
        {
            ViewBag.MaDL = new SelectList(db.DATLICHes, "MaDL", "GhiChu");
            ViewBag.IDVatTu = new SelectList(db.VatTus, "IDVatTu", "Ten");
            ViewBag.IDTienCong = new SelectList(db.DichVus, "IDTienCong", "Ten");
            return View();
        }

        // POST: BaoDuong11111/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDBaoDuong,MaDL,IDVatTu,SoLuong,IDTienCong,GhiChu")] BaoDuong1 baoDuong1)
        {
            if (ModelState.IsValid)
            {
                db.BaoDuong1.Add(baoDuong1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDL = new SelectList(db.DATLICHes, "MaDL", "GhiChu", baoDuong1.MaDL);
            ViewBag.IDVatTu = new SelectList(db.VatTus, "IDVatTu", "Ten", baoDuong1.IDVatTu);
            ViewBag.IDTienCong = new SelectList(db.DichVus, "IDTienCong", "Ten", baoDuong1.IDTienCong);
            return View(baoDuong1);
        }

        // GET: BaoDuong11111/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaoDuong1 baoDuong1 = db.BaoDuong1.Find(id);
            if (baoDuong1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDL = new SelectList(db.DATLICHes, "MaDL", "GhiChu", baoDuong1.MaDL);
            ViewBag.IDVatTu = new SelectList(db.VatTus, "IDVatTu", "Ten", baoDuong1.IDVatTu);
            ViewBag.IDTienCong = new SelectList(db.DichVus, "IDTienCong", "Ten", baoDuong1.IDTienCong);
            return View(baoDuong1);
        }

        // POST: BaoDuong11111/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDBaoDuong,MaDL,IDVatTu,SoLuong,IDTienCong,GhiChu")] BaoDuong1 baoDuong1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baoDuong1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDL = new SelectList(db.DATLICHes, "MaDL", "GhiChu", baoDuong1.MaDL);
            ViewBag.IDVatTu = new SelectList(db.VatTus, "IDVatTu", "Ten", baoDuong1.IDVatTu);
            ViewBag.IDTienCong = new SelectList(db.DichVus, "IDTienCong", "Ten", baoDuong1.IDTienCong);
            return View(baoDuong1);
        }

        // GET: BaoDuong11111/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaoDuong1 baoDuong1 = db.BaoDuong1.Find(id);
            if (baoDuong1 == null)
            {
                return HttpNotFound();
            }
            return View(baoDuong1);
        }

        // POST: BaoDuong11111/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaoDuong1 baoDuong1 = db.BaoDuong1.Find(id);
            db.BaoDuong1.Remove(baoDuong1);
            db.SaveChanges();
            return RedirectToAction("Index");
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
