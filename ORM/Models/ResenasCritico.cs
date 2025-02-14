using System;
using System.Collections.Generic;

namespace ORM.Models;

public partial class ResenasCritico
{
    public int Id { get; set; }

    public int PeliculaId { get; set; }

    public int CriticoId { get; set; }

    public sbyte? Rating { get; set; }

    public string? Comentario { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Critico Critico { get; set; } = null!;

    public virtual Pelicula Pelicula { get; set; } = null!;
}
