using System;
using System.Collections.Generic;

namespace ORM.Models;

public partial class Trailer
{
    public int Id { get; set; }

    public int PeliculaId { get; set; }

    public string Url { get; set; } = null!;

    public string? Idioma { get; set; }

    public string? Calidad { get; set; }

    public virtual Pelicula Pelicula { get; set; } = null!;
}
