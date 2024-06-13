using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Models;

public partial class Pais
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
