using System;
using System.Collections.Generic;

namespace ORM.Models;

public partial class PeliculaPremio
{
    public int Id { get; set; }

    public int PeliculaId { get; set; }

    public int PremioId { get; set; }

    public string? Categoria { get; set; }

    public int? Anio { get; set; }

    public virtual Pelicula Pelicula { get; set; } = null!;

    public virtual Premio Premio { get; set; } = null!;
}
