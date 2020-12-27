using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TurneroIgle.Models
{
    public class Turno
    {
        private int idTurno;
        private string nombre;
        private string apellido;
        private string dni;
        private int idFecha;
        private string telefono;
        private int idEstado;

        public Turno(int idTurno, string nombre, string apellido, string dni, int idFecha, string telefono, int idEstado)
        {
            this.idTurno = idTurno;
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.idFecha = idFecha;
            this.telefono = telefono;
            this.idEstado = idEstado;
        }

        public Turno()
        {

        }
        public int IdTurno { get => idTurno; set => idTurno = value; }

        [Required(ErrorMessage = "*Ingrese correctamente el Nombre")]
        [StringLength(50, ErrorMessage = "*El Nombre es demasiado largo(50 caracteres)")]
        public string Nombre { get => nombre; set => nombre = value; }

        [Required(ErrorMessage = "*Ingrese correctamente el Apellido")]
        [StringLength(50, ErrorMessage = "*El Apellido es demasiado largo(50 caracteres)")]
        public string Apellido { get => apellido; set => apellido = value; }

        [Required(ErrorMessage = "*Ingrese correctamente el DNI")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El DNI debe ser un numero")]
        [StringLength(50, ErrorMessage = "*El DNI no es valido")]
        public string Dni { get => dni; set => dni = value; }

        public int IdFecha { get => idFecha; set => idFecha = value; }

        [Required(ErrorMessage = "*Ingrese correctamente el Telefono")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El Telefono debe ser numerico (Codigo de area sin el 15)")]
        [StringLength(50, ErrorMessage = "*El Telefono no es valido")]
        public string Telefono { get => telefono; set => telefono = value; }

        public int IdEstado { get => idEstado; set => idEstado = value; }

    }

}