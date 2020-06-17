using FitnessAPI.Models.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAPI.DTOs
{
    public class SetupDTO
    {
        public string WeightMetric { get; set; }

        public string HeightMetric { get; set; }

        public string Gender { get; set; }

        public string Age { get; set; } //Type string for encrypted process

        public string Weight { get; set; }

        public string Height { get; set; }

        public string Language { get; set; }

        public TrainingFrequencyType TrainingFrequency { get; set; }

        public ExperienceLevelType ExperienceLevel { get; set; } 

        public ConditioningLevelType ConditioningLevel { get; set; } 

        public List<GoalType> Goals { get; set; }

    }
}