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
                string consulta = @"select top 1 idFecha, CONVERT(varchar, fechaTurno, 3) as fechaTurnoProx
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
                        Fecha aux = new Fecha(idFecha, fechaTurno);
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