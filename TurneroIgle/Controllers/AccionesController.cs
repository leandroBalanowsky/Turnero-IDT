using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurneroIgle.Acceso_Datos;
using TurneroIgle.Models;

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
        public ActionResult EliminarTurno(int idTurno)
        {
            bool resultado = AD_turno.EliminarTurno(idTurno);
            if (resultado)
            {
                ViewBag.Mensaje = "El turno se elimino correctamente";
                return View();
            }
            else
            {
                ViewBag.Mensaje = "El turno no se pudo eliminar";
                return View();
            }
        }
    }
}