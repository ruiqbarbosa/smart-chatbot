using FitnessAPI.Models.Translations;
using System.Collections.Generic;

namespace FitnessAPI.Models
{
    public class Plan
    {
        public int ID { get; set; }

        public string Code { get; set; }

        public string ImagePath { get; set; }

        public int? WeekIndex { get; set; }

        public double? Rating { get; set; }  //1-5

        public BodyAreaType? MainBodyAreaId { get; set; }
        public virtual BodyArea MainBodyArea { get; set; }

        public BodyAreaType? SecBodyAreaId { get; set; }
        public virtual BodyArea SecBodyArea { get; set; }

        public int ProgramId { get; set; }
        public virtual Program Program { get; set; }

        public virtual ICollection<Training> TrainingTypes { get; set; }

        public virtual ICollection<PlanTranslation> Translations { get; set; }

        public virtual ICollection<Workout> Workouts { get; set; }
    }
}