using FitnessAPI.Models.Setup;

namespace FitnessAPI.Models.Translations
{
    public class ProgramTranslation
    {
        public int ID { get; set; }

        public LanguageType LanguageType { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int ProgramId { get; set; }

        public virtual Program Program { get; set; }
    }
}