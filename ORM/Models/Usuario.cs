using System;
using System.Collections.Generic;

namespace ORM.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Boleto> Boletos { get; set; } = new List<Boleto>();

    public virtual ICollection<Resena> Resenas { get; set; } = new List<Resena>();
}
