using ApiCine.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ORM.Controllers;
using ORM.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()  // Permite solicitudes de cualquier origen
                   .AllowAnyMethod()  // Permite cualquier método (GET, POST, PUT, DELETE)
                   .AllowAnyHeader(); // Permite cualquier encabezado
        });
});

// Agregar soporte para controladores y Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Habilitar Swagger en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

// Endpoints para Películas
app.MapGet("/listadoPeliculas", () =>
{
    PeliculasController oPeliculaController = new PeliculasController(new CineContext());
    var listaPeliculas = oPeliculaController.ListadoPeliculas().Result;
    return listaPeliculas;
})
.WithName("listadoPeliculas")
.WithOpenApi();

app.MapPost("/agregarPelicula", (Pelicula nuevaPelicula) =>
{
    PeliculasController oPeliculaController = new PeliculasController(new CineContext());
    oPeliculaController.AgregarPelicula(nuevaPelicula);
    return "Película agregada correctamente.";
})
.WithName("altaPelicula")
.WithOpenApi();

app.MapDelete("/borrarPelicula/{id}", (long id) =>
{
    PeliculasController oPeliculaController = new PeliculasController(new CineContext());
    oPeliculaController.BorrarPelicula(id);
    return "Película eliminada correctamente.";
})
.WithName("borrarPelicula")
.WithOpenApi();

app.MapPut("/actualizarTituloPelicula/{id}", (long id, string nuevoTitulo) =>
{
    PeliculasController oPeliculaController = new PeliculasController(new CineContext());
    oPeliculaController.ActualizarTituloPelicula(id, nuevoTitulo);
    return "Título de la película actualizado.";
})
.WithName("actualizarTituloPelicula")
.WithOpenApi();


// Endpoints para Actores
app.MapGet("/listadoActores", () =>
{
    ActoresController oActoresController = new ActoresController(new CineContext());
    var listaActores = oActoresController.ListadoActores().Result;
    return listaActores;
})
.WithName("listadoActores")
.WithOpenApi();

app.MapPost("/agregarActor", (Actore nuevoActor) =>
{
    ActoresController oActoresController = new ActoresController(new CineContext());
    oActoresController.AgregarActor(nuevoActor);
    return "Actor agregado correctamente.";
})
.WithName("altaActor")
.WithOpenApi();

app.MapDelete("/borrarActor/{id}", (long id) =>
{
    ActoresController oActoresController = new ActoresController(new CineContext());
    oActoresController.BorrarActor(id);
    return "Actor eliminado correctamente.";
})
.WithName("borrarActor")
.WithOpenApi();

app.MapPut("/actualizarNombreActor/{id}", (long id, string nuevoNombre) =>
{
    ActoresController oActoresController = new ActoresController(new CineContext());
    oActoresController.ActualizarNombreActor(id, nuevoNombre);
    return "Nombre del actor actualizado.";
})
.WithName("actualizarNombreActor")
.WithOpenApi();

app.MapPut("/actualizarActor/{id}", (long id, Actore updatedActor) =>
{
    ActoresController oActoresController = new ActoresController(new CineContext());
    oActoresController.ActualizarActor(id, updatedActor);
    return "Actor actualizado correctamente.";
})
.WithName("actualizarActor")
.WithOpenApi();

app.Run();
