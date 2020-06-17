using FitnessAPI.Models.Setup;

namespace FitnessAPI.Models.Translations
{
    public class MuscleTranslation
    {
        public int ID { get; set; }

        public LanguageType LanguageType { get; set; }

        public string Name { get; set; }

        public int MuscleId { get; set; }

        public virtual Muscle Muscle { get; set; }
    }
}