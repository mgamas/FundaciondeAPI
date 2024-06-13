using System;
using System.Collections.Generic;

namespace Models;

public partial class Programa
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<DetalleDonacion> DetalleDonacions { get; set; } = new List<DetalleDonacion>();
}
