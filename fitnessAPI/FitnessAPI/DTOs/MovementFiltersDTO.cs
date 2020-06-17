using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAPI.DTOs
{
    public class MovementFiltersDTO
    {
        public List<MovementDTO> Movements { get; set; }

        public List<CategoryEquipmentsDTO> EquipmentCategories { get; set; }

        public List<CategoryMuscleGroupDTO> MuscleGroups { get; set; }
    }
}