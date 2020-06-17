using FitnessAPI.Models.Setup;

namespace FitnessAPI.Models.Translations
{
    public class SingleWorkoutTranslation
    {
        public int ID { get; set; }

        public LanguageType LanguageType { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int SingleWorkoutId { get; set; }

        public virtual SingleWorkout SingleWorkout { get; set; }
    }
}