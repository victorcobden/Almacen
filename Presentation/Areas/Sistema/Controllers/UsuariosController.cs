using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Areas.Sistema.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Sistema/Usuarios
        public ActionResult Index()
        {
            return View();
        }
    }
}