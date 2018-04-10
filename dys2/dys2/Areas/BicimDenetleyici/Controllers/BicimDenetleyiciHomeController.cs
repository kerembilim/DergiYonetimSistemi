using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dys2.Areas.BicimDenetleyici.Controllers
{
    [Authorize(Roles = "bicimdenetleyici")]
    public class BicimDenetleyiciHomeController : Controller
    {
        // GET: BicimDenetleyici/BicimDenetleyiciHome
        public ActionResult Index()
        {
            return View();
        }
    }
}