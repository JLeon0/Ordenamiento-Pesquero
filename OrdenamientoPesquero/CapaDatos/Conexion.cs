using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaDatos
{
    public class Conexion
    {
        public SqlConnection con;

        public static string obtenertconexion()
        {
            return Properties.Settings.Default.OrdPesqueroConnectionString;
        }
        public Conexion()
        {
            con = new SqlConnection(obtenertconexion());
            con.Open();
        }


        //Ejecutar Procedimiento
        public int Ejecutar(string Proc, string[] Parametros, params Object[] DatosParametro)
        {
            SqlCommand cmd = new SqlCommand();
            Conexion conexion = new Conexion();
            cmd.Connection = con;
            cmd.CommandText = Proc;
            cmd.CommandType = CommandType.StoredProcedure;

            if (Proc.Length != 0 && Parametros.Length == DatosParametro.Length)
            {
                int i = 0;
                foreach (string parametro in Parametros)
                    cmd.Parameters.AddWithValue(parametro, DatosParametro[i++]);
                try
                {
                    return cmd.ExecuteNonQuery();
                    try
                    {
                        this.con.Close();
                    }
                    catch
                    {

                    }
                }
                catch (Exception ms)
                {
                    return 0;
                }
            }
            return 0;
        }

        public DataTable getDatosTabla(string Proc, string[] Parametros, params Object[] DatosParametro)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            Conexion conexion = new Conexion();
            cmd.Connection = con;
            cmd.CommandText = Proc;
            cmd.CommandType = CommandType.StoredProcedure;

            if (Proc.Length != 0 && Parametros.Length == DatosParametro.Length)
            {
                int i = 0;
                foreach (string parametro in Parametros)
                    cmd.Parameters.AddWithValue(parametro, DatosParametro[i++]);
                try
                {
                    SqlDataReader dr = null;
                    dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    return dt;
                }
                catch (Exception ms)
                { }
            }
            return dt;
        }
    }
}