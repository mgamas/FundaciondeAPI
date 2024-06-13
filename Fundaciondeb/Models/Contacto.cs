using System;
using System.Collections.Generic;

namespace Models;

public partial class Contacto
{
    public int Id { get; set; }

    public int? UsuarioId { get; set; }

    public string NombreCliente { get; set; } = null!;

    public string EmailCliente { get; set; } = null!;

    public string Asunto { get; set; } = null!;

    public string Mensaje { get; set; } = null!;

    public DateTime? FechaEnvio { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
