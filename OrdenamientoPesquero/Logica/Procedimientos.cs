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
        Conexion c = new Conexion();

        //Unidades Económicas
        #region
        public int Registrar_Unidad(Unidad_Economica UE)
        {
            string[] Parametros = { "@rnpa", "@Nombre", "@Rfc", "@calleynum", "@colonia", "@localidad", "@municipio", "@cp", "@presidente", "@secretario", "@tesorero", "@telpres", "@telsecre", "@teltesor", "@correo", "@telefono", "@Tipo" };
            return c.Ejecutar("RegistrarUnidad", Parametros, UE.RNPA, UE.NOMBRE, UE.RFC, UE.CALLE, UE.COLONIA, UE.LOCALIDAD, UE.MUNICIPIO, UE.CP, UE.PRESIDENTE, UE.SECRETARIO, UE.TESORERO, UE.TELPRES, UE.TELSECRE, UE.TELTESOR, UE.CORREO, UE.TELEFONO, UE.TIPO);   
        }
        public int Actualizar_Unidad(Unidad_Economica UE)
        {
            string[] Parametros = { "@rnpa", "@Nombre", "@Rfc", "@calleynum", "@colonia", "@localidad", "@municipio", "@cp", "@presidente", "@secretario", "@tesorero", "@telpres", "@telsecre", "@teltesor", "@correo", "@telefono", "@Tipo" };
            return c.Ejecutar("ActualizarUnidad", Parametros, UE.RNPA, UE.NOMBRE, UE.RFC, UE.CALLE, UE.COLONIA, UE.LOCALIDAD, UE.MUNICIPIO, UE.CP, UE.PRESIDENTE, UE.SECRETARIO, UE.TESORERO, UE.TELPRES, UE.TELSECRE, UE.TELTESOR, UE.CORREO, UE.TELEFONO, UE.TIPO);

        }
        public int Eliminar_Unidad(String RNPA)
        {
            string[] Parametros = { "@rnpa" };
            return c.Ejecutar("Eliminarunidad", Parametros, RNPA);
        }
        #endregion

        //Permisos
        #region Permisos
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
            return c.Ejecutar(" EliminarPermiso", Parametros, Numpermiso);
        }
        #endregion


        public DataTable Obtener_todas_unidades(string RNPA)
        {
            string[] Parametros = { "@rnpa" };
            return c.getDatosTabla("ObtenerDatos", Parametros, RNPA);
        }

        #region Pescador
        public int Registrar_Pescador(Pescador PES)
        {
            string[] Parametros = {"@nombre", "@appat", "@apmat", "@curp", "@rfc", "@escolaridad", "@tiposangre", "@sexo", "@lugarnacimiento", "@fechanac", "@callenum", "@colonia", "@munici", "@codpos", "@tel", "@tipo", "@ocupacion", "@cuerpo", "@matricula" };
            return c.Ejecutar("RegistrarPescador", Parametros, PES.NOMBRE, PES.AP_PAT, PES.AP_MAT, PES.CURP, PES.RFC, PES.ESCOLARIDAD, PES.TIP_SANG, PES.SEXO, PES.LUG_NACIMI, PES.FECH_NACIMI, PES.CALLENUM, PES.COLONIA, PES.MUNICIPIO, PES.CP, PES.TEL, PES.TIPO_PESC, PES.OCP_LABORAL, PES.CUERPO_DE_AGUA, PES.MATRICULA);

        }
        public int Actualizar_Pescador(Pescador PES)
        {
            string[] Parametros = {"@nombre", "@appat", "@apmat", "@curp", "@rfc", "@escolaridad", "@tiposangre", "@sexo", "@lugarnacimiento", "@fechanac", "@callenum", "@colonia", "@munici", "@codpos", "@tel", "@tipo", "@ocupacion", "@cuerpo", "@matricula" };
            return c.Ejecutar("ActualizarPescador", Parametros, PES.NOMBRE, PES.AP_PAT, PES.AP_MAT,PES.CURP, PES.RFC, PES.ESCOLARIDAD, PES.TIP_SANG, PES.SEXO,PES.LUG_NACIMI, PES.FECH_NACIMI, PES.CALLENUM, PES.COLONIA, PES.MUNICIPIO, PES.CP, PES.TEL, PES.TIPO_PESC, PES.OCP_LABORAL, PES.CUERPO_DE_AGUA, PES.MATRICULA);

        }
        public int Eliminar_Pescador(String CURP)
        {
            string[] Parametros = { "@curp" };
            return c.Ejecutar("EliminarPescador", Parametros, CURP);
        }
        #endregion
        #region Embarcacion
        public int Registrar_Embarcacion(Embarcacion EMB)
        {
            string[] Parametros = {"@matricula", "@nombre", "@rnpaemb", "@numchip", "@RegNUm", "@FechaExped", "@Fechachipeo", "@RNPATIT", "@munici", "@motorHP", "@motormarca","@eslora", "@manga", "@puntal", "@arqueobruto", "@arqueoneto", "@tonelaje", "@Observaciones"};
            return c.Ejecutar("RegistrarEmbarca", Parametros, EMB.Matricula, EMB.Nombre, EMB.RNP, EMB.AVID, EMB.REGISTRONUM, EMB.FECHAEXP, EMB.FECHACHIPEADO, EMB.RNPATITULAR, EMB.MUNICIPIO, EMB.HP, EMB.MARCA, EMB.ESLORA, EMB.MANGA, EMB.PUNTAL, EMB.ARQUEOBRUTO, EMB.ARQUEONETO, EMB.TONELAJE, EMB.OBSERVACIONES);

        }
        public int Actualizar_Embarcacion(Embarcacion EMB)
        {
            string[] Parametros = { "@matricula", "@nombre", "@rnpaemb", "@numchip", "@RegNUm", "@FechaExped", "@Fechachipeo", "@RNPATIT", "@munici", "@motorHP", "@motormarca", "@eslora", "@manga", "@puntal", "@arqueobruto", "@arqueoneto", "@tonelaje", "@Observaciones" };
            return c.Ejecutar("ActualizarEmbacacion", Parametros, EMB.Matricula, EMB.Nombre, EMB.RNP, EMB.AVID, EMB.REGISTRONUM, EMB.FECHAEXP, EMB.FECHACHIPEADO, EMB.RNPATITULAR, EMB.MUNICIPIO, EMB.HP, EMB.MARCA, EMB.ESLORA, EMB.MANGA, EMB.PUNTAL, EMB.ARQUEOBRUTO, EMB.ARQUEONETO, EMB.TONELAJE, EMB.OBSERVACIONES);

        }
        public int Eliminar_Embarcacion(String Matricula)
        {
            string[] Parametros = { "@matricula" };
            return c.Ejecutar("EliminarEmbarca", Parametros, Matricula);
        }
        #endregion
    }
}
