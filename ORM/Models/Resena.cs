using System;
using System.Collections.Generic;

namespace ORM.Models;

public partial class Resena
{
    public int Id { get; set; }

    public int PeliculaId { get; set; }

    public int UsuarioId { get; set; }

    public sbyte? Rating { get; set; }

    public string? Comentario { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Pelicula Pelicula { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
