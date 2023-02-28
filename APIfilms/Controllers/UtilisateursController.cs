using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIfilms.Models.EntityFramework;
using System.Collections;
using APIfilms.Models.DataManager;
using APIfilms.Models.Repository;

namespace APIfilms.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UtilisateursController : ControllerBase
    {
       // private readonly FilmRatingsDBContext _context;
        private readonly IDataRepository<Utilisateur> dataRepository;

        public UtilisateursController(IDataRepository<Utilisateur> dataRepo)

        {
             dataRepository = dataRepo;
        }




    /// <summary>
    /// Get a many currency.
    /// </summary>
    /// <returns>Http response</returns>
    /// <response code="200">When the all user is found</response>

    // GET: api/Utilisateurs
    [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<Utilisateur>>> GetUtilisateurs()
        {
            return dataRepository.GetAll();
        }


        /// <summary>
        /// Get a single currency.
        /// </summary>
        /// <returns>Http response</returns>
        /// <response code="200">When the currency user is found</response>
        /// <response code="404">When the currency user is not found</response>

        // GET: api/Utilisateurs/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Utilisateur>> GetUtilisateurById(int id)
        {
            var utilisateur = await dataRepository.GetByIdAsync(id);
            //var utilisateur = await _context.Utilisateurs.FindAsync(id);
            if (utilisateur == null)
            {
                return NotFound();
            }
            return utilisateur;

        }


        /// <summary>
        /// Get a single currency.
        /// </summary>
        /// <returns>Http response</returns>
        /// <response code="200">When the user is modify</response>
        /// <response code="400">When the user is not found</response>

        // PUT: api/Utilisateurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutUtilisateur(int id, Utilisateur utilisateur)
        {
            if (id != utilisateur.UtilisateurId)
            {
                return BadRequest();
            }
            var userToUpdate = await dataRepository.GetByIdAsync(id);
            if (userToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(userToUpdate.Value, utilisateur);
                return NoContent();
            }
        }


        /// <summary>
        /// Get a single currency.
        /// </summary>
        /// <returns>Http response</returns>
        /// <response code="201">When the currency user is add</response>
        /// <response code="400">When the currency user is not add</response>

        // POST: api/Utilisateurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Utilisateur>> PostUtilisateur(Utilisateur utilisateur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(utilisateur);
            return CreatedAtAction("GetById", new { id = utilisateur.UtilisateurId }, utilisateur); // GetById : nom de l’action
        }

        /// <summary>
        /// Get a single currency.
        /// </summary>
        /// <returns>Http response</returns>
        /// <response code="200">When the user is delete</response>
        /// <response code="404">When the user is not found</response>

        // DELETE: api/Utilisateurs/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUtilisateur(int id)
        {
            var utilisateur = await dataRepository.GetByIdAsync(id);
            if (utilisateur.Value == null)
            {
                return NotFound();
                
            }
            await dataRepository.DeleteAsync(utilisateur.Value);
            return NoContent();
        }

        //private bool UtilisateurExists(int id)
        //{
        // return _context.Utilisateurs.Any(e => e.UtilisateurId == id);
        //}



        /// <summary>
        /// Get a single currency.
        /// </summary>
        /// <returns>Http response</returns>
        /// <response code="200">When the user is find with mail</response>
        /// <response code="404">When the mail is not found</response>


        // GET: api/Utilisateurs/toto@titi.fr
        [HttpGet]
        [Route("[action]/{email}")]
        [ActionName("GetByEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Utilisateur>> GetUtilisateurByEmail(string email)
        {
            var utilisateur = await dataRepository.GetByStringAsync(email);
            if (utilisateur == null)
            {
                return NotFound();
            }
            return utilisateur;
        }
    }
}
