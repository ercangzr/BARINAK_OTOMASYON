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

namespace BARINAK_OTOMASYON.Controllers
{
    public class SahipController : Controller
    {
        private BarinakContext db = new BarinakContext();

        // GET: Sahip
        public ActionResult Index()
        {
            return View(db.Sahipler.ToList());
        }

        
        // GET: Sahip/Ekle
        public ActionResult Ekle()
        {
            return View();
        }

        // POST: Sahip/Ekle
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekle([Bind(Include = "SAHIP_ID,SAHIP_AD,SAHIP_SOYAD,SAHIP_TEL,SAHIP_ADRES")] Sahip sahip)
        {
            if (ModelState.IsValid)
            {
                db.Sahipler.Add(sahip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sahip);
        }

        // GET: Sahip/Düzenle/5
        public ActionResult Düzenle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sahip sahip = db.Sahipler.Find(id);
            if (sahip == null)
            {
                return HttpNotFound();
            }
            return View(sahip);
        }

        // POST: Sahip/Düzenle/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Düzenle([Bind(Include = "SAHIP_ID,SAHIP_AD,SAHIP_SOYAD,SAHIP_TEL,SAHIP_ADRES")] Sahip sahip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sahip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sahip);
        }

        // GET: Sahip/Sil/5
        public ActionResult Sil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sahip sahip = db.Sahipler.Find(id);
            if (sahip == null)
            {
                return HttpNotFound();
            }
            return View(sahip);
        }

        // POST: Sahip/Sil/5
        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sahip sahip = db.Sahipler.Find(id);
            db.Sahipler.Remove(sahip);
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
