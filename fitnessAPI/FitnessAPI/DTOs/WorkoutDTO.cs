using FitnessAPI.Helpers;
using FitnessAPI.Models;
using FitnessAPI.Models.Setup;
using System.Collections.Generic;

namespace FitnessAPI.DTOs
{
    public class WorkoutDTO
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public BodyAreaType? MainBodyArea { get; set; }

        private BodyAreaType? _SecBodyArea;
        public BodyAreaType? SecBodyArea
        {
            get { return _SecBodyArea; }
            set
            {
                if (value == null)
                    _SecBodyArea = BodyAreaType.None;
                else
                    _SecBodyArea = value;
            }
        }

        public int PlanId { get; set; }

        public string Duration { get; set; }

        public string Volume { get; set; }

        public List<MuscleGroupDTO> MuscleGroups { get; set; }

        public List<MuscleDTO> Muscles { get; set; }

        public List<GeneralDTO> TrainingTypes { get; set; }

        public List<ExerciseDTO> Exercises { get; set; } = new List<ExerciseDTO>();

    }
}