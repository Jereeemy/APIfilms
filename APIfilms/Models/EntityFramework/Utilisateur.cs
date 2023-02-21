using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Intrinsics.X86;

namespace APIfilms.Models.EntityFramework
{
    //[PrimaryKey("NotesFilm")]
    [Table("T_E_UTILISATEUR_UTL")]
    public partial class Utilisateur
    {
        private int utl_id;
        private string? utl_nom;
        private string? utl_prenom;
        private string? utl_mobile;
        private string? utl_mail;
        private string? utl_pwd;
        private string? utl_rue;
        private string? utl_cp;
        private string? utl_ville;
        private string? utl_pays;
        private float? utl_latitude;
        private float? utl_longitude;
        private DateTime utl_datecreation;

        [InverseProperty("UtilisateurNotant")]
        public virtual ICollection<Notation> NotesUtilisateur { get; set; } = null!;

        [Key]
        [Column("utl_id")]

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

        
        [Column("utl_nom")]
        [StringLength(50)]

        public string? Nom
        {
            get
            {
                return utl_nom;
            }

            set
            {
                utl_nom = value;
            }
        }

        
        [Column("utl_prenom")]
        [StringLength(50)]

        public string? Prenom
        {
            get
            {
                return utl_prenom;
            }

            set
            {
                utl_prenom = value;
            }
        }

        
        [Column("utl_mobile", TypeName = "char(10)")]

        public string? Mobile
        {
            get
            {
                return utl_mobile;
            }

            set
            {
                utl_mobile = value;
            }
        }

        
        [Column("utl_mail")]
        [StringLength(100)]
        [Required]
        
        public string? Mail
        {
            get
            {
                return utl_mail;
            }

            set
            {
                utl_mail = value;
            }
        }

        
        [Column("utl_pwd")]
        [StringLength(64)]
        [Required]

        public string? Pwd
        {
            get
            {
                return utl_pwd;
            }

            set
            {
                utl_pwd = value;
            }
        }

        
        [Column("utl_rue")]
        [StringLength(200)]
        

        public string? Rue
        {
            get
            {
                return utl_rue;
            }

            set
            {
                utl_rue = value;
            }
        }

        
        [Column("utl_cp",TypeName = "char(5)")]

        public string? CodePostal
        {
            get
            {
                return utl_cp;
            }

            set
            {
                utl_cp = value;
            }
        }

        
        [Column("utl_ville")]
        [StringLength(50)]

        public string? Ville
        {
            get
            {
                return utl_ville;
            }

            set
            {
                utl_ville = value;
            }
        }

        
        [Column("utl_pays")]
        [StringLength(50)]
        [DefaultValue("France")]

        public string? Pays
        {
            get
            {
                return utl_pays;
            }

            set
            {
                utl_pays = value;
            }
        }

       
        [Column("utl_latitude")]
        public float? Latitude
        {
            get
            {
                return utl_latitude;
            }

            set
            {
                utl_latitude = value;
            }
        }

        
        [Column("utl_longitude")]
        public float? Longitude
        {
            get
            {
                return utl_longitude;
            }

            set
            {
                utl_longitude = value;
            }
        }

        
        [Column("utl_datecreation", TypeName ="date")]
        [DefaultValue("now()")]
        [Required]
        public DateTime DateCreation
        {
            get
            {
                return utl_datecreation;
            }

            set
            {
                utl_datecreation = value;
            }
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
