using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Generator;
using KT2020_59132942.Models;

namespace KT2020_59132942.Controllers
{
    public class DocGia_59132942Controller : Controller
    {
        private KT2020_59132942Entities db = new KT2020_59132942Entities();
        // GET: DocGia_59132942
        public ActionResult Index()
        {
            var docGias = db.DocGias.Include(d => d.LoaiDocGia);
            return View(docGias.ToList());
        }

        public ActionResult TimKiem(string MaDG = "", string HoTen = "")
        {
            int id = 0;
            if (!MaDG.Equals("")) id = int.Parse(MaDG);
            var dg = db.DocGias.Where(d => d.MaDB == id || (id == 0 && (d.HoDG + " " + d.TenDG).Contains(HoTen)));
            return View(dg);
        }


        // GET: DocGia_59132942/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocGia docGia = db.DocGias.Find(id);
            if (docGia == null)
            {
                return HttpNotFound();
            }
            return View(docGia);
        }

        // GET: DocGia_59132942/Create
        public ActionResult Create()
        {
            DocGia dg = new DocGia();
            ViewBag.MaLoaiDG = new SelectList(db.LoaiDocGias, "MaLoaiDG", "TenLoaiDG");
            return View(dg);
        }

        // POST: DocGia_59132942/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDB,HoDG,TenDG,NgaySinh,GioiTinh,Email,AnhDG,MaLoaiDG")] DocGia docGia)
        {
            //System.Web.HttpPostedFileBase Avatar;
            var imgNV = Request.Files["Avatar"];
            //Lấy thông tin từ input type=file có tên Avatar
            string postedFileName = System.IO.Path.GetFileName(imgNV.FileName);
            //Lưu hình đại diện về Server
            var path = Server.MapPath("/Images/" + postedFileName);
            imgNV.SaveAs(path); //*************************************************

            if (ModelState.IsValid)
            {
                db.DocGias.Add(docGia);
                docGia.AnhDG = postedFileName;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiDG = new SelectList(db.LoaiDocGias, "MaLoaiDG", "TenLoaiDG", docGia.MaLoaiDG);
            return View(docGia);
        }

        // GET: DocGia_59132942/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocGia docGia = db.DocGias.Find(id);
            if (docGia == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiDG = new SelectList(db.LoaiDocGias, "MaLoaiDG", "TenLoaiDG", docGia.MaLoaiDG);
            return View(docGia);
        }

        // POST: DocGia_59132942/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDB,HoDG,TenDG,NgaySinh,GioiTinh,Email,AnhDG,MaLoaiDG")] DocGia docGia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(docGia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiDG = new SelectList(db.LoaiDocGias, "MaLoaiDG", "TenLoaiDG", docGia.MaLoaiDG);
            return View(docGia);
        }

        // GET: DocGia_59132942/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocGia docGia = db.DocGias.Find(id);
            if (docGia == null)
            {
                return HttpNotFound();
            }
            return View(docGia);
        }

        // POST: DocGia_59132942/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DocGia docGia = db.DocGias.Find(id);
            db.DocGias.Remove(docGia);
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
