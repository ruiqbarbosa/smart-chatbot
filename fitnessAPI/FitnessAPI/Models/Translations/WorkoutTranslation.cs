using FitnessAPI.Models.Setup;

namespace FitnessAPI.Models.Translations
{
    public class WorkoutTranslation
    {
        public int ID { get; set; }

        public LanguageType LanguageType { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int WorkoutId { get; set; }

        public virtual Workout Workout { get; set; }
    }
}