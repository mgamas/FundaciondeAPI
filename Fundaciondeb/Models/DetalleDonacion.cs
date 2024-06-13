using System;
using System.Collections.Generic;

namespace Models;

public partial class DetalleDonacion
{
    public int Id { get; set; }

    public int DonacionId { get; set; }

    public int IdPrograma { get; set; }

    public int TipoServicio { get; set; }

    public string? Comentario { get; set; }

    public int? Cantidad { get; set; }

    public DateTime? FechaDetalle { get; set; }

    public virtual Donacion Donacion { get; set; } = null!;

    public virtual Programa IdProgramaNavigation { get; set; } = null!;

    public virtual Servicio TipoServicioNavigation { get; set; } = null!;
}
