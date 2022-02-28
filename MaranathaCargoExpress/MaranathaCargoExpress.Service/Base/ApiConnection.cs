using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaranathaCargoExpress.Service.Base
{
    public class ApiConnection
    {
        //Url de la API sin el Swageer
        public static string ApiUrl = "https://localhost:44371/";

        public static class EndPoints
        {
            public static string Cliente = "api/Cliente/";
            public static string Empleado = "api/Empleado/";
            public static string Rol = "api/Rol/";
            public static string Persona = "api/Persona/";
            public static string Traduccion = "api/Traduccion/";
            public static string Usuario = "api/Usuario/";
            public static string TipoCliente = "api/TipoCliente/";
            public static string TipoPersona = "api/TipoPersona/";
        }
    }
}
