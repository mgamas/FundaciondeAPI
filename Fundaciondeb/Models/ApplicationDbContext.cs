using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contacto> Contactos { get; set; }

    public virtual DbSet<DetalleDonacion> DetalleDonacions { get; set; }

    public virtual DbSet<Direccion> Direccions { get; set; }

    public virtual DbSet<Donacion> Donacions { get; set; }

    public virtual DbSet<Pais> Pais { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Profesion> Profesions { get; set; }

    public virtual DbSet<Programa> Programas { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<RolPermiso> RolPermisos { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<Sexo> Sexos { get; set; }

    public virtual DbSet<TelefonoTipo> TelefonoTipos { get; set; }

    public virtual DbSet<Testimonio> Testimonios { get; set; }

    public virtual DbSet<TokenAcceso> TokenAccesos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__contacto__3213E83FBF8BB290");

            entity.ToTable("contacto");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Asunto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("asunto");
            entity.Property(e => e.EmailCliente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email_cliente");
            entity.Property(e => e.FechaEnvio)
                .HasColumnType("datetime")
                .HasColumnName("fecha_envio");
            entity.Property(e => e.Mensaje)
                .HasColumnType("text")
                .HasColumnName("mensaje");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_cliente");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Contactos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__contacto__usuari__7E37BEF6");
        });

        modelBuilder.Entity<DetalleDonacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__detalle___3213E83FE9EDB378");

            entity.ToTable("detalle_donacion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Comentario)
                .HasColumnType("text")
                .HasColumnName("comentario");
            entity.Property(e => e.DonacionId).HasColumnName("donacion_id");
            entity.Property(e => e.FechaDetalle)
                .HasColumnType("datetime")
                .HasColumnName("fecha_detalle");
            entity.Property(e => e.IdPrograma).HasColumnName("id_programa");
            entity.Property(e => e.TipoServicio).HasColumnName("tipo_servicio");

            entity.HasOne(d => d.Donacion).WithMany(p => p.DetalleDonacions)
                .HasForeignKey(d => d.DonacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__detalle_d__donac__7A672E12");

            entity.HasOne(d => d.IdProgramaNavigation).WithMany(p => p.DetalleDonacions)
                .HasForeignKey(d => d.IdPrograma)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__detalle_d__id_pr__00200768");

            entity.HasOne(d => d.TipoServicioNavigation).WithMany(p => p.DetalleDonacions)
                .HasForeignKey(d => d.TipoServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__detalle_d__tipo___01142BA1");
        });

        modelBuilder.Entity<Direccion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__direccio__3213E83F515C69EA");

            entity.ToTable("direccion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Donacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__donacion__3213E83F27149028");

            entity.ToTable("donacion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaDonacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_donacion");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("monto");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
            entity.Property(e => e.Voucher)
                .HasMaxLength(2048)
                .HasColumnName("voucher");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Donacions)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__donacion__usuari__797309D9");
        });

        modelBuilder.Entity<Pais>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__pais__3213E83F797CFD0B");

            entity.ToTable("pais");

            entity.HasIndex(e => e.Nombre, "UQ__pais__72AFBCC6FC277DFE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__permiso__3213E83FAA944A65");

            entity.ToTable("permiso");

            entity.HasIndex(e => e.Nombre, "UQ__permiso__72AFBCC6D4ADC67D").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Profesion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__profesio__3213E83F198ACA3F");

            entity.ToTable("profesion");

            entity.HasIndex(e => e.Nombre, "UQ__profesio__72AFBCC653C0D220").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Programa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__programa__3213E83FCC9FECC7");

            entity.ToTable("programa");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rol__3213E83FE0BBA6C3");

            entity.ToTable("rol");

            entity.HasIndex(e => e.Rol1, "UQ__rol__C2B79D26D0A37D96").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Rol1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("rol");
        });

        modelBuilder.Entity<RolPermiso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rol_perm__3213E83F9ED307C4");

            entity.ToTable("rol_permiso");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PermisoId).HasColumnName("permiso_id");
            entity.Property(e => e.RolId).HasColumnName("rol_id");

            entity.HasOne(d => d.Permiso).WithMany(p => p.RolPermisos)
                .HasForeignKey(d => d.PermisoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rol_permi__permi__7D439ABD");

            entity.HasOne(d => d.Rol).WithMany(p => p.RolPermisos)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rol_permi__rol_i__7C4F7684");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__servicio__3213E83F1EEB160A");

            entity.ToTable("servicio");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Sexo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sexo__3213E83F456095C0");

            entity.ToTable("sexo");

            entity.HasIndex(e => e.Sexo1, "UQ__sexo__2C8B08FE053DE834").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Sexo1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("sexo");
        });

        modelBuilder.Entity<TelefonoTipo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__telefono__3213E83F70B991B5");

            entity.ToTable("telefonoTipo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Tipo)
                .HasMaxLength(25)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Testimonio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__testimon__3213E83F3AFD51CB");

            entity.ToTable("testimonio");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contenido)
                .HasColumnType("text")
                .HasColumnName("contenido");
            entity.Property(e => e.FechaEnvio)
                .HasColumnType("datetime")
                .HasColumnName("fecha_envio");
            entity.Property(e => e.NombreAutor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_autor");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Testimonios)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__testimoni__usuar__7F2BE32F");
        });

        modelBuilder.Entity<TokenAcceso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__token_ac__3213E83FB96521BF");

            entity.ToTable("token_acceso");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaEmision)
                .HasColumnType("datetime")
                .HasColumnName("fecha_emision");
            entity.Property(e => e.FechaExpiracion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_expiracion");
            entity.Property(e => e.Token)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("token");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.TokenAccesos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__token_acc__usuar__7B5B524B");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usuario__3213E83F9FABFD2B");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.Email, "UQ__usuario__AB6E61648ABE3B81").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.DireccionId).HasColumnName("direccion_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Nit).HasColumnName("NIT");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.PaisId).HasColumnName("pais_id");
            entity.Property(e => e.ProfesionId).HasColumnName("profesion_id");
            entity.Property(e => e.RolId).HasColumnName("rol_id");
            entity.Property(e => e.SexoId).HasColumnName("sexo_id");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
            entity.Property(e => e.TelefonoTipoId).HasColumnName("telefonoTipo_id");

            entity.HasOne(d => d.Direccion).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.DireccionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuario__direcci__76969D2E");

            entity.HasOne(d => d.Pais).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.PaisId).OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuario__pais_id__75A278F5");

            entity.HasOne(d => d.Profesion).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.ProfesionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuario__profesi__74AE54BC");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuario__rol_id__787EE5A0");

            entity.HasOne(d => d.Sexo).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.SexoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuario__sexo_id__778AC167");

            entity.HasOne(d => d.TelefonoTipo).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.TelefonoTipoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuario__telefon__73BA3083");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
