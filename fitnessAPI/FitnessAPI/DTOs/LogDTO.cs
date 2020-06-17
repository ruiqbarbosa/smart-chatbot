using System;

namespace FitnessAPI.DTOs
{
    public class LogDTO
    {
        public int ID { get; set; }

        public DateTime DateTime { get; set; }
        public string Date
        {
            get { return this.DateTime.ToString("yyyy-MM-dd"); }
        }

        public string ProgramName { get; set; }

        public string PlanName { get; set; }

        public string WorkoutName { get; set; }

        public string SingleWorkoutName { get; set; }

        public string Duration { get; set; }

        public string Volume { get; set; }

    }
}