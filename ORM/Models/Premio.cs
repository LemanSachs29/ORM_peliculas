using System;
using System.Collections.Generic;

namespace ORM.Models;

public partial class Premio
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? Anio { get; set; }

    public virtual ICollection<PeliculaPremio> PeliculaPremios { get; set; } = new List<PeliculaPremio>();
}
