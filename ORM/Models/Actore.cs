using System;
using System.Collections.Generic;

namespace ORM.Models;

public partial class Actore
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Apellido { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? Nacionalidad { get; set; }

    public virtual ICollection<PeliculaActor> PeliculaActors { get; set; } = new List<PeliculaActor>();
}
