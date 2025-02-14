using System;
using System.Collections.Generic;

namespace ORM.Models;

public partial class Pelicula
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateOnly? FechaLanzamiento { get; set; }

    public int? Duracion { get; set; }

    public decimal? Rating { get; set; }

    public string? Idioma { get; set; }

    public virtual ICollection<Funcione> Funciones { get; set; } = new List<Funcione>();

    public virtual ICollection<PeliculaActor> PeliculaActors { get; set; } = new List<PeliculaActor>();

    public virtual ICollection<PeliculaFestival> PeliculaFestivals { get; set; } = new List<PeliculaFestival>();

    public virtual ICollection<PeliculaPremio> PeliculaPremios { get; set; } = new List<PeliculaPremio>();

    public virtual ICollection<Publicidad> Publicidads { get; set; } = new List<Publicidad>();

    public virtual ICollection<Resena> Resenas { get; set; } = new List<Resena>();

    public virtual ICollection<ResenasCritico> ResenasCriticos { get; set; } = new List<ResenasCritico>();

    public virtual ICollection<Trailer> Trailers { get; set; } = new List<Trailer>();

    public virtual ICollection<Directore> Directors { get; set; } = new List<Directore>();

    public virtual ICollection<Estudio> Estudios { get; set; } = new List<Estudio>();

    public virtual ICollection<Genero> Generos { get; set; } = new List<Genero>();

    public virtual ICollection<Productore> Productors { get; set; } = new List<Productore>();
}
