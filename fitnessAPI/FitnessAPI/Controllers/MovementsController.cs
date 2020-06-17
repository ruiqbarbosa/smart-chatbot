using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using FitnessAPI.DTOs;
using FitnessAPI.Helpers;
using FitnessAPI.Models;
using FitnessAPI.Models.Setup;
using FitnessAPI.Persistence.Repositories;
using FitnessAPI.Persistence.RepositoriesInterfaces;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FitnessAPI.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Movements")]
    public class MovementsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        private readonly IMovementRepository movementRepository;

        public MovementsController()
        {
            var store = new UserStore<ApplicationUser>(db);
            var manager = new ApplicationUserManager(store);
            
            this.movementRepository = new MovementRepository(db);

        }

        public MovementsController(IMovementRepository movementRepository)
        {
            this.movementRepository = movementRepository;
        }

        [Route("getMovementsNames")]
        public async Task<List<string>> GetMovementsNames()
        {
            var movements = await movementRepository.GetMovementsIDsAndNames(LanguageType.pt_PT);

            return movements.GetAlphabeticallySeparatedList();
        }

        [Route("getMovementInfo/{movement}")]
        [ResponseType(typeof(MovementInfoDTO))]
        public async Task<IHttpActionResult> GetMovementInfo(string movement)
        {
            Movement movementDB;
            bool isNumeric = int.TryParse(movement, out int movementID);

            // Get from DB
            if (isNumeric)
                movementDB = await movementRepository.GetMovementByID(movementID);
            else
                movementDB = await movementRepository.GetMovementByName(movement);

            if (movementDB == null)
                return NotFound();

            // Setup the text language
            var name = movementDB.Translations.FirstOrDefault(trans => trans.LanguageType == LanguageType.pt_PT).Name;
            var commonMistakes = movementDB.Translations.FirstOrDefault(trans => trans.LanguageType == LanguageType.pt_PT).CommonMistakes.OrderBy(x => x.Id).Select(x => x.Data).ToList();
            var steps = movementDB.Translations.FirstOrDefault(trans => trans.LanguageType == LanguageType.pt_PT).Steps.OrderBy(x=>x.Id).Select(x=> x.Data).ToList();
            var tips = movementDB.Translations.FirstOrDefault(trans => trans.LanguageType == LanguageType.pt_PT).Tips.OrderBy(x => x.Id).Select(x => x.Data).ToList();

            var movementInfo = new MovementInfoDTO { CommonMistakes = commonMistakes, Name = name, Steps = steps, Tips = tips };

            return Ok(movementInfo);
        }

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}