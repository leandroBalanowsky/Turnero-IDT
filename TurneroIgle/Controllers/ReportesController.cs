using Rotativa;
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
        private List<SelectListItem> cargarFechasAnteriores()
        {
            List<Fecha> fecha = AD_fechas.fechaTurnosAnteriores();
            List<SelectListItem> lista = fecha.ConvertAll(f =>
            {
                return new SelectListItem()
                {
                    Text = f.Dia + ", " + f.FechaTurno.Date.ToShortDateString(),
                    Value = f.IdFecha.ToString(),
                    Selected = false
                };
            });

            return lista;

        }
        // GET: Reportes
        public ActionResult Index()
        {
            Fecha anterior = AD_fechas.fechaAnterior();
            ReporteVM reporte = new ReporteVM(anterior.IdFecha);
            Fecha turno = AD_fechas.fechaActual();
            ViewBag.Fecha = turno.ToString();
            ViewBag.items = cargarFechasAnteriores();
            return View(reporte);
        }
        public ActionResult Lista()
        {
            List<Turno> turnoActuales = AD_reportes.TurnosActualesConfirmados();
            return View(turnoActuales);
        }
        [HttpPost]
        public ActionResult Index(int IdFecha)
        {
            ReporteVM reporte = new ReporteVM(IdFecha);
            Fecha turno = AD_fechas.fechaActual();
            ViewBag.Fecha = turno.ToString();
            ViewBag.items = cargarFechasAnteriores();
            return View(reporte);
        }

    }

}