using System;
using System.Collections.Generic;

namespace ORM.Models;

public partial class Productore
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Apellido { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? Nacionalidad { get; set; }

    public virtual ICollection<Pelicula> Peliculas { get; set; } = new List<Pelicula>();
}
