using dys2.Areas.Hakem.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dy2.Areas.Admin.Controllers
{
    [Authorize(Roles = "hakem")]
    public class HakemHomeController : HakemController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}