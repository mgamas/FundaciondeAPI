using System;
using System.Collections.Generic;

namespace Models;

public partial class Direccion
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
