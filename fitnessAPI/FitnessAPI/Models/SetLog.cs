using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models
{
    public class SetLog
    {
        public int ID { get; set; }

        public string Code { get; set; }

        public int LogInstance { get; set; }

        public DateTime DateTime { get; set; }

        public TimeSpan? RestTime { get; set; }

        //CardioLog
        public int? Calories { get; set; }

        //CardioLog
        public double? Distance { get; set; }

        //CardioLog & TimeLog
        public TimeSpan? Duration { get; set; }

        //CardioLog
        public double? Speed { get; set; }

        //TimeLog & WeightAndRepsLog
        public Weight Weight { get; set; } = new Weight();

        //RepsOnlyLog & WeightAndRepsLog
        public int? Reps { get; set; }

        //WeightAndRepsLog
        public Intensity Intensity { get; set; } = new Intensity();

        public string DurationWk { get; set; }

        public string VolumeWk { get; set; }

        public int SetId { get; set; }
        public virtual Set Set { get; set; }

        public virtual TrainingMaxes TrainingMaxes { get; set; }
    }
}