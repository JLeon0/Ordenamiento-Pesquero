using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaDatos
{
    public class Conexion
    {
        public SqlConnection conexion;

        public static string obtenertconexion()
        {
            return Properties.Settings.Default.OrdPesqueroConnectionString;
        }
        public Conexion()
        {
            conexion = new SqlConnection(obtenertconexion());
        }

        public void ejecutar(SqlCommand cmd)
        {
            conexion.Open();
            cmd.Connection = conexion;
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            conexion.Close();
        }

    }
}