using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServicioWebORMCine
{
    /// <summary>
    /// Descripción breve de actores
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class actores : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {


            actoresControllers oActoresControllers = new actoresControllers();

            var resultadoActores = oActoresControllers.ListadoActores();


            foreach (var item in resultadoActores)
            {
                Console.WriteLine(item.Nombre);
            }

            return "Hola a todos";
        }
    }
}
