using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIfilms.Models.EntityFramework
{
    //[PrimaryKey("FilmNote,UtilisateurNotant")]
    [Table("T_J_NOTATION_NOT")]
    public partial class Notation
    {
        private int utl_id;
        private int flm_id;
        private int not_note;


        [ForeignKey(nameof(Film))]
        [InverseProperty("NotesFilm")]
        public virtual Film FilmNote { get; set; } = null!;

        [ForeignKey(nameof(Film))]
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

        public int FilmId
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

        public int Note
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
        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
