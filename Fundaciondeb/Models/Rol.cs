using System;
using System.Collections.Generic;

namespace Models;

public partial class Rol
{
    public int Id { get; set; }

    public string Rol1 { get; set; } = null!;

    public virtual ICollection<RolPermiso> RolPermisos { get; set; } = new List<RolPermiso>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
