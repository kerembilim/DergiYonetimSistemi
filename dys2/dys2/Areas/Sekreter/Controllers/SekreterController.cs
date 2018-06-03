using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dys2.Areas.Sekreter.Controllers
{
    [Authorize(Roles = "sekreter")]
    public class SekreterController : Controller
    {
        // GET: Hakem/Hakem
        public ActionResult Index()
        {
            return View();
        }
    }
}