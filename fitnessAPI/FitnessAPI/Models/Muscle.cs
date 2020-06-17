using FitnessAPI.Models.Translations;
using System.Collections.Generic;

namespace FitnessAPI.Models
{
    public class Muscle
    {
        public int ID { get; set; }

        public string Code { get; set; }

        public int MuscleGroupID { get; set; }

        public virtual MuscleGroup MuscleGroup { get; set; }

        public virtual ICollection<MovementMuscle> MovementMuscles { get; set; }

        public virtual ICollection<MuscleTranslation> Translations { get; set; }
    }
}