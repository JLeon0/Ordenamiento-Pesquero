﻿using System;
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
        public string bdd = "OrdPesquero";
        Conexion c;
        public Procedimientos()
        {
            c = new Conexion(bdd);
            c.bdda = bdd;

        }
        public void cambiarbd(string b)
        {
            c.bdda = b;
        }
        public bool Cargar(string path)
        {
            CerrarConexion();
            return c.cargar(path);
        }
        public void Generar(string dir, string rnpa)
        {
            //c.con.Close();
            c.Generer_respaldo(dir, rnpa);
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


        public DataTable ChecarCapitan(string RNPA, string MATRICULA)
        {
            string[] Parametros = { "@rnpa", "@matricula" };
            return c.getDatosTabla("ChecarCapitan", Parametros, RNPA, MATRICULA);
        }
        public DataTable ChecarMarineros(string RNPA, string MATRICULA)
        {
            string[] Parametros = { "@rnpa", "@matricula" };
            return c.getDatosTabla("ChecarMarineros", Parametros, RNPA, MATRICULA);
        }
        public int Actualizar_RNPA(string RNPAViejo, string RNPANuevo)
        {
            string[] Parametros = { "@rnpaviejo", "@rnpanuevo" };
            return c.Ejecutar("ActualizarRNPA", Parametros, RNPAViejo, RNPANuevo);
        }

        public DataTable ObtenerExpedientePescadorXUnidad(string RNPA)
        {
            string[] Parametros = { "@rnpa" };
            return c.getDatosTabla("ObtenerExpedientePescadorXUnidad", Parametros, RNPA);
        }
        public DataTable PescadoresXUnidad(string RNPA)
        {
            string[] Parametros = { "@RNPA" };
            return c.getDatosTabla("CurpxUnidad", Parametros, RNPA);
        }


        #endregion


        #region Permisos
        public int EliminarRelac(string perm)
        {
            string[] Parametros = { "@PERMISO" };
            return c.Ejecutar("EliminarRelacion", Parametros, perm);
        }
        public int Registrar_Equipo(string perm, string cantidad, string tipo, string caracteristicas)
        {
            string[] Parametros = { "@NPERM", "@CANTIDAD", "@TIPO", "@CARACT" };
            return c.Ejecutar("RegistrarEquiposPesca", Parametros, perm, cantidad, tipo, caracteristicas);
        }
        public int Borrar_equipo(string perm)
        {
            string[] Parametros = { "@NPERM" };
            return c.Ejecutar("BorrarEquiposPesca", Parametros, perm);
        }
        public int Registrar_Permiso(Permiso perm)
        {
            string[] Parametros = { "@folio", "@rnpa", "@npermiso", "@pesqueria", "@lugarexpedicion", "@diaexpedicion", "@finvigencia", "@zonapesca", "@sitiosdesembarque", "@tipoperm" };
            return c.Ejecutar("RegistrarPermiso", Parametros, perm.FOLIO, perm.RNPA, perm.NPERMISO, perm.PESQUERIA, perm.LUGAR, perm.DIAEXP, perm.FINVIGENCIA, perm.ZONAPESC, perm.SITIOS, perm.TIPOPERM);
        }
        public int Actualizar_Permiso(Permiso perm)
        {
            string[] Parametros = { "@folio", "@rnpa", "@npermiso", "@pesqueria", "@lugarexpedicion", "@diaexpedicion", "@finvigencia", "@zonapesca", "@sitiosdesembarque", "@tipoperm" };
            return c.Ejecutar("ActualizarPermiso", Parametros, perm.FOLIO, perm.RNPA, perm.NPERMISO, perm.PESQUERIA, perm.LUGAR, perm.DIAEXP, perm.FINVIGENCIA, perm.ZONAPESC, perm.SITIOS, perm.TIPOPERM);
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
        public DataTable p()
        {
            string[] Parametros = {};
            return c.getDatosTabla("p", Parametros);
        }
        public DataSet t()
        {
            string[] Parametros = { };
            return c.obtntab("t", Parametros);
        }
        public DataTable ObtenerPesquerias()
        {
            string[] Parametros = { };
            return c.getDatosTabla("ObtenerPesqueria", Parametros);
        }
        public int RegistrarPesqueria(string pesqueria)
        {
            string[] Parametros = { "@pesqueria" };
            return c.Ejecutar("RegistrarPesqueria", Parametros, pesqueria);
        }
        #endregion


        #region Obtener
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
        public DataTable Obtener_todos_los_nombres(string Nombre)
        {
            string[] Parametros = { "@nombre" };
            return c.getDatosTabla("ObtenerNombres", Parametros, Nombre);
        }
        public DataTable Obtener_unidad(string nombre)
        {
            string[] Parametros = { "@nombre" };
            return c.getDatosTabla("ObtenerNombres", Parametros, nombre);
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
        #endregion


        #region Pescador
        public int Registrar_Pescador(Pescador PES)
        {
            if (PES.MATRICULA != "NO APLICA")
            {
                string[] Parametros = { "@nombre", "@appat", "@apmat", "@curp", "@rfc", "@escolaridad", "@tiposangre", "@sexo", "@lugarnacimiento", "@fechanac", "@callenum", "@colonia", "@munici", "@codpos", "@tel", "@tipo", "@ocupacion", "@cuerpo", "@matricula", "@correo", "@localidad", "@ordenado", "@seguro", "@fechaexp_folio", "@fechaven_folio" };
                return c.Ejecutar("RegistrarPescador", Parametros, PES.NOMBRE, PES.AP_PAT, PES.AP_MAT, PES.CURP, PES.RFC, PES.ESCOLARIDAD, PES.TIP_SANG, PES.SEXO, PES.LUG_NACIMI, PES.FECH_NACIMI, PES.CALLENUM, PES.COLONIA, PES.MUNICIPIO, PES.CP, PES.TEL, PES.TIPO_PESC, PES.OCP_LABORAL, PES.CUERPO_DE_AGUA, PES.MATRICULA, PES.CORREO, PES.LOCALIDAD, PES.ORDENADO, PES.SEGURO, PES.FECHAEXPF, PES.FECHAVENF);

            }
            else
            {
                string[] Parametros = { "@nombre", "@appat", "@apmat", "@curp", "@rfc", "@escolaridad", "@tiposangre", "@sexo", "@lugarnacimiento", "@fechanac", "@callenum", "@colonia", "@munici", "@codpos", "@tel", "@tipo", "@ocupacion", "@cuerpo", "@matricula", "@correo", "@localidad", "@ordenado", "@RNPATIT", "@seguro",  "@fechaexp_folio", "@fechaven_folio" };
                return c.Ejecutar("RegistrarAcuacultor", Parametros, PES.NOMBRE, PES.AP_PAT, PES.AP_MAT, PES.CURP, PES.RFC, PES.ESCOLARIDAD, PES.TIP_SANG, PES.SEXO, PES.LUG_NACIMI, PES.FECH_NACIMI, PES.CALLENUM, PES.COLONIA, PES.MUNICIPIO, PES.CP, PES.TEL, PES.TIPO_PESC, PES.OCP_LABORAL, PES.CUERPO_DE_AGUA, PES.MATRICULA, PES.CORREO, PES.LOCALIDAD, PES.ORDENADO, PES.RNPA, PES.SEGURO, PES.FECHAEXPF, PES.FECHAVENF);
            }

        }
        public int Actualizar_Pescador(Pescador PES)
        {
            string[] Parametros = { "@nombre", "@appat", "@apmat", "@curp", "@rfc", "@escolaridad", "@tiposangre", "@sexo", "@lugarnacimiento", "@fechanac", "@callenum", "@colonia", "@munici", "@codpos", "@tel", "@tipo", "@ocupacion", "@cuerpo", "@matricula", "@correo", "@localidad", "@ordenado", "@RNPATIT", "@seguro",  "@fechaexp_folio", "@fechaven_folio" };
            return c.Ejecutar("Actualizar_pescador", Parametros, PES.NOMBRE, PES.AP_PAT, PES.AP_MAT, PES.CURP, PES.RFC, PES.ESCOLARIDAD, PES.TIP_SANG, PES.SEXO, PES.LUG_NACIMI, PES.FECH_NACIMI, PES.CALLENUM, PES.COLONIA, PES.MUNICIPIO, PES.CP, PES.TEL, PES.TIPO_PESC, PES.OCP_LABORAL, PES.CUERPO_DE_AGUA, PES.MATRICULA, PES.CORREO, PES.LOCALIDAD, PES.ORDENADO, PES.RNPA, PES.SEGURO, PES.FECHAEXPF, PES.FECHAVENF);

        }

        public int Actualizar_CURP(string CurpVieja, string CurpNueva)
        {
            string[] Parametros = { "@curpvieja", "@curpnueva" };
            return c.Ejecutar("ActualizarCurp", Parametros, CurpVieja, CurpNueva);
        }


        public int Eliminar_Pescador(string CURP, int Eliminar)
        {
            string[] Parametros = { "@curp", "@Eliminar" };
            return c.Ejecutar("EliminarPescador", Parametros, CURP, Eliminar);
        }

        public DataTable Obtener_Pescador(string Curp)
        {
            string[] Parametros = { "@Curp" };
            return c.getDatosTabla("ObtenerPescador", Parametros, Curp);
        }
        public int InsertarImagen(string CURP, byte[] imagen, byte[] firma, byte[] huella)
        {
            string[] Parametros = { "@curp", "@imagen", "@firma" ,"@huella"};
            return c.Ejecutar("InsertarImagen", Parametros, CURP, imagen, firma, huella);
        }
        public int InsertarArchivos(string CURP, byte[] archivo)
        {
            string[] Parametros = { "@curp", "@actanac" };
            return c.Ejecutar("InsertarPDF", Parametros, CURP, archivo);
        }
        public DataTable ObtenerExpedientePescador(string curp)
        {
            string[] Parametros = { "@curp" };
            return c.getDatosTabla("ObtenerExpedientePescador", Parametros, curp);
        }


        public DataTable ObtenerImagen(string curp)
        {
            string[] Parametros = { "@curp" };
            return c.getDatosTabla("ObtenerImagen", Parametros, curp);
        }
        public DataTable ObtenerFirma(string curp)
        {
            string[] Parametros = { "@curp" };
            return c.getDatosTabla("ObtenerFirma", Parametros, curp);
        }
        public DataTable BuscarNombre(string nombre, string rnpa)
        {
            string[] Parametros = { "@nombre", "@rnpa" };
            return c.getDatosTabla("BuscarPescador", Parametros, nombre, rnpa);
        }
        #endregion


        #region Embarcacion
        public int Registrar_Embarcacion(Embarcacion EMB)
        {
            string[] Parametros = { "@matricula", "@nombre", "@RNPATIT", "@motorHP", "@eslora", "@manga", "@puntal", "@arqueobruto", "@arqueoneto", "@tonelaje", "@servicio", "@trafico", "@nmotores", "@nchip", "@fchip", "@rchip", "@regnum", "@fexp", "@cap", "@marin", "@motormarca" };
            return c.Ejecutar("RegistrarEmbarca", Parametros, EMB.Matricula, EMB.Nombre, EMB.RNPATITULAR, EMB.HP, EMB.ESLORA, EMB.MANGA, EMB.PUNTAL, EMB.ARQUEOBRUTO, EMB.ARQUEONETO, EMB.TONELAJE, EMB.SERVICIO, EMB.TRAFICO, EMB.NMOTORES, EMB.NCHIP, EMB.FECHACHIPEADO, EMB.RESPCHIP, EMB.REGISTRONUM, EMB.FECHAEXP, EMB.CAPITAN, EMB.MARINERO, EMB.MARCA);

        }
        public int Actualizar_Embarcacion(Embarcacion EMB)
        {
            string[] Parametros = { "@matricula", "@nombre", "@RNPATIT", "@motorHP", "@eslora", "@manga", "@puntal", "@arqueobruto", "@arqueoneto", "@tonelaje", "@servicio", "@trafico", "@nmotores", "@nchip", "@fchip", "@rchip", "@regnum", "@fexp", "@cap", "@marin", "@motormarca" };
            return c.Ejecutar("ActualizarEmbacacion", Parametros, EMB.Matricula, EMB.Nombre, EMB.RNPATITULAR, EMB.HP, EMB.ESLORA, EMB.MANGA, EMB.PUNTAL, EMB.ARQUEOBRUTO, EMB.ARQUEONETO, EMB.TONELAJE, EMB.SERVICIO, EMB.TRAFICO, EMB.NMOTORES, EMB.NCHIP, EMB.FECHACHIPEADO, EMB.RESPCHIP, EMB.REGISTRONUM, EMB.FECHAEXP, EMB.CAPITAN, EMB.MARINERO, EMB.MARCA);

        }
        public int Actualizar_MATRICULA(string matvieja, string matnueva)
        {
            string[] Parametros = { "@matvieja", "@matnueva" };
            return c.Ejecutar("ActualizarMatricula", Parametros, matvieja, matnueva);
        }
        public int Eliminar_Embarcacion(string Matricula)
        {
            string[] Parametros = { "@matricula" };
            return c.Ejecutar("EliminarEmbarca", Parametros, Matricula);
        }
        public int registrar_perm_emb(Embarcacion emb, string Permiso)
        {
            string[] Parametros = { "@MATRI", "@PERMISO" };
            return c.Ejecutar("REGISTRO_PER_EMB", Parametros, emb.Matricula, Permiso);
        }

        public DataTable ObtenerCertMatrXUnidad(string RNPA)
        {
            string[] Parametros = { "@RNPA" };
            return c.getDatosTabla("CertMatXUnidad", Parametros, RNPA);
        }

        public DataTable ObtenerEmbarca(string Matricula)
        {
            string[] Parametros = { "@matricula" };
            return c.getDatosTabla("Obtener_Embarcacion", Parametros, Matricula);
        }
        public DataTable NpermisoxEmbarca(string Matricula)
        {
            string[] Parametros = { "@matricula" };
            return c.getDatosTabla("NpermisoxEmbarca", Parametros, Matricula);
        }
        public DataTable PermisosxEmbarca(string Matricula)
        {
            string[] Parametros = { "@matricula" };
            return c.getDatosTabla("PermisosxEmbarca", Parametros, Matricula);
        }

        #endregion


        #region Resumen
        public DataTable Resumen(string RNPA)
        {
            string[] Parametros = { "@RNPA" };
            return c.getDatosTabla("Resumen", Parametros, RNPA);
        }

        public DataTable ResumenPesqueria(string RNPA)
        {
            string[] Parametros = { "@RNPA" };
            return c.getDatosTabla("Pesquerias", Parametros, RNPA);
        }
        public DataTable ResumenSocios(string RNPA)
        {
            string[] Parametros = { "@RNPA" };
            return c.getDatosTabla("ResumenSocios", Parametros, RNPA);
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


        #region Federacion
        public int Registar_Federacion(string Nombre, string Presidente, string Telefono, string Correo)
        {
            string[] Parametros = { "@nombre", "@presidente", "@telefono", "@correo" };
            return c.Ejecutar("RegistrarFederacion", Parametros, Nombre, Presidente, Telefono, Correo);
        }
        public int Actualizar_Federacion(string Nombre, string Presidente, string Telefono, string Correo, int Folio)
        {
            string[] Parametros = { "@nombre", "@presidente", "@telefono", "@correo", "@folio" };
            return c.Ejecutar("ActualizarFederacion", Parametros, Nombre, Presidente, Telefono, Correo, Folio);
        }
        public int Eliminar_Federacion(int Folio)
        {
            string[] Parametros = { "@folio" };
            return c.Ejecutar("EliminarFederacion", Parametros, Folio);
        }
        public DataTable Obtener_Federaciones()
        {
            string[] Parametros = { "@Folio" };
            return c.getDatosTabla("ObtenerFederacion", Parametros, new string[] { "" });
        }
        public int AsignarFederacion(int Folio, string RNPA)
        {
            string[] Parametros = { "@folio", "@RNPA" };
            return c.Ejecutar("AsignarFederacion", Parametros, Folio, RNPA);
        }
        public DataTable ObtenerUnaFederacion(string RNPA)
        {
            string[] Parametros = { "@RNPA" };
            return c.getDatosTabla("ObtenerUnaFederacion", Parametros, RNPA);

        }
        #endregion


        #region Solicitudes
        public int Registrar_Solicitud(Solicitud soli)
        {
            string[] Parametros = { "@nombre", "@curp", "@folio", "@fecha", "@prioridad", "@concepto", "@estatus", "@monto", "@responsable", "@director", "@observaciones" };
            return c.Ejecutar("RegistrarSolicitud", Parametros, soli.NOMBRE, soli.CURP, soli.FOLIO, soli.FECHA, soli.PRIORIDAD, soli.CONCEPTO, soli.ESTATUS, soli.MONTO, soli.RESPONSABLE, soli.DIRECTOR, soli.OBSERVACIONES);
        }

        public int Actualizar_Solicitud(Solicitud soli)
        {
            string[] Parametros = { "@nombre", "@curp", "@folio", "@fecha", "@prioridad", "@concepto", "@estatus", "@monto", "@responsable", "@director", "@observaciones" };
            return c.Ejecutar("ActualizarSolicitud", Parametros, soli.NOMBRE, soli.CURP, soli.FOLIO, soli.FECHA, soli.PRIORIDAD, soli.CONCEPTO, soli.ESTATUS, soli.MONTO, soli.RESPONSABLE, soli.DIRECTOR, soli.OBSERVACIONES);
        }

        public DataTable ObtenerSolicitudes(string curp)
        {
            string[] Parametros = { "@curp" };
            return c.getDatosTabla("ObtenerSolicitudesxCurp", Parametros, curp);
        }

        public int Entregar_Solicitud(string folio)
        {
            string[] Parametros = { "@folio" };
            return c.Ejecutar("EntregarSolicitud", Parametros, folio);
        }
        #endregion


        #region Apoyos
        public int Registrar_Apoyo(Solicitud soli)
        {
            string[] Parametros = { "@nombre", "@curp", "@folio", "@fecha", "@concepto", "@observaciones", "@montoE", "@montoF", "@montoP", "@programa" };
            return c.Ejecutar("RegistrarApoyo", Parametros, soli.NOMBRE, soli.CURP, soli.FOLIO, soli.FECHA, soli.CONCEPTO, soli.OBSERVACIONES, soli.MONTOESTATAL, soli.MONTOFEDERAL, soli.MONTOPRODUCTOR, soli.PROGRAMA);
        }

        public int Actualizar_Apoyo(Solicitud soli)
        {
            string[] Parametros = { "@nombre", "@curp", "@folio", "@fecha", "@concepto", "@observaciones", "@montoE", "@montoF", "@montoP", "@programa" };
            return c.Ejecutar("ActualizarApoyo", Parametros, soli.NOMBRE, soli.CURP, soli.FOLIO, soli.FECHA, soli.CONCEPTO, soli.OBSERVACIONES, soli.MONTOESTATAL, soli.MONTOFEDERAL, soli.MONTOPRODUCTOR, soli.PROGRAMA);

        }
        public DataTable ObtenerApoyos (string curp)
        {
            string[] Parametros = { "@curp" };
            return c.getDatosTabla("ObtenerApoyosxCurp", Parametros, curp);
        }
        #endregion


        #region Respaldos
        public int PasarPescadores()
        {
            string[] Parametros = { };
            return c.EjecutarMaster("PasarPescadores2", Parametros);
        }
        public int PasarDirectiva()
        {
            string[] Parametros = {  };
            return c.EjecutarMaster("PasarDirectiva2", Parametros);
        }
        public int PasarEmbarcaciones()
        {
            string[] Parametros = {  };
            return c.EjecutarMaster("PasarEmbarcaciones2", Parametros);
        }
        public int PasarPermisos()
        {
            string[] Parametros = {  };
            return c.EjecutarMaster("PasarPermisos2", Parametros);
        }
        public int PasarUnidad()
        {
            string[] Parametros = { };
            return c.EjecutarMaster("PasarUnidad2", Parametros);
        }
        public int PasarEquipoPesca()
        {
            string[] Parametros = {  };
            return c.EjecutarMaster("PasarEquipoPesca2", Parametros);
        }
        public int PasarEmbarcaPermis()
        {
            string[] Parametros = {  };
            return c.EjecutarMaster("PasarEmbarcaPermis2", Parametros);
        }
        public int PasarPescadores2(string rnpa)
        {
            string[] Parametros = { "@rnpa"};
            return c.EjecutarMaster("PasarPescadores3", Parametros, rnpa);
        }
        public int PasarDirectiva2(string rnpa)
        {
            string[] Parametros = { "@rnpa" };
            return c.EjecutarMaster("PasarDirectiva3", Parametros, rnpa);
        }
        public int PasarEmbarcaciones2(string rnpa)
        {
            string[] Parametros = { "@rnptitular" };
            return c.EjecutarMaster("PasarEmbarcaciones3", Parametros, rnpa);
        }
        public int PasarPermisos2(string rnpa)
        {
            string[] Parametros = { "@rnpa" };
            return c.EjecutarMaster("PasarPermisos3", Parametros, rnpa);
        }
        public int PasarUnidad2(string rnpa)
        {
            string[] Parametros = {"@rnpa" };
            return c.EjecutarMaster("PasarUnidad3", Parametros, rnpa);
        }
        public int PasarEquipoPesca2(string rnpa)
        {
            string[] Parametros = { "@rnpa" };
            return c.EjecutarMaster("PasarEquipoPesca3", Parametros, rnpa);
        }
        public int PasarEmbarcaPermis2(string rnpa)
        {
            string[] Parametros = { "@rnpa" };
            return c.EjecutarMaster("PasarEmbarcaPermis3", Parametros, rnpa);
        }
        public int CerrarConexion()
        {
            string[] Parametros = { "@bd" };
            return c.EjecutarMaster("cerrarCon", Parametros, "OrdPesquero2");
        }

        public int limpiar()
        {
            string[] Parametros = { };
            return c.Ejecutar2("limpiar", Parametros);
        }

        #endregion


    }
}
