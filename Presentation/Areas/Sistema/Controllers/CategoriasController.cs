using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Areas.Sistema.Controllers
{
    [Authorize]
    public class CategoriasController : Controller
    {
        // GET: Sistema/Categorias
        public ActionResult Index()
        {
            return View();
        }
    }
}