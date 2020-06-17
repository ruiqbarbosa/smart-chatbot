using FitnessAPI.Models.Translations;
using System.Collections.Generic;

namespace FitnessAPI.Models
{
    public class Workout
    {
        public int ID { get; set; }

        public string Code { get; set; }

        public string ImagePath { get; set; }

        public DayOfTheWeekType DayOfTheWeek { get; set; }

        public double? Rating { get; set; }  //1-5

        public int PlanId { get; set; }
        public virtual Plan Plan { get; set; }

        public BodyAreaType? MainBodyAreaId { get; set; }
        public virtual BodyArea MainBodyArea { get; set; }

        public BodyAreaType? SecBodyAreaId { get; set; }
        public virtual BodyArea SecBodyArea { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }

        public virtual ICollection<Training> TrainingTypes { get; set; }

        public virtual ICollection<WorkoutTranslation> Translations { get; set; }

    }
}