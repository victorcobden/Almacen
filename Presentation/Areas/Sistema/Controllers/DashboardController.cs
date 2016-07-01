using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Areas.Sistema.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        // GET: Sistema/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}