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
        private List<Turno> listaAnteriores;
        private List<Turno> listaEspera;

        public ReporteVM(int idFecha)
        {
            this.listaAsisten = new List<Turno>();
            this.ListaAnteriores = new List<Turno>();
            this.listaEspera = new List<Turno>();
            CargarReportes(idFecha);
        }

        private void CargarReportes(int idFecha)
        {
            listaAsisten = AD_reportes.TurnosActualesConfirmados();
            listaAnteriores = AD_reportes.ListaAnteriores(idFecha);
            listaEspera = AD_reportes.TurnosEspera();

        }

        public List<Turno> ListaAsisten { get => listaAsisten; set => listaAsisten = value; }
        public List<Turno> ListaAnteriores { get => listaAnteriores; set => listaAnteriores = value; }
        public List<Turno> ListaEspera { get => listaEspera; set => listaEspera = value; }
    }
}