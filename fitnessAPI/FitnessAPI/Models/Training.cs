using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models
{
    public class Training
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public TrainingType TrainingType { get; set; }

        public virtual ICollection<Movement> Movements { get; set; }

        public virtual ICollection<Plan> Plans { get; set; }

        public virtual ICollection<Program> Programs { get; set; }

        public virtual ICollection<SingleWorkout> SingleWorkouts { get; set; }

        public virtual ICollection<Workout> Workouts { get; set; }
    }
}