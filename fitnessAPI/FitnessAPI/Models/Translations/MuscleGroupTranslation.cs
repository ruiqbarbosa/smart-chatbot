using FitnessAPI.Models.Setup;

namespace FitnessAPI.Models.Translations
{
    public class MuscleGroupTranslation
    {
        public int ID { get; set; }

        public LanguageType LanguageType { get; set; }

        public string Name { get; set; }

        public int MuscleGroupId { get; set; }

        public virtual MuscleGroup MuscleGroup { get; set; }
    }
}