using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models
{
    public class MovementMuscleGroup
    {
        [Key, Column(Order = 0)]
        public int MovementID { get; set; }
        public virtual Movement Movement { get; set; }

        [Key, Column(Order = 1)]
        public int MuscleGroupID { get; set; }
        public virtual MuscleGroup MuscleGroup { get; set; }

        public bool IsMainMuscleGroup { get; set; } = true;
    }
}