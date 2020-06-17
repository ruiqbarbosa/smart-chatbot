using FitnessAPI.DTOs;
using FitnessAPI.Models;
using FitnessAPI.Models.Setup;
using System.Collections.Generic;
using System.Linq;

namespace FitnessAPI.TypeAdapters
{
    public static class MovementAdapter
    {
        public static MovementDTO ToDTO(this Movement movement, string userID, LanguageType language)
        {
            return new MovementDTO
            {
                ID = movement.ID,
                Name = movement.Translations.FirstOrDefault(trans => trans.LanguageType == language).Name,
                ImagePath = movement.ImagePath,
                VideoPath = movement.VideoPath,
                IsCompound = movement.IsCompound,
                Calories = movement.Calories,
                Duration = movement.Duration,
                CreatedType = movement.CreatedType,
                DefaultRecordType = movement.DefaultRecordType,
                Level = movement.Level,
                Type = movement.Type,
                BodyArea = movement.BodyAreaId,
                UserID = movement.ApplicationUserId,
                IsFavourite = movement.Favourites.Where(u => u.ApplicationUserId == userID).Count() == 1 ? true : false,
                Equipments = movement.Equipments.ToList().ToDTO(userID, language),
                TrainingTypes = movement.TrainingTypes.Select(x => new TrainingTypeDTO { TrainingType = x.TrainingType }).ToList(),
                MuscleGroups = movement.MovementMuscleGroups.Select(x => new MuscleGroupDTO { ID = x.MuscleGroupID, IsMain =x.IsMainMuscleGroup, Name = x.MuscleGroup.Translations.FirstOrDefault(trans => trans.LanguageType == language).Name }).ToList(),
                Muscles = movement.MovementMuscles.Select(x => new MuscleDTO { ID = x.MuscleID, IsMain = x.IsMainMuscle, Name = x.Muscle.Translations.FirstOrDefault(trans => trans.LanguageType == language).Name, MuscleGroupID = x.Muscle.MuscleGroupID }).ToList()
            };
        }

        public static List<MovementDTO> ToDTO(this List<Movement> movements, string userID, LanguageType language)
        {
            return movements.Select(m => m.ToDTO(userID, language)).ToList();
        }
    }
}