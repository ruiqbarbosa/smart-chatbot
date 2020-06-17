using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models.Setup
{
    public class Goal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public GoalType GoalType { get; set; }

        public virtual ICollection<Program> Programs { get; set; }

        public virtual ICollection<SingleWorkout> SingleWorkouts { get; set; }

        public virtual ICollection<Setup> Setups { get; set; }
    }
}