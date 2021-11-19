using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AppAnimes.Models
{
    public partial class AppAnimesDBContext : DbContext
    {
        public AppAnimesDBContext()
        {
        }

        public AppAnimesDBContext(DbContextOptions<AppAnimesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anime> Animes { get; set; }
        public virtual DbSet<Historial> Historial { get; set; }
        public virtual DbSet<Temporada> Temporadas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=AppAnimesDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Anime>(entity =>
            {
                entity.Property(e => e.Genero)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NombreIngles)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Historial>(entity =>
            {
                entity.HasKey(e => e.IdHistorial);

                entity.ToTable("Historial");

                entity.HasIndex(e => e.AnimeId, "IX_Historial_AnimeId");

                entity.HasIndex(e => e.TemporadaId, "IX_Historial_TemporadaId");

                entity.Property(e => e.IdHistorial).HasColumnName("id_historial");

                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.VistoEn)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Anime)
                    .WithMany(p => p.Historials)
                    .HasForeignKey(d => d.AnimeId)
                    .HasConstraintName("FK_Historial_Animes");
            });

            modelBuilder.Entity<Temporada>(entity =>
            {
                entity.HasIndex(e => e.AnimeId, "IX_Temporadas_AnimeId");

                entity.Property(e => e.Estado)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreTemporada)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TemporadaEstreno)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.HasOne(d => d.Anime)
                    .WithMany(p => p.Temporadas)
                    .HasForeignKey(d => d.AnimeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Temporadas_Animes");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
