using System;
using System.Collections.Generic;

namespace ORM.Models;

public partial class PeliculaFestival
{
    public int Id { get; set; }

    public int PeliculaId { get; set; }

    public int FestivalId { get; set; }

    public DateOnly? ScreeningDate { get; set; }

    public string? PremioGanado { get; set; }

    public virtual Festivale Festival { get; set; } = null!;

    public virtual Pelicula Pelicula { get; set; } = null!;
}
