using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CapaDatos;

namespace Logica
{
    public class Procedimientos
    {
        Conexion c = new Conexion();
        public int Registrar_Unidad(Unidad_Economica UE)
        {
            string[] Parametros = { "@rnpa", "@Nombre", "@Rfc", "@calleynum", "@colonia", "@localidad", "@municipio", "@cp", "@presidente", "@secretario", "@tesorero", "@telpres", "@telsecre", "@teltesor", "@correo", "@telefono", "@Tipo" };
            return c.Ejecutar("RegistrarUnidad", Parametros, UE.RNPA, UE.NOMBRE, UE.RFC, UE.CALLE, UE.COLONIA, UE.LOCALIDAD, UE.MUNICIPIO, UE.CP, UE.PRESIDENTE, UE.SECRETARIO, UE.TESORERO, UE.TELPRES, UE.TELSECRE, UE.TELTESOR, UE.CORREO, UE.TELEFONO, UE.TIPO);   
        }
        public void Actualizar_Unidad(Unidad_Economica UE)
        {

        }
        public void Eliminar_Unidad(String RNPA)
        {

        }
    }
}
