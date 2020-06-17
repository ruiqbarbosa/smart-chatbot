using FitnessAPI.DTOs;
using FitnessAPI.Helpers;
using FitnessAPI.Models;
using FitnessAPI.Models.Setup;
using FitnessAPI.Persistence.RepositoriesInterfaces;
using FitnessAPI.TypeAdapters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessAPI.Persistence.Repositories
{
    public class MovementRepository : IMovementRepository, IDisposable
    {
        private ApplicationDbContext context;

        public MovementRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Movement> GetMovementByID(int id)
        {
            return await context.Movements.FirstOrDefaultAsync(x=> x.ID == id);
        }

        public async Task<Movement> GetMovementByName(string name)
        {
            var movements = await context.Movements.ToListAsync();
            var movementByName = movements.
                Where(movement => movement.Translations.Where(transl => transl.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).Count()>0).FirstOrDefault();

            if(movementByName == null)
                movementByName = movements.
                    Where(movement => movement.Translations.Where(transl => transl.Name.ContainsIgnoreCase(name, StringComparison.OrdinalIgnoreCase)).Count() > 0).FirstOrDefault();

            return movementByName;
        }

        public async Task<List<ShortModelDTO>> GetMovementsIDsAndNames(LanguageType language)
        {
            var movements = await context.Movements.Where(x => (x.CreatedType == CreatedType.Template))
                .Select(movement => new ShortModelDTO
                {
                    ID = movement.ID,
                    Name = movement.Translations.FirstOrDefault(trans => trans.LanguageType == LanguageType.pt_PT).Name,
                    })
                .OrderBy(x => x.Name).ToListAsync();

            return movements;
        }

        #region Dispose
        // To detect redundant calls
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}