using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TurneroIgle.Models;

namespace TurneroIgle.Acceso_Datos
{
    public class AD_turno
    {
        public static bool insertarConfirmado(Turno t)
        {
            bool resultado = false;

            string cadenaConeccion = System.Configuration.ConfigurationManager.AppSettings["cadenaBD"];
            SqlConnection conexion = new SqlConnection(cadenaConeccion);

            try
            {
                SqlCommand comando = new SqlCommand();
                string consulta = @"insert into Turnos values(@nombre, @apellido, @dni, @idFecha, @telefono, @idEstado)";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@nombre", t.Nombre);
                comando.Parameters.AddWithValue("@apellido", t.Apellido);
                comando.Parameters.AddWithValue("@dni", t.Dni);
                comando.Parameters.AddWithValue("@idFecha", t.IdFecha);
                comando.Parameters.AddWithValue("@telefono", t.Telefono);
                comando.Parameters.AddWithValue("@idEstado", 1);

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;
                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                resultado = true;

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
        public static bool insertarEnEspera(Turno t)
        {
            bool resultado = false;

            string cadenaConeccion = System.Configuration.ConfigurationManager.AppSettings["cadenaBD"];
            SqlConnection conexion = new SqlConnection(cadenaConeccion);

            try
            {
                SqlCommand comando = new SqlCommand();
                string consulta = @"insert into Turnos values(@nombre, @apellido, @dni, @idFecha, @telefono, @idEstado)";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@nombre", t.Nombre);
                comando.Parameters.AddWithValue("@apellido", t.Apellido);
                comando.Parameters.AddWithValue("@dni", t.Dni);
                comando.Parameters.AddWithValue("@idFecha", t.IdFecha);
                comando.Parameters.AddWithValue("@telefono", t.Telefono);
                comando.Parameters.AddWithValue("@idEstado", 3);

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;
                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                resultado = true;

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
        public static bool turnoNoExiste(Turno t)
        {
            bool resultado = true;
            string cadenaConeccion = System.Configuration.ConfigurationManager.AppSettings["cadenaBD"];
            SqlConnection conexion = new SqlConnection(cadenaConeccion);

            try
            {
                SqlCommand comando = new SqlCommand();
                string consulta = @"select dni 
                                    from Turnos
                                    where dni = @dni and idFecha = @idFecha";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@dni", t.Dni);
                comando.Parameters.AddWithValue("@idFecha", t.IdFecha);

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;
                conexion.Open();
                comando.Connection = conexion;
                SqlDataReader dr = comando.ExecuteReader();
                if (dr != null)
                {
                    if (dr.Read())
                    {
                        resultado = false;
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
        public static int contadorTurno()
        {
            int resultado = 0;
            string cadenaConeccion = System.Configuration.ConfigurationManager.AppSettings["cadenaBD"];
            SqlConnection conexion = new SqlConnection(cadenaConeccion);

            try
            {
                SqlCommand comando = new SqlCommand();
                string consulta = @"select count(*) as contTurnos
                                    from Turnos
                                    where idEstado in (1, 2) and idFecha = (select top 1 idFecha
                                    from fechas
                                    where fechaTurno > GETDATE()
                                    order by fechaTurno asc)";
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
                        resultado = int.Parse(dr["contTurnos"].ToString());


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