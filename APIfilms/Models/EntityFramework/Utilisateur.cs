using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Intrinsics.X86;

namespace APIfilms.Models.EntityFramework
{
    //[PrimaryKey("NotesFilm")]

    [Table("t_e_utilisateur_utl")]
    public class Utilisateur
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

        // avec tout
        public Utilisateur(ICollection<Notation> notesUtilisateur, int utilisateurId, string? nom, string? prenom, string? mobile, string mail, string? pwd, string? rue, string? codePostal, string? ville, string? pays, float? latitude, float? longitude, DateTime dateCreation)
        {
            this.NotesUtilisateur = notesUtilisateur;
            this.UtilisateurId = utilisateurId;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Mobile = mobile;
            this.Mail = mail;
            this.Pwd = pwd;
            this.Rue = rue;
            this.CodePostal = codePostal;
            this.Ville = ville;
            this.Pays = pays;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.DateCreation = dateCreation;
        }

        // sans l'id
        public Utilisateur(ICollection<Notation> notesUtilisateur, string? nom, string? prenom, string? mobile, string mail, string? pwd, string? rue, string? codePostal, string? ville, string? pays, float? latitude, float? longitude, DateTime dateCreation)
        {
            this.NotesUtilisateur = notesUtilisateur;
            //this.UtilisateurId = utilisateurId;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Mobile = mobile;
            this.Mail = mail;
            this.Pwd = pwd;
            this.Rue = rue;
            this.CodePostal = codePostal;
            this.Ville = ville;
            this.Pays = pays;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.DateCreation = dateCreation;
        }
        public Utilisateur() { }
        // sans la note
        public Utilisateur(int utilisateurId, string? nom, string? prenom, string? mobile, string mail, string? pwd, string? rue, string? codePostal, string? ville, string? pays, float? latitude, float? longitude, DateTime dateCreation)
        {
            //this.NotesUtilisateur = notesUtilisateur;
            this.UtilisateurId = utilisateurId;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Mobile = mobile;
            this.Mail = mail;
            this.Pwd = pwd;
            this.Rue = rue;
            this.CodePostal = codePostal;
            this.Ville = ville;
            this.Pays = pays;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.DateCreation = dateCreation;
        }

        [InverseProperty(nameof(Notation.UtilisateurNotant))]
        public virtual ICollection<Notation> NotesUtilisateur { get; set; } = new List<Notation>();

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
        [RegularExpression(@"^0[0-9]{9}$", ErrorMessage = "Numéro e téléphone non valide")]
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
        [Required]
        [EmailAddress]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La longueur d’un email doit être comprise entre 6 et 100 caractères.")]
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
        //[RegularExpression(@" ^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Mot de passe non valide")]
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

        [Column("utl_cp", TypeName = "char(5)")]
        [MinLength(5)]
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

        [Column("utl_datecreation", TypeName = "date")]
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

        public override bool Equals(object? obj)
        {
            return obj is Utilisateur utilisateur &&
                   this.UtilisateurId == utilisateur.UtilisateurId &&
                   this.Nom == utilisateur.Nom &&
                   this.Prenom == utilisateur.Prenom &&
                   this.Mobile == utilisateur.Mobile &&
                   this.Mail == utilisateur.Mail &&
                   this.Pwd == utilisateur.Pwd &&
                   this.Rue == utilisateur.Rue &&
                   this.CodePostal == utilisateur.CodePostal &&
                   this.Ville == utilisateur.Ville &&
                   this.Pays == utilisateur.Pays &&
                   this.Latitude == utilisateur.Latitude &&
                   this.Longitude == utilisateur.Longitude &&
                   this.DateCreation == utilisateur.DateCreation;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(this.NotesUtilisateur);
            hash.Add(this.UtilisateurId);
            hash.Add(this.Nom);
            hash.Add(this.Prenom);
            hash.Add(this.Mobile);
            hash.Add(this.Mail);
            hash.Add(this.Pwd);
            hash.Add(this.Rue);
            hash.Add(this.CodePostal);
            hash.Add(this.Ville);
            hash.Add(this.Pays);
            hash.Add(this.Latitude);
            hash.Add(this.Longitude);
            hash.Add(this.DateCreation);
            return hash.ToHashCode();
        }
    }
}
