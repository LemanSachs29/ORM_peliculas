using System;
using System.Collections.Generic;

namespace ORM.Models;

public partial class Estudio
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Ubicacion { get; set; }

    public short? AnioFundacion { get; set; }

    public virtual ICollection<Pelicula> Peliculas { get; set; } = new List<Pelicula>();
}
