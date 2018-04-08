using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dys2.Areas.BolumEditoru.Controllers
{
    [Authorize(Roles = "bolumeditoru")]
    public class AdminController : Controller
    {
    }
}