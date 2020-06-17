using FitnessAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAPI.DTOs
{
    public class ExerciseDTO
    {
        public int ID { get; set; }

        public int? Index { get; set; }

        public TimeSpan? RestTime { get; set; }
        
        public int MovementId { get; set; }
        public MovementDTO Movement { get; set; }

        public int? SingleWorkoutId { get; set; }
        public SingleWorkoutDTO SingleWorkout { get; set; }

        public int? SuperSetId { get; set; }

        public int? WorkoutId { get; set; }
        //public WorkoutDTO Workout { get; set; }
        public bool IsNew { get; set; } = false;

        public List<SetDTO> Sets { get; set; }
    }
}