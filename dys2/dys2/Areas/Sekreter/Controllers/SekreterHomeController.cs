using dys2.Areas.Hakem.Controllers;
using dys2.Areas.Sekreter.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dy2.Areas.Admin.Controllers
{
    [Authorize(Roles = "sekreter")]
    public class SekreterHomeController : SekreterController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}