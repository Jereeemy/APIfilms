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
using APIfilms.Models.DataManager;
using APIfilms.Models.Repository;
using Moq;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace APIfilms.Controllers.Tests
{
    [TestClass()]
    public class UtilisateursControllerTests
    {

        private UtilisateursController controller;
        private FilmRatingsDBContext context;
        private IDataRepository<Utilisateur> dataRepository;
        UtilisateursController utilisateurController;

      


        public UtilisateursControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FilmRatingsDBContext>().UseNpgsql("Server=localhost;port=5432;Database=FilmRatingDB; uid=postgres;password=postgres;");
            context = new FilmRatingsDBContext(builder.Options);
            dataRepository = new UtilisateurManager(context);
            controller = new UtilisateursController(dataRepository);
        }


       /* [TestMethod()]
        public async Task GetUtilisateursTestAsync()
        {
            var builder = new DbContextOptionsBuilder<FilmRatingsDBContext>().UseNpgsql("Server=localhost;port=5432;Database=FilmRatingDB; uid=postgres;password=postgres;");
            context = new FilmRatingsDBContext(builder.Options);
            dataRepository = new UtilisateurManager(context);
            controller = new UtilisateursController(dataRepository);

            ActionResult<IEnumerable<Utilisateur>> users = await controller.GetUtilisateurs();
            CollectionAssert.AreEqual(context.Utilisateurs.ToList(), users.Value.ToList(), "La liste renvoyée n'est pas la bonne.");
        }*/

        [TestMethod()]
        public void GetUtilisateursTest()
        {
            

            var result = controller.GetUtilisateurs().Result.Value;

            Utilisateur u1 = new Utilisateur(new List<Notation>(), 1, "Calidaaaaa", "Lilley", "0653930778", "clilleymd@last.fm", "Toto12345678!", "Impasse des bergeronnettes", "74200", "Allinges", "France", (float)46.344795, (float)6.4885845, new DateTime(2023, 02, 27));
            Utilisateur u2 = new Utilisateur(new List<Notation>(), 2, "Gwendolin", "Dominguez", "0724970555", "gdominguez0@washingtonpost.com", "Toto12345678!", "Chemin de gom", "73420", "Voglans", "France", (float)45.622154, (float)5.8853216, new DateTime(2023, 02, 27));
            Utilisateur u3 = new Utilisateur(new List<Notation>(), 3, "Randolph", "Richings", "0630271158", "rrichings1@naver.com", "Toto12345678!", "Route des charmottes d'en bas", "74890", "Bons-en-Chablais", "France", (float)46.25732, (float)6.367676, new DateTime(2023, 02, 27));


            List<Utilisateur> listeUtilisateurRecuperees = new List<Utilisateur> { u1, u2, u3 };

            CollectionAssert.AreEqual(result.Where(s => s.UtilisateurId <= 3).ToList(), listeUtilisateurRecuperees);
        }

        [TestMethod()]
        public void GetUtilisateurByIdTest()
        {
           

            //Act
            var result1 = controller.GetUtilisateurById(2);


            Utilisateur u2 = new Utilisateur(new List<Notation>(), 2, "Gwendolin", "Dominguez", "0724970555", "gdominguez0@washingtonpost.com", "Toto12345678!", "Chemin de gom", "73420", "Voglans", "France", (float)45.622154, (float)5.8853216, new DateTime(2023, 02, 27));

            //Assert

            Assert.AreEqual(result1.Result.Value, u2);
            Assert.IsNull(result1.Result.Result, "Erreur est pas null"); //Test de l'erreur
            Assert.IsInstanceOfType(result1.Result, typeof(ActionResult<Utilisateur>), "Pas un ActionResult"); // Test du type de retour
            Assert.IsInstanceOfType(result1.Result.Value, typeof(Utilisateur), "Pas un utilisateur"); // Test du type du contenu (valeur) du retour


        }




        [TestMethod()]
        public void GetUtilisateurByIdTest_NotFound()
        {
           

            Utilisateur u1 = new Utilisateur(new List<Notation>(), 1, "Calida", "Lilley", "0653930778", "clilleymd@last.fm", "Toto12345678!", "Impasse des bergeronnettes", "74200", "Allinges", "France", (float)46.344795, (float)6.4885845, new DateTime(2023, 02, 27));
            var result1 = controller.GetUtilisateurById(100);



            Assert.AreEqual(result1.Result.Value, null);
            //Assert.IsNull(result1.Result.Result, "Erreur est pas null"); //Test de l'erreur
            Assert.IsInstanceOfType(result1.Result, typeof(ActionResult<Utilisateur>), "Pas un ActionResult"); // Test du type de retour
                                                                                                               //Assert.IsInstanceOfType(result1.Result.Value, typeof(Utilisateur), "Pas un utilisateur"); // Test du type du contenu (valeur) du retour
        }


        [TestMethod()]
        public void GetUtilisateurByEmailTest()
        {
           

            //Act
            var result1 = controller.GetUtilisateurByEmail("gdominguez0@washingtonpost.com");


            Utilisateur u2 = new Utilisateur(new List<Notation>(), 2, "Gwendolin", "Dominguez", "0724970555", "gdominguez0@washingtonpost.com", "Toto12345678!", "Chemin de gom", "73420", "Voglans", "France", (float)45.622154, (float)5.8853216, new DateTime(2023, 02, 27));

            //Assert

            Assert.AreEqual(result1.Result.Value, u2);
            Assert.IsNull(result1.Result.Result, "Erreur est pas null"); //Test de l'erreur
            Assert.IsInstanceOfType(result1.Result, typeof(ActionResult<Utilisateur>), "Pas un ActionResult"); // Test du type de retour
            Assert.IsInstanceOfType(result1.Result.Value, typeof(Utilisateur), "Pas un utilisateur"); // Test du type du contenu (valeur) du retour
        }
        [TestMethod()]
        public void GetUtilisateurByEmail_NotFound()
        {
           

            //Act
            var result1 = controller.GetUtilisateurByEmail("aaaa");
            


            Utilisateur u2 = new Utilisateur(new List<Notation>(), 2, "Gwendolin", "Dominguez", "0724970555", "gdominguez0@washingtonpost.com", "Toto12345678!", "Chemin de gom", "73420", "Voglans", "France", (float)45.622154, (float)5.8853216, new DateTime(2023, 02, 27));

            //Assert

            Assert.AreEqual(result1.Result.Value, null);

            Assert.IsInstanceOfType(result1.Result, typeof(ActionResult<Utilisateur>), "Pas un ActionResult"); // Test du type de retour
                                                                                                               // Assert.IsInstanceOfType(result1.Result.Value, typeof(Utilisateur), "Pas un utilisateur"); // Test du type du contenu (valeur) du retour
        }


        /*[TestMethod()]
        public void PutUtilisateurTest()
        {
            var builder = new DbContextOptionsBuilder<FilmRatingsDBContext>().UseNpgsql("Server=localhost;port=5432;Database=FilmRatingDB; uid=postgres;password=postgres;");
            context = new FilmRatingsDBContext(builder.Options);
            dataRepository = new UtilisateurManager(context);
            controller = new UtilisateursController(dataRepository);

            // Arrange
            Random rnd = new Random();
            int chiffre = rnd.Next(1, 1000000000);
           
            Utilisateur userAtester = new Utilisateur()
            {
                UtilisateurId = 7,
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
            var result = controller.PutUtilisateur(userAtester.UtilisateurId, userAtester).Result; // .Result pour appeler la méthode async de manière synchrone, afin d'attendre l’ajout
            // Assert
            Utilisateur? userRecupere = context.Utilisateurs.Where(u => u.UtilisateurId == userAtester.UtilisateurId).FirstOrDefault(); // On récupère l'utilisateur créé directement dans la BD grace à son mail unique
            Assert.AreEqual(userRecupere, userAtester, "Utilisateurs pas identiques");


        }*/

        [TestMethod()]
        public async Task PutUtilisateurTest()
        {

           

            Utilisateur user = await context.Utilisateurs.FindAsync(146);
            user.Nom += "a";
            await controller.PutUtilisateur(user.UtilisateurId, user);
            Utilisateur modifie = await context.Utilisateurs.FindAsync(146);
            Assert.AreEqual(user, modifie, "pas les memes");
        }




        [TestMethod()]
        public void PostUtilisateurTest_CreationOK()
        {

          

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

            Utilisateur? userRecupere = context.Utilisateurs.Where(u => u.Mail.ToUpper() == userAtester.Mail.ToUpper()).FirstOrDefault(); // On récupère l'utilisateur créé directement dans la BD grace à son mail

            userAtester.UtilisateurId = userRecupere.UtilisateurId;
            Assert.AreEqual(userRecupere, userAtester, "Utilisateurs pas identiques");

            Assert.IsInstanceOfType(result, typeof(ActionResult<Utilisateur>), "Pas un ActionResult<Utilisateur>");
            Assert.IsInstanceOfType(result.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result2 = result.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result2.Value, typeof(Utilisateur), "Pas un Utilisateur");



        }



        [TestMethod()]
        public void PostUtilisateurTest_Mobile()
        {

           

            // Arrange
            Random rnd = new Random();
            int chiffre = rnd.Next(1, 1000000000);

            Utilisateur userAtester = new Utilisateur()
            {
                Nom = "MACHIN",
                Prenom = "Luc",
                Mobile = "0101010101",
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

            Assert.IsInstanceOfType(result, typeof(ActionResult<Utilisateur>), "Pas un ActionResult<Utilisateur>");
            Assert.IsInstanceOfType(result.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");

            Utilisateur? userRecupere = context.Utilisateurs.Where(u => u.Mobile == userAtester.Mobile).FirstOrDefault(); // On récupère l'utilisateur créé directement dans la BD grace à son mail

            userAtester.UtilisateurId = userRecupere.UtilisateurId;
            Assert.AreEqual(userRecupere, userAtester, "Utilisateurs pas identiques");



        }


        /*[TestMethod()]
        public void DeleteUtilisateurTest()
        {
            var builder = new DbContextOptionsBuilder<FilmRatingsDBContext>().UseNpgsql("Server=localhost;port=5432;Database=FilmRatingDB; uid=postgres;password=postgres;");
            context = new FilmRatingsDBContext(builder.Options);
            dataRepository = new UtilisateurManager(context);
            controller = new UtilisateursController(dataRepository);

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

            Utilisateur? userRecupere = context.Utilisateurs.Where(u => u.UtilisateurId == userAtester.UtilisateurId).FirstOrDefault();
            Assert.AreNotEqual(userRecupere, userAtester, "Utilisateurs identiques");


        }*/

        [TestMethod()]
        public async Task DeleteUtilisateurTest()
        {
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
            EntityEntry<Utilisateur> res = context.Utilisateurs.Add(userAtester);
            context.SaveChanges();
            IActionResult result = await controller.DeleteUtilisateur(res.Entity.UtilisateurId);

            Utilisateur user = context.Utilisateurs.Where(u => u.UtilisateurId == res.Entity.UtilisateurId).FirstOrDefault();

            Assert.IsNull(user, "Non");


        }

        [TestMethod]
        public void DeleteUtilisateur_ModelValidated_200OK()
        {
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

            //Verify Model
            //VerifyModel(userAtester);

            context.Utilisateurs.Add(userAtester);
            context.SaveChanges();
            var utlLast = context.Utilisateurs.OrderBy(k => k.UtilisateurId).LastOrDefault();

            // Act
            var result = controller.DeleteUtilisateur(utlLast.UtilisateurId).Result;

            // Assert
            
            var userSuppr = controller.GetUtilisateurById(utlLast.UtilisateurId).Result;

            Assert.AreEqual(((NoContentResult)result).StatusCode, StatusCodes.Status204NoContent, "Pas 204NoContent");
           

        }

        [TestMethod]
        public void DeleteUtilisateur_ModelValidated_404NotFound()
        {

            
            // Act
            var result = controller.DeleteUtilisateur(-1);
            Thread.Sleep(1000);

            /* Asserts */
            Assert.IsInstanceOfType(result, typeof(Task<IActionResult>), "Pas un Task<IActionResult>"); // Test du type de retour
            Assert.IsNotNull(result.Result, "Erreur est null"); // Test de l'erreur
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult), "Doit être un NotFoundResult"); // Test du type de l'erreur
            Assert.AreEqual(((NotFoundResult)result.Result).StatusCode, StatusCodes.Status404NotFound, "Pas 404"); // Teste si l'erreur est une 404
        }



        [TestMethod]
        public void Postutilisateur_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Utilisateur>>();
            var userController = new UtilisateursController(mockRepository.Object);
            Utilisateur user = new Utilisateur
            {
                Nom = "POISSON",
                Prenom = "Pascal",
                Mobile = "1",
                Mail = "poisson@gmail.com",
                Pwd = "Toto12345678!",
                Rue = "Chemin de Bellevue",
                CodePostal = "74940",
                Ville = "Annecy-le-Vieux",
                Pays = "France",
                Latitude = null,
                Longitude = null
            };
            // Act
            var actionResult = userController.PostUtilisateur(user).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Utilisateur>), "Pas un ActionResult<Utilisateur>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Utilisateur), "Pas un Utilisateur");
            user.UtilisateurId = ((Utilisateur)result.Value).UtilisateurId;
            Assert.AreEqual(user, (Utilisateur)result.Value, "Utilisateurs pas identiques");
        }


        [TestMethod]
        public void GetUtilisateurById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Utilisateur user = new Utilisateur
            {
                UtilisateurId = 1,
                Nom = "Calida",
                Prenom = "Lilley",
                Mobile = "0653930778",
                Mail = "clilleymd@last.fm",
                Pwd = "Toto12345678!",
                Rue = "Impasse des bergeronnettes",
                CodePostal = "74200",
                Ville = "Allinges",
                Pays = "France",
                Latitude = 46.344795F,
                Longitude = 6.4885845F
            };
            var mockRepository = new Mock<IDataRepository<Utilisateur>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(user);
            var userController = new UtilisateursController(mockRepository.Object);
            // Act
            var actionResult = userController.GetUtilisateurById(1).Result;
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(user, actionResult.Value as Utilisateur);
        }

        [TestMethod]
        public void GetUtilisateurById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Utilisateur>>();
            var userController = new UtilisateursController(mockRepository.Object);
            // Act
            var actionResult = userController.GetUtilisateurById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetUtilisateurById_UnknownMailPassed_ReturnsNotFoundResult_AvecMoq()
        {
            

            var mockRepository = new Mock<IDataRepository<Utilisateur>>();
            var userController = new UtilisateursController(mockRepository.Object);
            // Act
            var actionResult = userController.GetUtilisateurByEmail("toto@gmail.fr").Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }


        [TestMethod]
        public void GetUtilisateurByEmail_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Utilisateur user = new Utilisateur
            {
                UtilisateurId = 1,
                Nom = "Calida",
                Prenom = "Lilley",
                Mobile = "0653930778",
                Mail = "clilleymd@last.fm",
                Pwd = "Toto12345678!",
                Rue = "Impasse des bergeronnettes",
                CodePostal = "74200",
                Ville = "Allinges",
                Pays = "France",
                Latitude = 46.344795F,
                Longitude = 6.4885845F
            };
            var mockRepository = new Mock<IDataRepository<Utilisateur>>();
            
            mockRepository.Setup(y => y.GetByStringAsync("clilleymd@last.fm").Result).Returns(user);
            var userController = new UtilisateursController(mockRepository.Object);
            // Act
            var actionResult = userController.GetUtilisateurByEmail("clilleymd@last.fm").Result;
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(user, actionResult.Value as Utilisateur);
        }

        [TestMethod]
        public void DeleteUtilisateurTest_AvecMoq()
        {
            // Arrange
            Utilisateur user = new Utilisateur
            {
                UtilisateurId = 1,
                Nom = "Calida",
                Prenom = "Lilley",
                Mobile = "0653930778",
                Mail = "clilleymd@last.fm",
                Pwd = "Toto12345678!",
                Rue = "Impasse des bergeronnettes",
                CodePostal = "74200",
                Ville = "Allinges",
                Pays = "France",
                Latitude = 46.344795F,
                Longitude = 6.4885845F
            };
            var mockRepository = new Mock<IDataRepository<Utilisateur>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(user);
            
            var userController = new UtilisateursController(mockRepository.Object);
            // Act
            var actionResult = userController.DeleteUtilisateur(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }

        [TestMethod]
        public void PutUtilisateurTest_AvecMoq()
        {
            // Le mail doit être unique donc 2 possibilités :
            // 1. on s'arrange pour que le mail soit unique en concaténant un random ou un timestamp
            // 2. On supprime le user après l'avoir créé. Dans ce cas, nous avons besoin d'appeler la méthode DELETE de l’API ou remove du DbSet.
            Utilisateur user = new Utilisateur()
            {
                Nom = "MACHIN",
                Prenom = "Luc",
                Mobile = "0606070809",
                Mail = "machin" + "@gmail.com",
                Pwd = "Toto1234!",
                Rue = "Chemin de Bellevue",
                CodePostal = "74940",
                Ville = "Annecy-le-Vieux",
                Pays = "France",
                Latitude = null,
                Longitude = null
            };

            // Act
            var mockRepository = new Mock<IDataRepository<Utilisateur>>();
            mockRepository.Setup(x => x.GetByIdAsync(20).Result).Returns(user);
            var userController = new UtilisateursController(mockRepository.Object);


            user.Nom = "a";
            userController.PutUtilisateur(user.UtilisateurId, user);

            var actionResult = userController.GetUtilisateurById(20).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Utilisateur>), "Pas un ActionResult<Utilisateur>");
            var result = actionResult.Value;
            Console.WriteLine(result.GetType());
            Assert.IsInstanceOfType(result, typeof(Utilisateur), "Pas un Utilisateur");
            user.UtilisateurId = ((Utilisateur)result).UtilisateurId;
            Assert.AreEqual(user, (Utilisateur)result, "Utilisateurs pas identiques");
        }

        /*[TestMethod]
        public void Pututilisateur_ModelValidated_UpdateOK_AvecMoq()
        {
            // Arrange
            Utilisateur userAMaJ = new Utilisateur
            {
                UtilisateurId = 1,
                Nom = "Calida",
                Prenom = "Lilley",
                Mobile = "0653930778",
                Mail = "clilleymd@last.fm",
                Pwd = "Toto12345678!",
                Rue = "Impasse des bergeronnettes",
                CodePostal = "74200",
                Ville = "Allinges",
                Pays = "France",
                Latitude = 46.344795F,
                Longitude = 6.4885845F
            };
            Utilisateur userUpdated = new Utilisateur
            {
                UtilisateurId = 1,
                Nom = "POISSONT",
                Prenom = "Pascal",
                Mobile = "0653930778",
                Mail = "clilleymd@last.fm",
                Pwd = "Toto12345678!",
                Rue = "Impasse des bergeronnettes",
                CodePostal = "74200",
                Ville = "Allinges",
                Pays = "France",
                Latitude = 46.344795F,
                Longitude = 6.4885845F
            };
            var mockRepository = new Mock<IDataRepository<Utilisateur>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(userAMaJ);
            var userController = new UtilisateursController(mockRepository.Object);

            // Act
            var actionResult = userController.PutUtilisateur(userUpdated.UtilisateurId, userUpdated).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }*/



    }
}