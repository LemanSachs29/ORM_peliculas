using System;
using System.Collections.Generic;

namespace ORM.Models;

public partial class Sala
{
    public int Id { get; set; }

    public int CineId { get; set; }

    public string Nombre { get; set; } = null!;

    public int Capacidad { get; set; }

    public virtual Cine Cine { get; set; } = null!;

    public virtual ICollection<Funcione> Funciones { get; set; } = new List<Funcione>();
}
