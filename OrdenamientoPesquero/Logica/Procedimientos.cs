using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaDatos;

namespace Logica
{
    public class Procedimientos
    {
        public string bdd="OrdPesquero";
        Conexion c;
        public Procedimientos()
        {
            c = new Conexion(bdd);
            c.bdda = bdd;

        }
        public void cambiarbd(string b)
        {
            c.bdda = bdd;
        }
        public bool Cargar(string path)
        {
            return c.cargar(path);
        }
        public void Generar()
        {
            //c.con.Close();
            c.Generer_respaldo();
        }

        #region UnidadEconomica
        public int Registrar_Unidad(Unidad_Economica UE)
        {
            string[] Parametros = { "@rnpa", "@Nombre", "@Rfc", "@calleynum", "@colonia", "@localidad", "@municipio", "@cp", "@correo", "@telefono", "@Tipo" };
            return c.Ejecutar("RegistrarUnidad", Parametros, UE.RNPA, UE.NOMBRE, UE.RFC, UE.CALLE, UE.COLONIA, UE.LOCALIDAD, UE.MUNICIPIO, UE.CP, UE.CORREO, UE.TELEFONO, UE.TIPO);
        }
        public int Actualizar_Unidad(Unidad_Economica UE)
        {
            string[] Parametros = { "@rnpa", "@Nombre", "@Rfc", "@calleynum", "@colonia", "@localidad", "@municipio", "@cp", "@correo", "@telefono", "@Tipo" };
            return c.Ejecutar("ActualizarUnidad", Parametros, UE.RNPA, UE.NOMBRE, UE.RFC, UE.CALLE, UE.COLONIA, UE.LOCALIDAD, UE.MUNICIPIO, UE.CP, UE.CORREO, UE.TELEFONO, UE.TIPO);

        }
        public int Eliminar_Unidad(String RNPA)
        {
            string[] Parametros = { "@rnpa" };
            return c.Ejecutar("Eliminarunidad", Parametros, RNPA);
        }
        #endregion


        #region Permisos
        public int Registrar_Equipo(string perm, string cantidad, string tipo, string caracteristicas)
        {
            string[] Parametros = { "@NPERM", "@CANTIDAD", "@TIPO", "@CARACT"};
            return c.Ejecutar("RegistrarEquiposPesca", Parametros, perm, cantidad, tipo, caracteristicas);
        }
        public int Borrar_equipo(string perm)
        {
            string[] Parametros = { "@NPERM"};
            return c.Ejecutar("BorrarEquiposPesca", Parametros, perm);
        }
        public int Registrar_Permiso(Permiso perm)
        {
            string[] Parametros = { "@folio", "@rnpa", "@npermiso", "@pesqueria", "@lugarexpedicion", "@diaexpedicion", "@finvigencia", "@zonapesca", "@sitiosdesembarque", "@observaciones" };
            return c.Ejecutar("RegistrarPermiso", Parametros, perm.FOLIO, perm.RNPA, perm.NPERMISO, perm.PESQUERIA, perm.LUGAR, perm.DIAEXP, perm.FINVIGENCIA, perm.ZONAPESC, perm.SITIOS, perm.OBSERVACIONES);
        }
        public int Actualizar_Permiso(Permiso perm)
        {
            string[] Parametros = { "@folio", "@rnpa", "@npermiso", "@pesqueria", "@lugarexpedicion", "@diaexpedicion", "@finvigencia", "@zonapesca", "@sitiosdesembarque", "@observaciones" };
            return c.Ejecutar("ActualizarPermiso", Parametros, perm.FOLIO, perm.RNPA, perm.NPERMISO, perm.PESQUERIA, perm.LUGAR, perm.DIAEXP, perm.FINVIGENCIA, perm.ZONAPESC, perm.SITIOS, perm.OBSERVACIONES);
        }
        public int Eliminar_Permiso(String Numpermiso)
        {
            string[] Parametros = { "@Npermiso" };
            return c.Ejecutar("EliminarPermiso", Parametros, Numpermiso);
        }
        public DataTable ObtenerNoPermisos(string RNPA)
        {
            string[] Parametros = { "@rnpa" };
            return c.getDatosTabla("NoPermisoxUnidad", Parametros, RNPA);
        }
        public DataTable ObtenerPermiso(string nopermiso)
        {
            string[] Parametros = { "@Nopermiso" };
            return c.getDatosTabla("PermisoxNoPermiso", Parametros, nopermiso);
        }
        public DataTable NumeroEmbarcaciones(string nopermiso)
        {
            string[] Parametros = { "@Nopermiso" };
            return c.getDatosTabla("NumeroEmbarcacionesxPermiso", Parametros, nopermiso);
        }
        public DataTable EmbarcacionesxPermiso(string nopermiso)
        {
            string[] Parametros = { "@Nopermiso" };
            return c.getDatosTabla("EmbarcacionesxPermiso", Parametros, nopermiso);
        }
        public DataTable EquiposxPermiso(string nopermiso)
        {
            string[] Parametros = { "@numPermiso" };
            return c.getDatosTabla("EquiposxPermiso", Parametros, nopermiso);
        }
        #endregion

        public DataTable ObtenerMunicipios()
        {
            return c.getDatosTabla("Municipios", new string[0], new string[0]);
        }
        public DataTable ObtenerLocalidades(string M)
        {
            string[] Parametros = { "@M" };
            return c.getDatosTabla("Localidades", Parametros, M);
        }
        public DataTable Obtener_todas_unidades(string RNPA)
        {
            string[] Parametros = { "@rnpa" };
            return c.getDatosTabla("ObtenerDatos", Parametros, RNPA);
        }
        public DataTable Obtener_todos_los_nombres()
         {
            string[] Parametros = {  };
            return c.getDatosTabla("ObtenerNombres", Parametros);
        }
        public DataTable Obtener_unidad(string nombre)
        {
            string[] Parametros = { "@nombre" };
            return c.getDatosTabla("ObtenerxNombre", Parametros, nombre);
        }
        public DataTable Obtener_Directiva(string rnpa)
        {
            string[] Parametros = { "@rnpa" };
            return c.getDatosTabla("ObtenerDirectiva", Parametros, rnpa);
        }

        public DataTable Obtener_unidades(string RNPA)
        {
            string[] Parametros = { "@rnpa" };
            return c.getDatosTabla("Obtener", Parametros, RNPA);
        }

        #region Pescador
        public int Registrar_Pescador(Pescador PES)
        {
            string[] Parametros = {"@nombre", "@appat", "@apmat", "@curp", "@rfc", "@escolaridad", "@tiposangre", "@sexo", "@lugarnacimiento", "@fechanac", "@callenum", "@colonia", "@munici", "@codpos", "@tel", "@tipo", "@ocupacion", "@cuerpo", "@matricula","@correo","@localidad","@ordenado" };
            return c.Ejecutar("RegistrarPescador", Parametros, PES.NOMBRE, PES.AP_PAT, PES.AP_MAT, PES.CURP, PES.RFC, PES.ESCOLARIDAD, PES.TIP_SANG, PES.SEXO, PES.LUG_NACIMI, PES.FECH_NACIMI, PES.CALLENUM, PES.COLONIA, PES.MUNICIPIO, PES.CP, PES.TEL, PES.TIPO_PESC, PES.OCP_LABORAL, PES.CUERPO_DE_AGUA, PES.MATRICULA, PES.CORREO,PES.LOCALIDAD, PES.ORDENADO);

        }
        public int Actualizar_Pescador(Pescador PES)
        {
            string[] Parametros = {"@nombre", "@appat", "@apmat", "@curp", "@rfc", "@escolaridad", "@tiposangre", "@sexo", "@lugarnacimiento", "@fechanac", "@callenum", "@colonia", "@munici", "@codpos", "@tel", "@tipo", "@ocupacion", "@cuerpo", "@matricula", "@correo", "@localidad", "@ordenado" };
            return c.Ejecutar("Actualizar_pescador", Parametros, PES.NOMBRE, PES.AP_PAT, PES.AP_MAT,PES.CURP, PES.RFC, PES.ESCOLARIDAD, PES.TIP_SANG, PES.SEXO,PES.LUG_NACIMI, PES.FECH_NACIMI, PES.CALLENUM, PES.COLONIA, PES.MUNICIPIO, PES.CP, PES.TEL, PES.TIPO_PESC, PES.OCP_LABORAL, PES.CUERPO_DE_AGUA, PES.MATRICULA, PES.CORREO, PES.LOCALIDAD, PES.ORDENADO);

        }
        public int Eliminar_Pescador(String CURP)
        {
            string[] Parametros = { "@curp" };
            return c.Ejecutar("EliminarPescador", Parametros, CURP);
        }
        public DataTable Obtener_curp(string RNPA)
        {
            string[] Parametros = { "@RNPA" };
            return c.getDatosTabla("CurpxUnidad", Parametros, RNPA);
        }
        public DataTable Obtener_Pescador(string Curp)
        {
            string[] Parametros = { "@Curp" };
            return c.getDatosTabla("ObtenerPescador", Parametros, Curp);
        }
        #endregion


        #region Embarcacion
        public int Registrar_Embarcacion(Embarcacion EMB)
        {
            string[] Parametros = {"@matricula", "@nombre","@RNPATIT","@motorHP", "@eslora", "@manga", "@puntal", "@arqueobruto","@arqueoneto","@tonelaje", "@servicio", "@trafico", "@nmotores" };
            return c.Ejecutar("RegistrarEmbarca", Parametros, EMB.Matricula, EMB.Nombre, EMB.RNPATITULAR,EMB.HP, EMB.ESLORA, EMB.MANGA, EMB.PUNTAL, EMB.ARQUEOBRUTO, EMB.ARQUEONETO, EMB.TONELAJE, EMB.SERVICIO, EMB.TRAFICO, EMB.NMOTORES);

        }
        public int Actualizar_Embarcacion(Embarcacion EMB)
        {
            string[] Parametros = { "@matricula", "@nombre", "@RNPATIT","@motorHP", "@eslora", "@manga", "@puntal", "@arqueobruto", "@arqueoneto", "@tonelaje", "@servicio", "@trafico", "@nmotores"};
            return c.Ejecutar("ActualizarEmbacacion", Parametros, EMB.Matricula, EMB.Nombre,EMB.RNPATITULAR, EMB.HP, EMB.ESLORA, EMB.MANGA, EMB.PUNTAL, EMB.ARQUEOBRUTO, EMB.ARQUEONETO, EMB.TONELAJE, EMB.SERVICIO, EMB.TRAFICO, EMB.NMOTORES);

        }
        public int Eliminar_Embarcacion(string Matricula)
        {
            string[] Parametros = { "@matricula" };
            return c.Ejecutar("EliminarEmbarca", Parametros, Matricula);
        }
        public int registrar_perm_emb(Embarcacion emb, string Permiso)
        {
            string[] Parametros = { "@MATRI", "@NOMBRE", "@RNPA", "@MUNICIPIO", "@HP", "@MARCA", "@PERMISO" };
            return c.Ejecutar("REGISTRO_PER_EMB", Parametros, emb.Matricula, emb.Nombre, emb.RNPATITULAR, emb.MUNICIPIO, emb.HP, emb.MARCA, Permiso);
        }

        public DataTable ObtenerCertMatrXUnidad(string RNPA)
        {
            string[] Parametros = { "@RNPA" };
            return c.getDatosTabla("CertMatXUnidad", Parametros, RNPA);
        }

        #endregion


        #region Resumen
        public DataTable Resumen(string RNPA)
        {
            string[] Parametros = { "@RNPA" };
            return c.getDatosTabla("Resumen", Parametros, RNPA);
        }

        public DataTable ResumenPesqueria (string RNPA)
        {
            string[] Parametros = { "@RNPA" };
            return c.getDatosTabla("Pesquerias", Parametros, RNPA);
        }
        #endregion


        #region Directiva
        public int Registrar_Directiva(Directiva dir)
        {
            string[] Parametros = { "@RNPA", "@NOMBRE", "@CARGO", "@FECHA_ING", "@TELEFONO" };
            return c.Ejecutar("Registrar_Directiva", Parametros, dir.RNPA, dir.Nombre, dir.Cargo, dir.Fecha_Ing, dir.Telefono);
        }

        public void EliminarDirectiva(string RNPA)
        {
            string[] Parametros = { "@rnpa" };
            c.Ejecutar("EliminarDirectiva", Parametros, RNPA);
        }
        #endregion
    }
}
