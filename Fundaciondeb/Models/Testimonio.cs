using System;
using System.Collections.Generic;

namespace Models;

public partial class Testimonio
{
    public int Id { get; set; }

    public int? UsuarioId { get; set; }

    public string NombreAutor { get; set; } = null!;

    public string Contenido { get; set; } = null!;

    public DateTime? FechaEnvio { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
