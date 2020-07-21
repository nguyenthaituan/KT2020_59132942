using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KT2020_59132942.Models;

namespace KT2020_59132942.Controllers
{
    public class LoaiDocGia_59132942Controller : Controller
    {
        private KT2020_59132942Entities db = new KT2020_59132942Entities();

        // GET: LoaiDocGia_59132942
        public ActionResult Index()
        {
            return View(db.LoaiDocGias.ToList());
        }

        // GET: LoaiDocGia_59132942/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiDocGia loaiDocGia = db.LoaiDocGias.Find(id);
            if (loaiDocGia == null)
            {
                return HttpNotFound();
            }
            return View(loaiDocGia);
        }

        // GET: LoaiDocGia_59132942/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiDocGia_59132942/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoaiDG,TenLoaiDG")] LoaiDocGia loaiDocGia)
        {
            if (ModelState.IsValid)
            {
                db.LoaiDocGias.Add(loaiDocGia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiDocGia);
        }

        // GET: LoaiDocGia_59132942/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiDocGia loaiDocGia = db.LoaiDocGias.Find(id);
            if (loaiDocGia == null)
            {
                return HttpNotFound();
            }
            return View(loaiDocGia);
        }

        // POST: LoaiDocGia_59132942/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoaiDG,TenLoaiDG")] LoaiDocGia loaiDocGia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiDocGia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiDocGia);
        }

        // GET: LoaiDocGia_59132942/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiDocGia loaiDocGia = db.LoaiDocGias.Find(id);
            if (loaiDocGia == null)
            {
                return HttpNotFound();
            }
            return View(loaiDocGia);
        }

        // POST: LoaiDocGia_59132942/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiDocGia loaiDocGia = db.LoaiDocGias.Find(id);
            db.LoaiDocGias.Remove(loaiDocGia);
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
