using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FitnessAPI.Models
{
    public class Exercise
    {
        public int ID { get; set; }

        public string Code { get; set; }

        public int? Index { get; set; }

        public TimeSpan? RestTime { get; set; }

        //[ForeignKey("Movement")]
        public int MovementId { get; set; }
        public virtual Movement Movement { get; set; }

        public int? SingleWorkoutId { get; set; }
        public virtual SingleWorkout SingleWorkout { get; set; }

        public int? SuperSetId { get; set; }
        public virtual SuperSet SuperSet { get; set; }

        public int? WorkoutId { get; set; }
        public virtual Workout Workout { get; set; }

        public virtual ICollection<Set> Sets { get; set; }

        [NotMapped]
        public int SetsCount
        {
            get
            {
                if (Sets == null || !Sets.Any())
                    return 0;
                else
                    return Sets.Count();
            }
        }

    }
}