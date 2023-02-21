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

        public virtual DbSet<Film> Films { get; set; }

        public virtual DbSet<Notation> Notations { get; set; }

        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

            => optionsBuilder.UseNpgsql("Server=localhost;port=5432;Database=FilmsDB; uid=postgres; password=postgres;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notation>(entity =>
            {
                entity.HasKey(e => new { e.FilmId, e.UtilisateurId }).HasName("pk_notation");

                entity.HasOne(d => d.FilmNote).WithMany(p => p.NotesFilm).HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_notesfilm_film");

                entity.HasOne(d => d.UtilisateurNotant).WithMany(p => p.NotesUtilisateur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_notesutilisateur_utilisateur");
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.HasKey(e => e.FilmId).HasName("pk_film2");
            });


            modelBuilder.Entity<Utilisateur>(entity =>
            {
               /* entity.Property(b => b.Pays).HasDefaultValue("France");

                entity.Property(b => b.DateCreation).HasDefaultValueSql("now()");*/

                entity.HasIndex(c => c.Mail).IsUnique();
            });


            /*modelBuilder.Entity<Film>(entity =>
             {
                 entity.HasKey(e => e.FilmId).HasName("pk_film");

                 entity.HasOne(d => d.NotesFilm).WithMany(p => p.Films)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("fk_film_categorie");
             });*/

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.HasKey(e => e.UtilisateurId).HasName("pk_utilisateur2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
