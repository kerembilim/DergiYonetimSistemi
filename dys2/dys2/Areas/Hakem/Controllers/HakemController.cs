using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dys2.Areas.Hakem.Controllers
{
    [Authorize(Roles = "hakem")]
    public class HakemController : Controller
    {
        // GET: Hakem/Hakem
        public ActionResult Index()
        {
            return View();
        }
    }
}