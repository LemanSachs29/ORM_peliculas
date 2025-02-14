using System;
using System.Collections.Generic;

namespace ORM.Models;

public partial class Cine
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Ciudad { get; set; }

    public string? Pais { get; set; }

    public virtual ICollection<Sala> Salas { get; set; } = new List<Sala>();
}
