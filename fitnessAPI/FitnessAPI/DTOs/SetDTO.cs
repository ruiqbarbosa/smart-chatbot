using FitnessAPI.Models;

namespace FitnessAPI.DTOs
{
    public class SetDTO
    {
        public int ID { get; set; }

        public int ExerciseId { get; set; }

        public int? Index { get; set; }

        public string RestTime { get; set; }

        public string Duration { get; set; }

        public int? Reps { get; set; }

        public double? Speed { get; set; }

        public double? Weight { get; set; }

        public IntensityDTO Intensity { get; set; } = new IntensityDTO();

        public bool IsDone { get; set; } = false;

    }
}