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


        public virtual DbSet<Anime> Animes { get; set; }
        public virtual DbSet<Historial> Historial { get; set; }
        public virtual DbSet<Temporada> Temporadas { get; set; }

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


            modelBuilder.Entity<Anime>(entity =>
            {
                // entity.HasKey(e => e.AnimeId);

                // entity.ToTable("Animes");

                // entity.Property(e => e.AnimeId).HasColumnName("id_anime");

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

                entity.Property(e => e.IdHistorial).HasColumnName("id_historial");

                entity.Property(e => e.FechaFin).HasColumnType("datetime");


                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.VistoEn).HasMaxLength(50).IsUnicode(false);

                entity.HasOne(d => d.Anime)
                    .WithMany(p => p.Historials)
                    .HasForeignKey(d => d.AnimeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Historial_Animes");


                entity.HasOne(d => d.Temporada)
                .WithMany(p => p.Historials)
                .HasForeignKey(d => d.TemporadaId)
                .HasConstraintName("FK_Historial_Temporadas");

            });

            modelBuilder.Entity<Temporada>(entity =>
            {



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
