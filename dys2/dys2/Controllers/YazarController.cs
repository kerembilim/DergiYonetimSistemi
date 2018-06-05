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
    [Authorize]
    public class YazarController : Controller
    {
        private MakaleAnahtarContext db = new MakaleAnahtarContext();

        // GET: Yazar
        public ActionResult Index()
        {
            List<Makale> m1 = new List<Makale>();
            
            
            foreach (var item in db.Makaleler.ToList())
            {
                if (item.SekreterOnay==0)
                {
                    item.Durum = "sekreter onayı bekleniyor";
                    db.SaveChanges();
                }
                else if (item.SekreterOnay==Makale.OnayDurum.Red)
                {
                    item.Durum = "makaleniz kabul edilmedi";
                    db.SaveChanges();
                }
                else if (item.SekreterOnay==Makale.OnayDurum.Kabul&&item.BolumEditoruMail==null)
                {
                    item.Durum ="bölum editoru atanması bekleniyor";
                    db.SaveChanges();
                }
                else if (item.HakemMail1==null&&item.HakemMail2==null&&item.HakemMail3==null)
                {
                    item.Durum = "hakem atanması bekleniyor";
                    db.SaveChanges();
                }
                else if (item.HakemYorum1==null&&item.HakemYorum2==null&&item.HakemYorum3==null)
                {
                    item.Durum = "hakem görüşleri bekleniyor";
                    db.SaveChanges();
                }
                else if (item.BolumEditoruOnay==0)
                {
                    item.Durum = "bölüm editörü onayı bekleniyor";
                }
                else if (item.BolumEditoruOnay==Makale.OnayDurum.Duzenlenmeli)
                {
                    item.Durum = "revize istendi";
                    db.SaveChanges();
                }
                else if (item.BolumEditoruOnay==Makale.OnayDurum.Red)
                {
                    item.Durum = "makaleniz kabul edilmedi";
                    db.SaveChanges();
                }
                else if (item.BicimDenetleyici==0)
                {
                    item.Durum = "biçim denetleyici onayı bekleniyor";
                    db.SaveChanges();
                }
                else if (item.EditorOnay==0)
                {
                    item.Durum = "Editör onayı bekleniyor";
                    db.SaveChanges();
                }
                else if (item.EditorOnay==Makale.OnayDurum.Duzenlenmeli)
                {
                    item.Durum = "revize istendi";
                    db.SaveChanges();
                }
                else if (item.EditorOnay==Makale.OnayDurum.Red)
                {
                    item.Durum = "makaleniz kabul edilmedi";
                    db.SaveChanges();
                }
                else
                {
                    item.Durum = "yayın sürecinde";
                    db.SaveChanges();
                }
            }
            m1 = db.Makaleler.ToList();
            return View(m1);
        }
        public ActionResult AnahtarEkle(int? id)
        {
            List<AnahtarKelime> a = new List<AnahtarKelime>();
            foreach (var item in db.AnahtarKelimeler)
            {
                if (!(db.Makaleler.Find(id).Anahtarlar.Any(x => x.Kelime == item.Kelime)))
                {
                    a.Add(item);
                }

                ViewBag.makalem = id;


            }

            return View(a);

        }
        public ActionResult DosyaYukle(int id)
        {
            ViewBag.makalem = id;

            return View();
        }

        [HttpPost]
        public ActionResult DosyaYukle(HttpPostedFileBase file, int id)
        {


            if (file != null && file.ContentLength > 0)
            {
                var extensition = Path.GetExtension(file.FileName);

                if (extensition == ".pdf")
                {
                    var folder = Server.MapPath("~/pdfs");
                    var randomfilename = Path.GetRandomFileName();
                    var filename = Path.ChangeExtension(randomfilename, ".pdf");
                    db.Makaleler.Find(id).DosyaIsmi = filename;
                    db.SaveChanges();

                    var path = Path.Combine(folder, filename);

                    //var filename = Path.GetFileName(file.FileName);
                    //var path = Path.Combine(Server.MapPath("~/upload"), filename);

                    file.SaveAs(path);
                    return RedirectToAction("Index");
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
        public ActionResult DosyaAc(int? id)
        {
            Makale m1 = db.Makaleler.Find(id);
            return View(m1);
        }

        public ActionResult AnahtarEsle(int makaleid, int anahtarid)
        {
            AnahtarKelime k1 = new AnahtarKelime();
            k1 = db.AnahtarKelimeler.Find(anahtarid);
            Makale m1 = new Makale();
            m1 = db.Makaleler.Find(makaleid);
            m1.Anahtarlar.Add(k1);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult OnayaGonder(int ?id)
        {
            db.Makaleler.Find(id).OnayaGonder = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Yazar/Details/5
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

        // GET: Yazar/Create
        public ActionResult Create()
        {
            return View();
        }
         
        // POST: Yazar/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OnayaGonder,YayinBasligi,Ozet,Doi,Kaynaklar,DosyaIsmi,BicimDenetleyici,SekreterOnay,EditorOnay,BolumEditoruOnay,BolumEditoruMail,HakemMail1,HakemMail2,HakemMail3,HakemYorum1,HakemYorum2,HakemYorum3")] Makale makale)
        {//makale ve yazar eslestir
            if (ModelState.IsValid)
            {
                makale.YazarName = User.Identity.Name;
                db.Makaleler.Add(makale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(makale);
        }

        // GET: Yazar/Edit/5
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

        // POST: Yazar/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OnayaGonder,YayinBasligi,Ozet,Doi,Kaynaklar,BicimDenetleyici,SekreterOnay,EditorOnay,BolumEditoruOnay,BolumEditoruMail,HakemMail1,HakemMail2,HakemMail3,HakemYorum1,HakemYorum2,HakemYorum3")] Makale makale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(makale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(makale);
        }

        // GET: Yazar/Delete/5
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

        // POST: Yazar/Delete/5
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
