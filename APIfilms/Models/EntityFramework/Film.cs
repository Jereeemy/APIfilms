using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIfilms.Models.EntityFramework
{

    //[PrimaryKey("NotesFilm")]
    [Table("T_E_FILM_FLM")]
    public partial class Film
    {
        private int flm_id;
        private string flm_titre;
        private string flm_resume;
        private DateTime flm_datesortie;
        private double flm_duree;
        private string flm_genre;

        [InverseProperty("FilmNote")]
        public virtual ICollection<Notation> NotesFilm { get; set; } = null!;

        [Key]
        [Column("flm_id")]

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

        
        [Column("flm_titre")]
        [StringLength(100)]
        [Required]
        public string Titre
        {
            get
            {
                return flm_titre;
            }

            set
            {
                flm_titre = value;
            }
        }

        
        [Column("flm_resume")]

        public string Resume
        {
            get
            {
                return flm_resume;
            }

            set
            {
                flm_resume = value;
            }
        }

        
        [Column("flm_datesortie", TypeName = "date")]
        
        public DateTime DateSortie
        {
            get
            {
                return flm_datesortie;
            }

            set
            {
                flm_datesortie = value;
            }
        }

       
        [Column("flm_duree", TypeName = "numeric(3,0)")]
        
        public double Duree
        {
            get
            {
                return flm_duree;
            }

            set
            {
                flm_duree = value;
            }
        }

        
        [Column("flm_genre")]
        [StringLength(30)]

        public string Genre
        {
            get
            {
                return flm_genre;
            }

            set
            {
                flm_genre = value;
            }
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
