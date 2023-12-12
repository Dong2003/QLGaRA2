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
    public class ChiTietBDsController : Controller
    {
        private DA_QLGarageEntities db = new DA_QLGarageEntities();

        // GET: ChiTietBDs
        public ActionResult Index()
        {
            var chiTietBDs = db.ChiTietBDs.Include(c => c.DATLICH).Include(c => c.SOKM).Include(c => c.VatTu);
            return View(chiTietBDs.ToList());
        }

        // GET: ChiTietBDs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietBD chiTietBD = db.ChiTietBDs.Find(id);
            if (chiTietBD == null)
            {
                return HttpNotFound();
            }
            return View(chiTietBD);
        }

        // GET: ChiTietBDs/Create
        public ActionResult Create()
        {
            ViewBag.MaDL = new SelectList(db.DATLICHes, "MaDL", "GhiChu");
            ViewBag.IDKM = new SelectList(db.SOKMs, "IDKM", "IDKM");
            ViewBag.IDVatTu = new SelectList(db.VatTus, "IDVatTu", "Ten");
            return View();
        }

        // POST: ChiTietBDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDChiTietBD,MaDL,IDKM,IDVatTu")] ChiTietBD chiTietBD)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietBDs.Add(chiTietBD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDL = new SelectList(db.DATLICHes, "MaDL", "GhiChu", chiTietBD.MaDL);
            ViewBag.IDKM = new SelectList(db.SOKMs, "IDKM", "IDKM", chiTietBD.IDKM);
            ViewBag.IDVatTu = new SelectList(db.VatTus, "IDVatTu", "Ten", chiTietBD.IDVatTu);
            return View(chiTietBD);
        }

        // GET: ChiTietBDs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietBD chiTietBD = db.ChiTietBDs.Find(id);
            if (chiTietBD == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDL = new SelectList(db.DATLICHes, "MaDL", "GhiChu", chiTietBD.MaDL);
            ViewBag.IDKM = new SelectList(db.SOKMs, "IDKM", "IDKM", chiTietBD.IDKM);
            ViewBag.IDVatTu = new SelectList(db.VatTus, "IDVatTu", "Ten", chiTietBD.IDVatTu);
            return View(chiTietBD);
        }

        // POST: ChiTietBDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDChiTietBD,MaDL,IDKM,IDVatTu")] ChiTietBD chiTietBD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietBD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDL = new SelectList(db.DATLICHes, "MaDL", "GhiChu", chiTietBD.MaDL);
            ViewBag.IDKM = new SelectList(db.SOKMs, "IDKM", "IDKM", chiTietBD.IDKM);
            ViewBag.IDVatTu = new SelectList(db.VatTus, "IDVatTu", "Ten", chiTietBD.IDVatTu);
            return View(chiTietBD);
        }

        // GET: ChiTietBDs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietBD chiTietBD = db.ChiTietBDs.Find(id);
            if (chiTietBD == null)
            {
                return HttpNotFound();
            }
            return View(chiTietBD);
        }

        // POST: ChiTietBDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietBD chiTietBD = db.ChiTietBDs.Find(id);
            db.ChiTietBDs.Remove(chiTietBD);
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
