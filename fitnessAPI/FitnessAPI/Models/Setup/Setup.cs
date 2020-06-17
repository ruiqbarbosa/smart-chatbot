using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models.Setup
{
    public class Setup
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

        public WeightMetricType WeightMetric { get; set; } = WeightMetricType.Kg;

        public HeightMetricType HeightMetric { get; set; } = HeightMetricType.Cm;

        public TrainingFrequencyType TrainingFrequency { get; set; } = TrainingFrequencyType.None;

        public ExperienceLevelType ExperienceLevel { get; set; } = ExperienceLevelType.None;

        public ConditioningLevelType ConditioningLevel { get; set; } = ConditioningLevelType.None;

        public LanguageType Language { get; set; } = LanguageType.en_US;

        public virtual ICollection<Goal> Goals { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}