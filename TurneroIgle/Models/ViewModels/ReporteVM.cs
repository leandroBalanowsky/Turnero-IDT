using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TurneroIgle.Acceso_Datos;

namespace TurneroIgle.Models.ViewModels
{
    public class ReporteVM
    {
        private List<Turno> listaAsisten;

        public ReporteVM()
        {
            this.listaAsisten = new List<Turno>();
            CargarReportes();
        }

        private void CargarReportes()
        {
            listaAsisten = AD_reportes.TurnosActualesConfirmados();   
        }

        public List<Turno> ListaAsisten { get => listaAsisten; set => listaAsisten = value; }
    }
}