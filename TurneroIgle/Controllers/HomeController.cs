using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurneroIgle.Acceso_Datos;
using TurneroIgle.Models;


namespace TurneroIgle.Controllers
{
    public class HomeController : Controller
    {
        private int cantidadTurnos = 5;

        private int contador()
        {
            int contador = cantidadTurnos - AD_turno.contadorTurno();
            return contador;
        }

        private List<SelectListItem> cargarFechas()
        {
            List<Fecha> fechaActual = AD_fechas.fechaTurnoActual();
            List<SelectListItem> lista = fechaActual.ConvertAll(f =>
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
        public ActionResult Index()
        {
            ViewBag.items = cargarFechas();
            ViewBag.cont = contador();
            return View();
        }
        [HttpPost]
        public ActionResult Index(Turno model)
        {



            if (ModelState.IsValid)
            {
                bool noExiste = AD_turno.turnoNoExiste(model);
                if (noExiste)
                {
                    if (contador() == 0)
                    {
                        bool resultado = AD_turno.insertarEnEspera(model);
                        if (resultado)
                        {
                            return RedirectToAction("CargaExitosa", "Acciones");
                        }
                        else
                        {
                            ViewBag.items = cargarFechas();
                            ViewBag.cont = contador();
                            return View(model);
                        }
                    }
                    else
                    {
                        bool resultado = AD_turno.insertarConfirmado(model);
                        if (resultado)
                        {
                            return RedirectToAction("CargaExitosa", "Acciones");
                        }
                        else
                        {
                            ViewBag.items = cargarFechas();
                            ViewBag.cont = contador();
                            return View(model);
                        }
                    }

                }
                else
                {
                    return RedirectToAction("YaTieneTurno", "Acciones");

                }

            }
            else
            {
                ViewBag.items = cargarFechas();
                ViewBag.cont = contador();
                return View(model);
            }
        }
        public ActionResult BuscarTurno()
        {
            ViewBag.items = cargarFechas();
            ViewBag.Mensaje = "Ingrese su DNI";
            return View();
        }
        [HttpPost]
        public ActionResult BuscarTurno(string Dni, int IdFecha)
        {
            ViewBag.items = cargarFechas();
            ViewBag.Mensaje = "NO HAY TURNO REGISTRADO PARA EL DNI " + Dni + " (Asegurese de haber puesto bien el DNI)";
            Turno model = AD_turno.BuscarTurno(Dni, IdFecha);
            return View(model);
        }
    }
}