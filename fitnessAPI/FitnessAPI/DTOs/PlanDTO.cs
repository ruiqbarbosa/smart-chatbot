using FitnessAPI.Helpers;
using FitnessAPI.Models;
using FitnessAPI.Models.Setup;
using System.Collections.Generic;

namespace FitnessAPI.DTOs
{
    public class PlanDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }        

        public string ImagePath { get; set; }

        public int? WeekIndex { get; set; }        

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

        public List<GeneralDTO> TrainingTypes { get; set; }

        public List<WorkoutDTO> Workouts { get; set; } = new List<WorkoutDTO>();

    }
}