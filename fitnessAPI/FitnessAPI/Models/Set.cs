using System;
using System.Collections.Generic;

namespace FitnessAPI.Models
{
    public class Set
    {
        public int ID { get; set; }

        public string Code { get; set; }

        public int? Index { get; set; }

        public TimeSpan? RestTime { get; set; }

        //Cardio & Time
        public TimeSpan? Duration { get; set; }

        //Cardio
        public double? Speed { get; set; }

        //Reps Only & WeightAndReps
        public int? Reps { get; set; }

        //WeightAndReps
        public Weight Weight { get; set; } = new Weight();

        //WeightAndReps
        public Intensity Intensity { get; set; } = new Intensity();

        public int ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set; }

        public virtual ICollection<SetLog> SetLogs { get; set; }

    }
}