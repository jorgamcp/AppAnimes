using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AppAnimes.Models
{
    public partial class AppAnimesDBContext : DbContext
    {
        /*
            Representa una conexion a SQL Server
        */

        public AppAnimesDBContext()
        {
        }

        public AppAnimesDBContext(DbContextOptions<AppAnimesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnimesHistoricoVistaAppAnimesDB> AnimesHistoricoVistaTriggerDbtests { get; set; }
        public virtual DbSet<Animes> Animes { get; set; }
        public virtual DbSet<Historial> Historial { get; set; }
        public virtual DbSet<Temporadas> Temporadas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=AppAnimesDB;Integrated Security=True");
            }
            //optionsBuilder.LogTo(Console.WriteLine); Muestra el SQL Generado
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<AnimesHistoricoVistaAppAnimesDB>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("AnimesHistoricoVista");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_fin");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_inicio");

                entity.Property(e => e.FechaPausa)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_pausa");

                entity.Property(e => e.IdHistorial).HasColumnName("id_historial");

                entity.Property(e => e.IdTemp).HasColumnName("id_temp");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(756)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Animes>(entity =>
            {
                entity.HasKey(e => e.IdAnime);

                entity.ToTable("Animes");

                entity.Property(e => e.IdAnime).HasColumnName("id_anime");

                entity.Property(e => e.Genero)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("genero");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.NombreEnIngles)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre_en_ingles");
            });

            modelBuilder.Entity<Historial>(entity =>
            {
                entity.HasKey(e => e.IdHistorial);

                entity.ToTable("Historial");

                entity.Property(e => e.IdHistorial).HasColumnName("id_historial");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_fin");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_inicio");

                entity.Property(e => e.FechaPausa)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_pausa");

                entity.Property(e => e.IdAnime).HasColumnName("id_anime");

                entity.Property(e => e.IdTemp).HasColumnName("id_temp");

                entity.Property(e => e.VistoEn)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("visto_en");

                entity.HasOne(d => d.IdAnimeNavigation)
                    .WithMany(p => p.Historial)
                    .HasForeignKey(d => d.IdAnime)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_historial_animes");
            });

            modelBuilder.Entity<Temporadas>(entity =>
            {
                entity.HasKey(e => new { e.IdAnime, e.IdTemporada });

                entity.ToTable("Temporadas");

                entity.Property(e => e.IdAnime).HasColumnName("id_anime");

                entity.Property(e => e.IdTemporada).HasColumnName("id_temporada");

                entity.Property(e => e.Estado)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.NombreTemporada)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("nombre_temporada");

                entity.Property(e => e.TemporadaEstreno)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("temporada_estreno");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.HasOne(d => d.IdAnimeNavigation)
                    .WithMany(p => p.Temporadas)
                    .HasForeignKey(d => d.IdAnime)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_temporadas_animes");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
