using ORM.Models;
using ORM.Controllers;

Console.WriteLine("Listado de Actores:");

// Instanciar el controlador
actoresControllers oActoresControllers = new actoresControllers();

// Obtener la lista de actores
var actores = oActoresControllers.ListadoActores();

// Recorrer y mostrar en consola
foreach (var actor in actores)
{
    Console.WriteLine($"Nombre: {actor.Nombre}, Apellido: {actor.Apellido}, Nacionalidad: {actor.Nacionalidad}");
}
