using dys2.Areas.Editor.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dy2.Areas.Admin.Controllers
{
    [Authorize(Roles = "editor")]
    public class EditorHomeController : EditorController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}