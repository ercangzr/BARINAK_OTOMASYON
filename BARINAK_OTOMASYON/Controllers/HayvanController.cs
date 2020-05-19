using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BARINAK_OTOMASYON.DAL;
using BARINAK_OTOMASYON.Models;

namespace BARINAK_OTOMASYON.Controllers { 
    [_SessionControl]
    public class HayvanController : Controller
    {
        private BarinakContext db = new BarinakContext();
        [Authorize]
        // GET: Hayvan
        public ActionResult Index()
        {
            return View(db.Hayvanlar.ToList());
        }

        

        // GET: Hayvan/Ekle
        public ActionResult Ekle()
        {
            return View();
        }

        // POST: Hayvan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekle([Bind(Include = "HAYVAN_ID,HAYVAN_CINSI,HAYVAN_YASI,HAYVAN_CINSIYETI")] Hayvan hayvan)
        {
            if (ModelState.IsValid)
            {
                db.Hayvanlar.Add(hayvan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hayvan);
        }

        // GET: Hayvan/Düzenle/5
        public ActionResult Düzenle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hayvan hayvan = db.Hayvanlar.Find(id);
            if (hayvan == null)
            {
                return HttpNotFound();
            }
            return View(hayvan);
        }

        // POST: Hayvan/Düzenle/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Düzenle([Bind(Include = "HAYVAN_ID,HAYVAN_CINSI,HAYVAN_YASI,HAYVAN_CINSIYETI")] Hayvan hayvan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hayvan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hayvan);
        }

        // GET: Hayvan/Sil/5
        public ActionResult Sil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hayvan hayvan = db.Hayvanlar.Find(id);
            if (hayvan == null)
            {
                return HttpNotFound();
            }
            return View(hayvan);
        }

        // POST: Hayvan/Sil/5
        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hayvan hayvan = db.Hayvanlar.Find(id);
            db.Hayvanlar.Remove(hayvan);
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
