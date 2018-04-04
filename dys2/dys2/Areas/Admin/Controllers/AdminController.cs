using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dys2.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
    }
}