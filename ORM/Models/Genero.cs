using System;
using System.Collections.Generic;

namespace ORM.Models;

public partial class Genero
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Pelicula> Peliculas { get; set; } = new List<Pelicula>();
}
