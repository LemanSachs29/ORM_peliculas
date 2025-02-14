using System;
using System.Collections.Generic;

namespace ORM.Models;

public partial class Critico
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Apellido { get; set; }

    public string? Afiliacion { get; set; }

    public virtual ICollection<ResenasCritico> ResenasCriticos { get; set; } = new List<ResenasCritico>();
}
