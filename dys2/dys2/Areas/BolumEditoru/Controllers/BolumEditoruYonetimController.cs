using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dys2.Models;

namespace dys2.Areas.BolumEditoru.Controllers
{
    [Authorize(Roles = "bolumeditoru")]
    public class BolumEditoruYonetimController : Controller
    {
        private MakaleAnahtarContext db = new MakaleAnahtarContext();

        // GET: BolumEditoru/BolumEditoruYonetim
        public ActionResult Index()
        {
            List<Makale> m1 = new List<Makale>();
            foreach (var item in db.Makaleler)
            {
                if ((item.SekreterOnay == Makale.OnayDurum.Kabul) && (item.BolumEditoruMail==User.Identity.Name) )
                {
                    m1.Add(item);
                }
            }

            return View(m1);
           
        }

        // GET: BolumEditoru/BolumEditoruYonetim/Details/5
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

        // GET: BolumEditoru/BolumEditoruYonetim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BolumEditoru/BolumEditoruYonetim/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,YayinBasligi,Ozet,Doi,Kaynaklar,DosyaIsmi,BicimDenetleyici,SekreterOnay,EditorOnay,BolumEditoruOnay,HakemYorum1,HakemYorum2,HakemYorum3")] Makale makale)
        {
            if (ModelState.IsValid)
            {
                db.Makaleler.Add(makale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(makale);
        }

        // GET: BolumEditoru/BolumEditoruYonetim/Edit/5
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

        // POST: BolumEditoru/BolumEditoruYonetim/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,YayinBasligi,Ozet,Doi,Kaynaklar,DosyaIsmi,BicimDenetleyici,SekreterOnay,EditorOnay,BolumEditoruOnay,HakemYorum")] Makale makale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(makale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(makale);
        }

        // GET: BolumEditoru/BolumEditoruYonetim/Delete/5
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

        // POST: BolumEditoru/BolumEditoruYonetim/Delete/5
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
