using System;
using System.Collections.Generic;

namespace ORM.Models;

public partial class Festivale
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Ubicacion { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public virtual ICollection<PeliculaFestival> PeliculaFestivals { get; set; } = new List<PeliculaFestival>();
}
