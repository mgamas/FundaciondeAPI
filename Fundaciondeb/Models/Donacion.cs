using System;
using System.Collections.Generic;

namespace Models;

public partial class Donacion
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public decimal Monto { get; set; }

    public DateTime? FechaDonacion { get; set; }

    public byte[] Voucher { get; set; } = null!;

    public virtual ICollection<DetalleDonacion> DetalleDonacions { get; set; } = new List<DetalleDonacion>();

    public virtual Usuario Usuario { get; set; } = null!;
}
