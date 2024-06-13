using System;
using System.Collections.Generic;

namespace Models;

public partial class TokenAcceso
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public string Token { get; set; } = null!;

    public DateTime? FechaEmision { get; set; }

    public DateTime FechaExpiracion { get; set; }

    public int Estado { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
