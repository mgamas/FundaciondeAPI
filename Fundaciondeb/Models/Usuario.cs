using System;
using System.Collections.Generic;

namespace Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int TelefonoTipoId { get; set; }

    public int? Telefono { get; set; }

    public int ProfesionId { get; set; }

    public int PaisId { get; set; }

    public int DireccionId { get; set; }

    public string Email { get; set; } = null!;

    public int Nit { get; set; }

    public string Contraseña { get; set; } = null!;

    public int SexoId { get; set; }

    public int RolId { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Contacto> Contactos { get; set; } = new List<Contacto>();

    public virtual Direccion Direccion { get; set; } = null!;

    public virtual ICollection<Donacion> Donacions { get; set; } = new List<Donacion>();

    public virtual Pais Pais { get; set; } = null!;

    public virtual Profesion Profesion { get; set; } = null!;

    public virtual Rol Rol { get; set; } = null!;

    public virtual Sexo Sexo { get; set; } = null!;

    public virtual TelefonoTipo TelefonoTipo { get; set; } = null!;

    public virtual ICollection<Testimonio> Testimonios { get; set; } = new List<Testimonio>();

    public virtual ICollection<TokenAcceso> TokenAccesos { get; set; } = new List<TokenAcceso>();
}
