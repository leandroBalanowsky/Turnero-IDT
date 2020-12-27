using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurneroIgle.Acceso_Datos;
using TurneroIgle.Models;
using TurneroIgle.Models.ViewModels;

namespace TurneroIgle.Controllers
{
    public class ReportesController : Controller
    {
        // GET: Reportes
        public ActionResult Index()
        {
            ReporteVM reporte = new ReporteVM();
            Fecha turno = AD_fechas.fechaActual();
            ViewBag.Fecha = turno.ToString();
            return View(reporte);
        }
    }
}