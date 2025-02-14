using System;
using System.Collections.Generic;

namespace ORM.Models;

public partial class Publicidad
{
    public int Id { get; set; }

    public int PeliculaId { get; set; }

    public string Campaña { get; set; } = null!;

    public decimal? Presupuesto { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public virtual Pelicula Pelicula { get; set; } = null!;
}
