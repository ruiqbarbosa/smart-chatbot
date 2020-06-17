using System.Collections.Generic;

namespace FitnessAPI.DTOs
{
    public class CategoryMuscleGroupDTO
    {
        public MuscleGroupDTO Category { get; set; }

        public List<MuscleDTO> List { get; set; }

    }
}