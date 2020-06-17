using System.Collections.Generic;

namespace FitnessAPI.DTOs
{
    public class ProgramFiltersDTO
    {
        public List<ProgramDTO> Programs { get; set; }

        public List<CategoryEquipmentsDTO> EquipmentCategories { get; set; }

        public List<CategoryMuscleGroupDTO> MuscleGroups { get; set; }
    }
}