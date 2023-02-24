using Microsoft.VisualStudio.TestTools.UnitTesting;
using APIfilms.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIfilms.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using System.Text.RegularExpressions;

namespace APIfilms.Controllers.Tests
{
    [TestClass()]
    public class UtilisateursControllerTests
    {

        UtilisateursController utilisateurController;
        [TestMethod()]
        public void UtilisateursControllerTest()
        {

        }

        [TestMethod()]
        public void GetUtilisateursTest()
        {
            var builder = new DbContextOptionsBuilder<FilmRatingsDBContext>().UseNpgsql("Server=localhost;port=5432;Database=FilmRatingDB; uid=postgres;password=postgres;");
            FilmRatingsDBContext _context = new FilmRatingsDBContext(builder.Options);
            UtilisateursController controller = new UtilisateursController(_context);

            var result = controller.GetUtilisateurs().Result.Value;

            Utilisateur u1 = new Utilisateur(new List<Notation>(), 1, "Calida", "Lilley", "0653930778", "clilleymd@last.fm", "Toto12345678!", "Impasse des bergeronnettes", "74200", "Allinges", "France", (float)46.344795, (float)6.4885845, new DateTime(2023, 02, 24));
            Utilisateur u2 = new Utilisateur(new List<Notation>(), 2, "Gwendolin", "Dominguez", "0724970555", "gdominguez0@washingtonpost.com", "Toto12345678!", "Chemin de gom", "73420", "Voglans", "France", (float)45.622154, (float)5.8853216, new DateTime(2023, 02, 24));
            Utilisateur u3 = new Utilisateur(new List<Notation>(), 3, "Randolph", "Richings", "0630271158", "rrichings1@naver.com", "Toto12345678!", "Route des charmottes d'en bas", "74890", "Bons-en-Chablais", "France", (float)46.25732, (float)6.367676, new DateTime(2023, 02, 24));


            List<Utilisateur> listeUtilisateurRecuperees = new List<Utilisateur> { u1, u2, u3 };

            CollectionAssert.AreEqual(result.Where(s => s.UtilisateurId <= 3).ToList(), listeUtilisateurRecuperees);
        }

        [TestMethod()]
        public void GetUtilisateurByIdTest()
        {
            var builder = new DbContextOptionsBuilder<FilmRatingsDBContext>().UseNpgsql("Server=localhost;port=5432;Database=FilmRatingDB; uid=postgres;password=postgres;");
            FilmRatingsDBContext _context = new FilmRatingsDBContext(builder.Options);
            UtilisateursController controller = new UtilisateursController(_context);

            //Act
            var result1 = controller.GetUtilisateurById(2);


            Utilisateur u2 = new Utilisateur(new List<Notation>(), 2, "Gwendolin", "Dominguez", "0724970555", "gdominguez0@washingtonpost.com", "Toto12345678!", "Chemin de gom", "73420", "Voglans", "France", (float)45.622154, (float)5.8853216, new DateTime(2023, 02, 24));

            //Assert

            Assert.AreEqual(result1.Result.Value, u2);
            Assert.IsNull(result1.Result.Result, "Erreur est pas null"); //Test de l'erreur
            Assert.IsInstanceOfType(result1.Result, typeof(ActionResult<Utilisateur>), "Pas un ActionResult"); // Test du type de retour
            Assert.IsInstanceOfType(result1.Result.Value, typeof(Utilisateur), "Pas un utilisateur"); // Test du type du contenu (valeur) du retour


        }




        [TestMethod()]
        public void GetUtilisateurByIdTest_NotFound()
        {
            var builder = new DbContextOptionsBuilder<FilmRatingsDBContext>().UseNpgsql("Server=localhost;port=5432;Database=FilmRatingDB; uid=postgres;password=postgres;");
            FilmRatingsDBContext _context = new FilmRatingsDBContext(builder.Options);
            UtilisateursController controller = new UtilisateursController(_context);

            Utilisateur u1 = new Utilisateur(new List<Notation>(), 1, "Calida", "Lilley", "0653930778", "clilleymd@last.fm", "Toto12345678!", "Impasse des bergeronnettes", "74200", "Allinges", "France", (float)46.344795, (float)6.4885845, new DateTime(2023, 02, 24));
            var result1 = controller.GetUtilisateurById(100);



            Assert.AreEqual(result1.Result.Value, null);
            //Assert.IsNull(result1.Result.Result, "Erreur est pas null"); //Test de l'erreur
            Assert.IsInstanceOfType(result1.Result, typeof(ActionResult<Utilisateur>), "Pas un ActionResult"); // Test du type de retour
                                                                                                               //Assert.IsInstanceOfType(result1.Result.Value, typeof(Utilisateur), "Pas un utilisateur"); // Test du type du contenu (valeur) du retour
        }


        [TestMethod()]
        public void GetUtilisateurByEmailTest()
        {
            var builder = new DbContextOptionsBuilder<FilmRatingsDBContext>().UseNpgsql("Server=localhost;port=5432;Database=FilmRatingDB; uid=postgres;password=postgres;");
            FilmRatingsDBContext _context = new FilmRatingsDBContext(builder.Options);
            UtilisateursController controller = new UtilisateursController(_context);

            //Act
            var result1 = controller.GetUtilisateurByEmail("gdominguez0@washingtonpost.com");


            Utilisateur u2 = new Utilisateur(new List<Notation>(), 2, "Gwendolin", "Dominguez", "0724970555", "gdominguez0@washingtonpost.com", "Toto12345678!", "Chemin de gom", "73420", "Voglans", "France", (float)45.622154, (float)5.8853216, new DateTime(2023, 02, 24));

            //Assert

            Assert.AreEqual(result1.Result.Value, u2);
            Assert.IsNull(result1.Result.Result, "Erreur est pas null"); //Test de l'erreur
            Assert.IsInstanceOfType(result1.Result, typeof(ActionResult<Utilisateur>), "Pas un ActionResult"); // Test du type de retour
            Assert.IsInstanceOfType(result1.Result.Value, typeof(Utilisateur), "Pas un utilisateur"); // Test du type du contenu (valeur) du retour
        }
        [TestMethod()]
        public void GetUtilisateurByEmail_NotFound()
        {
            var builder = new DbContextOptionsBuilder<FilmRatingsDBContext>().UseNpgsql("Server=localhost;port=5432;Database=FilmRatingDB; uid=postgres;password=postgres;");
            FilmRatingsDBContext _context = new FilmRatingsDBContext(builder.Options);
            UtilisateursController controller = new UtilisateursController(_context);

            //Act
            var result1 = controller.GetUtilisateurByEmail("aaaa");


            Utilisateur u2 = new Utilisateur(new List<Notation>(), 2, "Gwendolin", "Dominguez", "0724970555", "gdominguez0@washingtonpost.com", "Toto12345678!", "Chemin de gom", "73420", "Voglans", "France", (float)45.622154, (float)5.8853216, new DateTime(2023, 02, 24));

            //Assert

            Assert.AreEqual(result1.Result.Value, null);

            Assert.IsInstanceOfType(result1.Result, typeof(ActionResult<Utilisateur>), "Pas un ActionResult"); // Test du type de retour
                                                                                                               // Assert.IsInstanceOfType(result1.Result.Value, typeof(Utilisateur), "Pas un utilisateur"); // Test du type du contenu (valeur) du retour
        }


        [TestMethod()]
        public void PutUtilisateurTest()
        {
            var builder = new DbContextOptionsBuilder<FilmRatingsDBContext>().UseNpgsql("Server=localhost;port=5432;Database=FilmRatingDB; uid=postgres;password=postgres;");
            FilmRatingsDBContext _context = new FilmRatingsDBContext(builder.Options);
            UtilisateursController controller = new UtilisateursController(_context);

            // Arrange
            Random rnd = new Random();
            int chiffre = rnd.Next(1, 1000000000);

            Utilisateur userAtester = new Utilisateur()
            {
                UtilisateurId = 10,
                Nom = "MACHIN",
                Prenom = "Luc",
                Mobile = "0606070809",
                Mail = "machin" + chiffre + "@gmail.com",
                Pwd = "Toto1234!",
                Rue = "Chemin de Bellevue",
                CodePostal = "74940",
                Ville = "Annecy-le-Vieux",
                Pays = "France",
                Latitude = null,
                Longitude = null
            };

            var result = controller.PutUtilisateur(10, userAtester).Result;

            Utilisateur? userRecupere = _context.Utilisateurs.Where(u => u.UtilisateurId == userAtester.UtilisateurId).FirstOrDefault();
            Assert.AreEqual(userRecupere, userAtester, "Utilisateurs pas identiques");


        }



        [TestMethod()]
        public void PostUtilisateurTest_CreationOK()
        {

            var builder = new DbContextOptionsBuilder<FilmRatingsDBContext>().UseNpgsql("Server=localhost;port=5432;Database=FilmRatingDB; uid=postgres;password=postgres;");
            FilmRatingsDBContext _context = new FilmRatingsDBContext(builder.Options);
            UtilisateursController controller = new UtilisateursController(_context);

            // Arrange
            Random rnd = new Random();
            int chiffre = rnd.Next(1, 1000000000);

            Utilisateur userAtester = new Utilisateur()
            {
                Nom = "MACHIN",
                Prenom = "Luc",
                Mobile = "0606070809",
                Mail = "machin" + chiffre + "@gmail.com",
                Pwd = "Toto1234!",
                Rue = "Chemin de Bellevue",
                CodePostal = "74940",
                Ville = "Annecy-le-Vieux",
                Pays = "France",
                Latitude = null,
                Longitude = null
            };

            // Act
            var result = controller.PostUtilisateur(userAtester).Result;

            Utilisateur? userRecupere = _context.Utilisateurs.Where(u => u.Mail.ToUpper() == userAtester.Mail.ToUpper()).FirstOrDefault(); // On récupère l'utilisateur créé directement dans la BD grace à son mail

            userAtester.UtilisateurId = userRecupere.UtilisateurId;
            Assert.AreEqual(userRecupere, userAtester, "Utilisateurs pas identiques");



        }



        [TestMethod()]
        public void PostUtilisateurTest_Mobile()
        {

            var builder = new DbContextOptionsBuilder<FilmRatingsDBContext>().UseNpgsql("Server=localhost;port=5432;Database=FilmRatingDB; uid=postgres;password=postgres;");
            FilmRatingsDBContext _context = new FilmRatingsDBContext(builder.Options);
            UtilisateursController controller = new UtilisateursController(_context);

            // Arrange
            Random rnd = new Random();
            int chiffre = rnd.Next(1, 1000000000);

            Utilisateur userAtester = new Utilisateur()
            {
                Nom = "MACHIN",
                Prenom = "Luc",
                Mobile = "1",
                Mail = "machin" + chiffre + "@gmail.com",
                Pwd = "Toto1234!",
                Rue = "Chemin de Bellevue",
                CodePostal = "74940",
                Ville = "Annecy-le-Vieux",
                Pays = "France",
                Latitude = null,
                Longitude = null
            };

            string PhoneRegex = @"^0[0-9]{9}$";
            Regex regex = new Regex(PhoneRegex);
            if (!regex.IsMatch(userAtester.Mobile))
            {
                controller.ModelState.AddModelError("Mobile", "Le n° de mobile doit contenir 10 chiffres"); //On met le même message que dans la classe Utilisateur.
            }

            // Act
            var result = controller.PostUtilisateur(userAtester).Result;

            Utilisateur? userRecupere = _context.Utilisateurs.Where(u => u.Mail.ToUpper() == userAtester.Mail.ToUpper()).FirstOrDefault(); // On récupère l'utilisateur créé directement dans la BD grace à son mail

            userAtester.UtilisateurId = userRecupere.UtilisateurId;
            Assert.AreEqual(userRecupere, userAtester, "Utilisateurs pas identiques");



        }


        [TestMethod()]
        public void DeleteUtilisateurTest()
        {
            var builder = new DbContextOptionsBuilder<FilmRatingsDBContext>().UseNpgsql("Server=localhost;port=5432;Database=FilmRatingDB; uid=postgres;password=postgres;");
            FilmRatingsDBContext _context = new FilmRatingsDBContext(builder.Options);
            UtilisateursController controller = new UtilisateursController(_context);

            // Arrange
            Random rnd = new Random();
            int chiffre = rnd.Next(1, 1000000000);
            
            Utilisateur userAtester = new Utilisateur()
            {
                
                Nom = "MACHIN",
                Prenom = "Luc",
                Mobile = "1",
                Mail = "machin" + chiffre + "@gmail.com",
                Pwd = "Toto1234!",
                Rue = "Chemin de Bellevue",
                CodePostal = "74940",
                Ville = "Annecy-le-Vieux",
                Pays = "France",
                Latitude = null,
                Longitude = null
            };

            var result2 = controller.PostUtilisateur(userAtester).Result;
           
            var result = controller.DeleteUtilisateur(userAtester.UtilisateurId).Result;

            Utilisateur? userRecupere = _context.Utilisateurs.Where(u => u.UtilisateurId == userAtester.UtilisateurId).FirstOrDefault();
            Assert.AreNotEqual(userRecupere, userAtester, "Utilisateurs identiques");


        }

    }
}