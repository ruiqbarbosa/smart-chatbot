using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models
{
    public class BodyArea
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public BodyAreaType BodyAreaType { get; set; }

        public virtual ICollection<Movement> Movements { get; set; }

        public virtual ICollection<Plan> Plans_Main { get; set; }
        public virtual ICollection<Plan> Plans_Sec { get; set; }

        public virtual ICollection<Program> Programs_Main { get; set; }
        public virtual ICollection<Program> Programs_Sec { get; set; }

        public virtual ICollection<SingleWorkout> SingleWorkouts_Main { get; set; }
        public virtual ICollection<SingleWorkout> SingleWorkouts_Sec { get; set; }

        public virtual ICollection<Workout> Workouts_Main { get; set; }
        public virtual ICollection<Workout> Workouts_Sec { get; set; }

    }
}