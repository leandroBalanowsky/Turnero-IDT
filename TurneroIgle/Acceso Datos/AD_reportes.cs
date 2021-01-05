using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TurneroIgle.Models;

namespace TurneroIgle.Acceso_Datos
{
    public class AD_reportes
    {
        public static List<Turno> TurnosActualesConfirmados()
        {
            List<Turno> resultado = new List<Turno>();
            string cadenaConeccion = System.Configuration.ConfigurationManager.AppSettings["cadenaBD"];
            SqlConnection conexion = new SqlConnection(cadenaConeccion);

            try
            {
                SqlCommand comando = new SqlCommand();
                string consulta = @"select * from turnos where idEstado = 1 and idFecha = (select top 1 idFecha
                                    from fechas
                                    where fechaTurno >= CONVERT (date, GETDATE())
                                    order by fechaTurno asc);";

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;
                conexion.Open();
                comando.Connection = conexion;
                SqlDataReader dr = comando.ExecuteReader();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        int idTurno = int.Parse(dr["idTurno"].ToString());
                        string nombre = dr["nombre"].ToString();
                        string apellido = dr["apellido"].ToString();
                        string dni = dr["dni"].ToString();
                        int idFecha = int.Parse(dr["idFecha"].ToString());
                        string telefono = dr["telefono"].ToString();
                        int idEstado = int.Parse(dr["idEstado"].ToString());

                        Turno aux = new Turno(idTurno, nombre, apellido, dni, idFecha, telefono, idEstado);
                        resultado.Add(aux);


                    }

                }
                dr.Close();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                conexion.Close();
            }
            return resultado;
        }
        public static List<Turno> ListaAnteriores(int idFecha)
        {
            List<Turno> resultado = new List<Turno>();
            string cadenaConeccion = System.Configuration.ConfigurationManager.AppSettings["cadenaBD"];
            SqlConnection conexion = new SqlConnection(cadenaConeccion);

            try
            {
                SqlCommand comando = new SqlCommand();
                string consulta = "select * from turnos where idEstado = 1 and idFecha  = @id";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@id", idFecha);
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;
                conexion.Open();
                comando.Connection = conexion;
                SqlDataReader dr = comando.ExecuteReader();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        int idTurno = int.Parse(dr["idTurno"].ToString());
                        string nombre = dr["nombre"].ToString();
                        string apellido = dr["apellido"].ToString();
                        string dni = dr["dni"].ToString();
                        int fecha = int.Parse(dr["idFecha"].ToString());
                        string telefono = dr["telefono"].ToString();
                        int idEstado = int.Parse(dr["idEstado"].ToString());

                        Turno aux = new Turno(idTurno, nombre, apellido, dni, fecha, telefono, idEstado);
                        resultado.Add(aux);


                    }

                }
                dr.Close();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                conexion.Close();
            }
            return resultado;
        }
        public static List<Turno> TurnosEspera()
        {
            List<Turno> resultado = new List<Turno>();
            string cadenaConeccion = System.Configuration.ConfigurationManager.AppSettings["cadenaBD"];
            SqlConnection conexion = new SqlConnection(cadenaConeccion);

            try
            {
                SqlCommand comando = new SqlCommand();
                string consulta = @"select * from turnos where idEstado = 3 and idFecha = (select top 1 idFecha
                                    from fechas
                                    where fechaTurno >= CONVERT (date, GETDATE())
                                    order by fechaTurno asc);";

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;
                conexion.Open();
                comando.Connection = conexion;
                SqlDataReader dr = comando.ExecuteReader();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        int idTurno = int.Parse(dr["idTurno"].ToString());
                        string nombre = dr["nombre"].ToString();
                        string apellido = dr["apellido"].ToString();
                        string dni = dr["dni"].ToString();
                        int idFecha = int.Parse(dr["idFecha"].ToString());
                        string telefono = dr["telefono"].ToString();
                        int idEstado = int.Parse(dr["idEstado"].ToString());

                        Turno aux = new Turno(idTurno, nombre, apellido, dni, idFecha, telefono, idEstado);
                        resultado.Add(aux);


                    }

                }
                dr.Close();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                conexion.Close();
            }
            return resultado;
        }

    }
}