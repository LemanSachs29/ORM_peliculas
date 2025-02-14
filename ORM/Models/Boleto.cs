using System;
using System.Collections.Generic;

namespace ORM.Models;

public partial class Boleto
{
    public int Id { get; set; }

    public int FuncionId { get; set; }

    public int? UsuarioId { get; set; }

    public string? Asiento { get; set; }

    public decimal Precio { get; set; }

    public DateTime? FechaCompra { get; set; }

    public virtual Funcione Funcion { get; set; } = null!;

    public virtual Usuario? Usuario { get; set; }
}
