using FitnessAPI.DTOs;
using FitnessAPI.Models;
using FitnessAPI.Models.Setup;
using System.Collections.Generic;
using System.Linq;

namespace FitnessAPI.TypeAdapters
{
    public static class MuscleGroupAdapter
    {
        public static CategoryMuscleGroupDTO ToDTO(this MuscleGroup muscleGroup, LanguageType language)
        {
            return new CategoryMuscleGroupDTO
            {
                Category = new MuscleGroupDTO { ID = muscleGroup.ID, Name = muscleGroup.Translations.FirstOrDefault(trans => trans.LanguageType == language).Name },
                List = muscleGroup.Muscles.Select(y => new MuscleDTO()
                {
                    ID = y.ID,
                    Name = y.Translations.FirstOrDefault(trans => trans.LanguageType == language).Name,
                    MuscleGroupID = y.MuscleGroupID,
                }).ToList()
            };
        }

        public static List<CategoryMuscleGroupDTO> ToDTO(this List<MuscleGroup> muscleGroups, LanguageType language)
        {
            return muscleGroups.Select(e => e.ToDTO(language)).ToList();
        }
    }
}