using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dys2.Models;
using System.IO;

namespace dys2.Areas.Sekreter.Controllers
{
    [Authorize(Roles = "sekreter")]
    public class SekreterYonetimController : Controller
    {
        private MakaleAnahtarContext db = new MakaleAnahtarContext();

  
        public ActionResult Index()
        {
            List<Makale> m1 = new List<Makale>();
            foreach (var item in db.Makaleler)
            {
                if (item.OnayaGonder==true &&item.BicimDenetleyici==0&&item.BolumEditoruOnay==0&&item.SekreterOnay==0)
                {
                    m1.Add(item);
                }
            }

            return View(m1);
        }
        public ActionResult Arsiv()
        {
            List<Makale> m1 = new List<Makale>();

            foreach (var item in db.Makaleler)
            {
                if (item.OnayaGonder == true)
                {
                    m1.Add(item);
                }
            }

            return View(m1);
        }
        public ActionResult DosyaAc(int? id)
        {
            Makale m1 = db.Makaleler.Find(id);
            return View(m1);
        }
        public ActionResult Onayla(int ?id)
        {
            db.Makaleler.Find(id).SekreterOnay = Makale.OnayDurum.Kabul;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Red(int? id)
        {
            db.Makaleler.Find(id).SekreterOnay = Makale.OnayDurum.Red;

            return RedirectToAction("Index");
        }




        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makale makale = db.Makaleler.Find(id);
            if (makale == null)
            {
                return HttpNotFound();
            }
            return View(makale);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makale makale = db.Makaleler.Find(id);
            if (makale == null)
            {
                return HttpNotFound();
            }
            return View(makale);
        }

        // POST: Hakem/HakemYonetim/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SekreterOnay")] Makale makale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(makale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(makale);
        }

        // GET: Hakem/HakemYonetim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makale makale = db.Makaleler.Find(id);
            if (makale == null)
            {
                return HttpNotFound();
            }
            return View(makale);
        }

        // POST: Hakem/HakemYonetim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Makale makale = db.Makaleler.Find(id);
            db.Makaleler.Remove(makale);
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
