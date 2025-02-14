using System;
using System.Collections.Generic;

namespace ORM.Models;

public partial class Funcione
{
    public int Id { get; set; }

    public int PeliculaId { get; set; }

    public int SalaId { get; set; }

    public DateTime FechaHora { get; set; }

    public int? Duracion { get; set; }

    public virtual ICollection<Boleto> Boletos { get; set; } = new List<Boleto>();

    public virtual Pelicula Pelicula { get; set; } = null!;

    public virtual Sala Sala { get; set; } = null!;
}
