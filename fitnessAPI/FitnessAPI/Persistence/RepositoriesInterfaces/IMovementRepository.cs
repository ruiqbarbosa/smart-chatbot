using FitnessAPI.DTOs;
using FitnessAPI.Models;
using FitnessAPI.Models.Setup;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessAPI.Persistence.RepositoriesInterfaces
{
    public interface IMovementRepository : IDisposable
    {
        Task<Movement> GetMovementByID(int id);

        Task<Movement> GetMovementByName(string name);

        Task<List<ShortModelDTO>> GetMovementsIDsAndNames(LanguageType language);

    }
}