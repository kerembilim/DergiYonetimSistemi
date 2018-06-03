using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dys2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.IsInRole("admin"))
            {
                return RedirectToAction("Index", "RolYonetim", new { area = "Admin" });
            }
            else if (User.IsInRole("bicimdenetleyici"))
            {
                return RedirectToAction("Index", "BicimDenetleyiciYonetim", new { area = "BicimDenetleyici" });
            }
            else if (User.IsInRole("bolumeditoru"))
            {
                return RedirectToAction("Index", "BolumEditoruYonetim", new { area = "BolumEditoru" });
            }
            else if (User.IsInRole("editor"))
            {
                return RedirectToAction("Index", "EditorYonetim", new { area = "Editor" });
            }
            else if (User.IsInRole("hakem"))
            {
                return RedirectToAction("Index", "HakemYonetim", new { area = "Hakem" });
            }
            else if (User.IsInRole("sekreter"))
            {
                return RedirectToAction("Index", "SekreterYonetim", new { area = "Sekreter" });
            }
            else if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index","Yazar");
            }


            return View();
           
                
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}