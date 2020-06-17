using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models
{
    public class MovementMuscle
    {
        [Key, Column(Order = 0)]
        public int MovementID { get; set; }
        public virtual Movement Movement { get; set; }

        [Key, Column(Order = 1)]
        public int MuscleID { get; set; }
        public virtual Muscle Muscle { get; set; }

        public bool IsMainMuscle { get; set; } = true;

    }
}