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

        public Fecha(int idFecha, DateTime fechaTurno)
        {
            this.IdFecha = idFecha;
            this.FechaTurno = fechaTurno;
        }

        public int IdFecha { get => idFecha; set => idFecha = value; }
        public DateTime FechaTurno { get => fechaTurno; set => fechaTurno = value; }

    }
}