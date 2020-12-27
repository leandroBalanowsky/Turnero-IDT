using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TurneroIgle.Models;

namespace TurneroIgle.Acceso_Datos
{
    public class AD_fechas
    {
        public static List<Fecha> fechaTurnoActual()
        {
            List<Fecha> resultado = new List<Fecha>();
            string cadenaConeccion = System.Configuration.ConfigurationManager.AppSettings["cadenaBD"];
            SqlConnection conexion = new SqlConnection(cadenaConeccion);

            try
            {
                SqlCommand comando = new SqlCommand();
                string consulta = @"select top 1 idFecha, CONVERT(varchar, fechaTurno, 3) as fechaTurnoProx, dia
                                    from fechas
                                    where fechaTurno > GETDATE()
                                    order by fechaTurno asc;";
                comando.Parameters.Clear();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;
                conexion.Open();
                comando.Connection = conexion;
                SqlDataReader dr = comando.ExecuteReader();
                if (dr != null)
                {
                    if (dr.Read())
                    {
                        int idFecha = int.Parse(dr["idFecha"].ToString());
                        DateTime fechaTurno = DateTime.Parse(dr["fechaTurnoProx"].ToString());
                        string dia = dr["dia"].ToString();
                        Fecha aux = new Fecha(idFecha, fechaTurno, dia);
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
        public static Fecha fechaActual()
        {
            Fecha resultado = null;
            string cadenaConeccion = System.Configuration.ConfigurationManager.AppSettings["cadenaBD"];
            SqlConnection conexion = new SqlConnection(cadenaConeccion);

            try
            {
                SqlCommand comando = new SqlCommand();
                string consulta = @"select top 1 idFecha, CONVERT(varchar, fechaTurno, 3) as fechaTurnoProx, dia
                                    from fechas
                                    where fechaTurno > GETDATE()
                                    order by fechaTurno asc;";
                comando.Parameters.Clear();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;
                conexion.Open();
                comando.Connection = conexion;
                SqlDataReader dr = comando.ExecuteReader();
                if (dr != null)
                {
                    if (dr.Read())
                    {
                        int idFecha = int.Parse(dr["idFecha"].ToString());
                        DateTime fechaTurno = DateTime.Parse(dr["fechaTurnoProx"].ToString());
                        string dia = dr["dia"].ToString();
                        resultado = new Fecha(idFecha, fechaTurno, dia);
                        

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