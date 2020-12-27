using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurneroIgle.Models
{
    public class Fecha
    {
        private int idFecha;
        private DateTime fechaTurno;
        private string dia;

        public Fecha(int idFecha, DateTime fechaTurno, string dia)
        {
            this.IdFecha = idFecha;
            this.FechaTurno = fechaTurno;
            this.Dia = dia;
        }

        public int IdFecha { get => idFecha; set => idFecha = value; }
        public DateTime FechaTurno { get => fechaTurno; set => fechaTurno = value; }
        public string Dia { get => dia; set => dia = value; }

        override public string ToString()
        {
            return dia + ", " + fechaTurno.Date.ToShortDateString();
        }
    }
}