using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Salary.Models
{
    public partial class SalaryDiagContext : DbContext
    {
        public SalaryDiagContext()
        {
        }

        public SalaryDiagContext(DbContextOptions<SalaryDiagContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ciudad> Ciudads { get; set; }
        public virtual DbSet<DetalleUsuario> DetalleUsuarios { get; set; }
        public virtual DbSet<Empleo> Empleos { get; set; }
        public virtual DbSet<Experiencium> Experiencia { get; set; }
        public virtual DbSet<Provincium> Provincia { get; set; }
        public virtual DbSet<PuestoLaboral> PuestoLaborals { get; set; }
        public virtual DbSet<TipoContrato> TipoContratos { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-9Q224AK;Database=SalaryDiag;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.HasKey(e => e.IdCiudad);

                entity.ToTable("Ciudad");

                entity.Property(e => e.IdCiudad).ValueGeneratedNever();

                entity.Property(e => e.Ciudad1)
                    .HasMaxLength(250)
                    .HasColumnName("Ciudad");

                entity.Property(e => e.Latitud).HasMaxLength(150);

                entity.Property(e => e.Longitud).HasMaxLength(150);
            });

            modelBuilder.Entity<DetalleUsuario>(entity =>
            {
                entity.HasKey(e => e.IdDetalle);

                entity.ToTable("DetalleUsuario");

                entity.Property(e => e.IdDetalle).ValueGeneratedNever();

                entity.Property(e => e.EstadoCivil).HasMaxLength(150);

                entity.Property(e => e.FechaNacimiento).HasMaxLength(50);

                entity.Property(e => e.Genero).HasMaxLength(50);
            });

            modelBuilder.Entity<Empleo>(entity =>
            {
                entity.HasKey(e => e.IdEmpleo);

                entity.ToTable("Empleo");

                entity.Property(e => e.IdEmpleo).ValueGeneratedNever();

                entity.Property(e => e.Empresa).HasMaxLength(50);
            });

            modelBuilder.Entity<Experiencium>(entity =>
            {
                entity.HasKey(e => e.IdExperiencia);

                entity.Property(e => e.IdExperiencia).ValueGeneratedNever();

                entity.Property(e => e.Experiencia).HasMaxLength(50);
            });

            modelBuilder.Entity<Provincium>(entity =>
            {
                entity.HasKey(e => e.Idprovincia)
                    .HasName("PK_Provincia_1");

                entity.Property(e => e.Idprovincia).ValueGeneratedNever();

                entity.Property(e => e.Provincia)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PuestoLaboral>(entity =>
            {
                entity.HasKey(e => e.IdPuesto)
                    .HasName("PK_Puesto Laboral");

                entity.ToTable("PuestoLaboral");

                entity.Property(e => e.IdPuesto).ValueGeneratedNever();

                entity.Property(e => e.Puesto).HasMaxLength(50);
            });

            modelBuilder.Entity<TipoContrato>(entity =>
            {
                entity.HasKey(e => e.IdContrato);

                entity.ToTable("TipoContrato");

                entity.Property(e => e.IdContrato).ValueGeneratedNever();

                entity.Property(e => e.Contrato).HasMaxLength(50);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK_Tipo Usuario");

                entity.ToTable("TipoUsuario");

                entity.Property(e => e.IdTipoUsuario).ValueGeneratedNever();

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).ValueGeneratedNever();

                entity.Property(e => e.Apellido).HasMaxLength(150);

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.Nombre).HasMaxLength(150);

                entity.Property(e => e.Pass).HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
