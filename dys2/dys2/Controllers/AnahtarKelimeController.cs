﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dys2.Models;

namespace dys2.Controllers
{
    public class AnahtarKelimeController : Controller
    {
        private MakaleAnahtarContext db = new MakaleAnahtarContext();

        // GET: AnahtarKelime
        public ActionResult Index()
        {
            return View(db.AnahtarKelimeler.ToList());
        }

        // GET: AnahtarKelime/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnahtarKelime anahtarKelime = db.AnahtarKelimeler.Find(id);
            if (anahtarKelime == null)
            {
                return HttpNotFound();
            }
            return View(anahtarKelime);
        }

        // GET: AnahtarKelime/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnahtarKelime/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Kelime")] AnahtarKelime anahtarKelime)
        {
            if (ModelState.IsValid)
            {
                db.AnahtarKelimeler.Add(anahtarKelime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(anahtarKelime);
        }

        // GET: AnahtarKelime/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnahtarKelime anahtarKelime = db.AnahtarKelimeler.Find(id);
            if (anahtarKelime == null)
            {
                return HttpNotFound();
            }
            return View(anahtarKelime);
        }

        // POST: AnahtarKelime/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Kelime")] AnahtarKelime anahtarKelime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anahtarKelime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anahtarKelime);
        }

        // GET: AnahtarKelime/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnahtarKelime anahtarKelime = db.AnahtarKelimeler.Find(id);
            if (anahtarKelime == null)
            {
                return HttpNotFound();
            }
            return View(anahtarKelime);
        }

        // POST: AnahtarKelime/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnahtarKelime anahtarKelime = db.AnahtarKelimeler.Find(id);
            db.AnahtarKelimeler.Remove(anahtarKelime);
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
