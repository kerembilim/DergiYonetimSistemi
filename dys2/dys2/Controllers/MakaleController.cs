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

namespace dys2.Controllers
{
    public class MakaleController : Controller
    {
        private MakaleAnahtarContext db = new MakaleAnahtarContext();

        // GET: Makale
        public ActionResult Index()
        {
            return View(db.Makaleler.ToList());
        }

        // GET: Makale/Details/5
        public ActionResult AnahtarEkle(int? id)
        {
            List<AnahtarKelime> a = new List<AnahtarKelime>();
            foreach (var item in db.AnahtarKelimeler)
            {
                if (!(db.Makaleler.Find(id).Anahtarlar.Any(x=>x.Kelime==item.Kelime)))//hata fırlatıyor
                {
                    a.Add(item);
                }

                ViewBag.makalem = id;


            }
           
            return View(a);
        }
        [HttpGet]
        public ActionResult DosyaYukle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DosyaYukle(HttpPostedFileBase file, int makaleid)
        {


            if (file != null && file.ContentLength > 0)
            {
                var extensition = Path.GetExtension(file.FileName);

                if (extensition == ".pdf")
                {
                    var folder = Server.MapPath("~/pdfs");
                    var randomfilename = Path.GetRandomFileName();
                    var filename = Path.ChangeExtension(randomfilename, ".pdf");

                    var path = Path.Combine(folder, filename);

                    //var filename = Path.GetFileName(file.FileName);
                    //var path = Path.Combine(Server.MapPath("~/upload"), filename);

                    file.SaveAs(path);
                }
                else
                {
                    ViewData["message"] = "Pdf dosyası seçiniz.";
                }
            }
            else
            {
                ViewData["message"] = "Bir dosya seçiniz";
            }

            //veritabanı kayıt işlemini
            //Product => productid , image = filename
            //product nesnesini veritanına kayıt et.
            //<img src="/upload/@image">

            return View();
        }
    
    public ActionResult AnahtarEsle (int makaleid,int anahtarid)
        {
            AnahtarKelime k1 = new AnahtarKelime();
            k1 = db.AnahtarKelimeler.Find(anahtarid);
            Makale m1 = new Makale();
            m1 = db.Makaleler.Find(makaleid);
            m1.Anahtarlar.Add(k1);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Makale/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Makale/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,YayinBasligi,Ozet,Doi,Kaynaklar,SekreterOnay,EditorOnay,BolumEditoruOnay,HakemYorum")] Makale makale)
        {
            if (ModelState.IsValid)
            {
                db.Makaleler.Add(makale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(makale);
        }

        // GET: Makale/Edit/5
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

        // POST: Makale/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,YayinBasligi,Ozet,Doi,Kaynaklar,SekreterOnay,EditorOnay,BolumEditoruOnay,HakemYorum")] Makale makale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(makale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(makale);
        }

        // GET: Makale/Delete/5
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

        // POST: Makale/Delete/5
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
