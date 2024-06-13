using System;
using System.Collections.Generic;

namespace Models;

public partial class Sexo
{
    public int Id { get; set; }

    public string Sexo1 { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
