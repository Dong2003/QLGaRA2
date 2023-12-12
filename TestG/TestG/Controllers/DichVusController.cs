using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestG.Models;
using PagedList;
using PagedList.Mvc;
using System.Web.UI;

namespace TestG.Controllers
{
    public class DichVusController : Controller
    {
        private DA_QLGarageEntities db = new DA_QLGarageEntities();

        // GET: DichVus
        public ActionResult Index(string timkiem, int? idloai, int? page)
        {
            ModelDichVu map = new ModelDichVu();
            var data = map.DanhSach(timkiem, idloai);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var pagedData = data.ToPagedList(pageNumber, pageSize);
            return View(pagedData);
        }

        // GET: DichVus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DichVu dichVu = db.DichVus.Find(id);
            if (dichVu == null)
            {
                return HttpNotFound();
            }
            return View(dichVu);
        }

        // GET: DichVus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DichVus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDTienCong,Ten,GiaTri")] DichVu dichVu)
        {
            if (ModelState.IsValid)
            {
                db.DichVus.Add(dichVu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dichVu);
        }

        // GET: DichVus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DichVu dichVu = db.DichVus.Find(id);
            if (dichVu == null)
            {
                return HttpNotFound();
            }
            return View(dichVu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDTienCong,Ten,GiaTri")] DichVu dichVu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dichVu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dichVu);
        }

        // GET: DichVus/Delete/5
        public ActionResult Delete(int? id)
        {
            DichVu dv = db.DichVus.Find(id);

            db.DichVus.Remove(dv);
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
