using System.Collections.Generic;

namespace FitnessAPI.DTOs
{
    public class WorkoutFiltersDTO
    {
        public List<SingleWorkoutDTO> Workouts { get; set; }

        public List<CategoryEquipmentsDTO> EquipmentCategories { get; set; }

        public List<CategoryMuscleGroupDTO> MuscleGroups { get; set; }
    }
}