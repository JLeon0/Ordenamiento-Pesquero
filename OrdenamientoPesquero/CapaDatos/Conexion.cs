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
using System.IO;

namespace CapaDatos
{
    public class Conexion
    {
        public SqlConnection con;
        public string bdda;
        public string CONEXIONPERRONA = "";

        public static string obtenertconexion()
        {
            return Properties.Settings.Default.OrdPesqueroConnectionString;
        }
        public string setString(string instancia)
        {
            CONEXIONPERRONA = "Data source = " + instancia + "; Initial Catalog = OrdPesquero; Integrated Security = true;";
            Properties.Settings.Default.OrdPesqueroConnectionString = CONEXIONPERRONA;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //hacemos la modificacion de la cadena de conexion (ServerDb es el atributo que tengo en app.config)
            for (int i = 0; i < config.ConnectionStrings.ConnectionStrings.Count; i++)
            {
                config.ConnectionStrings.ConnectionStrings[i].ConnectionString = CONEXIONPERRONA;
            }
            //Cambiamos el modo de guardado
            config.Save(ConfigurationSaveMode.Modified, true);
            // modificamos el guardado
            Properties.Settings.Default.Save();
            return CapaDatos.Properties.Settings.Default.OrdPesqueroConnectionString;
        }
        public Conexion(string bd) { 
            bdda=bd;
            con = new SqlConnection(obtenertconexion());
            //con.ChangeDatabase(bdda);
            //con.Open();
        }
        public Conexion(string bd, string instancia)
        {
            bdda = bd;
            con = new SqlConnection(setString(instancia));
        }
        public void Generer_respaldo(string direc, string rnpa)
        {
            string back = "BACKUP DATABASE[OrdPesquero2] TO DISK = N'"+direc+"\\"+rnpa+".bak"+"' WITH NOFORMAT, NOINIT, NAME = N'test-Completa Base de datos Copia de seguridad', SKIP,NOREWIND, NOUNLOAD,  STATS = 10";
            try
            {
                SqlCommand cmd = new SqlCommand(back, con);
                con.Open();
                cmd.ExecuteNonQuery();
               // string temporaryTableName = "temp";
               // string _sql = "";
               // string AremoteTempPath = "C:/wamp64/resp.bak";
               // string AlocalPath = "C:/Users/ERNESTOPADILLA/Desktop";
               // string fileName = "resp.bak";
               // string _dbname = "OrdPesquero";
               // _sql = String.Format("IF OBJECT_ID('tempdb..##{0}') IS " +
               //      "NOT NULL DROP TABLE ##{0}", temporaryTableName);
               // cmd.CommandText = _sql;
               // cmd.ExecuteNonQuery();
               // _sql = String.Format("CREATE TABLE ##{0} (bck VARBINARY(MAX))",
               //                      temporaryTableName);
               // cmd.CommandText = _sql;
               // cmd.ExecuteNonQuery();
               // _sql = String.Format("INSERT INTO ##{0} SELECT bck.* FROM " +
               //"OPENROWSET(BULK '{1}',SINGLE_BLOB) bck",
               //temporaryTableName, AremoteTempPath, _dbname);
               // cmd.CommandText = _sql;
               // cmd.ExecuteNonQuery();
               // _sql = String.Format("SELECT bck FROM ##{0}", temporaryTableName);
               // SqlDataAdapter da = new SqlDataAdapter(_sql, con);
               // DataSet ds = new DataSet();
               // da.Fill(ds);
               // DataRow dr = ds.Tables[0].Rows[0];
               // byte[] backupFromServer = new byte[0];
               // backupFromServer = (byte[])dr["bck"];
               // int aSize = new int();
               // aSize = backupFromServer.GetUpperBound(0) + 1;

               // FileStream fs = new FileStream(String.Format("{0}\\{1}",
               //                 AlocalPath, fileName), FileMode.OpenOrCreate,
               //                 FileAccess.Write);
               // fs.Write(backupFromServer, 0, aSize);
               // fs.Close();

               // _sql = String.Format("DROP TABLE ##{0}", temporaryTableName);
               // cmd.CommandText = _sql;
               // cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.ToString());
            }
        }

        public bool cargar(string archivo)
        {
            //con.ChangeDatabase("master");
            //con.Close();
            string deleete = "Drop database OrdPesquero2";
            string sBackup = " RESTORE DATABASE OrdPesquero2" +
                             " FROM DISK = '" + archivo + "'" +
                             " WITH REPLACE";
            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
            csb.DataSource = ".\\SQLEXPRESS";
            // Es mejor abrir la conexión con la base Master
            csb.InitialCatalog = "master";
            csb.IntegratedSecurity = true;
            //csb.ConnectTimeout = 480; // el predeterminado es 15

            using (SqlConnection cn = new SqlConnection(csb.ConnectionString))
            {
                try
                {
                    cn.Open();
                    SqlCommand cmdDrop = new SqlCommand(deleete, cn);
                    cmdDrop.ExecuteNonQuery();
                    SqlCommand cmdBackUp = new SqlCommand(sBackup, cn);
                    cmdBackUp.ExecuteNonQuery();
                    //MessageBox.Show("Se ha restaurado la copia de la base de datos.",
                    //                "Restaurar base de datos",
                    //                MessageBoxButtons.OK,
                    //                MessageBoxIcon.Information);

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
        public DataSet obtntab(string Proc, string[] Parametros, params Object[] DatosParametro)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cn = new SqlConnection(obtenertconexion()))
            {
                try
                {
                    cn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("exec t", cn);
                    da.Fill(ds);
                    cn.Close();
                }
                catch(Exception s)
                {

                }
                return ds;
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
                }
                catch (Exception s)
                {
                    return dt;
                }
            }
        }
        public int EjecutarMaster(string Proc, string[] Parametros, params Object[] DatosParametro)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
            csb.DataSource = ".\\SQLEXPRESS";
            // Es mejor abrir la conexión con la base Master
            csb.InitialCatalog = "master";
            csb.IntegratedSecurity = true;
            //csb.ConnectTimeout = 480; // el predeterminado es 15

            using (SqlConnection cn = new SqlConnection(csb.ConnectionString))
            {
                cn.Open();
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
        public int Ejecutar2(string Proc, string[] Parametros, params Object[] DatosParametro)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection cn = new SqlConnection(obtenertconexion()))
            {
                cn.Open();
                cn.ChangeDatabase("OrdPesquero2");
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
    }
}