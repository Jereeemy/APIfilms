using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIfilms.Models.EntityFramework
{
    //[PrimaryKey("FilmNote,UtilisateurNotant")]
    
    [Table("t_j_notation_not")]
    public partial class Notation
    {
        private int utl_id;
        private int? flm_id;
        private int? not_note;


        [ForeignKey("FilmId")]
        [InverseProperty("NotesFilm")]
        public virtual Film FilmNote { get; set; } = null!;

        [ForeignKey("UtilisateurId")]
        [InverseProperty("NotesUtilisateur")]
        public virtual Utilisateur UtilisateurNotant { get; set; } = null!;


        [Key]
        [Column("utl_id")]
        [ForeignKey("Utilisateur")]
        public int UtilisateurId
        {
            get
            {
                return utl_id;
            }

            set
            {
                utl_id = value;
            }
        }

        [Key]
        [Column("flm_id")]
        [ForeignKey("Film")]

        public int? FilmId
        {
            get
            {
                return flm_id;
            }

            set
            {
                flm_id = value;
            }
        }

            
        [Column("not_note")]
        /*[Range(0,5)]*/
        [Required]

        public int? Note
        {
            get
            {
                return not_note;
            }

            set
            {
                not_note = value;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Notation notation &&
                   EqualityComparer<Film>.Default.Equals(this.FilmNote, notation.FilmNote) &&
                   EqualityComparer<Utilisateur>.Default.Equals(this.UtilisateurNotant, notation.UtilisateurNotant) &&
                   this.UtilisateurId == notation.UtilisateurId &&
                   this.FilmId == notation.FilmId &&
                   this.Note == notation.Note;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.FilmNote, this.UtilisateurNotant, this.UtilisateurId, this.FilmId, this.Note);
        }
        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
