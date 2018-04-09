using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dys2.Models;

namespace dys2.Areas.Hakem.Controllers
{
    [Authorize(Roles = "hakem")]
    public class HakemYonetimController : Controller
    {
        private MakaleAnahtarContext db = new MakaleAnahtarContext();

        // GET: Hakem/HakemYonetim
        public ActionResult Index()
        {
            List<Makale> m1 = new List<Makale>();
            foreach (var item in db.Makaleler)
            {
                if ( (item.HakemMail1 == User.Identity.Name)|| (item.HakemMail2 == User.Identity.Name) || (item.HakemMail3 == User.Identity.Name) )
                {
                    m1.Add(item);
                }
            }

            return View(m1);
        }

        // GET: Hakem/HakemYonetim/Details/5
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

        // GET: Hakem/HakemYonetim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hakem/HakemYonetim/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,YayinBasligi,Ozet,Doi,Kaynaklar,DosyaIsmi,BicimDenetleyici,SekreterOnay,EditorOnay,BolumEditoruOnay,BolumEditoruMail,HakemMail1,HakemMail2,HakemMail3,HakemYorum1,HakemYorum2,HakemYorum3")] Makale makale)
        {
            if (ModelState.IsValid)
            {
                db.Makaleler.Add(makale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(makale);
        }

        // GET: Hakem/HakemYonetim/Edit/5
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
        public ActionResult Edit([Bind(Include = "Id,YayinBasligi,Ozet,Doi,Kaynaklar,DosyaIsmi,BicimDenetleyici,SekreterOnay,EditorOnay,BolumEditoruOnay,BolumEditoruMail,HakemMail1,HakemMail2,HakemMail3,HakemYorum1,HakemYorum2,HakemYorum3")] Makale makale)
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
