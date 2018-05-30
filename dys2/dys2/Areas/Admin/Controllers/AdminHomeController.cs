using dys2.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dy2.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminHomeController : AdminController
    {
        // GET: Admin/Home
       
    }
}