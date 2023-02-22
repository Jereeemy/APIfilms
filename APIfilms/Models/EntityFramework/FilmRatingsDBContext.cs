using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;
using System;
using System.Collections.Generic;


namespace APIfilms.Models.EntityFramework
{
    public partial class FilmRatingsDBContext : DbContext
    {
       public FilmRatingsDBContext()
        {
        }

        public FilmRatingsDBContext(DbContextOptions<FilmRatingsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Notation> Notations { get; set; } = null!;
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; } = null!;
        public virtual DbSet<Film> Films { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;port=5432;Database=FilmsDB; uid=postgres;password=postgres;");
            }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notation>(entity =>
            {
                entity.HasKey(e => new { e.FilmId, e.UtilisateurId })
                    .HasName("pk_avis");

                entity.HasOne(d => d.FilmNote)
                    .WithMany(p => p.NotesFilm)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_avis_film");

                entity.HasOne(d => d.UtilisateurNotant)
                    .WithMany(p => p.NotesUtilisateur)
                    .HasForeignKey(d => d.UtilisateurId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_avis_utilisateur");

            });

            /* modelBuilder.Entity<Film>(entity =>
             {
                 entity.HasOne(d => d.CategorieNavigation)
                     .WithMany(p => p.Films)
                     .HasForeignKey(d => d.Categorie)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("fk_film_categorie");
             });*/
            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.Property(b => b.Pays).HasDefaultValue("France");

                entity.Property(b => b.DateCreation).HasDefaultValueSql("now()");

                entity.HasIndex(c => c.Mail).IsUnique();
            });
            modelBuilder.Entity<Notation>(entity =>
            {
                entity.HasCheckConstraint("CK_Notation_not_note", "not_note between 0 and 5");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
