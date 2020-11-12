using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TurneroIgle.Controllers
{
    public class AccionesController : Controller
    {
        // GET: Acciones
        public ActionResult CargaExitosa()
        {
            return View();
        }
        public ActionResult YaTieneTurno()
        {
            return View();
        }
    }
}