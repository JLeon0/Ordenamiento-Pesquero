using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Windows.Forms;
using System.Configuration;

namespace CapaDatos
{
    public class Conexion
    {
        public SqlConnection con;
        public string bdda;
        public static string obtenertconexion()
        {
            return Properties.Settings.Default.OrdPesqueroConnectionString;
        }
        public Conexion(string bd) { 
            bdda=bd;
            con = new SqlConnection(obtenertconexion());
            //con.ChangeDatabase(bdda);
            //con.Open();
        }
        public void Generer_respaldo()
        {
            string back = "BACKUP DATABASE[OrdPesquero] TO DISK = N'C:/wamp64/resp.bak' WITH NOFORMAT, NOINIT, NAME = N'test-Completa Base de datos Copia de seguridad', SKIP,NOREWIND, NOUNLOAD,  STATS = 10";
            try
            {
                SqlCommand cmd = new SqlCommand(back, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("El backup fue realizado exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public bool cargar(string archivo)
        {
            //con.ChangeDatabase("master");
            //con.Close();
            string sBackup = " RESTORE DATABASE OrdPesquero" +
                             " FROM DISK = '" + archivo + "'" +
                             " WITH REPLACE";

            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
            csb.DataSource = ".";
            // Es mejor abrir la conexión con la base Master
            csb.InitialCatalog = "master";
            csb.IntegratedSecurity = true;
            //csb.ConnectTimeout = 480; // el predeterminado es 15

            using (SqlConnection cn = new SqlConnection(csb.ConnectionString))
            {
                try
                {
                    cn.Open();

                    SqlCommand cmdBackUp = new SqlCommand(sBackup, cn);
                    cmdBackUp.ExecuteNonQuery();
                    MessageBox.Show("Se ha restaurado la copia de la base de datos.",
                                    "Restaurar base de datos",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    cn.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                                    "Error al restaurar la base de datos",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        //Ejecutar Procedimiento
        public int Ejecutar(string Proc, string[] Parametros, params Object[] DatosParametro)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection cn = new SqlConnection(obtenertconexion()))
            {
                cn.Open();
                cn.ChangeDatabase(bdda);
                cmd.Connection = cn;
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
                            cn.Close();
                        }
                        catch { }
                    }
                    catch (Exception ms)
                    {
                        cn.Close();
                        return 0;
                    }
                }
                cn.Close();
                return 0;
            }
        }

        public DataTable getDatosTabla(string Proc, string[] Parametros, params Object[] DatosParametro)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection cn = new SqlConnection(obtenertconexion()))
            {
                try
                {
                    cn.Open();
                    cn.ChangeDatabase(bdda);
                    cmd.Connection = cn;
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
                            cn.Close();
                            return dt;
                        }
                        catch (Exception ms)
                        { }
                    }
                    cn.Close();
                    return dt;
                }catch(Exception s)
                {
                    return dt;
                }
            }
        }
    }
}