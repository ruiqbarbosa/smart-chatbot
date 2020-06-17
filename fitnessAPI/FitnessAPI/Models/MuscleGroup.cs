using FitnessAPI.Models.Translations;
using System.Collections.Generic;

namespace FitnessAPI.Models
{
    public class MuscleGroup
    {
        public int ID { get; set; }

        public string Code { get; set; }

        public virtual ICollection<Muscle> Muscles { get; set; }

        public virtual ICollection<MovementMuscleGroup> MovementMuscleGroups { get; set; }

        public virtual ICollection<MuscleGroupTranslation> Translations { get; set; }
    }
}