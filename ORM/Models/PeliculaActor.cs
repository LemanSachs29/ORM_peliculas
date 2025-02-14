using System;
using System.Collections.Generic;

namespace ORM.Models;

public partial class PeliculaActor
{
    public int PeliculaId { get; set; }

    public int ActorId { get; set; }

    public string? Personaje { get; set; }

    public int? Orden { get; set; }

    public virtual Actore Actor { get; set; } = null!;

    public virtual Pelicula Pelicula { get; set; } = null!;
}
