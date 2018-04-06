using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dys2.Areas.Editor.Controllers
{
    [Authorize(Roles = "editor")]
    public class EditorController : Controller
    {
    }
}