// See https://aka.ms/new-console-template for more information

using ORM.Models;
using ORM.Controllers;

//Console.WriteLine("Hello, World!");


//actoresControllers oActoresControllers=new actoresControllers();

//var miActor = new Actore();

/*
miActor.Nombre = "Robert";
miActor.Apellido = "De Niro";
miActor.Nacionalidad = "EEUU";
miActor.FechaNacimiento = new DateOnly(1947, 8, 17);

oActoresControllers.Add(miActor);
*/

/* oActoresControllers.UpdateActor(5, "Roberto"); */

/*
miActor.Nombre = "Sylvester";
miActor.Apellido = "Stallone";
miActor.Nacionalidad = "EEUU";
miActor.FechaNacimiento = new DateOnly(1946, 6, 6);
*/



//oActoresControllers.DeletedActore(5);

PeliculaController miController = new PeliculaController();

var pelicula = miController.ListadoPelicula();

Console.WriteLine("Pelicula");





